using Client.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Client.Services.Interfaces;
using Client.Services;
using Client;

namespace Client
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Xamarin.Forms.Page CreateMainPage()
        {
            var page = Container.Resolve<LoginPage>();
            return new Xamarin.Forms.NavigationPage(page);
        }

        protected override void RegisterTypes()
        {
            Client.App.Container = Container;
            Container.RegisterType<IServiceClient, ServiceClient>();
        }
    }
}