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
            throw new NotImplementedException();
        }
    }
}
