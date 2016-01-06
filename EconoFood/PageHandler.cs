using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EconoFood
{
    public class PageHandler : Page
    {
        public List<String> CamposObrigatorios
        {
            get
            {
                if (HttpContext.Current.Session["CamposObrigatorios"] == null)
                    return new List<string>();

                return (List<string>)HttpContext.Current.Session["CamposObrigatorios"];
            }
            set
            {
                HttpContext.Current.Session["CamposObrigatorios"] = value;
            }
        }

        public void DestacarCampo(WebControl controle)
        {
            List<string> Campos = CamposObrigatorios;
            controle.Style.Add("border-color", "red");
            Campos.Add(controle.ToolTip);
            CamposObrigatorios = Campos;
        }

        public void DestacarCampo(HtmlTable controle)
        {
            List<string> Campos = CamposObrigatorios;
            controle.Style.Add("border-color", "red");
            Campos.Add(controle.ID);
            CamposObrigatorios = Campos;
        }
    }
}