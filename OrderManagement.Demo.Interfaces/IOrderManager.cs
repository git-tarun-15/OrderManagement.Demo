using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Interfaces
{
    public interface IOrderManager
    {
        Task<List<OrderItem>> GetInventory();
        Task<bool> CheckInventory(string productId, int qty);  
    }
}
