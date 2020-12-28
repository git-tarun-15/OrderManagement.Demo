using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Demo.DataAccess
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;   
        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;  
        }

        public async Task<List<OrderItem>> GetInventory()
        {
            var inventories = new List<OrderItem>
                            {
                                new OrderItem {ProductId= 1, ItemName= "Item-1", Price=100, Quantity=10 },
                                new OrderItem {ProductId= 2, ItemName= "Item-2", Price=200, Quantity=20 },
                                new OrderItem {ProductId= 3, ItemName= "Item-3", Price=300, Quantity=30 },
                                new OrderItem {ProductId= 4, ItemName= "Item-4", Price=400, Quantity=40 },
                                new OrderItem {ProductId= 5, ItemName= "Item-5", Price=500, Quantity=50 },
                                new OrderItem {ProductId= 6, ItemName= "Item-6", Price=600, Quantity=60 },
                                new OrderItem {ProductId= 7, ItemName= "Item-7", Price=700, Quantity=70 },
                                new OrderItem {ProductId= 8, ItemName= "Item-8", Price=800, Quantity=5 },
                                new OrderItem {ProductId= 9, ItemName= "Item-9", Price=900, Quantity=4 },
                                new OrderItem {ProductId= 10, ItemName= "Item-10", Price=1000, Quantity=1 }
                            };
            return await Task.FromResult(inventories);
        }

        public async Task<bool> CheckInventory(string productId, int qty)
        {
            var inventories = await GetInventory().ConfigureAwait(false);
            return inventories.Any(i => i.ProductId == Convert.ToInt32(productId) && i.Quantity >= qty);
        }
    }
}
