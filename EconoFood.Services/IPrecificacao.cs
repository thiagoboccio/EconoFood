using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EconoFood.Services
{
    [ServiceContract]
    public interface IPrecificacao
    {            
        [OperationContract]
        List<DTO.Precificacao> Listar();
                
        [OperationContract]
        DTO.Precificacao PesquisarPorID(DTO.Precificacao precificacao);

        [OperationContract]
        List<DTO.Precificacao> PesquisarPorProduto(DTO.Precificacao precificacao);

        [OperationContract]
        int Gravar(DTO.Precificacao precificacao);        
    }    
}
