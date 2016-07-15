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
    public interface IProduto
    {
            
        [OperationContract]
        List<DTO.Produto> Listar();

        [OperationContract]
        List<DTO.Produto> ListarPorCategoria(int TipoProduto);

        [OperationContract]
        List<DTO.Produto> PesquisarPorNome(string nomeProduto);

        [OperationContract]
        DTO.Produto PesquisarPorID(int idProduto);

        [OperationContract]
        int Gravar(DTO.Produto produto);

        [OperationContract]
        List<DTO.ProdutoImagem> ListarImagens(int idProduto);

        [OperationContract]
        List<DTO.Comparacao> Comparar(List<DTO.Produto> produtos);
    }    
}
