﻿using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Dominio : IDominio
    {        
        public List<DTO.Dominio> Listar()
        {
            var bll = new Business.DominioBLL();
            return bll.Listar();             
        }

        public List<DTO.Dominio> PesquisarPorTipo(eTipoDominio idTipoDominio)
        {
            var bll = new Business.DominioBLL();
            return bll.ObterPorTipo((short)idTipoDominio);
        }

        public List<DTO.Dominio> PesquisarPorID(short idDominio)
        {
            var bll = new Business.DominioBLL();
            return bll.ObterPorID(idDominio);
        }
        
        public int Gravar(DTO.Dominio Dominio)
        {
            var bll = new Business.DominioBLL();
            return bll.Gravar(Dominio);            
        }

        public void Excluir(DTO.Dominio Dominio)
        {
            var bll = new Business.DominioBLL();
            bll.Excluir(Dominio);
        }
    }
}
