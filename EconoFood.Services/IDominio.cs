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
    public interface IDominio
    {            
        [OperationContract]
        List<DTO.Dominio> Listar();
        
        [OperationContract]
        List<DTO.Dominio> PesquisarPorTipo(eTipoDominio idTipoDominio);

        [OperationContract]
        int Gravar(DTO.Dominio Dominio);

        [OperationContract]
        void Excluir(DTO.Dominio Dominio);
    }    
}
