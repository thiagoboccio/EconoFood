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
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public ePedido.StatusPagamento StatusPagamento { get; set; }        
        public ePedido.StatusPedido StatusPedido { get; set; }
        public short IdEntregador { get; set; }
        public string NomeEntregador { get; set; }
        public string Receptor { get; set; }
        public string DocumentoReceptor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
