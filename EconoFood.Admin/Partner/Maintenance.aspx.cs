using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.Partner
{
    public partial class Maintenance : PageHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {

            }
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
                NotificarCampo(txtNome);
            else
                RemoverNotificacaoCampo(txtNome);

            if (string.IsNullOrEmpty(txtURLConsulta.Text.Trim()))
                NotificarCampo(txtURLConsulta);
            else
                RemoverNotificacaoCampo(txtURLConsulta);

            if (string.IsNullOrEmpty(txtURLFiliada.Text.Trim()))
                NotificarCampo(txtURLFiliada);
            else
                RemoverNotificacaoCampo(txtURLFiliada);

            return CamposObrigatorios.Count == 0;
        }
    }
}