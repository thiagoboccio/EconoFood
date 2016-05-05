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
                        conector = new Conector(Procedures.ProdutoImagem_INSERT);
                        foreach (var imagem in produto.Imagens)
                        {
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
                    throw;
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
                produto.Detalhe = new ProdutoDetalhe();
                produto.IdProduto = Convert.ToInt32(resultado["IdProduto"].ToString());
                produto.Nome = resultado["Nome"].ToString();
                produto.Status = int.Parse(resultado["Status"].ToString());
                produto.Detalhe.Descricao = resultado["Descricao"].ToString();
                produto.Detalhe.Dimensao = resultado["Dimensao"].ToString();
                produto.Detalhe.IdProduto = Convert.ToInt32(resultado["IdProduto"]);
                produto.Detalhe.IdProdutoDetalhe = Convert.ToInt32(resultado["IdProdutoDetalhe"]);
                produto.Detalhe.Peso = resultado["Peso"].ToString();
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
                produto.IdProduto = Convert.ToInt32(linha["IdProduto"].ToString());
                produto.Nome = linha["Nome"].ToString();
                produto.Status = int.Parse(linha["Status"].ToString());
                produto.TipoProduto = int.Parse(linha["TipoProduto"].ToString());
                retorno.Add(produto);
            }

            return retorno;
        }

        public List<Produto> CompararPreco(string produto)
        {
            //CRIAR THREAD
            ExtraService.ServiceExtraClient extraClient = new ExtraService.ServiceExtraClient();
            var resultadoExtra = extraClient.ObterPrecoProdutoExtra(new ExtraService.ObterPrecoProdutoExtraRequest { nomeProduto = produto });

            SondaService.ServiceSondaClient sondaClient = new SondaService.ServiceSondaClient();
            var resultadoSonda = sondaClient.ObterPrecoProdutoSonda(new SondaService.ObterPrecoProdutoSondaRequest { nomeProduto = produto });

            var retorno = new List<Produto>();
            //retorno.Add(resultadoExtra.)


            return retorno;
        }
    }
}
