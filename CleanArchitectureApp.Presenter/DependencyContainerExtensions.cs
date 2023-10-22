using CleanArchitectureApp.Dto.Category;
using CleanArchitectureApp.OutputPort.Category;
using CleanArchitectureApp.Presenter.Category;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Presenter
{
    public static class DependencyContainerExtensions
    {
        public static IServiceCollection DependencyPresenter(this IServiceCollection services)
        {
            services.AddScoped<IGetCategoriesOutputPort, GetCategoriesPresenter>();
            services.AddScoped<IPresenter<List<CategoryDto>>, GetCategoriesPresenter>();
            return services;
        } 
    }
}
