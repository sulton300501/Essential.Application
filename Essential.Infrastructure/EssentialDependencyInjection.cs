using Essential.Application.Abstraction.Repository;
using Essential.Infrastructure.Persistance;
using Essential.Infrastructure.Persistance.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Infrastructure
{
    public static class EssentialDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddDbContext<EssentialDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("EssentialProject"));

            });

            services.AddScoped<IEssentialRepository,EssentialRepository>();


            return services;


        }
    }
}
