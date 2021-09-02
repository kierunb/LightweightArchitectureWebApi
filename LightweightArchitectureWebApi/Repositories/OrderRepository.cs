using LightweightArchitectureWebApi.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightweightArchitectureWebApi.Repositories
{
    
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<Order> GetById(int id)
        {
            return await Task.FromResult(
                new Order { OrderId = id, Name = $"Order: {id}", Price = id * 2, Status = 1 }
            );
        }
    }
}
