using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using INSS.Context;
using INSS.Services;
using INSS.Repository;
using INSS.Interfaces.Repository;
using INSS.Interfaces.Services;

namespace PrgCalculoINSS
{
    public class Startup
    {
        public Startup() 
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var calculatorInssService = serviceProvider.GetService<ICalculadorInss>();
            var parametroAliquitaService = serviceProvider.GetService<IParametroAliquotaService>();

            parametroAliquitaService.PopularBaseParametro();

            Application.Run(new FrmCalculoINSS(parametroAliquitaService, calculatorInssService));
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICalculadorInss, CalculadorInss>()
                    .AddScoped<IParametroAliquotaService, ParametroAliquotaService>()
                    .AddScoped<IFuncionarioRepository, FuncionarioRepository>()
                    .AddScoped<IParametroAliquotaRepository, ParametroAliquotaRepository>()
                    .AddDbContext<DbInssContext>(opt => opt.UseInMemoryDatabase("INSS"));
        }
    }
}
