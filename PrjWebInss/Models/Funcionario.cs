using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjWebInss.Models
{
    public class Funcionario
    {
        public long ID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public decimal Salario { get; set; }

        public decimal SalarioDescontado { get; set; }
    }
}
