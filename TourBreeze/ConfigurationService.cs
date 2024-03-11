using TourBreeze.Server.Service.Implimentation;
using TourBreeze.Server.Service.Interface;
using TourBreeze.Server;
using Microsoft.EntityFrameworkCore;

namespace TourBreeze
{
    public class ConfigurationService
    {
        /// <summary>
        /// Ragistration Dependancies
        /// </summary>
        /// <param name="services">builder.Services</param>
        /// <param name="configuration"> builder.Configuration</param>
        public static void RagistrationDependancies(IServiceCollection services ,ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddScoped<IProductRepo, ProductRepo>();
        }
    }
}
