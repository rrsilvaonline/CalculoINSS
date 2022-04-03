using System;
using System.Collections.Generic;
using System.Text;

using INSS.Context;
using INSS.Entities;
using INSS.Interfaces.Repository;

namespace INSS.Interfaces.Services
{
    public interface IParametroAliquotaService
    {
        void PopularBaseParametro();
        IEnumerable<ParametroAliquota> GetAll();
        ParametroAliquota GetObject(long pParamId);
        ParametroAliquota GetObject(decimal pParamSalario, int pParamAno);
        Boolean DeleteObject(long pParamId);
        ParametroAliquota SaveObject(ParametroAliquota pParam);
    }
}
