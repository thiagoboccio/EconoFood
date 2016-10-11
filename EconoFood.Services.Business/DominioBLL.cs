using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;

namespace EconoFood.Services.Business
{
    public class DominioBLL
    {
        public List<Dominio> Listar()
        {
            var DAL = new DominioDAL();
            return DAL.Listar();
        }

        public int Gravar(Dominio dominio)
        {
            var DAL = new DominioDAL();
            return DAL.Inserir(dominio);
        }

        public void Excluir(Dominio dominio)
        {
            var DAL = new DominioDAL();
            DAL.Excluir(dominio);
        }

        public List<Dominio> ObterPorTipo(short idTipoDominio)
        {
            var DAL = new DominioDAL();
            return DAL.ObterPorTipo(idTipoDominio);
        }

        public List<Dominio> ObterPorID(short idDominio)
        {
            var DAL = new DominioDAL();
            return DAL.ObterPorID(idDominio);
        }
    }
}
