using CleanArchitectureApp.Dto.Category;
using CleanArchitectureApp.Entities.Interfaces;
using CleanArchitectureApp.InputPort.Category;
using CleanArchitectureApp.OutputPort.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Interactor.Category
{
    public class GetCategoriesInteractor : IGetCategoriesInputPort
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGetCategoriesOutputPort _output;

        public GetCategoriesInteractor(ICategoryRepository categoryRepository, IGetCategoriesOutputPort output)
        {
            _categoryRepository = categoryRepository;
            _output = output;
        }

        public void Handler()
        {
            List<CategoryDto> categories = _categoryRepository.GetCategories().Where(c => c.Bhabilitado == 1)
                .Select(category => new CategoryDto
                {
                    CategoryId = category.Iidcategoria,
                    CategoryName = category.Nombre,
                    Description = category.Descripcion
                }).ToList();

            _output.Handler(categories);
        }
    }
}
