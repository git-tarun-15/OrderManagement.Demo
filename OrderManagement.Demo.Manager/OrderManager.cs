using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Manager
{
    public class OrderManager : IOrderManager
    {
        private IInventoryRepository _inventoryRepository;

        public OrderManager(IInventoryRepository inventoryRepository)
        {
            
            _inventoryRepository = inventoryRepository;
        }
       
        public async Task<List<OrderItem>> GetInventory()
        {
            return await _inventoryRepository.GetInventory().ConfigureAwait(false);
        }
        public async Task<bool> CheckInventory(string productId, int qty)
        {
            return await _inventoryRepository.CheckInventory(productId,qty).ConfigureAwait(false);
        }
    }
}
