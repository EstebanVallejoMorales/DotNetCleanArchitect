using CleanArchitectureApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Categorium> GetCategories()
        {
            using (BdventaContext context = new BdventaContext())
            {
                return context.Categoria.ToList();
            }
        }

        public List<Categorium> GetCategoriesByName(string name)
        {
            using(BdventaContext context = new BdventaContext())
            {
                return context.Categoria.Where(c => c.Nombre.Contains(name)).ToList();
            }
        }
    }
}
