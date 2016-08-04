using Android.App;
using Client.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Login), typeof(Client.Droid.LoginPageRenderer))]
namespace Client.Droid
{
    public class LoginPageRenderer: PageRenderer
    {

        public LoginPageRenderer()
        {
            var activity = this.Context as Activity;
            var auth = new OAuth2Authenticator(
                clientId: "1251742814858891",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());
                    var id = obj["id"].ToString().Replace("\"", ""); // Id has extraneous quotation marks
                    var name = obj["name"].ToString().Replace("\"", "");
                    await App.NavigateToProfile(string.Format("Hello {0}", name));
                }
                else
                {
                    await App.NavigateToProfile("Cancelled");
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }
    }
}
