using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using INSS.Entities;

namespace INSS.Interfaces.Repository
{
    public interface IFuncionarioRepository
    {
        public IEnumerable<Funcionario> GetAll();
        public Funcionario GetObject(long pParamId);
        public Boolean DeleteObject(long pParamId);
        public Funcionario SaveObject(Funcionario pParam);
    }
}
