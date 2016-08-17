using Client.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client
{
    public class App : Application
    {
        public static IUnityContainer Container { get; internal set; }

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }

        public static async Task NavigateOnCancel()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public static async Task NavigateToProfile(string message)
        {
            await App.Current.MainPage.Navigation.PushAsync(new HomePage(message));
        }
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
