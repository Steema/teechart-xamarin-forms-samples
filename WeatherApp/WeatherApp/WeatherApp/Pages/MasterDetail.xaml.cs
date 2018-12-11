using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.Pages;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MasterDetail : MasterDetailPage
    {

        public static bool IsNavigable;
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public static Utils.StatusPermissions statusPermissions;
        public static readonly int[] PAGES_NOT_RESET_AXIS = { 0, 1, 6, 8 }; // 9 con GroundLevel

        public MasterDetail()
        {

            InitializeComponent();
            statusPermissions = new Utils.StatusPermissions();
            MasterBehavior = MasterBehavior.Popover;

            if (!statusPermissions.CheckConnection()) NavigateFromMenu(0);
            else { NavigateFromMenu(1); }

            this.IsPresented = false;
            IsNavigable = false;

        }

        public async Task NavigateFromMenu(int id)
        {

            if (WeatherPage.CityChanged) {

                for(int i = 0; i < 10; i++)
                {

                    if(MenuPages.ContainsKey(i))
                    {

                        Page page = MenuPages[i].RootPage;
                        if (page is Visualization) MenuPages.Remove(i);

                    }

                }
                WeatherPage.CityChanged = false;

            }

            if (!MenuPages.ContainsKey(id))
            {

                switch (id)
                {

                    case (int)MenuItemType.Error:
                        MenuPages.Add(id, new NavigationPage(new ErrorPage(statusPermissions.errorType)));
                        break;
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new TodayPage()));
                        break;
                    case (int)MenuItemType.Temperature:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.Temperature, App.Weather)));
                        break;
                    case (int)MenuItemType.MinMaxTemperature:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.MinMaxTemperature, App.Weather)));
                        break;
                    case (int)MenuItemType.MinMaxTemperatureHistogram:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.MinMaxTemperatureHistogram, App.Weather)));
                        break;
                    case (int)MenuItemType.Humidity:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.Humidity, App.Weather)));
                        break;
                    case (int)MenuItemType.WindSpeed:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.WindSpeed, App.Weather)));
                        break;
                    case (int)MenuItemType.SeaLevel:
                        MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.SeaLevel, App.Weather)));
                        break;
                    //case (int)MenuItemType.GroundLevel:
                        //MenuPages.Add(id, new NavigationPage(new Visualization(MenuItemType.GroundLevel, App.Weather)));
                        //break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;

                }

            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                
                if (!PAGES_NOT_RESET_AXIS.Contains(id)) (MenuPages[id].RootPage as Visualization).chartView.Chart.Axes.Reset();
                if(id == (int)MenuItemType.WindSpeed) (MenuPages[id].RootPage as Visualization).RefreshCircularGauge();

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }

        }

    }
}
