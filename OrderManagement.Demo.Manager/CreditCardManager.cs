using Newtonsoft.Json;
using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Demo.Manager
{
    public class CreditCardManager : ICreditCardManager
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private string _domainURL;        
        public CreditCard Card { get; set; }
        public string AuthorizeToken { get; set; }

        private readonly decimal AuthCharge = 1;
        public CreditCardManager(string domainURL)
        {
            _domainURL = domainURL;
            
        }
        public async Task<string> AuthorizeCard(CreditCard card)
        {
            try
            {  
                var result = JsonConvert.SerializeObject(card);
                var stringContent = new StringContent(result, UnicodeEncoding.UTF8, "application/json");

                //This statement calls a not existing URL. This is just an example...
                var response = await httpClient.PostAsync(_domainURL + "/Authorize", stringContent);
                Card = card;
                if (response.IsSuccessStatusCode)
                {
                    await ChargePayment(card.CardNumber, AuthCharge).ConfigureAwait(false);
                }
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                 // return string.Empty;  
            }
            // Returning success for testing purpose  
            return "Dummy_Token";
            
        }

        public async Task<bool> ChargePayment(string creditCardNumber, decimal amount)
        {
            Payment card = new Payment
            {
                CardNumber = creditCardNumber,
                Amount = amount,
                AuthorizeToken = AuthorizeToken
            };
            var response = await PaymentProcess(card).ConfigureAwait(false);
            return response;  
        }

        public async Task<bool> OrderPayment(Order order)
        {
            try
            {
                Payment card = new Payment
                {
                    CardNumber = order.CreditCard,
                    Amount = order.TotalAmount,
                    AuthorizeToken = order.AuthorizedToken
                };
                                
                return await PaymentProcess(card).ConfigureAwait(false);
            }
            catch (Exception ex)
            {                
            }
            // Returning success for testing purpose  
            return true;  
        }
        private async Task<bool> PaymentProcess(Payment payment)
        {
            try
            {
                var result = JsonConvert.SerializeObject(payment);
                var stringContent = new StringContent(result, UnicodeEncoding.UTF8, "application/json");

                //This statement calls a not existing URL. This is just an example...
                var response = await httpClient.PostAsync(_domainURL + "/Payment", stringContent);
                return (response.Content.ReadAsStringAsync().Result == "Success") ? true : false;
            }
            catch (Exception ex)
            {
            }
            // Returning success for testing purpose  
            return true;
        }

    }
}
