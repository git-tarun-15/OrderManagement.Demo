using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Demo.Model
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public string AuthorizeToken { get; set; }
        public decimal Amount { get; set; }
    }
}
