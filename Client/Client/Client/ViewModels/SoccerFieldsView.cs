using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class SoccerFieldsView: ContentPage
    {
        public SoccerFieldsView()
        {
            Title = "Soccer Field";
            Init();
        }

        public async Task Init()
        {
           

            var label = new Label
            {
                Text = "Hello"
            };
            Content = new StackLayout
            {
                Children =
                {
                    label
                }
            };
        }
    }
}
