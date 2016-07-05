using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Framework
{
    public static class Procedures
    {
        #region PRODUTO
        /// <summary>
        /// BUSCA TODOS OS PRODUTOS SEM FILTRO
        /// </summary>
        public static readonly string Produto_SELECT_ALL = "Produto_SELECT_ALL";
        /// <summary>
        /// BUSCA PRODUTO POR:
        /// <paramref name="ID"/>
        /// /
        /// <paramref name="NOME"/>
        /// </summary>
        public static readonly string Produto_SELECT = "Produto_SELECT";
        /// <summary>
        /// BUSCA PRODUTO POR:
        /// <paramref name="CATEGORIA"/>        
        /// </summary>
        public static readonly string Produto_SELECT_POR_CATEGORIA = "Produto_SELECT_POR_CATEGORIA";
        /// <summary>
        /// CRIA UM NOVO PRODUTO
        /// </summary>
        public static readonly string Produto_INSERT = "Produto_INSERT";
        /// <summary>
        /// ATUALIZA UM PRODUTO
        /// </summary>
        public static readonly string Produto_UPDATE = "Produto_UPDATE";
        /// <summary>
        /// CRIA UM NOVO DETALHE DE PRODUTO
        /// </summary>
        public static readonly string ProdutoDetalhe_INSERT = "ProdutoDetalhe_INSERT";
        /// <summary>
        /// ATUALIZA UM DETALHE DO PRODUTO
        /// </summary>
        public static readonly string ProdutoDetalhe_UPDATE = "ProdutoDetalhe_UPDATE";
        #endregion

        #region PRODUTO IMAGEM
        /// <summary>
        /// GRAVA AS IMAGENS DE UM PRODUTO EXISTENTE
        /// </summary>
        public static readonly string ProdutoImagem_INSERT = "ProdutoImagem_INSERT";
        /// <summary>
        /// GRAVA AS IMAGENS DE UM PRODUTO EXISTENTE
        /// </summary>
        public static readonly string ProdutoImagem_UPDATE = "ProdutoImagem_UPDATE";
        /// <summary>
        /// RETORNA AS IMAGENS DE UM PRODUTO
        /// </summary>
        public static readonly string ProdutoImagem_SELECT = "ProdutoImagem_SELECT";
        public static readonly string ProdutoImagem_DELETE = "ProdutoImagem_DELETE"; 
        #endregion

        #region PEDIDO
        /// <summary>
        /// BUSCA TODOS OS PEDIDOS SEM FILTRO
        /// </summary>
        public static readonly string Pedido_SELECT_ALL = "Pedido_SELECT_ALL";

        /// <summary>
        /// BUSCA PRODUTO POR:
        /// <paramref name="ID"/>
        /// /
        /// <paramref name="DATA"/>
        /// /
        /// <paramref name="STATUS ENTREGA"/>
        /// </summary>
        public static readonly string Pedido_SELECT = "Pedido_SELECT";
        #endregion

        #region USUARIO
        public static readonly string Usuario_SELECT_ALL = "Usuario_SELECT_ALL";
        public static readonly string Usuario_INSERT = "Usuario_INSERT";
        public static readonly string Usuario_UPDATE = "Usuario_UPDATE";
        public static readonly string Usuario_DELETE = "Usuario_DELETE";
        public static readonly string Usuario_SELECT = "Usuario_SELECT";
        #endregion

        #region DOMINIO
        public static readonly string Dominio_SELECT_ALL = "Dominio_SELECT_ALL";
        public static readonly string Dominio_INSERT = "Dominio_INSERT";
        public static readonly string Dominio_UPDATE = "Dominio_UPDATE";
        public static readonly string Dominio_DELETE = "Dominio_DELETE";
        public static readonly string Dominio_SELECT_POR_ID = "Dominio_SELECT_POR_ID";
        public static readonly string Dominio_SELECT_POR_TIPO = "Dominio_SELECT_POR_TIPO";
        #endregion

        #region PRECIFICACAO
        public static readonly string Precificacao_SELECT = "Precificacao_SELECT";
        public static readonly string Precificacao_SELECT_ALL = "Precificacao_SELECT_ALL";        
        public static readonly string Precificacao_SELECT_POR_PRODUTO = "Precificacao_SELECT_POR_PRODUTO";
        public static readonly string Precificacao_INSERT = "Precificacao_INSERT";
        public static readonly string Precificacao_UPDATE = "Precificacao_UPDATE";
        public static readonly string Precificacao_DELETE = "Precificacao_DELETE";
        #endregion
    }
}
