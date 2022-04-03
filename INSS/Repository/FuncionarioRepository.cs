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
    public class FuncionarioRepository: IFuncionarioRepository
    {
        private readonly DbInssContext _context;

        public FuncionarioRepository(DbInssContext context)
        {
            this._context = context;
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

        public IEnumerable<Funcionario> GetAll()
        {
            return _context.Funcionario.ToList();
        }

        public Funcionario GetObject(long pParamId)
        {
            return _context.Funcionario.FirstOrDefault(x => x.ID == pParamId);
        }

        public Funcionario SaveObject(Funcionario pParam)
        {
            if (pParam != null)
            {
                if (pParam.ID == 0)
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
