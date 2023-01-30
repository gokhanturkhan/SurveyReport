using DAL.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessService(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../SurveyReport"));
            configurationManager.AddJsonFile("appsettings.json");

            services.AddDbContext<SurveyReportDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));
        }
    }
}
