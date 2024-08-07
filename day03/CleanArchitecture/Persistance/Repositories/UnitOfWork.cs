using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class UnitOfWork(SchoolContext _schoolContext) : IUnitOfWork
    {
        public async Task SaveChanges()
        {
            await _schoolContext.SaveChangesAsync();
        }
    }
}
