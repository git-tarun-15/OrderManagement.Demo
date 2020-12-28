using OrderManagement.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagement.Demo.UI
{
    public partial class _Default : Page
    {        
        public IUserAccountManager UserAccountManager { get; set; }
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = "admin";
                txtPWD.Attributes["value"] = "admin";
            }
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            var userId = await UserAccountManager.Login(txtUserName.Text, txtPWD.Text).ConfigureAwait(false);  
            if (userId > 0)
            {
                Session["UserId"] = userId;
                Response.Redirect("Inventory.aspx", false);
            }
            else
            {                
                this.lblError.Text = "Login Failed!";
            }
        }
    }
}