using CleanArchitectureApp.Entities.Interfaces;
using CleanArchitectureApp.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.EfCore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private BdventaContext _bdventaContext;

        public CategoryRepository(BdventaContext bdventaContext)
        {
            _bdventaContext = bdventaContext;
        }

        public bool AddCategory(Categorium category)
        {
            try
            {
                _bdventaContext.Categoria.Add(category);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Categorium> GetCategories()
        {
            return _bdventaContext.Categoria.ToList();
        }

        public List<Categorium> GetCategoriesByName(string name)
        {
            return _bdventaContext.Categoria.Where(c => c.Nombre.Contains(name)).ToList();
        }

        public bool RemoveCategory(int Iidcategoria)
        {
            try
            {
                var category = _bdventaContext.Categoria 
                    .Where(c=>c.Iidcategoria==Iidcategoria).FirstOrDefault();
                if (category!=null)
                {
                    category.Bhabilitado = 0;
                    _bdventaContext.Update(category);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCategory(Categorium category)
        {
            try
            {
                var categoryDb = _bdventaContext.Categoria
                    .Where(c => c.Iidcategoria == category.Iidcategoria).FirstOrDefault();
                if (categoryDb != null)
                {
                    _bdventaContext.Update(categoryDb);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
