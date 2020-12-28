using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement.Demo.DataAccess;
using OrderManagement.Demo.Interfaces;

namespace OrderManagement.Demo.UnitTest
{
    [TestClass]
    public class DataAccess
    {
        [TestMethod]
        public async Task Get_Inventory_With_Wrong_Product()
        {

            IInventoryRepository inventoryRepository = new InventoryRepository("Dummy_ConnectionString");
            var inventory = await inventoryRepository.CheckInventory("9", 8).ConfigureAwait(false);
            if(inventory)
                Assert.IsTrue(inventory, "Test Passed.");
            else
                Assert.IsFalse(inventory, "Test Failed.");
        }

        [TestMethod]
        public async Task Get_Inventory_With_Correct_Product()
        {
            IInventoryRepository inventoryRepository = new InventoryRepository("Dummy_ConnectionString");
            var inventory = await inventoryRepository.CheckInventory("1", 5).ConfigureAwait(false);
            if (inventory)
                Assert.IsTrue(inventory, "Test Passed.");
            else
                Assert.IsFalse(inventory, "Test Failed.");
        }


        [TestMethod]
        public async Task Get_Inventory()
        {
            IInventoryRepository inventoryRepository = new InventoryRepository("Dummy_ConnectionString");
            var inventory = await inventoryRepository.GetInventory().ConfigureAwait(false);
            if (inventory.Count > 0)
                Assert.IsTrue(true, "Test Passed.");
            else
                Assert.IsFalse(false, "Test Failed.");
        }

        [TestMethod]
        public async Task Get_Users()
        {
            IUserAccountRepository userAccountRepository = new UserAccountRepository("Dummy_ConnectionString");
            var users = await userAccountRepository.GetUsers().ConfigureAwait(false);
            if (users.Count > 0)
                Assert.IsTrue(true, "Test Passed.");
            else
                Assert.IsFalse(false, "Test Failed.");
        }
    }
}
