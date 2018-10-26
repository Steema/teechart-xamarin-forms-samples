using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using XamControls.Models;
using XamControls.Services;
using XamControls.ViewModels;
using XamControls.Views;

namespace XamControls.CustomRenders
{
    public class CustomSearchPage : ContentPage
    {

        public CustomSearchPage() { }

        public static readonly BindableProperty _Elevation =
            BindableProperty.Create("Elevation", typeof(int), typeof(CustomSearchPage), 8);

        public static readonly BindableProperty _Name =
            BindableProperty.Create("Text", typeof(string), typeof(CustomSearchPage), null);

        public static readonly BindableProperty _ListView =
            BindableProperty.Create("ListView", typeof(Xamarin.Forms.ListView), typeof(CustomSearchPage), null);

        public static readonly BindableProperty _ListItems =
            BindableProperty.Create("ListItems", typeof(List<ItemsListView>), typeof(CustomSearchPage), null);

        public static readonly BindableProperty _ChangePage =
            BindableProperty.Create("ChangePage", typeof(int), typeof(CustomSearchPage), 0);
        

        /// <summary>
        /// Change the hint text in searchView
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(_Name); }
            set { SetValue(_Name, value); }
        }

        public Xamarin.Forms.ListView ListView
        {
            get { return (Xamarin.Forms.ListView)GetValue(_ListView); }
            set { SetValue(_ListView, value); }
        }

        public List<ItemsListView> ListItems
        {
            get { return (List<ItemsListView>)GetValue(_ListItems); }
            set { SetValue(_ListItems, value); }
        }

        public int ChangePage
        {

            get { return (int)GetValue(_ChangePage); }
            set { SetValue(_ChangePage, value); }

        }

        public int Elevation
        {

            get { return (int)GetValue(_Elevation); }
            set { SetValue(_Elevation, value); }

        }

    }
}
