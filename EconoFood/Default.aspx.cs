using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            var client = new ProdutoService.ProdutoClient();
            var resultadoPesquisa = client.PesquisarPorNome(new ProdutoService.PesquisarPorNomeRequest { nomeProduto = txtPesquisaProduto.Text.Trim() });

            gvPesquisaProdutos.DataSource = resultadoPesquisa.PesquisarPorNomeResult;
            gvPesquisaProdutos.DataBind();
        }

        protected void gvPesquisaProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            //    lblStatus.Text = ((EconoFood.ProdutoService.Produto)e.Row.DataItem).Status == 1 ? "Ativo" : "Inativo";
            //}
        }
    }
}