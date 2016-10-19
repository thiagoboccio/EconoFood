using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class Parceiro
    {
        public String Nome { get; set; }
        public bool Status { get; set; }
        public string URLConsultaProdutos { get; set; }
        public string URLFiliada { get; set; }
        public byte[] Logotipo { get; set; }
    }
}
