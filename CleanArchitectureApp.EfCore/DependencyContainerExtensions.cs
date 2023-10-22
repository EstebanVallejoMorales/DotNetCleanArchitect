using CleanArchitectureApp.EfCore.Repository;
using CleanArchitectureApp.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.EfCore
{
    public static class DependencyContainerExtensions //Simulates Program.cs of CleanArchitectureApp project
    {
        //This is an extension method of the IServiceCollection, that's why it must be static and uses this in parameter.
        //https://www.youtube.com/watch?v=9cA1MK4Fj7k&ab_channel=hdeleon.net
        public static IServiceCollection DependenciyEf(this IServiceCollection services) 
        {
            /*Used to register services that are created once per request in an ASP.NET Core web application. 
             * Scoped means that each time an HTTP request is received, a new instance of the service is created 
             * and used for the duration of that request. When the request completes, the service is discarded.*/
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            //Note: AddDbContext is also an Extension method from EntityframeworkCore
            services.AddDbContext<BdventaContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-07LAHVE;database=BDVenta;Integrated Security=True;Encrypt=false");
            });
            return services;
        }
    }
}
