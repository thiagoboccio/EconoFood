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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarSituacaoPagamento();
                CarregarSituacaoEnvio();
            }
        }

        private void CarregarSituacaoEnvio()
        {
            var client = new DominioService.DominioClient();

            ddlSituacaoEnvio.DataValueField = "Id";
            ddlSituacaoEnvio.DataTextField = "Descricao";
            ddlSituacaoEnvio.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.SituacaoEnvio);
            ddlSituacaoEnvio.DataBind();
        }

        private void CarregarSituacaoPagamento()
        {
            var client = new DominioService.DominioClient();

            ddlSituacaoPagamento.DataValueField = "Id";
            ddlSituacaoPagamento.DataTextField = "Descricao";
            ddlSituacaoPagamento.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.SituacaoPagamento);
            ddlSituacaoPagamento.DataBind();
        }

        //private void ListarPedidos()
        //{
        //    var client = new PedidoService.PedidoClient();
        //    Pedidos = client.Listar();

        //    gvPedidos.DataSource = Pedidos;
        //    gvPedidos.DataBind();
        //}

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            var pesquisa = new PedidoService.Pedido();
            pesquisa.IdPedido = ToInt32(txtPedido.Text);
            pesquisa.StatusPagamento = (PedidoService.ePedidoStatusPagamento)ToInt16(ddlSituacaoPagamento.SelectedValue);
            pesquisa.StatusPedido = (PedidoService.ePedidoStatusPedido)ToInt16(ddlSituacaoEnvio.SelectedValue);
            pesquisa.IdEntregador = ToInt16(ddlEntregador.SelectedValue);

            var client = new PedidoService.PedidoClient();
            Pedidos = client.Pesquisar(pesquisa, ToDate(txtDataInicio.Text), ToDate(txtDataFim.Text));

            gvPedidos.DataSource = Pedidos;
            gvPedidos.DataBind();
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
    }
}