using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;

namespace EconoFood.Services.Business
{
    public class ProdutoBLL
    {
        public List<Produto> ListarTodos()
        {
            var DAL = new ProdutoDAL();
            return DAL.ListarTodos();
        }

        public List<Produto> Pesquisar(string nomeProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(nomeProduto, null);
        }

        public List<Produto> Pesquisar(int idProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(string.Empty, idProduto);
        }
    }
}
