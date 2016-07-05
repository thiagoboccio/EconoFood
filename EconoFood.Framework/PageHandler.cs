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
        private decimal decimalParser;
        private long longParser;
        private DateTime dateParser;
        
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

        public short ToInt16(string valor)
        {
            if (IsNumeric(valor)) return Convert.ToInt16(valor.Trim());

            return 0;
        }

        public int ToInt32(string valor)
        {
            if(IsNumeric(valor)) return Convert.ToInt32(valor.Trim());

            return 0;
        }

        public long ToInt64(string valor)
        {
            if (IsNumeric(valor)) return Convert.ToInt64(valor.Trim());

            return 0;
        }

        public decimal ToDecimal(string valor)
        {
            if (IsDecimal(valor)) return Convert.ToDecimal (valor.Trim());

            return 0;
        }

        public DateTime ToDate(string valor)
        {
            if (IsDate(valor)) return Convert.ToDateTime(valor.Trim());

            return DateTime.MinValue;
        }

        public bool IsEmpty(string valor) { return string.IsNullOrEmpty(valor.Trim()); }

        public bool IsNumeric(string valor) { return long.TryParse(valor.Trim(), out longParser); }

        public bool IsDecimal(string valor) { return Decimal.TryParse(valor.Trim(), out decimalParser); }

        public bool IsDate(string valor) { return DateTime.TryParse(valor.Trim(), out dateParser); }
    }
}