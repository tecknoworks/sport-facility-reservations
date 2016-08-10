using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Client.ViewModels;
using Client.Services;

namespace Client.Views
{
    public class EditMyAccountPage :TabbedPage
    {
       public RegisterPage registerPage = new RegisterPage();
        public EditMyAccountPage()
        {
            Title = "Edit My Account";
            Children.Add(registerPage);
        }        
    }
}
