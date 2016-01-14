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
        public List<Produto> Listar()
        {
            var DAL = new ProdutoDAL();
            return DAL.Listar();
        }

        public List<Produto> Pesquisar(string nomeProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(nomeProduto, null);
        }

        public Produto Pesquisar(int idProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(string.Empty, idProduto).FirstOrDefault();
        }

        public int Gravar(Produto produto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Inserir(produto);
        }        
    }
}
