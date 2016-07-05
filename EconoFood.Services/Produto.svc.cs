using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EconoFood.Services.Business;
using EconoFood.Services.DTO;

namespace EconoFood.Services
{
    public class Produto : IProduto
    {
        public List<DTO.Produto> Listar()
        {
            var bll = new Business.ProdutoBLL();
            return bll.Listar();             
        }

        public List<DTO.Produto> ListarPorCategoria(int TipoProduto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Listar(TipoProduto);
        }

        public List<DTO.Produto> PesquisarPorNome(string nomeProduto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Pesquisar(nomeProduto);
        }

        public DTO.Produto PesquisarPorID(int idProduto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Pesquisar(idProduto);
        }

        public int Gravar(DTO.Produto produto)
        {
            var bll = new Business.ProdutoBLL();
            return bll.Gravar(produto);            
        }

        public List<ProdutoImagem> ListarImagens(int idProduto)
        {
            var bll = new Business.ProdutoImagemBLL();
            return bll.ListarImagens(idProduto);
        }        
    }
}
