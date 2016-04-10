using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.User
{
    public partial class Deliveryman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherGridEntregadores();
                PreencherComboUsuarios();
            }
        }

        private void PreencherComboUsuarios()
        {
            var client = new UsuarioService.UsuarioClient();
            ddlUsuario.DataSource = client.Listar();
            ddlUsuario.DataBind();
        }

        private void PreencherGridEntregadores()
        {
            gvEntregador.DataSource = "";
            gvEntregador.DataBind();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}