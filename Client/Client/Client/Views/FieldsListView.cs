using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Practices.Unity;
using Android.App;
using Client.Models;

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

            await _viewModel.LoadFieldsAsync(); // TODO: checkl the suitable location for this call

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0, 8, 0, 8)
            };

            ListView listView = new ListView();
            listView.ItemsSource = _viewModel.Fields;
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "Location");
            listView.ItemTemplate = cell;

            listView.ItemTapped += (sender, args) => {
                if (listView.SelectedItem == null)
                    return;
                this.Navigation.PushAsync(new NewsDetailsView(listView.SelectedItem as Field));
                listView.SelectedItem = null;
            };

            listView.SetBinding(ListView.ItemsSourceProperty, "Fields");
            stack.Children.Add(listView);
            Content = stack;
        }


    }
}
