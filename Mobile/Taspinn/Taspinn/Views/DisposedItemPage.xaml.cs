using System;
using System.ComponentModel;
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

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(ItemDetailViewModel.DataStoreType.Disposed, item)));

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
            var item = (Item)mi.CommandParameter;
            var delete = await DisplayAlert($"Delete {item.Name}", "This action cannot be undone.", "Delete", "Cancel");

            if (delete)
            {
                await viewModel.DeleteItemAsync(item.Id);
            }
        }

        public async void OnMoveToShopList(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var item = (Item)mi.CommandParameter;

            var move = await DisplayAlert($"Move {item.Name}", "This action cannot be undone.", "Move", "Cancel");

            if (move)
            {
                await viewModel.MoveItemToShoppingListAsync(item.Id);
            }
        }
    }
}
