using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DTO;
using System.Data.SqlClient;
using EconoFood.Framework;
using System.Data;

namespace EconoFood.Services.DataAccess
{
    public class ProdutoImagemDAL
    {
        public List<ProdutoImagem> Listar(int idProduto)
        {
            Conector conector = new Conector(Procedures.ProdutoImagem_SELECT);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@IdProduto", Value = idProduto, SqlDbType = System.Data.SqlDbType.Int });

            var resultado = conector.Select(parametros);
            var retorno = new List<ProdutoImagem>();

            foreach (DataRow linha in resultado.Rows)
            {
                var produtoImagem = new ProdutoImagem();
                produtoImagem.IdProduto = Convert.ToInt32(linha["IdProduto"].ToString());
                produtoImagem.IdImagem = Convert.ToInt16(linha["IdImagem"].ToString());
                produtoImagem.Imagem = (byte[])linha["Imagem"];
                retorno.Add(produtoImagem);
            }

            return retorno;
        }
    }
}
