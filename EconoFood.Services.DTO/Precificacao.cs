using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EconoFood.Services.DTO
{
    [DataContract]
    public class Precificacao
    {
        [DataMember]
        public int IdPrecificacao { get; set; }
        [DataMember]
        public int IdProduto { get; set; }
        [DataMember]
        public decimal ValorCompra { get; set; }
        [DataMember]
        public decimal ValorVenda { get; set; }
        [DataMember]
        public decimal PercentualAplicado { get; set; }
        [DataMember]
        public DateTime DataInicio { get; set; }
    }
}
