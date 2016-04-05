using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Services.DTO
{
    public class Usuario
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public short Perfil { get; set; }
        public bool Status { get; set; }
        public string Senha { get; set; }
    }
}
