using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    [Serializable]
    public class ProdutoOrigem
    {
        public int IdProdutoOrigem { get; set; }
        public String NomeOrigem { get; set; }
    }
}
