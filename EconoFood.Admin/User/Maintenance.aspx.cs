using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EconoFood.Admin.UsuarioService;

namespace EconoFood.Admin.User
{
    public partial class Maintenance : PageHandler
    {
        #region [ Propriedades ]
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

        public UsuarioService.Usuario UsuarioEditado
        {
            get
            {
                if (ViewState["UsuarioEditado"] != null)
                    return (UsuarioService.Usuario)ViewState["UsuarioEditado"];

                return new UsuarioService.Usuario();
            }
            set { ViewState["UsuarioEditado"] = value; }
        }
        #endregion

        #region [ Eventos ]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimparSessao();
                CarregarComboPerfil();
                CarregarComboStatus();
                CarregarUsuarios();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarDados())
            {
                InserirUsuario();
                CarregarUsuarios();
                LimparCampos(Form.Controls[5]);
                LimparSessao();
                Alert("Cadastro efetuado com sucesso.");
            }
        }

        protected void gvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuario.PageIndex = e.NewPageIndex;
            gvUsuario.DataSource = RetornoConsulta;
            gvUsuario.DataBind();
        }

        protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                UsuarioEditado = BuscarUsuarioPorId(ToInt16(e.CommandArgument.ToString()));
                PreencherCampos(UsuarioEditado);
            }
        }

        #endregion

        #region [ Métodos ]
        private void LimparSessao()
        {
            UsuarioEditado = null;
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

        private void LimparCampos(Control contentPlaceHolder)
        {
            foreach (Control controle in contentPlaceHolder.Controls)
            {
                if (controle is TextBox) ((TextBox)controle).Text = string.Empty;
                if (controle is DropDownList) ((DropDownList)controle).SelectedValue = "-1";
            }
        }

        private void InserirUsuario()
        {
            var client = new Admin.UsuarioService.UsuarioClient();
            var usuario = new UsuarioService.Usuario();
            if (UsuarioEditado.Id > 0)
                usuario.Id = UsuarioEditado.Id;
            usuario.Email = txtEmail.Text.Trim().ToUpper();
            usuario.Nome = txtNome.Text.Trim().ToUpper();
            usuario.Perfil = ToInt16(ddlPerfil.SelectedValue);
            usuario.Senha = txtSenha.Text.Trim();
            usuario.DataNascimento = ToDate(txtDataNascimento.Text);
            usuario.Status = ddlStatus.SelectedValue == "1" ? true : false;
            usuario.CPF = txtCpf.Text.Trim();

            client.Gravar(usuario);
        }

        private bool ValidarDados()
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
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

            if (string.IsNullOrEmpty(txtDataNascimento.Text.Trim()))
                NotificarCampo(txtDataNascimento);
            else
                RemoverNotificacaoCampo(txtDataNascimento);

            if (string.IsNullOrEmpty(txtCpf.Text.Trim()))
                NotificarCampo(txtCpf);
            else
                RemoverNotificacaoCampo(txtCpf);

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

        private void PreencherCampos(Usuario usuario)
        {
            txtNome.Text = usuario.Nome;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;
            ddlPerfil.SelectedValue = ((short)usuario.Perfil).ToString();
            ddlStatus.SelectedValue = usuario.Status == true ? "1" : "0";
            txtCpf.Text = usuario.CPF;
            txtDataNascimento.Text = usuario.DataNascimento.ToString();
        }

        private UsuarioService.Usuario BuscarUsuarioPorId(short idUsuario)
        {
            var client = new UsuarioService.UsuarioClient();

            return client.PesquisarPorID(idUsuario);
        }
        #endregion        
    }
}