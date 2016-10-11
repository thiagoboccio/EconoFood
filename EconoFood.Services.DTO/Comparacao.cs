using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class Comparacao
    {
        public List<Produto> Produtos { get; set; }
        public int ProdutosDisponiveis
        {
            get { return Produtos.FindAll(o => o.Detalhe.ValorVenda != null).Count; }
        }
        public decimal PrecoTotal
        {
            get
            {
                decimal total = 0;
                foreach (var produto in Produtos)
                    if (produto.Detalhe.ValorVenda != null)
                        total += (decimal)produto.Detalhe.ValorVenda;

                return total;
            }
        }
        public double Score { get; set; }
        public short Partner { get; set; }
    }
}
