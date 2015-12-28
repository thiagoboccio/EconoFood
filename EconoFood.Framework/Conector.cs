using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Framework
{
    public class Conector
    {
        public Conector(string procedure)
        {
            _commandText = procedure;
        }

        private string _commandText;
        private SqlConnection _Connection;
        private SqlConnection Connection
        {
            get
            {
                try
                {
                    _Connection = new SqlConnection(@"Server=THIAGO-PC\SQLEXPRESS; user id=sa; password=123321; DataBase=EconoFood");
                    _Connection.Open();
                    return _Connection;
                }
                catch (ExceptionHandler ex)
                {
                    ex.BusinessMessage = "Erro ao criar conexão.";
                    throw ex;   
                }                
            }
        }
        private SqlCommand _Command;
        private SqlCommand Command
        {
            get
            {
                _Command = new SqlCommand(_commandText, this.Connection);
                _Command.CommandType = CommandType.StoredProcedure;
                return _Command;
            }
        }

        public SqlDataReader ExecuteReader()
        {
            var execucao = Command;
            return execucao.ExecuteReader();            
        }

        public int ExecuteNonQuery()
        {
            var execucao = Command;
            return execucao.ExecuteNonQuery();            
        }

        public DataTable Select(List<SqlParameter> parametros)
        {            
            var execucao = Command;
            parametros.ForEach(o => execucao.Parameters.Add(o));
            SqlDataAdapter da = new SqlDataAdapter(execucao);
            DataTable retorno = new DataTable();
            da.Fill(retorno);

            return retorno;
        }
    }
}
