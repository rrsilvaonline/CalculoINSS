using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INSS.Entities
{
    public class Funcionario
    {
        [Key]
        public long ID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public decimal Salario { get; set; }

        public decimal SalarioDescontado { get; set; }
    }
}
