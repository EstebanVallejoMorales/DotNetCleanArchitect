using CleanArchitectureApp.Dto.Category;
using CleanArchitectureApp.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) //Injection of DbContext configured in Program.cs
        {
            this._categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetCategories().Select(cat => new CategoryDto
            {
                CategoryId = cat.Iidcategoria,
                CategoryName = cat.Nombre,
                Description = cat.Descripcion
            }).ToList();
        }

        public List<CategoryDto> GetCategoriesByName(string name)
        {
            return _categoryRepository.GetCategoriesByName(name).Select(cat => new CategoryDto
            {
                CategoryId = cat.Iidcategoria,
                CategoryName = cat.Nombre,
                Description = cat.Descripcion
            }).ToList();
        }
    }
}
