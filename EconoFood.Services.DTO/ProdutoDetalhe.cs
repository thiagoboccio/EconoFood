using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class ProdutoDetalhe
    {
        public int IdProdutoDetalhe { get; set; }
        public int IdProduto { get; set; }
        public string Dimensao { get; set; }
        public string Peso { get; set; }
        public string Descricao { get; set; }
    }
}
