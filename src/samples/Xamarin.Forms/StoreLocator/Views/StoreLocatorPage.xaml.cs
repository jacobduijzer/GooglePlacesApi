using System;
using System.Collections.Generic;
using StoreLocator.ViewModels;
using Xamarin.Forms;

namespace StoreLocator.Views
{
    public partial class StoreLocatorPage : ContentPage
    {
        public StoreLocatorPage()
        {
            InitializeComponent();

            BindingContext = new StoreLocatorViewModel(Navigation);
        }
    }
}
