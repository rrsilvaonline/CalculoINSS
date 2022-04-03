using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using INSS.Context;
using INSS.Entities;
using INSS.Interfaces.Repository;

using Microsoft.EntityFrameworkCore;

namespace INSS.Repository
{
    public class ParametroAliquotaRepository: IParametroAliquotaRepository
    {
        private readonly DbInssContext _context;

        public ParametroAliquotaRepository(DbInssContext context)
        {
            _context = context;
        }
        public bool DeleteObject(long pParamId)
        {
            var obj = this.GetObject(pParamId);
            if (obj == null)
                return false;

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ParametroAliquota> GetAll()
        {
            return _context.ParametroAliquota.ToList();
        }

        public ParametroAliquota GetObject(long pParamId)
        {
            return _context.ParametroAliquota.FirstOrDefault(x => x.Id == pParamId);
        }

        public ParametroAliquota GetObject(decimal pParamSalario, int pParamAno)
        {
            ParametroAliquota vObject;
            var lista = this.GetAll();
            if (lista != null)
            {
                vObject = _context.ParametroAliquota.FirstOrDefault(x => x.Ano == pParamAno &&
                                                                  x.SalCntrMin <= pParamSalario &&
                                                                  x.SalCntrMax >= pParamSalario);
            }
            else
            {
                vObject = null;
            }
            return vObject;
        }

        public IEnumerable<ParametroAliquota> SetPopulaBase()
        {
            var parametro = new ParametroAliquota[]
            {
                new ParametroAliquota {Ano=2011,SalCntrMin=0,SalCntrMax=1106.90m,ValAlqt=8.00m,TetoMaximo = false},
                new ParametroAliquota {Ano=2011,SalCntrMin=1106.91m,SalCntrMax=1844.83m,ValAlqt=9.00m,TetoMaximo = false},
                new ParametroAliquota {Ano=2011,SalCntrMin=1884.84m,SalCntrMax=3689.66m,ValAlqt=11.00m,TetoMaximo = false},
                new ParametroAliquota {Ano=2011,SalCntrMin=3689.67m,SalCntrMax=10000.00m,ValAlqt=405.86m,TetoMaximo = true},

                new ParametroAliquota {Ano=2012,SalCntrMin=0,SalCntrMax=1000,ValAlqt=7.00m,TetoMaximo = false},
                new ParametroAliquota {Ano=2012,SalCntrMin=1000.01m,SalCntrMax=1500,ValAlqt=8.00m, TetoMaximo = false},
                new ParametroAliquota {Ano=2012,SalCntrMin=1500.01m,SalCntrMax=3000,ValAlqt=9.00m,TetoMaximo = false},
                new ParametroAliquota {Ano=2012,SalCntrMin=3000.01m,SalCntrMax=4000,ValAlqt=11.86m,TetoMaximo = false},
                new ParametroAliquota {Ano=2012,SalCntrMin=4000.01m,SalCntrMax=10000.00m,ValAlqt=500,TetoMaximo = true},
            };

            foreach (ParametroAliquota p in parametro)
            {
                _context.ParametroAliquota.Add(p);
            }
            _context.SaveChanges();
            return this.GetAll();
        }

        public ParametroAliquota SaveObject(ParametroAliquota pParam)
        {
            if (pParam != null)
            {
                if (pParam.Id == 0)
                {
                    _context.Add(pParam);
                }
                else
                {
                    _context.Update(pParam);
                }
                _context.SaveChanges();
                return pParam;
            }
            else
            {
                return null;
            }
        }
    }
}
