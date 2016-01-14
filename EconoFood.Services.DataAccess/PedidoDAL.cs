﻿using EconoFood.Framework;
using EconoFood.Services.DTO;
using EconoFood.Services.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DataAccess
{
    public class PedidoDAL : IBase<Pedido>
    {
        public bool Atualizar()
        {
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public int Inserir(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> Listar()
        {
            Conector conector = new Conector(Procedures.Produto_SELECT_ALL);
            var resultado = conector.ExecuteReader();

            var retorno = new List<Pedido>();
            while (resultado.Read())
            {
                var pedido = new Pedido();
                pedido.IdPedido = Convert.ToInt32(resultado["IdPedido"].ToString());
                //pedido.Nome = resultado["Nome"].ToString();
                //pedido.Status = int.Parse(resultado["Status"].ToString());
                retorno.Add(pedido);
            }

            return retorno;
        }

        public List<Pedido> Pesquisar(int? idPedido, 
            DateTime? dataInicio, 
            DateTime? dataFim, 
            ePedido.StatusPedido? statusPedido,
            ePedido.StatusPagamento? statusPagamento,
            int? IdEntregador)
        {
            Conector conector = new Conector(Procedures.Produto_SELECT);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter { ParameterName = "@DataPedidoInicio", Value = dataInicio });
            parametros.Add(new SqlParameter { ParameterName = "@DataPedidoFim", Value = dataFim });
            parametros.Add(new SqlParameter { ParameterName = "@IdPedido", Value = idPedido });
            parametros.Add(new SqlParameter { ParameterName = "@StatusPedido", Value = statusPedido });
            parametros.Add(new SqlParameter { ParameterName = "@StatusPagamento", Value = statusPagamento });
            parametros.Add(new SqlParameter { ParameterName = "@IdEntregador", Value = IdEntregador });

            var resultado = conector.Select(parametros);
            var retorno = new List<Pedido>();

            foreach (DataRow linha in resultado.Rows)
            {
                var pedido = new Pedido();
                pedido.DataPedido = Convert.ToDateTime(linha["DataPedido"].ToString());
                pedido.DataRecebimento = Convert.ToDateTime(linha["DataRecebimento"].ToString());
                pedido.DocumentoRecebimento = linha["DocumentoRecebimento"].ToString();
                pedido.IdEntregador = Convert.ToInt16(linha["IdEntregador"].ToString());
                pedido.IdPedido = Convert.ToInt32(linha["IdPedido"].ToString());
                pedido.Recebimento = linha["Recebimento"].ToString();
                pedido.StatusPagamento = (ePedido.StatusPagamento)Convert.ToInt16(linha["StatusPagamento"].ToString());
                pedido.StatusPedido = (ePedido.StatusPedido)Convert.ToInt16(linha["StatusPedido"].ToString());

                retorno.Add(pedido);
            }

            return retorno;
        }
    }
}