using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EconoFood.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {            
        [OperationContract]
        List<DTO.Usuario> Listar();

        [OperationContract]
        List<DTO.Usuario> ListarPorStatus(bool retornarInativos);

        [OperationContract]
        DTO.Usuario PesquisarPorID(short idUsuario);

        [OperationContract]
        int Gravar(DTO.Usuario Usuario);

        [OperationContract]
        void Excluir(DTO.Usuario Usuario);
    }    
}
