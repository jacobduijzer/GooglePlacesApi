
using StoreLocator.ViewModels;
using Xamarin.Forms;

namespace StoreLocator.Views
{
    public partial class SimpleFormDetailPage : ContentPage
    {
        public SimpleFormDetailPage(string placeId, string sessionToken)
        {
            InitializeComponent();

            BindingContext = new SimpleFormDetailViewModel(placeId, sessionToken);
        }
    }
}
