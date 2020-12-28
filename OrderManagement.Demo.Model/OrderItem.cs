using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Demo.Model
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
