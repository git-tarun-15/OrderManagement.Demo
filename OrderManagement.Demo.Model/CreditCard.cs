using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Demo.Model
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public decimal Amount { get; set; }
    }
}
