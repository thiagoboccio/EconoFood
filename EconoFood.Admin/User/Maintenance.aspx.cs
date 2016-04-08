using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.User
{
    public partial class Maintenance : PageHandler
    {
        //public List<string> Mensagens { get; set; }
        public List<EconoFood.Admin.UsuarioService.Usuario> RetornoConsulta
        {
            get
            {
                if (ViewState["RetornoConsulta"] != null)
                    return (List<EconoFood.Admin.UsuarioService.Usuario>)ViewState["RetornoConsulta"];

                return new List<EconoFood.Admin.UsuarioService.Usuario>();
            }
            set { ViewState["RetornoConsulta"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarComboPerfil();
                CarregarComboStatus();
                CarregarUsuarios();
            }
        }

        private void CarregarComboStatus()
        {
            ddlStatus.Items.Add(new ListItem { Text = "SELECIONE", Selected = true, Value = "-1" });
            ddlStatus.Items.Add(new ListItem { Text = "Inativo", Value = "0" });
            ddlStatus.Items.Add(new ListItem { Text = "Ativo", Value = "1" });            
        }

        private void CarregarComboPerfil()
        {
            var client = new Admin.DominioService.DominioClient();
                        
            ddlPerfil.DataTextField = "Descricao";
            ddlPerfil.DataValueField = "Id";
            ddlPerfil.DataSource = client.PesquisarPorTipo(DominioService.eTipoDominio.PerfilUsuario);
            ddlPerfil.DataBind();
            ddlPerfil.Items.Add(new ListItem { Selected = true, Enabled = true, Text = "SELECIONE", Value = "-1" });
        }

        private void CarregarUsuarios()
        {
            var client = new Admin.UsuarioService.UsuarioClient();
            RetornoConsulta = client.Listar();

            gvUsuario.DataSource = RetornoConsulta;
            gvUsuario.DataBind();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            { 
                InserirUsuario();
                CarregarUsuarios();
                Alert("Cadastro efetuado com sucesso.");
            }
        }

        private void InserirUsuario()
        {
            var client = new Admin.UsuarioService.UsuarioClient();
            client.Gravar(new UsuarioService.Usuario
            {
                Email = txtEmail.Text.Trim().ToUpper(),
                Nome = txtNome.Text.Trim().ToUpper(),
                Perfil = ToInt16(ddlPerfil.SelectedValue),
                Senha = txtSenha.Text.Trim(),
                Status = ddlStatus.SelectedValue == "1" ? true : false
            });
        }

        private bool ValidarDados()
        {
            if(string.IsNullOrEmpty(txtNome.Text.Trim()))
                NotificarCampo(txtNome);
            else
                RemoverNotificacaoCampo(txtNome);

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                NotificarCampo(txtEmail);
            else
                RemoverNotificacaoCampo(txtEmail);

            if (string.IsNullOrEmpty(txtSenha.Text.Trim()))
                NotificarCampo(txtSenha);
            else
                RemoverNotificacaoCampo(txtSenha);

            if (int.Parse(ddlPerfil.SelectedValue) == -1)
                NotificarCampo(ddlPerfil);
            else
                RemoverNotificacaoCampo(ddlPerfil);

            if (int.Parse(ddlStatus.SelectedValue) == -1)
                NotificarCampo(ddlStatus);
            else
                RemoverNotificacaoCampo(ddlStatus);

            return CamposObrigatorios.Count == 0;
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuario.PageIndex = e.NewPageIndex;
            gvUsuario.DataSource = RetornoConsulta;
            gvUsuario.DataBind();
        }
    }
}