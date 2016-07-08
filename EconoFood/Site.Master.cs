using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood
{
    public partial class SiteMaster : MasterPage
    {
        public List<ProdutoService.Produto> Carrinho
        {
            get
            {
                if (Session["Carrinho"] != null)
                    return (List<ProdutoService.Produto>)Session["Carrinho"];

                return new List<ProdutoService.Produto>();
            }
            set
            {
                Session["Carrinho"] = value;
                lstCarrinho.DataSource = Carrinho;
                lstCarrinho.DataBind();
                upCarrinho.Update();

                btnComparar.Visible = Carrinho.Count > 0;
            }
        }

        public String Pesquisa
        {
            get
            {
                if (Session["Pesquisa"] != null)
                    return Session["Pesquisa"].ToString();

                return string.Empty;
            }
            set { Session["Pesquisa"] = value; }
        }

        public int Categoria
        {
            get
            {
                if (ViewState["Categoria"] != null)
                    return (int)ViewState["Categoria"];

                return 0;
            }
            set
            {
                ViewState["Categoria"] = value;
            }
        }

        public List<ProdutoService.Produto> ProdutosListados
        {
            get
            {
                if (ViewState["produtosListados"] != null)
                    return (List<ProdutoService.Produto>)ViewState["produtosListados"];

                return new List<ProdutoService.Produto>();
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
                CarregarCategorias();
                btnComparar.Visible = false;
            }
        }

        private void CarregarCategorias()
        {
            DominioService.DominioClient client = new DominioService.DominioClient();
            lvCategorias.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.TipoProduto);
            lvCategorias.DataBind();
        }

        protected void lstCarrinho_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    var produto = (ProdutoService.Produto)e.Item.DataItem;
                    var img = (ImageButton)e.Item.FindControl("imgProduto");
                    var lblNome = (Label)e.Item.FindControl("lblNome");

                    if (img != null)
                    {
                        if (produto.Imagens.First() != null)
                        {
                            string base64String = Convert.ToBase64String(produto.Imagens.First().Imagem, 0, produto.Imagens.First().Imagem.Length);
                            img.ImageUrl = "data:image/jpeg;base64," + base64String;
                            img.PostBackUrl = String.Format("Product/Detail.aspx?id={0}", produto.IdProduto);
                        }
                    }

                    if (produto.Nome.Length > 20)
                        lblNome.Text = produto.Nome.Substring(0, 20) + "...";
                    else
                        lblNome.Text = produto.Nome;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lstCarrinho_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Remove")
            {
                var carrinhoLocal = new List<ProdutoService.Produto>();
                carrinhoLocal = Carrinho;
                carrinhoLocal.RemoveAll(o => o.IdProduto == int.Parse(e.CommandArgument.ToString()));
                Carrinho = carrinhoLocal;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Pesquisa = txtPesquisa.Text.Trim();
        }

        protected void lvCategorias_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName=="Categoria")
            {
                Categoria = int.Parse(e.CommandArgument.ToString());
                ListView lstViewProduto = (ListView)MainContent.FindControl("lstViewProduto");
                var client = new ProdutoService.ProdutoClient();
                ProdutosListados = client.ListarPorCategoria(new ProdutoService.ListarPorCategoriaRequest { TipoProduto = Categoria }).ListarPorCategoriaResult;
                lstViewProduto.DataSource = ProdutosListados;
                lstViewProduto.DataBind();
            }
        }        
    }
}