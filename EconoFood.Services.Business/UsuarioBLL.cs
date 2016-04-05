using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EconoFood.Services.DataAccess;
using EconoFood.Services.DTO;

namespace EconoFood.Services.Business
{
    public class UsuarioBLL
    {
        public List<Usuario> Listar()
        {
            var DAL = new UsuarioDAL();
            return DAL.Listar();
        }

        public int Gravar(Usuario usuario)
        {
            var DAL = new UsuarioDAL();
            return DAL.Inserir(usuario);
        }

        public void Excluir(Usuario usuario)
        {
            var DAL = new UsuarioDAL();
            DAL.Excluir(usuario);
        }
    }
}
