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
        public int intParser;

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

        public void NotificarCampo(WebControl controle)
        {
            List<string> Campos = CamposObrigatorios;
            controle.Style.Add("border-color", "#F5A9A9");
            Campos.Add(controle.ToolTip);
            CamposObrigatorios = Campos;
        }

        public void NotificarCampo(HtmlTable controle)
        {
            List<string> Campos = CamposObrigatorios;
            controle.Style.Add("border-color", "#F5A9A9");
            Campos.Add(controle.ID);
            CamposObrigatorios = Campos;
        }

        public void RemoverNotificacaoCampo(WebControl controle)
        {
            List<string> Campos = CamposObrigatorios;
            Campos.Remove(controle.ToolTip);
            CamposObrigatorios = Campos;
        }

        public void RemoverNotificacaoCampo(HtmlTable controle)
        {
            List<string> Campos = CamposObrigatorios;
            Campos.Remove(controle.ID);
            CamposObrigatorios = Campos;
        }

        public void Alert(string msg)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", string.Format("javascript:alert('{0}');", msg), true);
        }

        public void Popup(string url, string width, string height)
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "window.open", string.Format("javascript:window.open({0}, 'Despachar pedidos', width={1}, heigth={2});", url, width, height), true);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "window.open", string.Format("window.open({0}, 'Despachar pedidos', width={1}, heigth={2});", url, width, height), true);
        }
    }
}