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
            Pendente = 1,
            Pago = 2,
            Estornado = 3
        }
    }
}
