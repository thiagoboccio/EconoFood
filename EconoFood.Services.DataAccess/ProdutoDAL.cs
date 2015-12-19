using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Framework;
using EconoFood.Services.DTO;

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
                //produto.IdFonte = (int)resultado[0];
                produto.IdProduto = Convert.ToInt32(resultado["IdProduto"].ToString());
                produto.Nome = resultado["Nome"].ToString();
                produto.Status = Convert.ToInt32(resultado["Status"].ToString());
                retorno.Add(produto);
            }

            return retorno;
        }

        public List<Produto> CompararPreco(int idProduto)
        {
            return null;
        }
    }
}
