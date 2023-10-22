using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Dto.Category
{
    public class CreateCategoryDto
    {
        public int Iidcategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Bhabilitado { get; set; }
    }
}
