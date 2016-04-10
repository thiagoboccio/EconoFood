using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO.Enum
{ 
    public class ePedido
    {
        public enum StatusPedido
        {
            PedidoRealizado = 1,
            AguardandoPagamento = 2,
            EmissaoNotaFiscal = 3,
            ProdutoEmTransporte = 4,
            ProdutoEntregue = 5,
            Cancelado = 6
        }

        public enum StatusPagamento
        {
            Pendente = 1002,
            Pago = 1003,
            Estornado = 1004
        }
    }
}
