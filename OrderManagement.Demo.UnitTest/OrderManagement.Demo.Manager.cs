using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement.Demo.DataAccess;
using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Manager;
using OrderManagement.Demo.Model;

namespace OrderManagement.Demo.UnitTest
{
    [TestClass]
    public class Manager
    {
        [TestMethod]
        public async Task AuthorizeCard()
        {
            var card = new CreditCard
            {
                Amount = 1,
                CardNumber = "9999-9999-8888-8888",
                ClientId = "Dummy_ClientId",
                ClientSecret = "Dummy_ClientSecret",
                CVV = "333",
                ExpiryDate = "02/22"
            };

            CreditCardManager creditCardManager = new CreditCardManager("Dummy_DomainUrl");
            
            var response = await creditCardManager.AuthorizeCard(card).ConfigureAwait(false);
            if(response.Equals("Dummy_Token", StringComparison.CurrentCultureIgnoreCase) )
                Assert.IsTrue(true, "Test Passed.");
            else
                Assert.IsFalse(false, "Test Failed.");
        }

        [TestMethod]
        public async Task ChargePayment()
        {            
            CreditCardManager creditCardManager = new CreditCardManager("Dummy_DomainUrl");
            creditCardManager.AuthorizeToken = "Dummy_Token";
            var response  = await creditCardManager.ChargePayment("9999-9999-8888-8888", 1).ConfigureAwait(false);
            if (response)
                Assert.IsTrue(response, "Test Passed.");
            else
                Assert.IsFalse(response, "Test Failed.");
        }


        [TestMethod]
        public async Task SendEmail()
        {
            IEmailManager emailManager = new EmailManager();
            var response  = await emailManager.SendEmail("test@test.com", "from@from.com", "body test", "subject test").ConfigureAwait(false);
            if (response)
                Assert.IsTrue(response, "Test Passed.");
            else
                Assert.IsFalse(response, "Test Failed.");
        }

        [TestMethod]
        public async Task Login()
        {
            IUserAccountRepository userAccountRepository = new UserAccountRepository("Dummy_ConnectionString");
            IUserAccountManager userAccountManager = new UserAccountManager(userAccountRepository);
            var users = await userAccountManager.Login("admin","admin").ConfigureAwait(false);
            if (users > 0)
                Assert.IsTrue(true, "Test Passed.");
            else
                Assert.IsFalse(false, "Test Failed.");
        }
    }
}
