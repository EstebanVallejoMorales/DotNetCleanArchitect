using CleanArchitectureApp.Dto.Category;
using CleanArchitectureApp.OutputPort.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Presenter.Category
{
    public class GetCategoriesPresenter : IGetCategoriesOutputPort, IPresenter<List<CategoryDto>>
    {
        public List<CategoryDto> Content { get; private set; }

        public void Handler(List<CategoryDto> categories)
        {
            Content = categories;
        }
    }
}
