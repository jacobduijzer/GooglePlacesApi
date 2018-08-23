using System.Collections;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using System;

namespace StoreLocator.Controls
{
    public class RepeaterView : StackLayout
    {
        public static readonly BindableProperty ItemTemplateProperty = 
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(RepeaterView));

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(object), typeof(RepeaterView), Enumerable.Empty<object>(), BindingMode.OneWay, null, ItemsChanged);

        public static BindableProperty ItemClickCommandProperty =
            BindableProperty.Create("ItemClickCommand", typeof(ICommand), typeof(RepeaterView), null, BindingMode.TwoWay, null, ItemClickCommandChanged);
        
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;

            var repeater = (RepeaterView)bindable;
            repeater.Children.Clear();

            var dataTemplate = repeater.ItemTemplate;

            foreach (object viewModel in (IEnumerable)newValue)
            {
                var content = dataTemplate.CreateContent();
                if (!(content is View) && !(content is ViewCell))
                    return;

                var view = (content is View) ? content as View : ((ViewCell)content).View;

                view.BindingContext = viewModel;
                var command = repeater.GetValue(ItemClickCommandProperty);
                view.GestureRecognizers.Add(new TapGestureRecognizer 
                { 
                    Command = (ICommand)view.GetValue(ItemClickCommandProperty),
                    CommandParameter = viewModel
                });
                repeater.Children.Add(view);
            }
        }

        private static void ItemClickCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var itemsView = (StackLayout)bindable;
            if (newValue == oldValue)
                return;

            itemsView.SetValue(ItemClickCommandProperty, newValue);
        }
    }
}