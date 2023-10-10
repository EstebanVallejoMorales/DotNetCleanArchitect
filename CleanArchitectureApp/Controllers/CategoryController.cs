using CleanArchitectureApp.EfCore;
using CleanArchitectureApp.Entities.POCOS;
using CleanArchitectureApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    public class CategoryController : Controller
    {
        private BdventaContext _bdventaContext;

        public CategoryController(BdventaContext context) //Injection of DbContext configured in Program.cs
        {
            this._bdventaContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Categorium> GetCategories()
        {
            return _bdventaContext.Categoria.ToList(); //Now, we can use it in any method.
        }

        public List<Categorium> GetCategoriesByName(string name)
        {
            return _bdventaContext.Categoria.Where(c => c.Nombre.Contains(name)).ToList();
        }
    }
}
