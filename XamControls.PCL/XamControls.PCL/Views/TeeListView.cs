using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace XamControls.PCL.Views
{
    public class TeeListView<TView> : ContentView where TView : BindableObject
    {

        public readonly static BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<TView>), typeof(TeeListView<TView>), new List<TView>());
        ContentView _dataTemplate;

        public TeeListView()
        {
            
        }

        public IEnumerable<TView> ItemsSource
        {
            get => (IEnumerable<TView>)GetValue(ItemsSourceProperty);
            set
            {
                SetValue(ItemsSourceProperty, value);
                OnPropertyChanged();
                BindingContext = value;
                SetDataTemplate();
            }
        }
        public ContentView DataTemplate
        {
            get => _dataTemplate;
            set
            {
                _dataTemplate = value;
                OnPropertyChanged();
            }
        }

        private void SetDataTemplate()
        {
            StackLayout dataTemplateLayout = new StackLayout();
            dataTemplateLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            dataTemplateLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            foreach (var item in ItemsSource) {
                dataTemplateLayout.Children.Add(DataTemplate);
            }

            this.Content = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = dataTemplateLayout,
            }; 
        }

    }
}
