using CleanArchitectureApp.Entities.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Entities.Interfaces
{
    public interface ICategoryRepository
    {
        List<Categorium> GetCategories();
        List<Categorium> GetCategoriesByName(string name);
        bool AddCategory(Categorium category);
        bool RemoveCategory(int Iidcategoria);
        bool UpdateCategory(Categorium category);
    }
}
