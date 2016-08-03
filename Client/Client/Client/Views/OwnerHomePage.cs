﻿using System;
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
    class OwnerHomePage : TabbedPage
    {
        public OwnerHomePage()
        {
            Children.Add(new ReservationPage());
            Children.Add(new HomePage(Settings.FirstName));
        }

    }
}
