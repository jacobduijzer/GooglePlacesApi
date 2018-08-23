
using Xamarin.Forms;
using StoreLocator.ViewModels;

namespace StoreLocator.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            BindingContext = new StartViewModel(Navigation);
        }
    }
}
