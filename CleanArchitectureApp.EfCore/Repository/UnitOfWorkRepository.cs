using CleanArchitectureApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.EfCore.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public readonly BdventaContext context;

        public UnitOfWorkRepository(BdventaContext bdventaContext)
        {
            context = bdventaContext;
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
