using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.Product
{
    public partial class Precification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Inicializar();
        }

        private void Inicializar()
        {            
            ddlProduto.Items.Add(new ListItem { Selected = true, Text = "SELECIONE", Value = "-1" });
            var client = new ProdutoService.ProdutoClient();
            ddlProduto.DataSource = client.Listar(new ProdutoService.ListarRequest());
            ddlProduto.DataBind();
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduto.SelectedValue != "-1")
            {
                
                //gvPrecificacao.DataSource = client.PesquisarPorID;
                //gvPrecificacao.DataBind();
            }
        }
    }
}