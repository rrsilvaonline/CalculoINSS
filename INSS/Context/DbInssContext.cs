using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using INSS.Entities;

namespace INSS.Context
{
    public class DbInssContext: DbContext
    {
        public DbSet<ParametroAliquota> ParametroAliquota { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        public DbInssContext(DbContextOptions<DbInssContext> options) : base(options)
        {

        }
    }
}
