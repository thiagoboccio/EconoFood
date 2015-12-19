using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    [Serializable]
    public class Produto
    {
        public int IdProduto { get; set; }
        public String Nome { get; set; }
        public int Status { get; set; }
    }
}
