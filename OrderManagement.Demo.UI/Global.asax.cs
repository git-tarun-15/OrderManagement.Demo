using Autofac;
using Autofac.Integration.Web;
using OrderManagement.Demo.DataAccess;
using OrderManagement.Demo.Interfaces;
using OrderManagement.Demo.Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace OrderManagement.Demo.UI
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();              
            builder.RegisterType<UserAccountManager>().As<IUserAccountManager>().InstancePerRequest();
            builder.RegisterType<OrderManager>().As<IOrderManager>().InstancePerRequest();
            builder.RegisterType<InventoryRepository>().As<IInventoryRepository>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString).InstancePerRequest();
            builder.RegisterType<UserAccountRepository>().As<IUserAccountRepository>()
               .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString).InstancePerRequest();
            builder.RegisterType<CreditCardManager>().As<ICreditCardManager>()
               .WithParameter("domainURL", ConfigurationManager.AppSettings.Get("DomainURL")).InstancePerRequest();
            builder.RegisterType<EmailManager>().As<IEmailManager>();  

            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}