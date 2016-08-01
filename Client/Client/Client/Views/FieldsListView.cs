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
    public class FieldsListView : ContentPage
    {
        public FieldsListViewModel _viewModel;
        public FieldsListView()
        {
            Title = "Fields";
            Init();
        }
        public async Task Init()
        {
            _viewModel = App.Container.Resolve<FieldsListViewModel>(); 
            BindingContext = _viewModel;

            

            ListView listView = new ListView
            {
                ItemsSource = _viewModel.Fields,
                ItemTemplate = new DataTemplate(() =>
                {
                    var name = new Label();
                    name.SetBinding(Label.TextProperty, "Name");
                    var location = new Label();
                    location.SetBinding(Label.TextProperty, "Location");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                name,
                                location
                                }
                        }
                    };
                }
                )
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "Fields");
            await _viewModel.LoadFieldsAsync(); // TODO: checkl the suitable location for this call
            Content = listView;
        }
    }
}
