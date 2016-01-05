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

        public void Excluir()
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
                    Conector conector = new Conector(Procedures.Produto_INSERT);
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    parametros.Add(new SqlParameter { ParameterName = "@Status", Value = produto.Status });
                    parametros.Add(new SqlParameter { ParameterName = "@Nome", Value = produto.Nome });
                    parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Direction = ParameterDirection.Output });

                    conector.ExecuteNonQuery();

                    var IdProduto = parametros.Find(o => o.ParameterName == "@IdProduto");

                    if (IdProduto.Value != null && int.Parse(IdProduto.Value.ToString()) > 0)
                    {
                        conector = new Conector(Procedures.ProdutoImagem_INSERT);
                        foreach (var imagem in produto.Imagens)
                        {
                            parametros = new List<SqlParameter>();
                            parametros.Add(new SqlParameter { ParameterName = "@Imagem", Value = imagem.Imagem, SqlDbType = SqlDbType.Image });
                            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = IdProduto });

                            conector.ExecuteNonQuery();
                        }

                        transacao.Complete();
                        transacao.Dispose();
                        return int.Parse(IdProduto.Value.ToString());
                    }
                }
                catch (Exception)
                {
                    Transaction.Current.Rollback();
                    throw;
                }
            }
            return 0;
        }

        public List<Produto> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            Conector conector = new Conector(Procedures.Produto_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Produto>();
            while (resultado.Read())
            {
                var produto = new Produto();
                produto.IdProduto = Convert.ToInt32(resultado["IdProduto"].ToString());
                produto.Nome = resultado["Nome"].ToString();
                produto.Status = int.Parse(resultado["Status"].ToString());
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
