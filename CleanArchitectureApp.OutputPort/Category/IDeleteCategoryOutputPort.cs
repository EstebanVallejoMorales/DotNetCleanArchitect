using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.OutputPort.Category
{
    public interface IDeleteCategoryOutputPort
    {
        void Handler(bool response);
    }
}
