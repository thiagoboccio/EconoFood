using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;

namespace EconoFood.Services.Business
{
    public class ProdutoBLL
    {
        public List<Produto> Listar()
        {
            var DAL = new ProdutoDAL();
            var retorno = DAL.Listar();

            if (retorno != null)
                return retorno;

            return new List<Produto>();
        }

        public List<Produto> Listar(int TipoProduto)
        {
            var DAL = new ProdutoDAL();
            var retorno = DAL.Listar(TipoProduto);

            if (retorno != null)
                return retorno;

            return new List<Produto>();
        }

        public List<Produto> Pesquisar(string nomeProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(nomeProduto, null);
        }

        public Produto Pesquisar(int idProduto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Pesquisar(string.Empty, idProduto).FirstOrDefault();
        }

        public int Gravar(Produto produto)
        {
            var DAL = new ProdutoDAL();
            return DAL.Inserir(produto);
        }
        
        public List<Comparacao> CompararPreco(List<Produto> produtos)
        {
            var retorno = new List<Comparacao>();
            var DAL = new ProdutoDAL();
            var comparacoes = DAL.CompararPreco(produtos);

            //Regras de scores para descidir as 3 melhores opções de compra
            //primeira regra - maior disponibilidade de itens para entrega
            comparacoes.OrderByDescending(o => o.ProdutosDisponiveis).ToList()[0].Score += 1;
            comparacoes.OrderByDescending(o => o.ProdutosDisponiveis).ToList()[1].Score += 0.5;
            comparacoes.OrderByDescending(o => o.ProdutosDisponiveis).ToList()[2].Score += 0.25;

            //segunda regra - menor preço total
            comparacoes.OrderByDescending(o => o.PrecoTotal).ToList()[0].Score += 1;
            comparacoes.OrderByDescending(o => o.PrecoTotal).ToList()[1].Score += 0.5;
            comparacoes.OrderByDescending(o => o.PrecoTotal).ToList()[2].Score += 0.25;
                        
            retorno.Add(comparacoes.OrderByDescending(o => o.Score).ToList()[0]);
            retorno.Add(comparacoes.OrderByDescending(o => o.Score).ToList()[1]);
            retorno.Add(comparacoes.OrderByDescending(o => o.Score).ToList()[2]);

            return retorno;
            //regra futura (em análise) - menor prazo de entrega
        }
    }
}
