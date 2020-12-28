using OrderManagement.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagement.Demo.UI.PaymentService
{
    public partial class CreditCard : Page
    {
        public ICreditCardManager CreditCardManager { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                txtCard.Text = "5555-6666-7777-8888";
                txtCVV.Text = "123";  
            }
        }
        protected async void btnAuthPayment_Click(object sender, EventArgs e)
        {
            var card = new Model.CreditCard
            {
                CardNumber = txtCard.Text,
                ClientId = ConfigurationManager.AppSettings.Get("ClientId"),
                ClientSecret = ConfigurationManager.AppSettings.Get("ClientSecret"),
                CVV = txtCVV.Text,
                ExpiryDate = ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue
            };
            var token = await CreditCardManager.AuthorizeCard(card).ConfigureAwait(false);
            if(token.Length > 0)
            {
                lblmessage.Text = "Authorized";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", $"window.parent.parent.closeModal('{token}');", true);
            }
            else
            {
                lblmessage.Text = "Payment is not Authorized";
            }
        }
        
    }
}
