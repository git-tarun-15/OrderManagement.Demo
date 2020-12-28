using OrderManagement.Demo.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderManagement.Demo
{
    public partial class _Default : Page
    {
        public IDependency Dependency { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Now you can use the property that was set for you.
            this.DependencyLabel.Text = this.Dependency.InstanceId.ToString();
        }
    }
}