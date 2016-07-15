using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EconoFood.ProdutoService;

namespace EconoFood.Showroom
{
    public partial class Comparison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new ProdutoService.ProdutoClient();
            var comparacao = client.Comparar(new CompararRequest { produtos = Master.Carrinho });
            gv1.DataSource = comparacao.CompararResult[1];
            gv1.DataBind();
            gv2.DataSource = comparacao.CompararResult[0];
            gv2.DataBind();
            gv3.DataSource = comparacao.CompararResult[2];
            gv3.DataBind();
        }
    }
}