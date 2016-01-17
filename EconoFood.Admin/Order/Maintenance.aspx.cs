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
        public IList<PedidoService.Pedido> Pedidos
        {
            get
            {
                if (ViewState["Pedidos"] != null)
                    return (IList<PedidoService.Pedido>)ViewState["Pedidos"];

                return new List<PedidoService.Pedido>();
            }
            set
            {
                ViewState["Pedidos"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                ListarPedidos();
        }

        private void ListarPedidos()
        {
            var client = new PedidoService.PedidoClient();
            Pedidos = client.Listar();

            gvPedidos.DataSource = Pedidos;
            gvPedidos.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            //var pesquisa = new PedidoService.Pedido();
            //pesquisa.IdPedido = toInt32(txtPedido.Text);
            //pesquisa.StatusPagamento = (PedidoService.ePedidoStatusPagamento)ddlSituacaoPagamento.SelectedValue;
            //pesquisa.StatusPedido = (PedidoService.ePedidoStatusPedido)ddlSituacaoEnvio.SelectedValue;
            //pesquisa.IdEntregador = ToInt32(ddlEntregador.SelectedValue);

            //var client = new PedidoService.PedidoClient();
            //Pedidos = client.Pesquisar(pesquisa, ToDate(txtDataInicio.Text), ToDate(txtDataFim.Text));
        }
    }
}