using Client.iOS;
using Client.Models;
using Client.ViewModels;
using Client.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Microsoft.Practices.Unity;

[assembly: ExportRenderer(typeof(Login), typeof(LoginPageRenderer))]
namespace Client.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        public static string id;
        LoginViewModel vm;

        public override void ViewDidAppear(bool animated)
        {
            vm = App.Container.Resolve<LoginViewModel>();
            base.ViewDidAppear(animated);

            // I've used the values from your original post
            var auth = new OAuth2Authenticator(
                clientId: "1251742814858891",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                DismissViewController(true, null);

                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=id,first_name,email"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());
                    id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["first_name"];
                    var username = obj["email"].ToString();
                    User user = new User(id, username);
                    vm.GetUser(user);
                    //App.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                    await App.NavigateToProfile(string.Format("Hello {0}", name));
                }
                else
                {
                    await App.NavigateOnCancel();
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
