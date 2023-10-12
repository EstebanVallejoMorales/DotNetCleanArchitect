using CleanArchitectureApp.EfCore;
using CleanArchitectureApp.Entities.Interfaces;
using CleanArchitectureApp.Entities.POCOS;
using CleanArchitectureApp.Models;
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

        public List<Categorium> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public List<Categorium> GetCategoriesByName(string name)
        {
            return _categoryRepository.GetCategoriesByName(name);
        }
    }
}
