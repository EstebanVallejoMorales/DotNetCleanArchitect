using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.InputPort.Category
{
    public interface IDeleteCategoryInputPort
    {
        void Handler(int categoryId);
    }
}
