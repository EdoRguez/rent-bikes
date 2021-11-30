using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryManager
    {
        IOrderBikeRepository OrderBike { get; }
        IOrderRepository Order { get; }
        IBikeRepository Bike { get; }
        IRentalTypeRepository RentalType { get; }
        Task SaveAsync();
    }
}
