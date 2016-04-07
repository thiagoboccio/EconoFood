using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.Order
{
    public partial class Dispatch : System.Web.UI.Page
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
            if (Pedidos.Count > 0)
                ListarPedidos();
        }

        private void ListarPedidos()
        {
            gvPedidos.DataSource = Pedidos;
            gvPedidos.DataBind();
        }
    }
}