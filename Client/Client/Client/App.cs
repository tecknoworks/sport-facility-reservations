using Client.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Client
{
    public class App : Application
    {
        public static IUnityContainer Container { get; internal set; }

        public App()
        {
            Bootstrapper bs = new Bootstrapper();
            bs.Run(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
