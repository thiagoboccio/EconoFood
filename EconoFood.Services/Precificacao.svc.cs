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
    public class Precificacao : IPrecificacao
    {
        public int Gravar(DTO.Precificacao precificacao)
        {
            var bll = new PrecificacaoBLL();
            return bll.Gravar(precificacao);
        }

        public List<DTO.Precificacao> Listar()
        {
            var bll = new PrecificacaoBLL();
            return bll.Listar();
        }

        public DTO.Precificacao PesquisarPorID(DTO.Precificacao precificacao)
        {
            var bll = new PrecificacaoBLL();
            return bll.PesquisarPorID(precificacao);
        }

        public List<DTO.Precificacao> PesquisarPorProduto(DTO.Precificacao precificacao)
        {
            var bll = new PrecificacaoBLL();
            return bll.PesquisarPorProduto(precificacao);
        }
    }
}
