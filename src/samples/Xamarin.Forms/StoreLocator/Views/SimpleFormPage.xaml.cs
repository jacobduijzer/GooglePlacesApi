using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StoreLocator.ViewModels;

namespace StoreLocator.Views
{
    public partial class SimpleFormPage : ContentPage
    {
        public SimpleFormPage()
        {
            InitializeComponent();

            BindingContext = new SimpleFormViewModel(Navigation);
        }
    }
}
