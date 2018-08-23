using System.Windows.Input;
using MvvmHelpers;
using StoreLocator.Views;
using Xamarin.Forms;

namespace StoreLocator.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public StartViewModel(INavigation navigation) => _navigation = navigation;

        public ICommand ShowSimpleVersionCommand
        => new Command(async () => await _navigation.PushAsync(new SimpleFormPage()).ConfigureAwait(false));

        public ICommand ShowStoreLocatorCommand
        => new Command(async () => await _navigation.PushAsync(new StoreLocatorPage()).ConfigureAwait(false));


    }
}