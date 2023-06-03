using BarkodWeb.Data.Context;
using BarkodWeb.Data.Repositories.Abstractions;
using BarkodWeb.Data.Repositories.Concretes;
using BarkodWeb.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtansion( this IServiceCollection services,IConfiguration config )
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));






            // Replace with your connection string.
            //var connectionString = "Server=sql508.main-hosting.eu;User id=u207061878_Mraydogan;Password=Mraydogan_1998;Database=u207061878_BarkodWebDb;";

            //// Replace with your server version and type.
            //// Use 'MariaDbServerVersion' for MariaDB.
            //// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            //// For common usages, see pull request #1233.
            //var serverVersion = new MySqlServerVersion(new Version(5, 1,1));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
          
                    
            //);




            //services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped< IUnitOfWork, UnitOfWork >();

            return services;
        }
    }
}
