using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using INSS.Entities;

namespace INSS.Interfaces.Repository
{
    public interface IParametroAliquotaRepository
    {
        public IEnumerable<ParametroAliquota> GetAll();
        public ParametroAliquota GetObject(long pParamId);
        public ParametroAliquota GetObject(decimal pParamSalario, int pParamAno);
        public Boolean DeleteObject(long pParamId);
        public ParametroAliquota SaveObject(ParametroAliquota pParam);
        public IEnumerable<ParametroAliquota> SetPopulaBase();
    }
}
