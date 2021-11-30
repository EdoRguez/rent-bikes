using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;

        private IOrderBikeRepository _orderBikeRepository;
        private IOrderRepository _orderRepository;
        private IBikeRepository _bikeRepository;
        private IRentalTypeRepository _rentalTypeRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrderBikeRepository OrderBike
        {
            get
            {
                if (_orderBikeRepository == null)
                    _orderBikeRepository = new OrderBikeRepository(_context);

                return _orderBikeRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_context);

                return _orderRepository;
            }
        }

        public IBikeRepository Bike
        {
            get
            {
                if (_bikeRepository == null)
                    _bikeRepository = new BikeRepository(_context);

                return _bikeRepository;
            }
        }

        public IRentalTypeRepository RentalType
        {
            get
            {
                if (_rentalTypeRepository == null)
                    _rentalTypeRepository = new RentalTypeRepository(_context);

                return _rentalTypeRepository;
            }
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
