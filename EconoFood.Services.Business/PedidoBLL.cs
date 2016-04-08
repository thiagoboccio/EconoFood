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
        public List<Pedido> Pesquisar(Pedido pedido, DateTime? inicio, DateTime? fim)
        {
            var DAL = new PedidoDAL();
            int? IdPedido = null;
            int? IdEntregador = null;
            ePedido.StatusPedido? statusPedido = null;
            ePedido.StatusPagamento? statusPagamento = null;

            if (pedido.IdPedido > 0)
                IdPedido = pedido.IdPedido;
            if (pedido.IdEntregador > 0)
                IdEntregador = pedido.IdEntregador;
            if (pedido.StatusPedido != null)
                statusPedido = pedido.StatusPedido;
            if (pedido.StatusPagamento != null)
                statusPagamento = pedido.StatusPagamento;

            return DAL.Pesquisar(IdPedido, inicio, fim, pedido.StatusPedido, pedido.StatusPagamento, IdEntregador);            
        }

        public List<Pedido> Listar()
        {
            var DAL = new PedidoDAL();

            return DAL.Listar();
        }
    }
}
