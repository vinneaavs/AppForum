using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto03.AcessoDados.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.AcessoDados.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfStructDB(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = 
                services
                .AddDbContext<ForumContext>(
                options =>
                options
                .UseSqlServer(configuration.GetConnectionString("ForumConnection")))
                .BuildServiceProvider();

            var context = provider
                .GetRequiredService<ForumContext>();
            DbInitializer
                .Initialize(context);
            return services;
        }
    }
}
