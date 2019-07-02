using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.Models;

namespace XamControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UWPHomePage : ContentPage
    {

        public UWPHomePage()
        {
            InitializeComponent();
            InitializePage();
            
        }

        private void InitializePage()
        {
            listView.ItemsSource = GetData();
        }

        private List<ItemsListView> GetData()
        {
            List<ItemsListView> itemsListViews = new List<ItemsListView>();
            itemsListViews.Add(
                new ItemsListView(0, "Line", "Info", null, null)
            );
            return itemsListViews;
        }
    }
}