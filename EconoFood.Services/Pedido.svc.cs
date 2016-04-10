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
    public class Pedido : IPedido
    {
        public int Gravar(DTO.Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public IList<DTO.Pedido> Listar()
        {
            var BLL = new PedidoBLL();
            return BLL.Listar();
        }

        public IList<DTO.Pedido> Pesquisar(DTO.Pedido pedido, DateTime? inicio, DateTime? fim)
        {
            var BLL = new PedidoBLL();
            return BLL.Pesquisar(pedido, inicio, fim);
        }
    }
}
