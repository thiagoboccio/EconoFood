using EconoFood.Services.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public ePedido.StatusPagamento StatusPagamento { get; set; }        
        public ePedido.StatusPedido StatusPedido { get; set; }
        public short IdEntregador { get; set; }
        public string Recebimento { get; set; }
        public string DocumentoRecebimento { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
