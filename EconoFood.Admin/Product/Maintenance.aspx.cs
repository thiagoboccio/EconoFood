using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EconoFood.Admin.ProdutoService;

namespace EconoFood.Admin.Product
{
    public partial class Maintenance : PageHandler
    {
        #region [ Propriedades ]        
        public int idProduto
        {
            get
            {
                if (IsNumeric(Session["idProduto"].ToString()))
                    return int.Parse(Session["idProduto"].ToString());
                else
                    return 0;
            }
            set
            {
                Session["idProduto"] = value;
            }
        }

        public ProdutoService.ProdutoImagem Imagem1
        {
            get
            {
                if (Session["Imagem1"] != null)
                    return (ProdutoService.ProdutoImagem)Session["Imagem1"];

                return new ProdutoService.ProdutoImagem();
            }
            set { Session["Imagem1"] = value; }
        }

        public ProdutoService.ProdutoImagem Imagem2
        {
            get
            {
                if (Session["Imagem2"] != null)
                    return (ProdutoService.ProdutoImagem)Session["Imagem2"];

                return new ProdutoService.ProdutoImagem();
            }
            set { Session["Imagem2"] = value; }
        }

        public ProdutoService.ProdutoImagem Imagem3
        {
            get
            {
                if (Session["Imagem3"] != null)
                    return (ProdutoService.ProdutoImagem)Session["Imagem3"];

                return new ProdutoService.ProdutoImagem();
            }
            set { Session["Imagem3"] = value; }
        }
        #endregion

        #region [ Eventos ]
        protected void Page_Load(object sender, EventArgs e)
        {
            fuImagens.Attributes["onchange"] = "UploadFile(this)";

            if (!IsPostBack)
                Inicializar();            
        }

        private void Inicializar()
        {
            var client = new DominioService.DominioClient();
            ddlTipoProduto.Items.Add(new ListItem { Selected = true, Text = "SELECIONE", Value = "-1" });
            ddlTipoProduto.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.TipoProduto);
            ddlTipoProduto.DataBind();
        }

        protected void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            var client = new Admin.ProdutoService.ProdutoClient();
            var resultadoPesquisa = client.PesquisarPorNome(new ProdutoService.PesquisarPorNomeRequest { nomeProduto = txtPesquisaProduto.Text.Trim() });

