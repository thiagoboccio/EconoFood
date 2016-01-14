using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;
using EconoFood.Services.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.Business
{
    public class PedidoBLL
    {
        public List<Pedido> Pesquisar(Pedido pedido)
        {
            var DAL = new PedidoDAL();

            int? idPedido = null;
            DateTime? dataInicio;
            DateTime? dataFim;
            ePedido.StatusPedido? statusPedido;
            ePedido.StatusPagamento? statusPagamento;
            int? IdEntregador;

            if (pedido.IdPedido > 0)
                idPedido = pedido.IdPedido;

            //return DAL.Pesquisar();
            return null;
        }
    }
}
