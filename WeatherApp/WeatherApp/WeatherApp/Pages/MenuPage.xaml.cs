using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        MasterDetail RootPage { get => Application.Current.MainPage as MasterDetail; }
        public ObservableCollection<MasterListItems> ListViewItems { get; private set; }

        public MenuPage()
        {

            InitializeComponent();

            if(Device.RuntimePlatform == Device.Android)

                ListViewItems = new ObservableCollection<MasterListItems>()
                {

                    new MasterListItems(MenuItemType.Home, "Home", "ic_home_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.Temperature, "Temperature", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.MinMaxTemperature, "Min Temperature", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.MinMaxTemperatureHistogram, "Min/Max Temperature", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.Humidity, "Humidity", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.WindSpeed, "Wind Speed", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.SeaLevel, "Sea Level", "ic_label_outline_grey_24dp.xml"),
                    //new MasterListItems(MenuItemType.GroundLevel, "Ground Level", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.About, "About us", "ic_info_outline_grey_24dp.xml"),

                };

            else if(Device.RuntimePlatform == Device.iOS)
            {

                ListViewItems = new ObservableCollection<MasterListItems>()
                {

                    new MasterListItems(MenuItemType.Home, "Home", "home_ios.png"),
                    new MasterListItems(MenuItemType.Temperature, "Temperature", "etiqueta_ios.png"),
                    new MasterListItems(MenuItemType.MinMaxTemperature, "Min Temperature", "etiqueta_ios.png"),
                    new MasterListItems(MenuItemType.MinMaxTemperatureHistogram, "Min/Max Temperature", "etiqueta_ios.png"),
                    new MasterListItems(MenuItemType.Humidity, "Humidity", "etiqueta_ios.png"),
                    new MasterListItems(MenuItemType.WindSpeed, "Wind Speed", "etiqueta_ios.png"),
                    new MasterListItems(MenuItemType.SeaLevel, "Sea Level", "etiqueta_ios.png"),
                    //new MasterListItems(MenuItemType.GroundLevel, "Ground Level", "ic_label_outline_grey_24dp.xml"),
                    new MasterListItems(MenuItemType.About, "About us", "info_ios.png"),

                };

            }

            else {

                ListViewItems = new ObservableCollection<MasterListItems>()
                {

                    new MasterListItems(MenuItemType.Home, "Home", "Assets/ic_master/ic_home.png"),
                    new MasterListItems(MenuItemType.Temperature, "Temperature", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.MinMaxTemperature, "Min Temperature", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.MinMaxTemperatureHistogram, "Min/Max Temperature", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.Humidity, "Humidity", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.WindSpeed, "Wind Speed", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.SeaLevel, "Sea Level", "Assets/ic_master/ic_page.png"),
                    //new MasterListItems(MenuItemType.GroundLevel, "Ground Level", "Assets/ic_master/ic_page.png"),
                    new MasterListItems(MenuItemType.About, "About us", "Assets/ic_master/ic_info.png"),

                };

            }

            BindingContext = this;
            lvOptions.SelectedItem = ListViewItems.FirstOrDefault();
            lvOptions.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null || MasterDetail.statusPermissions.errorType == ErrorTypes.Connectivity) return;
                else
                {
                    try { if ((int)e.SelectedItem == -1) return; }
                    catch (InvalidCastException) { await ((this.Parent as MasterDetail).Detail as NavigationPage).PopAsync(); }
                }
                //else if (!MasterDetail.IsNavigable && ((MasterListItems)e.SelectedItem).Id == 0) return;
                if (!MasterDetail.IsNavigable && ((MasterListItems)e.SelectedItem).Id != MenuItemType.Home && ((MasterListItems)e.SelectedItem).Id != MenuItemType.About)
                {

                    lvOptions.SelectedItem = ListViewItems[0];
                    await DisplayAlert("Need location", "We need know your location for show data about weather in your city.", "OK");
                    return;
                }

                var id = (int)((MasterListItems)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);

            };

        }

        public void ClearSelectedItems()
        {

            lvOptions.SelectedItem = ListViewItems[0];

        }

        public void UnselectItem()
        {

            lvOptions.SelectedItem = -1;

        }

    }
}