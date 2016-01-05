using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EconoFood.Services.DTO
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int IdProduto { get; set; }
        [DataMember]
        public String Nome { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public List<ProdutoImagem> Imagens { get; set; }
    }
}
