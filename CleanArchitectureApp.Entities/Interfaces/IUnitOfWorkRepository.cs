using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Entities.Interfaces
{
    /// <summary>
    /// This unit of work groups database operations
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        int SaveChanges();
    }
}
