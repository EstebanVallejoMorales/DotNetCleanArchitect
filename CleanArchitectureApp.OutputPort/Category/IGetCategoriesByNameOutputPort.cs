using CleanArchitectureApp.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.OutputPort.Category
{
    public interface IGetCategoriesByNameOutputPort
    {
        void Handler(List<CategoryDto> categories);
    }
}
