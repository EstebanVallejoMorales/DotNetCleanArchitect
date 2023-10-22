using CleanArchitectureApp.InputPort.Category;
using CleanArchitectureApp.Interactor.Category;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Interactor
{
    public static class DependencyContainerExtensions
    {
        public static IServiceCollection DependencyInteractor(this IServiceCollection services)
        {
            services.AddScoped<IGetCategoriesInputPort, GetCategoriesInteractor>();
            return services;
        }
    }
}