            gvPesquisaProdutos.DataSource = resultadoPesquisa.PesquisarPorNomeResult;
            gvPesquisaProdutos.DataBind();
        }

        protected void gvPesquisaProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Manutencao"))
            {
                LimparSessao();
                idProduto = int.Parse(e.CommandArgument.ToString());
                divManutencao.Visible = true;

                PreencherCamposManutencao(idProduto);
            }
        }

        protected void gvPesquisaProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                lblStatus.Text = ((ProdutoService.Produto)e.Row.DataItem).Status == 1 ? "Ativo" : "Inativo";
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarCadastroProduto())
            {
                var client = new ProdutoService.ProdutoClient();
                client.Gravar(new ProdutoService.GravarRequest
                {
                    produto = new ProdutoService.Produto
                    {
                        IdProduto = idProduto > 0 ? idProduto : 0,
                        Nome = txtProduto.Text.Trim(),
                        Status = int.Parse(ddlStatus.SelectedValue),
                        Imagens = CarregarListaImagens(),
                        TipoProduto=ToInt32(ddlTipoProduto.SelectedValue)
                    }
                });
                LimparSessao();
                Alert("Produto cadastrado com sucesso.");
                divManutencao.Visible = false;
            }
        }

        protected void btnAdicionarImagem_Click(object sender, EventArgs e)
        {
            if (fuImagens.HasFile)
            {
                if (fuImagens.FileName.Contains(".png") || fuImagens.FileName.Contains(".jpg"))
                {
                    byte[] imageSize = new byte[fuImagens.PostedFile.ContentLength];
                    HttpPostedFile uploadedImage = fuImagens.PostedFile;
                    uploadedImage.InputStream.Read(imageSize, 0, (int)fuImagens.PostedFile.ContentLength);

                    if (Imagem1.Imagem == null)
                    {
                        var imagem = new ProdutoService.ProdutoImagem() { Imagem = imageSize };
                        Imagem1 = imagem;
                        ExecutarHandler(1);                        
                    }
                    else if (Imagem2.Imagem == null)
                    {
                        var imagem = new ProdutoService.ProdutoImagem() { Imagem = imageSize };
                        Imagem2 = imagem;
                        ExecutarHandler(2);
                    }
                    else if (Imagem3.Imagem == null)
                    {
                        var imagem = new ProdutoService.ProdutoImagem() { Imagem = imageSize };
                        Imagem3 = imagem;
                        ExecutarHandler(3);
                    }
                }
                else
                    Alert("Formato do arquivo inválido.");                
            }
            else
                Alert("Nenhuma imagem selecionada."); ;            
        }

        protected void btnNovoProduto_Click(object sender, EventArgs e)
        {
            LimparSessao();
            LimparCadastro();
            divManutencao.Visible = true;
        }
        
        protected void imgRemoveImagem1_Click(object sender, ImageClickEventArgs e)
        {
            Imagem1 = null;
            ExecutarHandler(1);
        }

        protected void imgRemoveImagem2_Click(object sender, ImageClickEventArgs e)
        {
            Imagem2 = null;
            ExecutarHandler(2);
        }

        protected void imgRemoveImagem3_Click(object sender, ImageClickEventArgs e)
        {
            Imagem3 = null;
            ExecutarHandler(3);
        }
        #endregion

        #region [ Métodos ]
        private void LimparCadastro()
        {
            txtProduto.Text = string.Empty;
            ddlStatus.SelectedValue = "-1";
            imgProduto1.Visible = imgProduto2.Visible = imgProduto3.Visible = true;
        }

        private void LimparSessao()
        {
            idProduto = 0;
            Imagem1 = Imagem2 = Imagem3 = null;
        }

        private List<ProdutoImagem> CarregarListaImagens()
        {
            List<ProdutoImagem> retorno = new List<ProdutoImagem>();

            if (Imagem1.Imagem != null)
                retorno.Add(new ProdutoImagem { Imagem = Imagem1.Imagem });
            if (Imagem2.Imagem != null)
                retorno.Add(new ProdutoImagem { Imagem = Imagem2.Imagem });
            if (Imagem3.Imagem != null)
                retorno.Add(new ProdutoImagem { Imagem = Imagem3.Imagem });

            return retorno;
        }

        private bool ValidarCadastroProduto()
        {
            if (string.IsNullOrEmpty(txtProduto.Text.Trim()))
                NotificarCampo(txtProduto);
            else
                RemoverNotificacaoCampo(txtProduto);

            if (int.Parse(ddlStatus.SelectedValue) == -1)
                NotificarCampo(ddlStatus);
            else
                RemoverNotificacaoCampo(ddlStatus);

            if (int.Parse(ddlTipoProduto.SelectedValue) == -1)
                NotificarCampo(ddlTipoProduto);
            else
                RemoverNotificacaoCampo(ddlTipoProduto);

            if ((Imagem1 == null || Imagem1.Imagem == null || Imagem1.Imagem.Length == 0) &&
                (Imagem2 == null || Imagem2.Imagem == null || Imagem2.Imagem.Length == 0) &&
                (Imagem3 == null || Imagem3.Imagem == null || Imagem3.Imagem.Length == 0))
                NotificarCampo(Imagens);
            else
                RemoverNotificacaoCampo(Imagens);

            return CamposObrigatorios.Count == 0;
        }

        private void PreencherCamposManutencao(int idProduto)
        {
            ProdutoService.ProdutoClient client = new ProdutoService.ProdutoClient();
            var produto = client.PesquisarPorID(new ProdutoService.PesquisarPorIDRequest { idProduto = idProduto });
            txtProduto.Text = produto.PesquisarPorIDResult.Nome;
            ddlStatus.SelectedValue = produto.PesquisarPorIDResult.Status.ToString();

            var imagens = client.ListarImagens(new ListarImagensRequest { idProduto = idProduto });
            if (imagens.ListarImagensResult != null && imagens.ListarImagensResult.Count > 0)
            {
                if (imagens.ListarImagensResult[0] != null)
                {
                    ProdutoImagem img = new ProdutoImagem();
                    img.IdImagem = imagens.ListarImagensResult[0].IdImagem;
                    img.IdProduto = imagens.ListarImagensResult[0].IdProduto;
                    img.Imagem = imagens.ListarImagensResult[0].Imagem;
                    Imagem1 = img;
                    ExecutarHandler(1);

                    img = new ProdutoImagem();
                    img.IdImagem = imagens.ListarImagensResult[1].IdImagem;
                    img.IdProduto = imagens.ListarImagensResult[1].IdProduto;
                    img.Imagem = imagens.ListarImagensResult[1].Imagem;
                    Imagem2 = img;
                    ExecutarHandler(2);

                    img = new ProdutoImagem();
                    img.IdImagem = imagens.ListarImagensResult[2].IdImagem;
                    img.IdProduto = imagens.ListarImagensResult[2].IdProduto;
                    img.Imagem = imagens.ListarImagensResult[2].Imagem;
                    Imagem3 = img;
                    ExecutarHandler(3);
                }
            }
            else
            {
                imgProduto1.ImageUrl = ResolveUrl("~/Content/Img/1450850589_Photographer_2.png");
                imgProduto2.ImageUrl = ResolveUrl("~/Content/Img/1450850589_Photographer_2.png");
                imgProduto3.ImageUrl = ResolveUrl("~/Content/Img/1450850589_Photographer_2.png");
            }
        }

        private void ExecutarHandler(int posicaoImagem)
        {
            switch (posicaoImagem)
            {
                case 1:
                    imgProduto1.ImageUrl = "~/Product/ImageHandler.ashx?img=1";
                    imgProduto1.Visible =
                    imgRemoveImagem1.Visible = true;
                    break;
                case 2:
                    imgProduto2.ImageUrl = "~/Product/ImageHandler.ashx?img=2";
                    imgProduto2.Visible =
                    imgRemoveImagem2.Visible = true;
                    break;
                case 3:
                    imgProduto3.ImageUrl = "~/Product/ImageHandler.ashx?img=3";
                    imgProduto3.Visible =
                    imgRemoveImagem3.Visible = true;
                    break;
            }
        }
        #endregion        
    }
}