﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Taspinn.Models;
using Taspinn.ViewModels;

namespace Taspinn.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        //public ItemDetailPage()
        //{
        //    InitializeComponent();

        //    var item = new Item
        //    {
        //        Name = "Item 1",
        //        Description = "This is an item description."
        //    };

        //    viewModel = new ItemDetailViewModel(,item);
        //    BindingContext = viewModel;
        //}

        async void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;

            await viewModel.UpdateCountAsync((int)value);
        }
    }
}