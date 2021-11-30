using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetBikes(bool trackChanges);
        Task<Bike> GetBike(Guid id, bool trackChanges);
        Task<IEnumerable<Bike>> GetBikesByIds(List<Guid?> ids, bool trackChanges);
    }
}
