using Entities;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RentalTypeRepository : RepositoryBase<RentalType>, IRentalTypeRepository
    {
        public RentalTypeRepository(ApplicationDbContext context): base(context) { }

        public Task<RentalType> GetRentalType(Guid id, bool trackChanges)
        {
            return FindSingleByCondition(x => x.Id == id, trackChanges);
        }

        public async Task<IEnumerable<RentalType>> GetRentalTypes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
