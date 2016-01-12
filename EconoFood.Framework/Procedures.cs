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
        /// CRIA UM NOVO PRODUTO
        /// </summary>
        public static readonly string Produto_INSERT = "Produto_INSERT";
        /// <summary>
        /// ATUALIZA UM PRODUTO
        /// </summary>
        public static readonly string Produto_UPDATE = "Produto_UPDATE";
        #endregion

        #region PRODUTO IMAGEM
        /// <summary>
        /// GRAVA AS IMAGENS DE UM PRODUTO EXISTENTE
        /// </summary>
        public static readonly string ProdutoImagem_INSERT = "ProdutoImagem_INSERT";
        /// <summary>
        /// RETORNA AS IMAGENS DE UM PRODUTO
        /// </summary>
        public static readonly string ProdutoImagem_SELECT = "ProdutoImagem_SELECT";
        #endregion
    }
}
