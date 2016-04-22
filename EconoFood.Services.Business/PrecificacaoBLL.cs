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
    }
}
