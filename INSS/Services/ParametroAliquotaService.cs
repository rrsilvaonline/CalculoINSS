using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using INSS.Context;
using INSS.Entities;
using INSS.Services;
using INSS.Interfaces.Repository;
using INSS.Interfaces.Services;

namespace INSS.Services
{
    public class ParametroAliquotaService: IParametroAliquotaService
    {
        private readonly IParametroAliquotaRepository _parametroAliquotaRepository;

        public ParametroAliquotaService(IParametroAliquotaRepository parametroAliquotaRepository)
        {
            _parametroAliquotaRepository = parametroAliquotaRepository;
        }

        public bool DeleteObject(long pParamId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParametroAliquota> GetAll()
        {
            return _parametroAliquotaRepository.GetAll();
        }

        public ParametroAliquota GetObject(long pParamId)
        {
            return _parametroAliquotaRepository.GetObject(pParamId);
        }

        public ParametroAliquota GetObject(decimal pParamSalario, int pParamAno)
        {
            return _parametroAliquotaRepository.GetObject(pParamSalario, pParamAno);
        }

        public void PopularBaseParametro()
        {
            try
            {
                var vLstObject = _parametroAliquotaRepository.SetPopulaBase();
                if (vLstObject != null)
                {
                    if(vLstObject.Count() > 0)
                    {
                        Console.WriteLine("Base de parametros criada com sucesso!");
                    }
                }
            }
            catch (Exception e)
            { 
            }
        }

        public ParametroAliquota SaveObject(ParametroAliquota pParam)
        {
            return _parametroAliquotaRepository.SaveObject(pParam);
        }
    }
}
