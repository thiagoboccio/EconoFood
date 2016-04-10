using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.Order
{
    public partial class Maintenance : PageHandler
    {
        #region [ Propriedades ]
        public List<PedidoService.Pedido> Pedidos
        {
            get
            {
                if (Session["Pedidos"] != null)
                    return (List<PedidoService.Pedido>)Session["Pedidos"];

                return new List<PedidoService.Pedido>();
            }
            set
            {
                Session["Pedidos"] = value;
            }
        }
        #endregion

        #region [ Eventos ]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarSituacaoPagamento();
                CarregarSituacaoEnvio();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
                Pesquisar();
        }

        protected void btnDespachar_Click(object sender, EventArgs e)
        {
            if (Pedidos.Count == 0)
                Alert("Favor buscar os pedidos à serem despachados.");
            else if (Pedidos.FindAll(o => o.StatusPedido == PedidoService.ePedidoStatusPedido.ProdutoEntregue).Count > 0)
                Alert("Existem pedidos concluídos na pesquisa, favor remove-los.");
            else
            {
                Popup("Dispatch.aspx", "800", "800");
            }
        }
        #endregion

        #region [ Métodos ]
        private void CarregarSituacaoEnvio()
        {
            var client = new DominioService.DominioClient();

            ddlSituacaoEnvio.DataValueField = "Id";
            ddlSituacaoEnvio.DataTextField = "Descricao";
            ddlSituacaoEnvio.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.SituacaoEnvio);
            ddlSituacaoEnvio.DataBind();
            ddlSituacaoEnvio.Items.Add(new ListItem { Selected = true, Text = "SELECIONE", Value = "-1" });
        }

        private void CarregarSituacaoPagamento()
        {
            var client = new DominioService.DominioClient();

            ddlSituacaoPagamento.DataValueField = "Id";
            ddlSituacaoPagamento.DataTextField = "Descricao";
            ddlSituacaoPagamento.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.SituacaoPagamento);
            ddlSituacaoPagamento.DataBind();
            ddlSituacaoPagamento.Items.Add(new ListItem { Selected = true, Text = "SELECIONE", Value = "-1" });
        }

        private bool ValidarCampos()
        {
            if (!IsEmpty(txtPedido.Text) && !IsNumeric(txtPedido.Text))
                NotificarCampo(txtPedido);
            else
                RemoverNotificacaoCampo(txtPedido);

            if (!IsEmpty(txtDataInicio.Text) && !IsDate(txtDataInicio.Text))
                NotificarCampo(txtDataInicio);
            else
                RemoverNotificacaoCampo(txtDataInicio);

            if (!IsEmpty(txtDataFim.Text) && !IsDate(txtDataFim.Text))
                NotificarCampo(txtDataFim);
            else
                RemoverNotificacaoCampo(txtDataFim);

            return true;
        }

        private void Pesquisar()
        {
            var pesquisa = new PedidoService.Pedido();

            pesquisa.IdPedido = ToInt32(txtPedido.Text);

            if (ToInt16(ddlSituacaoPagamento.SelectedValue) > 0)
                pesquisa.StatusPagamento = (PedidoService.ePedidoStatusPagamento)ToInt16(ddlSituacaoPagamento.SelectedValue);
            else
                pesquisa.StatusPagamento = null;

            if (ToInt16(ddlSituacaoEnvio.SelectedValue) > 0)
                pesquisa.StatusPedido = (PedidoService.ePedidoStatusPedido)ToInt16(ddlSituacaoEnvio.SelectedValue);
            else
                pesquisa.StatusPedido = null;

            if (ToInt16(ddlEntregador.SelectedValue) > 0)
                pesquisa.IdEntregador = ToInt16(ddlEntregador.SelectedValue);
            else
                pesquisa.IdEntregador = null;

            var client = new PedidoService.PedidoClient();
            Pedidos = client.Pesquisar(pesquisa, ToDate(txtDataInicio.Text), ToDate(txtDataFim.Text));

            gvPedidos.DataSource = Pedidos;
            gvPedidos.DataBind();

            //Só despacha se houverem pedidos, que ainda não tenham sido despachados para nenhum entregador.
            if (Pedidos.Count > 0 && Pedidos.FindAll(o => o.IdEntregador > 0).Count == 0)
                btnDespachar.Enabled = true;
        }
        #endregion                
    }
}