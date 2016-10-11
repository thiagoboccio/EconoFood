using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EconoFood.Framework;
using EconoFood.Services.DTO;
using EconoFood.Services.DTO.Enum;

namespace EconoFood.Services.DataAccess
{
    public class DominioDAL
    {
        public bool Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Dominio dominio)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            conector = new Conector(Procedures.Dominio_DELETE);
            parametros.Add(new SqlParameter { ParameterName = "@IdDominio", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = dominio.Id });

            conector.ExecuteNonQuery(parametros);
        }

        public int Inserir(Dominio dominio)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (dominio.Id > 0)
            {
                conector = new Conector(Procedures.Dominio_UPDATE);
                parametros.Add(new SqlParameter { ParameterName = "@IdDominio", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = dominio.Id });
            }
            else
            {
                conector = new Conector(Procedures.Dominio_INSERT);
                parametros.Add(new SqlParameter { ParameterName = "@IdDominio", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            }

            parametros.Add(new SqlParameter { ParameterName = "@Tipo", SqlDbType = SqlDbType.VarChar, Value = dominio.Tipo });
            parametros.Add(new SqlParameter { ParameterName = "@Descricao", SqlDbType = SqlDbType.SmallInt, Value = dominio.Descricao });

            conector.ExecuteNonQuery(parametros);

            return short.Parse(parametros.Find(o => o.ParameterName == "@IdDominio").Value.ToString());
        }

        public List<Dominio> Listar()
        {
            Conector conector = new Conector(Procedures.Dominio_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Dominio>();
            while (resultado.Read())
            {
                var dominio = new Dominio();
                dominio.Id = Convert.ToInt16(resultado["IdDominio"].ToString());
                dominio.Tipo = Convert.ToInt16(resultado["Tipo"].ToString());
                dominio.Descricao = resultado["Descricao"].ToString();

                retorno.Add(dominio);
            }

            return retorno;
        }

        public List<Dominio> ObterPorTipo(short idTipoDominio)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            conector = new Conector(Procedures.Dominio_SELECT_POR_TIPO);
            parametros.Add(new SqlParameter { ParameterName = "@Tipo", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = idTipoDominio });

            var resultado = conector.Select(parametros);
            var retorno = new List<Dominio>();

            foreach (DataRow item in resultado.Rows)
            {
                var dominio = new Dominio();
                dominio.Id = Convert.ToInt16(item["IdDominio"].ToString());
                dominio.Tipo = Convert.ToInt16(item["Tipo"].ToString());
                dominio.Descricao = item["Descricao"].ToString();

                retorno.Add(dominio);
            }
            
            return retorno;
        }

        public List<Dominio> ObterPorID(short idDominio)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            conector = new Conector(Procedures.Dominio_SELECT_POR_ID);
            parametros.Add(new SqlParameter { ParameterName = "@IdDominio", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = idDominio });

            var resultado = conector.Select(parametros);
            var retorno = new List<Dominio>();

            foreach (DataRow item in resultado.Rows)
            {
                var dominio = new Dominio();
                dominio.Id = Convert.ToInt16(item["IdDominio"].ToString());
                dominio.Tipo = Convert.ToInt16(item["Tipo"].ToString());
                dominio.Descricao = item["Descricao"].ToString();

                retorno.Add(dominio);
            }

            return retorno;
        }
    }
}
