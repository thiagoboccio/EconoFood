using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.Business
{
    public class PrecificacaoBLL
    {
        public int Gravar(Precificacao precificacao)
        {
            var DAL = new PrecificacaoDAL();
            return DAL.Inserir(precificacao);
        }

        public List<Precificacao> Listar()
        {
            var DAL = new PrecificacaoDAL();
            return DAL.Listar();
        }

        public Precificacao PesquisarPorID(Precificacao precificacao)
        {
            var DAL = new PrecificacaoDAL();
            return DAL.PesquisarPorID(precificacao);
        }

        public List<Precificacao> PesquisarPorProduto(Precificacao precificacao)
        {
            var DAL = new PrecificacaoDAL();
            return DAL.PesquisarPorProduto(precificacao);
        }
    }
}
