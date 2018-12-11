using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPage : ContentPage
    {

        MasterDetail RootPage { get => Application.Current.MainPage as MasterDetail; }

        public ErrorPage(ErrorTypes errorType)
        {
            InitializeComponent();

            switch(errorType)
            {

                case ErrorTypes.Connectivity:
                    lblError.Text = "We can't connect for get data";
                    if (Device.RuntimePlatform == Device.UWP) imageError.Source = "Assets/ic_warning_white_48dp.png";
                    Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
                    break;

            }

        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {

            if (e.IsConnected)
            {

                RootPage.Detail = new NavigationPage(new TodayPage());
                (RootPage.Master as MenuPage).ClearSelectedItems();
                MasterDetail.statusPermissions.errorType = ErrorTypes.None;
                Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged -= Current_ConnectivityChanged;

            }

        }
    }

    public enum ErrorTypes
    {

        None,
        Connectivity,
        LocationNoEnabled,
        LocationNotFound

    }

}