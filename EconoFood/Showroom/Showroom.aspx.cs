using EconoFood.ProdutoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EconoFood.Showroom
{
    public partial class Showroom : PageHandler
    {
        private List<Produto> carrinhoLocal;
        private List<Produto> produtosListados
        {
            get
            {
                if (ViewState["produtosListados"] != null)
                    return (List<Produto>)ViewState["produtosListados"];

                return new List<Produto>();
            }
            set
            {
                ViewState["produtosListados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
            }
            else
            {
                if (!string.IsNullOrEmpty(Master.Pesquisa))
                    CarregarProdutosPorTipo();
            }
        }

        private void CarregarProdutos()
        {
            var client = new ProdutoService.ProdutoClient();
            produtosListados = client.Listar(new ProdutoService.ListarRequest()).ListarResult;
            lstViewProduto.DataSource = produtosListados;
            lstViewProduto.DataBind();
        }

        private void CarregarProdutosPorTipo()
        {
            var client = new ProdutoService.ProdutoClient();
            //produtosListados = client.p
            lstViewProduto.DataSource = produtosListados;
            lstViewProduto.DataBind();
        }

        protected void lstViewProduto_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var produto = (Produto)e.Item.DataItem;
                var img = (ImageButton)e.Item.FindControl("imgProduto");

                if (img != null)
                {
                    if (produto.Imagens.First() != null)
                    {
                        string base64String = Convert.ToBase64String(produto.Imagens.First().Imagem, 0, produto.Imagens.First().Imagem.Length);
                        img.ImageUrl = "data:image/jpeg;base64," + base64String;
                        img.PostBackUrl = String.Format("../Product/Detail.aspx?id={0}", produto.IdProduto);
                    }
                }
            }
        }

        protected void lstViewProduto_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                carrinhoLocal = Master.Carrinho;
                carrinhoLocal.Add(produtosListados.Find(o => o.IdProduto == Convert.ToInt32(e.CommandArgument.ToString())));
                Master.Carrinho = carrinhoLocal;
            }
        }
    }
}