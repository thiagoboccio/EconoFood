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
    public interface IPedido
    {
        [OperationContract]
        IList<DTO.Pedido> Listar();

        [OperationContract]
        IList<DTO.Pedido> Pesquisar(DTO.Pedido pedido, DateTime inicio, DateTime fim);

        [OperationContract]
        int Gravar(DTO.Pedido pedido);        
    }    
}
