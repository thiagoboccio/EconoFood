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

        public int Inserir()
        {
            throw new NotImplementedException();
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

            var resultado   = conector.Select(parametros);
            var retorno     = new List<Produto>();

            foreach (DataRow linha in resultado.Rows)
            {
                var produto = new Produto();
                produto.IdProduto   = Convert.ToInt32(linha["IdProduto"].ToString());
                produto.Nome        = linha["Nome"].ToString();
                produto.Status      = int.Parse(linha["Status"].ToString());
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
