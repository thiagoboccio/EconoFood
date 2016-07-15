using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Framework;
using EconoFood.Services.DTO;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace EconoFood.Services.DataAccess
{
    public class ProdutoDAL : IBase<Produto>
    {
        public bool Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Excluir(DTO.Produto produto)
        {
            throw new NotImplementedException();
        }

        public int Inserir(DTO.Produto produto)
        {
            TransactionOptions options = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TimeSpan.FromSeconds(60)
            };

            using (TransactionScope transacao = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    Conector conector;
                    List<SqlParameter> parametros = new List<SqlParameter>();

                    if (produto.IdProduto > 0)
                    {
                        conector = new Conector(Procedures.Produto_UPDATE);
                        parametros.Add(new SqlParameter { ParameterName = "@IdProduto", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = produto.IdProduto });
                    }
                    else
                    {
                        conector = new Conector(Procedures.Produto_INSERT);
                        parametros.Add(new SqlParameter { ParameterName = "@IdProduto", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                    }

                    parametros.Add(new SqlParameter { ParameterName = "@Status", SqlDbType = SqlDbType.SmallInt, Value = produto.Status });
                    parametros.Add(new SqlParameter { ParameterName = "@Nome", SqlDbType = SqlDbType.VarChar, Value = produto.Nome });
                    parametros.Add(new SqlParameter { ParameterName = "@TipoProduto", SqlDbType = SqlDbType.Int, Value = produto.TipoProduto });

                    conector.ExecuteNonQuery(parametros);

                    var IdProduto = parametros.Find(o => o.ParameterName == "@IdProduto");

                    if (IdProduto.Value != null && int.Parse(IdProduto.Value.ToString()) > 0)
                    {
                        //Detalhes
                        parametros = new List<SqlParameter>();
                        if (produto.Detalhe.IdProdutoDetalhe > 0)
                        { 
                            conector = new Conector(Procedures.ProdutoDetalhe_UPDATE);
                            parametros.Add(new SqlParameter { ParameterName = "@IdProdutoDetalhe", Value = produto.Detalhe.IdProdutoDetalhe, SqlDbType = SqlDbType.Int });
                        }
                        else
                            conector = new Conector(Procedures.ProdutoDetalhe_INSERT);
                        
                        
                        parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = IdProduto.Value, SqlDbType = SqlDbType.Int });
                        parametros.Add(new SqlParameter { ParameterName = "@Dimensao", Value = produto.Detalhe.Dimensao, SqlDbType = SqlDbType.VarChar });
                        parametros.Add(new SqlParameter { ParameterName = "@Peso", Value = produto.Detalhe.Peso, SqlDbType = SqlDbType.VarChar });
                        parametros.Add(new SqlParameter { ParameterName = "@Descricao", Value = produto.Detalhe.Descricao, SqlDbType = SqlDbType.VarChar });

                        conector.ExecuteNonQuery(parametros);

                        //Imagens - Apaga as imagens da base para gravar as novas
                        parametros = new List<SqlParameter>();
                        conector = new Conector(Procedures.ProdutoImagem_DELETE);
                        parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = IdProduto.Value, SqlDbType = SqlDbType.Int });
                        conector.ExecuteNonQuery(parametros);
                        parametros = new List<SqlParameter>();

                        foreach (var imagem in produto.Imagens)
                        {
                            if (imagem.IdImagem > 0)
                            { 
                                conector = new Conector(Procedures.ProdutoImagem_UPDATE);
                                parametros.Add(new SqlParameter { ParameterName = "@IdImagem", Value = imagem.IdImagem, SqlDbType = SqlDbType.Int });
                            }
                            else
                                conector = new Conector(Procedures.ProdutoImagem_INSERT);

                            parametros = new List<SqlParameter>();
                            parametros.Add(new SqlParameter { ParameterName = "@Imagem", Value = imagem.Imagem, SqlDbType = SqlDbType.Image });
                            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = IdProduto.Value, SqlDbType = SqlDbType.Int });

                            conector.ExecuteNonQuery(parametros);
                        }

                        transacao.Complete();
                        transacao.Dispose();
                        return int.Parse(IdProduto.Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Transaction.Current.Rollback();
                    throw ex;
                }
            }
            return 0;
        }

        public List<Produto> Listar()
        {
            Conector conector = new Conector(Procedures.Produto_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Produto>();
            while (resultado.Read())
            {
                var produto = new Produto();
                produto.Imagens = new List<ProdutoImagem>();
                produto.Imagens.Add(new ProdutoImagem { Imagem = (byte[])resultado["Imagem"] });
                produto.Detalhe = new ProdutoDetalhe();
                produto.IdProduto = Convert.ToInt32(resultado["IdProduto"].ToString());
                produto.Nome = resultado["Nome"].ToString();
                produto.Status = int.Parse(resultado["Status"].ToString());
                produto.TipoProduto = int.Parse(resultado["TipoProduto"].ToString());
                produto.Detalhe.Descricao = resultado["Descricao"].ToString();
                produto.Detalhe.Dimensao = resultado["Dimensao"].ToString();
                produto.Detalhe.IdProduto = Convert.ToInt32(resultado["IdProduto"]);
                produto.Detalhe.IdProdutoDetalhe = Convert.ToInt32(resultado["IdProdutoDetalhe"]);
                produto.Detalhe.Peso = resultado["Peso"].ToString();
                produto.Detalhe.ValorVenda = Convert.ToDecimal(resultado["ValorVenda"]);
                retorno.Add(produto);
            }

            return retorno;
        }

        public List<Produto> Listar(int TipoProduto)
        {
            Conector conector = new Conector(Procedures.Produto_SELECT_POR_CATEGORIA);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@TipoProduto", Value = TipoProduto });
            
            var resultado = conector.Select(parametros);
            var retorno = new List<Produto>();

            foreach (DataRow linha in resultado.Rows)
            {
                var produto = new Produto();
                produto.Imagens = new List<ProdutoImagem>();
                produto.Imagens.Add(new ProdutoImagem { Imagem = (byte[])linha["Imagem"] });
                produto.Detalhe = new ProdutoDetalhe();
                produto.IdProduto = Convert.ToInt32(linha["IdProduto"].ToString());
                produto.Nome = linha["Nome"].ToString();
                produto.Status = int.Parse(linha["Status"].ToString());
                produto.TipoProduto = int.Parse(linha["TipoProduto"].ToString());
                produto.Detalhe.Descricao = linha["Descricao"].ToString();
                produto.Detalhe.Dimensao = linha["Dimensao"].ToString();
                produto.Detalhe.IdProduto = Convert.ToInt32(linha["IdProduto"]);
                produto.Detalhe.IdProdutoDetalhe = Convert.ToInt32(linha["IdProdutoDetalhe"]);
                produto.Detalhe.Peso = linha["Peso"].ToString();
                produto.Detalhe.ValorVenda = Convert.ToDecimal(linha["ValorVenda"]);
                retorno.Add(produto);
            }

            return retorno;
        }

        public List<Produto> Pesquisar(string nomeProduto, int? idProduto)
        {
            Conector conector = new Conector(Procedures.Produto_SELECT);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@Nome", Value = nomeProduto });
            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = idProduto });

            var resultado = conector.Select(parametros);
            var retorno = new List<Produto>();

            foreach (DataRow linha in resultado.Rows)
            {
                var produto = new Produto();
                produto.Imagens = new List<ProdutoImagem>();
                produto.Imagens.Add(new ProdutoImagem { Imagem = (byte[])linha["Imagem"] });
                produto.Detalhe = new ProdutoDetalhe();
                produto.IdProduto = Convert.ToInt32(linha["IdProduto"].ToString());
                produto.Nome = linha["Nome"].ToString();
                produto.Status = int.Parse(linha["Status"].ToString());
                produto.TipoProduto = int.Parse(linha["TipoProduto"].ToString());
                produto.Detalhe.Descricao = linha["Descricao"].ToString();
                produto.Detalhe.Dimensao = linha["Dimensao"].ToString();
                produto.Detalhe.IdProduto = Convert.ToInt32(linha["IdProduto"]);
                produto.Detalhe.IdProdutoDetalhe = Convert.ToInt32(linha["IdProdutoDetalhe"]);
                produto.Detalhe.Peso = linha["Peso"].ToString();
                retorno.Add(produto);
            }

            return retorno;
        }

        public List<Comparacao> CompararPreco(List<Produto> produtos)
        {
            List<Comparacao> retorno = new List<Comparacao>();           
                        
            //CRIAR THREAD
            ExtraService.ServiceExtraClient extraClient = new ExtraService.ServiceExtraClient();
            Comparacao comparacaoExtra = new Comparacao();
            List<Produto> produtosExtra = produtos;
            foreach (var produto in produtosExtra)
                produto.Detalhe.ValorVenda = extraClient.ObterPrecoProdutoExtra(new ExtraService.ObterPrecoProdutoExtraRequest { idProduto = produto.IdProduto }).ObterPrecoProdutoExtraResult;
            comparacaoExtra.Partner = 1;
            comparacaoExtra.Produtos = produtosExtra;
            retorno.Add(comparacaoExtra);

            SondaService.ServiceSondaClient sondaClient = new SondaService.ServiceSondaClient();
            Comparacao comparacaoSonda = new Comparacao();
            List<Produto> produtosSonda = produtos;
            foreach (var produto in produtosSonda)
                produto.Detalhe.ValorVenda = sondaClient.ObterPrecoProdutoSonda(new SondaService.ObterPrecoProdutoSondaRequest { idProduto = produto.IdProduto }).ObterPrecoProdutoSondaResult;
            comparacaoSonda.Partner = 2;
            comparacaoSonda.Produtos = produtosSonda;
            retorno.Add(comparacaoSonda);

            PaoDeAcucarService.ServicePaoDeAcucarClient paoDeAcucarClient = new PaoDeAcucarService.ServicePaoDeAcucarClient();
            Comparacao comparacaoPaoDeAcucar = new Comparacao();
            List<Produto> produtosPaoDeAcucar = produtos;
            foreach (var produto in produtosPaoDeAcucar)
                produto.Detalhe.ValorVenda = paoDeAcucarClient.ObterPrecoProdutoPaoDeAcucar(new PaoDeAcucarService.ObterPrecoProdutoPaoDeAcucarRequest { idProduto = produto.IdProduto }).ObterPrecoProdutoPaoDeAcucarResult;
            comparacaoPaoDeAcucar.Partner = 3;
            comparacaoPaoDeAcucar.Produtos = produtosPaoDeAcucar;
            retorno.Add(comparacaoPaoDeAcucar);
            
            return retorno;
        }
    }
}
