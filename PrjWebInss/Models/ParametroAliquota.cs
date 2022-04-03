using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjWebInss.Models
{
    public class ParametroAliquota
    {
        public long Id { get; set; }
        public decimal SalCntrMin { get; set; }
        public decimal SalCntrMax { get; set; }
        public decimal ValAlqt { get; set; }
        public int Ano { get; set; }
    }
}
