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
    public class UsuarioDAL : IBase<Usuario>
    {
        public bool Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Usuario usuario)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            conector = new Conector(Procedures.Usuario_DELETE);
            parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = usuario.Id });
            
            conector.ExecuteNonQuery(parametros);            
        }

        public int Inserir(Usuario usuario)
        {
            Conector conector;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (usuario.Id > 0)
            {
                conector = new Conector(Procedures.Usuario_UPDATE);
                parametros.Add(new SqlParameter { ParameterName = "@IdUsuario", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = usuario.Id });
            }
            else
            {
                conector = new Conector(Procedures.Usuario_INSERT);                
            }

            parametros.Add(new SqlParameter { ParameterName = "@NomeUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario.Nome });
            parametros.Add(new SqlParameter { ParameterName = "@EmailUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario.Email });
            parametros.Add(new SqlParameter { ParameterName = "@Perfil", SqlDbType = SqlDbType.SmallInt, Value = usuario.Perfil });
            parametros.Add(new SqlParameter { ParameterName = "@Status", SqlDbType = SqlDbType.Bit, Value = usuario.Status });
            parametros.Add(new SqlParameter { ParameterName = "@DataNascimento", SqlDbType = SqlDbType.DateTime, Value = usuario.DataNascimento });
            parametros.Add(new SqlParameter { ParameterName = "@Senha", SqlDbType = SqlDbType.NVarChar, Value = PasswordHandler.Encrypt(usuario.Senha, "econofood") });
            parametros.Add(new SqlParameter { ParameterName = "@Cpf", SqlDbType = SqlDbType.VarChar, Value = usuario.CPF });

            return conector.ExecuteNonQuery(parametros);            
        }

        public List<Usuario> Listar()
        {
            Conector conector = new Conector(Procedures.Usuario_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Usuario>();
            while (resultado.Read())
            {
                var usuario = new Usuario();
                usuario.Id      = Convert.ToInt16(resultado["IdUsuario"].ToString());
                usuario.Nome    = resultado["NomeUsuario"].ToString();
                usuario.Perfil  = Convert.ToInt16(resultado["Perfil"].ToString());
                usuario.Email   = resultado["EmailUsuario"].ToString();
                usuario.Status  = bool.Parse(resultado["Status"].ToString());
                usuario.Senha   = PasswordHandler.Decrypt(resultado["Senha"].ToString(), "econofood");
                usuario.DataNascimento = Convert.ToDateTime(resultado["DataNascimento"].ToString());
                usuario.CPF     = resultado["Cpf"].ToString();
                usuario.DataCadastro = Convert.ToDateTime(resultado["DataCadastro"].ToString());

                retorno.Add(usuario);
            }

            return retorno;
        }
        
        public List<Usuario> Listar(bool listarInativos)
        {
            Conector conector = new Conector(Procedures.Usuario_SELECT);
            List<SqlParameter> parametros = new List<SqlParameter>();
            
            if(!listarInativos)
                parametros.Add(new SqlParameter { ParameterName = "@Status", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Input, Value = true });

            var resultado = conector.Select(parametros);

            var retorno = new List<Usuario>();

            foreach (DataRow item in resultado.Rows)
            {
                var usuarioRetorno = new Usuario();
                usuarioRetorno.Id = Convert.ToInt16(item["IdUsuario"].ToString());
                usuarioRetorno.Nome = item["NomeUsuario"].ToString();
                usuarioRetorno.Perfil = Convert.ToInt16(item["Perfil"].ToString());
                usuarioRetorno.Email = item["EmailUsuario"].ToString();
                usuarioRetorno.Status = bool.Parse(item["Status"].ToString());
                usuarioRetorno.Senha = PasswordHandler.Decrypt(item["Senha"].ToString(), "econofood");
                usuarioRetorno.DataNascimento = Convert.ToDateTime(item["DataNascimento"].ToString());
                usuarioRetorno.CPF = item["Cpf"].ToString();
                usuarioRetorno.DataCadastro = Convert.ToDateTime(item["DataCadastro"].ToString());

                retorno.Add(usuarioRetorno);
            }            

            return retorno;
        }
    }
}
