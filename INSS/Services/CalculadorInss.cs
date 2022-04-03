using System;
using System.Collections.Generic;
using System.Text;
using INSS.Entities;
using INSS.Interfaces.Repository;
using INSS.Interfaces.Services;
using INSS.Repository;

namespace INSS.Services
{
    public class CalculadorInss : ICalculadorInss
    {
        IParametroAliquotaRepository _objParametroAliquota;

        public CalculadorInss(IParametroAliquotaRepository objParametroAliquota)
        {
            _objParametroAliquota = objParametroAliquota;
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            decimal vRetorno = 0;
            var vParametros = _objParametroAliquota.GetObject(salario, data.Year);

            vRetorno =  vParametros.TetoMaximo == true ? vParametros.ValAlqt : (salario * vParametros.ValAlqt) / 100;

            return vRetorno;
        }
    }
}
