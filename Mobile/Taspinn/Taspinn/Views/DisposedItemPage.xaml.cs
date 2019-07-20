using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Taspinn.Models;
using Taspinn.ViewModels;
using Xamarin.Forms;

namespace Taspinn.Views
{
    [DesignTimeVisible(false)]
    public partial class DisposedItemPage : ContentPage
    {
        DisposedItemsViewModel viewModel;

        public DisposedItemPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DisposedItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            DisposedItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var delete = await DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "Delete", "Cancel");

            //if (delete)
            //{
            //    viewModel.
            //}
        }
    }
}
