using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using INSS.Context;
using INSS.Entities;

namespace PrjWebInss
{
    public class Initializer
    {
        public static void Initialize(DbInssContext context)
        {
            context.Database.EnsureCreated();
            if (context.ParametroAliquota.Any())
            {
                return;
            }
            //popula os parametros para calculo
            var parametro = new ParametroAliquota[]
            {
                new ParametroAliquota {Ano=2011,SalCntrMin=0,SalCntrMax=1106.90m,ValAlqt=8.00m},
                new ParametroAliquota {Ano=2011,SalCntrMin=1106.91m,SalCntrMax=1844.83m,ValAlqt=9.00m},
                new ParametroAliquota {Ano=2011,SalCntrMin=1884.84m,SalCntrMax=3689.66m,ValAlqt=11.00m},
                new ParametroAliquota {Ano=2011,SalCntrMin=3689.67m,SalCntrMax=3689.66m,ValAlqt=405.86m},

                new ParametroAliquota {Ano=2012,SalCntrMin=0,SalCntrMax=1000,ValAlqt=7.00m},
                new ParametroAliquota {Ano=2012,SalCntrMin=1000.01m,SalCntrMax=1500,ValAlqt=8.00m},
                new ParametroAliquota {Ano=2012,SalCntrMin=1500.01m,SalCntrMax=3000,ValAlqt=9.00m},
                new ParametroAliquota {Ano=2012,SalCntrMin=3000.01m,SalCntrMax=4000,ValAlqt=11.86m},
                new ParametroAliquota {Ano=2012,SalCntrMin=4000.01m,SalCntrMax=3689.66m,ValAlqt=500},
            };

            foreach (ParametroAliquota p in parametro)
            {
                context.ParametroAliquota.Add(p);
            }
            context.SaveChanges();
        }
    }
}
