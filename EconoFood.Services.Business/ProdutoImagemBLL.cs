using EconoFood.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DataAccess;

namespace EconoFood.Services.Business
{
    public class ProdutoImagemBLL
    {
        public List<ProdutoImagem> ListarImagens(int idProduto)
        {
            var DAL = new ProdutoImagemDAL();
            return DAL.Listar(idProduto);
        }
    }
}
