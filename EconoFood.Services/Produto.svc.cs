using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EconoFood.Services.Business;
using EconoFood.Services.DTO;

namespace EconoFood.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Produto : IProduto
    {
        public List<DTO.Produto> Listar()
        {
            var bll = new Business.ProdutoBLL();
            return bll.ListarTodos();             
        }

        public List<DTO.Produto> PesquisarPorNome(string nomeProduto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Pesquisar(nomeProduto);
        }

        public List<DTO.Produto> PesquisarPorID(int idProduto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Pesquisar(idProduto);
        }
    }
}
