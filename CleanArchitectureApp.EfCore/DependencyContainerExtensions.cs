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
        public static IServiceCollection DependenciyEf(this IServiceCollection services) //This is an extension method of the IServiceCollection, that's why it must be static and uses this in parameter.
        {
            //Note: AddDbContext is also an Extension method from EntityframeworkCore
            services.AddDbContext<BdventaContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("server=DESKTOP-07LAHVE;database=BDVenta;Integrated Security=True;Encrypt=false");
            });
            return services;
        }
    }
}
