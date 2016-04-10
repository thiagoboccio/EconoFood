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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Usuario : IUsuario
    {
        public List<DTO.Usuario> Listar()
        {
            var bll = new Business.UsuarioBLL();
            return bll.Listar();             
        }

        public List<DTO.Usuario> ListarPorStatus(bool retornarInativos)
        {
            var bll = new Business.UsuarioBLL();
            return bll.Listar(retornarInativos);
        }

        public DTO.Usuario PesquisarPorID(short idUsuario)
        {
            var bll = new Business.UsuarioBLL();
            return bll.Listar().Find(o => o.Id == idUsuario);
        }

        public int Gravar(DTO.Usuario Usuario)
        {
            var bll = new Business.UsuarioBLL();
            return bll.Gravar(Usuario);            
        }

        public void Excluir(DTO.Usuario Usuario)
        {
            var bll = new Business.UsuarioBLL();
            bll.Excluir(Usuario);
        }
    }
}
