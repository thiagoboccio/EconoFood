using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EconoFood.ProdutoService;

namespace EconoFood.Showroom
{
    public partial class Comparison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DefinirMelhorCompra();
            }            
        }

        private void DefinirMelhorCompra()
        {
            var client = new ProdutoService.ProdutoClient();
            var comparacao = client.Comparar(new CompararRequest { produtos = Master.Carrinho });
            var primeiroColocado = new List<Comparacao>();
            var segundoColocado = new List<Comparacao>();
            var terceiroColocado = new List<Comparacao>();
            primeiroColocado.Add(comparacao.CompararResult[0]);
            segundoColocado.Add(comparacao.CompararResult[1]);
            terceiroColocado.Add(comparacao.CompararResult[2]);

            lblFrete1.Text = "Não informado";
            lblTotal1.Text = primeiroColocado[0].Produtos.Sum(o => o.Detalhe.ValorVenda).ToString();
            gv1.DataSource = primeiroColocado[0].Produtos;
            gv1.DataBind();

            lblFrete2.Text = "Não informado";
            lblTotal2.Text = segundoColocado[0].Produtos.Sum(o => o.Detalhe.ValorVenda).ToString();
            gv2.DataSource = segundoColocado[0].Produtos;
            gv2.DataBind();

            lblFrete3.Text = "Não informado";
            lblTotal3.Text = terceiroColocado[0].Produtos.Sum(o => o.Detalhe.ValorVenda).ToString();
            gv3.DataSource = terceiroColocado[0].Produtos;
            gv3.DataBind();
        }
    }
}