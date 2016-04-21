using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Showroom
{
    public partial class Showroom : PageHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new ProdutoService.ProdutoClient();
            var resultadoPesquisa = client.Listar(new ProdutoService.ListarRequest());

            gvProduto.DataSource = resultadoPesquisa.ListarResult;
            gvProduto.DataBind();
        }
    }
}