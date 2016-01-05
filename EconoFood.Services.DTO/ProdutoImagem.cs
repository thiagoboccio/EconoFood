using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class ProdutoImagem
    {
        public short IdImagem { get; set; }
        public int IdProduto { get; set; }
        public byte[] Imagem { get; set; }
    }
}
