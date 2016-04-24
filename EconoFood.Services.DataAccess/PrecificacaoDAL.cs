using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Framework;
using EconoFood.Services.DTO;
using System.Data.SqlClient;
using System.Data;

namespace EconoFood.Services.DataAccess
{
    public class PrecificacaoDAL : IBase<Precificacao>
    {
        public bool Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Precificacao entidade)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Precificacao precificacao)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (precificacao.IdPrecificacao > 0)
            {
                conector = new Conector(Procedures.Precificacao_UPDATE);
                parametros.Add(new SqlParameter { ParameterName = "@IdPrecificacao", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = precificacao.IdPrecificacao });
            }
            else
            {
                conector = new Conector(Procedures.Precificacao_INSERT);
            }

            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", SqlDbType = SqlDbType.Int, Value = precificacao.IdProduto });
            parametros.Add(new SqlParameter { ParameterName = "@ValorCompra", SqlDbType = SqlDbType.Decimal, Value = precificacao.ValorCompra });
            parametros.Add(new SqlParameter { ParameterName = "@ValorVenda", SqlDbType = SqlDbType.Decimal, Value = precificacao.ValorVenda });
            parametros.Add(new SqlParameter { ParameterName = "@PercentualAplicado", SqlDbType = SqlDbType.Decimal, Value = precificacao.PercentualAplicado });
            parametros.Add(new SqlParameter { ParameterName = "@DataInicio", SqlDbType = SqlDbType.DateTime, Value = precificacao.DataInicio });

            return conector.ExecuteNonQuery(parametros);
        }

        public List<Precificacao> Listar()
        {
            Conector conector = new Conector(Procedures.Precificacao_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Precificacao>();
            while (resultado.Read())
            {
                var precificacao = new Precificacao();
                precificacao.IdPrecificacao = Convert.ToInt16(resultado["IdPrecificacao"].ToString());
                precificacao.DataInicio = Convert.ToDateTime(resultado["DataInicio"].ToString());
                precificacao.IdProduto = Convert.ToInt16(resultado["IdProduto"].ToString());
                precificacao.PercentualAplicado = Convert.ToDecimal(resultado["PercentualAplicado"].ToString());
                precificacao.ValorCompra = Convert.ToDecimal(resultado["ValorCompra"].ToString());
                precificacao.ValorVenda = Convert.ToDecimal(resultado["ValorVenda"].ToString());

                retorno.Add(precificacao);
            }

            return retorno;
        }

        public List<Precificacao> PesquisarPorProduto(Precificacao precificacao)
        {
            Conector conector = new Conector(Procedures.Precificacao_SELECT_POR_PRODUTO);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = precificacao.IdProduto });

            var resultado = conector.Select(parametros);
            var retorno = new List<Precificacao>();

            foreach (DataRow linha in resultado.Rows)
            {
                var precificacaoRetorno = new Precificacao();
                precificacaoRetorno.IdProduto = Convert.ToInt32(linha["IdProduto"].ToString());
                precificacaoRetorno.DataInicio = Convert.ToDateTime(linha["DataInicio"].ToString());
                precificacaoRetorno.IdPrecificacao = Convert.ToInt32(linha["IdPrecificacao"].ToString());
                precificacaoRetorno.PercentualAplicado = Convert.ToDecimal(linha["PercentualAplicado"].ToString());
                precificacaoRetorno.ValorCompra = Convert.ToDecimal(linha["ValorCompra"].ToString());
                precificacaoRetorno.ValorVenda = Convert.ToDecimal(linha["ValorVenda"].ToString());
                
                retorno.Add(precificacaoRetorno);
            }

            return retorno;
        }

        public Precificacao PesquisarPorID(Precificacao precificacao)
        {
            Conector conector = new Conector(Procedures.Precificacao_SELECT_POR_PRODUTO);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = precificacao.IdPrecificacao });

            var resultado = conector.Select(parametros);
            
            if(resultado.Rows.Count > 0)
            {
                var precificacaoRetorno = new Precificacao();
                precificacaoRetorno.IdProduto = Convert.ToInt32(resultado.Rows[0]["IdProduto"].ToString());
                precificacaoRetorno.DataInicio = Convert.ToDateTime(resultado.Rows[0]["DataInicio"].ToString());
                precificacaoRetorno.IdPrecificacao = Convert.ToInt32(resultado.Rows[0]["IdPrecificacao"].ToString());
                precificacaoRetorno.PercentualAplicado = Convert.ToDecimal(resultado.Rows[0]["PercentualAplicado"].ToString());
                precificacaoRetorno.ValorCompra = Convert.ToDecimal(resultado.Rows[0]["ValorCompra"].ToString());
                precificacaoRetorno.ValorVenda = Convert.ToDecimal(resultado.Rows[0]["ValorVenda"].ToString());

                return precificacaoRetorno;
            }

            return null;
        }
    }
}
