using CleanArchitectureApp.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.InputPort.Category
{
    public interface ICreateCategoryInputPort
    {
        void Handler(CreateCategoryDto createCategory);
    }
}
