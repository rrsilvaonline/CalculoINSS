using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INSS.Entities
{
    public class ParametroAliquota
    {
        [Key]
        public long Id { get; set; }
        public decimal SalCntrMin { get; set; }
        public decimal SalCntrMax { get; set; }
        public decimal ValAlqt { get; set; }
        public int Ano { get; set; }
        public Boolean TetoMaximo { get; set; }
    }
}
