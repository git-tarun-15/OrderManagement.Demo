using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Interfaces
{
    public interface ICreditCardManager  
    {
        Task<string> AuthorizeCard(CreditCard card);
        Task<bool> OrderPayment(Order order);
        Task<bool> ChargePayment(string creditCardNumber, decimal amount);  
    }
}
