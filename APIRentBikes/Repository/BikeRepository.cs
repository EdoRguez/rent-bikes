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
    public class BikeRepository: RepositoryBase<Bike>, IBikeRepository
    {
        public BikeRepository(ApplicationDbContext context): base(context) { }

        public async Task<Bike> GetBike(Guid id, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id == id, trackChanges);
        }

        public async Task<IEnumerable<Bike>> GetBikes(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<Bike>> GetBikesByIds(List<Guid?> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }
    }
}
