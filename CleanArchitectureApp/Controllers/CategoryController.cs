using CleanArchitectureApp.Dto.Category;
using CleanArchitectureApp.EfCore;
using CleanArchitectureApp.Entities.Interfaces;
using CleanArchitectureApp.Entities.POCOS;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWorkRepository unitOfWorkRepository) //Injection of DbContext configured in Program.cs
        {
            _categoryRepository = categoryRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetCategories().Where(c => c.Bhabilitado == 1).Select(cat => new CategoryDto
            {
                CategoryId = cat.Iidcategoria,
                CategoryName = cat.Nombre,
                Description = cat.Descripcion
            }).ToList();
        }

        public List<CategoryDto> GetCategoriesByName(string name)
        {
            return _categoryRepository.GetCategoriesByName(name).Where(c => c.Bhabilitado == 1).Select(cat => new CategoryDto
            {
                CategoryId = cat.Iidcategoria,
                CategoryName = cat.Nombre,
                Description = cat.Descripcion
            }).ToList();
        }

        public bool DeleteCategory(int categoryId)
        {
            bool response = false;
            try
            {
                _categoryRepository.RemoveCategory(categoryId);
                response = Convert.ToBoolean(Convert.ToInt16(_unitOfWorkRepository.SaveChanges()));
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public bool CreateCategory([FromBody] CreateCategoryDto createCategory)
        {
            bool response;

            Categorium category = new Categorium 
            {
                Bhabilitado = createCategory.Bhabilitado,
                Descripcion = createCategory.Descripcion,
                Iidcategoria = createCategory.Iidcategoria,
                Nombre = createCategory.Nombre
            };

            try
            {
                if (category.Iidcategoria == 0)
                {
                    _categoryRepository.AddCategory(category);
                }
                else
                {
                    _categoryRepository.UpdateCategory(category);
                }
                response = Convert.ToBoolean(Convert.ToInt16(_unitOfWorkRepository.SaveChanges()));
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
    }
}
