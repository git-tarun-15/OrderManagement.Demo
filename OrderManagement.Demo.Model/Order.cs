using System;
using System.Collections.Generic;

namespace OrderManagement.Demo.Model
{
    public class Order
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; }  
        public string AuthorizedToken { get; set; }
        public string CreditCard { get; set; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
