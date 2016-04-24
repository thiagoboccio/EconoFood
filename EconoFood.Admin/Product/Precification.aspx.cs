using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EconoFood.Admin.Product
{
    public partial class Precification : PageHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Inicializar();
        }

        private void Inicializar()
        {            
            var client = new ProdutoService.ProdutoClient();
            ddlProduto.DataSource = client.Listar(new ProdutoService.ListarRequest()).ListarResult;
            ddlProduto.DataBind();
            ddlProduto.Items.Add(new ListItem { Selected = true, Text = "SELECIONE", Value = "-1" });
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduto.SelectedValue != "-1")
            {
                var client = new PrecificacaoService.PrecificacaoClient();
                gvPrecificacao.DataSource = client.PesquisarPorProduto(new PrecificacaoService.Precificacao { IdProduto = ToInt32(ddlProduto.SelectedValue) });
                gvPrecificacao.DataBind();
            }
            else
            {
                gvPrecificacao.DataSource = null;
                gvPrecificacao.DataBind();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (ValidarPrecificacao())
            {
                GravarPrecificacao();
                LimparCampos();
                Alert("Cadastro efetuado com sucesso.");
            }
        }

        private void LimparCampos()
        {
            txtDataInicio.Text = txtPercentualAplicado.Text = txtValorCompra.Text = txtValorVenda.Text = string.Empty;
            ddlProduto.SelectedValue = "-1";
            gvPrecificacao.DataSource = null;
            gvPrecificacao.DataBind();
        }

        private void GravarPrecificacao()
        {
            var client = new PrecificacaoService.PrecificacaoClient();
            client.Gravar(new PrecificacaoService.Precificacao
            {
                DataInicio = ToDate(txtDataInicio.Text),
                IdProduto = ToInt32(ddlProduto.SelectedValue),
                PercentualAplicado = ToDecimal(txtPercentualAplicado.Text),
                ValorCompra = ToDecimal(txtValorCompra.Text),
                ValorVenda = ToDecimal(txtValorVenda.Text)
            });
        }

        private bool ValidarPrecificacao()
        {
            if (IsEmpty(txtDataInicio.Text.Trim()) || !IsDate(txtDataInicio.Text))
                NotificarCampo(txtDataInicio);
            else
                RemoverNotificacaoCampo(txtDataInicio);

            if (ToInt32(ddlProduto.SelectedValue) == -1)
                NotificarCampo(ddlProduto);
            else
                RemoverNotificacaoCampo(ddlProduto);

            if (IsEmpty(txtPercentualAplicado.Text) || !IsDecimal(txtPercentualAplicado.Text))
                NotificarCampo(txtPercentualAplicado);
            else
                RemoverNotificacaoCampo(txtPercentualAplicado);

            if (IsEmpty(txtValorCompra.Text) || !IsDecimal(txtValorCompra.Text))
                NotificarCampo(txtValorCompra);
            else
                RemoverNotificacaoCampo(txtValorCompra);


            if (IsEmpty(txtValorVenda.Text) || !IsDecimal(txtValorVenda.Text))
                NotificarCampo(txtValorVenda);
            else
                RemoverNotificacaoCampo(txtValorVenda);

            return CamposObrigatorios.Count == 0;
        }

        protected void txtValorVenda_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmpty(txtValorVenda.Text) && IsDecimal(txtValorVenda.Text))
                CalcularMargemDeLucro("valor");
        }

        private void CalcularMargemDeLucro(string origem)
        {
            if (origem.Equals("valor"))
            {
                var valorCompra = ToDecimal(txtValorCompra.Text);
                var valorVenda = ToDecimal(txtValorVenda.Text);
                if (valorVenda > valorCompra)
                {
                    txtPercentualAplicado.Text = (((valorVenda*100)/valorCompra)-100).ToString();
                }
                else { Alert("O valor de venda deve ser maior que o de compra."); }
            }
            else if (origem.Equals("percentual"))
            {
                var compra = ToDecimal(txtValorCompra.Text);
                var percentual = ToDecimal(txtPercentualAplicado.Text);

                if (percentual > 0)
                    txtValorVenda.Text = (((compra * percentual) / 100) + compra).ToString();
                else { Alert("O percentual deve ser positivo."); }
            }
        }

        protected void txtPercentualAplicado_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmpty(txtPercentualAplicado.Text) && IsDecimal(txtPercentualAplicado.Text))
                CalcularMargemDeLucro("percentual");
        }
    }
}