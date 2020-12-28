using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagement.Demo.UI
{
    public partial class Inventory : Page
    {
        public IOrderManager OrderManager { get; set; } 
        public ICreditCardManager CreditCardManager { get; set; }
        public IEmailManager EmailManager { get; set; }
        public IUserAccountManager UserAccountManager { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ddlInventory.Items.Add(new ListItem("Please Select an Item", "0"));

                var inventory = await this.OrderManager.GetInventory().ConfigureAwait(false);
                if (inventory != null && inventory.Count > 0)
                {
                    inventory.ForEach(item => ddlInventory.Items.Add(new ListItem(item.ItemName, item.ProductId.ToString())));
                }
                divPayment.Visible = false;
            }
        }

        protected async void btnValidate_Click(object sender, EventArgs e)
        {
            var response = await OrderManager.CheckInventory(ddlInventory.SelectedValue, Convert.ToInt32(ddlQuantity.SelectedValue)).ConfigureAwait(false);
            if (response)
            {
                lblMessage.Text = "Item is available, Please go ahead & authorize your card";
                divPayment.Visible = true;
            }
            else
            {
                lblMessage.Text = "Inventory is not available, Please go ahead & modify your cart.";
                divPayment.Visible = false;
            }

        }

        protected async void btnPayment_Click(object sender, EventArgs e)
        {
            if (hdnToken.Value.Length > 0 && hdnToken.Value.Equals("Dummy_Token", StringComparison.CurrentCultureIgnoreCase))
            {
                var inventory = await OrderManager.GetInventory().ConfigureAwait(false);
                var users = await UserAccountManager.GetUsers().ConfigureAwait(false);
                
                var user = users.Where(u => u.UserId == Convert.ToInt32(Session["UserId"])).FirstOrDefault();

                var order = inventory.Where(item => item.ProductId.ToString().Equals(ddlInventory.SelectedValue, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var lstItems = new List<OrderItem>();
                lstItems.Add(order);

                var orderDetails = new Order
                {
                    UserId = user.UserId,                    
                    Date = new DateTime(),
                    TotalAmount = Convert.ToDecimal(ddlQuantity.SelectedValue) * Convert.ToDecimal(order.Price),
                    Items = lstItems,
                    AuthorizedToken = hdnToken.Value, 
                    CreditCard = string.Empty
                };
                
                var response = await CreditCardManager.OrderPayment(orderDetails).ConfigureAwait(false);
               
                if (response)
                {
                    response = await EmailManager.SendEmail(user.UserEmail,"ordermanager@test.com", "Order Placed Successfully. It will be shipped shortly.", $"Order: {order.ProductId} Confirmation").ConfigureAwait(false);
                    if (response)
                    {
                        lblMessage.Text = "Payment Successful & Shipping details send to User Email.";
                        hdnToken.Value = string.Empty;  
                    }
                    else
                    {
                        lblMessage.Text = "Payment is not Successful, Please try again later.";
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", $"openModal('PaymentService/index.aspx');", true);
            }
        }
    }
}
