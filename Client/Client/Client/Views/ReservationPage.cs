using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace Client.Views
{
    class ReservationPage : ContentPage
    {
        Button acceptBtn;
        public ReservationPageViewModel _viewModel;
        public ReservationPage()
        {
            Title = "Reservation Page";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<ReservationPageViewModel>();
            BindingContext = _viewModel;
            ListView listView = new ListView
            {
                ItemsSource = _viewModel.ReservedFields,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameField = new Label();
                    nameField.SetBinding(Label.TextProperty, "Field");

                    var hour = new Label();
                    hour.SetBinding(Label.TextProperty, "StartHour");

                    acceptBtn = new Button
                    {
                        Text = "Accept",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Font = Font.SystemFontOfSize(NamedSize.Micro)
                    };
                    //  acceptBtn.SetBinding(Button.CommandProperty, "BlaCommand");
                    acceptBtn.Clicked += Button_Clicked;

                    var rejectBtn = new Button
                    {
                        Text = "Reject",
                        BackgroundColor = Color.Red,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Font = Font.SystemFontOfSize(NamedSize.Micro)
                    };

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                nameField,
                                hour,
                                acceptBtn,
                                rejectBtn
                                }
                        }
                    };
                }
                )
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "ReservedFields");
            await _viewModel.LoadReservedFieldsAsync();
            Content = listView;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.OnBla();
        }
    }
}
