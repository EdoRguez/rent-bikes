using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRentalTypeRepository
    {
        Task<IEnumerable<RentalType>> GetRentalTypes(bool trackChanges);
        Task<RentalType> GetRentalType(Guid id, bool trackChanges);
    }
}
