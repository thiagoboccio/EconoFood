using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Framework
{
    public interface IBase<T>
    {
        List<T> Listar();
        List<T> ListarTodos();
        bool Atualizar();
        int Inserir();
        void Excluir();        
    }
}
