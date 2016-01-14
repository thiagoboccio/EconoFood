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
        bool Atualizar();
        int Inserir(T entidade);
        void Excluir();        
    }
}
