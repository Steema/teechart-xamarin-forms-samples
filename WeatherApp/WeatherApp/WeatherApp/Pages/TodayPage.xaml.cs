using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Pages
{
    public partial class TodayPage : ContentPage
    {
        string FILENAME = "Current";
        string FOLDER = "WEATHER";
        public ObservableCollection<MainListWeather> lstCWeather { get; private set; }

        public TodayPage()
        {

            InitializeComponent();
            IsBusy = true;
            LoadingFragment();
            GetPermissions();
            BindingContext = lstCWeather;

        }

        private ToolbarItem SearchItem()
        {

            ToolbarItem toolbarItem = new ToolbarItem();

            if (Device.RuntimePlatform == Device.UWP)
            {

                toolbarItem.Text = "Settings";
                toolbarItem.Icon = "Assets/ic_settings.png";

            }
            else
            {

                toolbarItem.Text = "Search";
                toolbarItem.Icon = "ic_explore_white_24dp.png";

            }
            toolbarItem.Clicked += ToolbarItem_Clicked;

            return toolbarItem;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            if(Device.RuntimePlatform == Device.UWP) (((this.Parent as NavigationPage).Parent as MasterDetail).Master as MenuPage).UnselectItem();
            this.Navigation.PushAsync(new WeatherPage());

        }

        private StackLayout layoutLoading;
        private void LoadingFragment()
        {

            ActivityIndicator loadingIndicator;

            if (IsBusy)
            {

                loadingIndicator = new ActivityIndicator();
                layoutLoading = new StackLayout();

                loadingIndicator.IsRunning = true;
                loadingIndicator.Color = Color.White;
                loadingIndicator.HorizontalOptions = LayoutOptions.Center;
                loadingIndicator.VerticalOptions = LayoutOptions.Center;

                layoutLoading.WidthRequest = 500;
                layoutLoading.HeightRequest = 100;
                layoutLoading.HorizontalOptions = LayoutOptions.Center;
                layoutLoading.VerticalOptions = LayoutOptions.Center;
                layoutLoading.Orientation = StackOrientation.Vertical;

                layoutLoading.Children.Add(loadingIndicator);
                (mainGrid.Children[0] as StackLayout).Children.Add(layoutLoading);

            }
            else
            {

                if(layoutLoading != null) (mainGrid.Children[0] as StackLayout).Children.Remove(layoutLoading);

            }

        }

        private async void ShowInfo()
        {
            try
            {
                GetLocalValues();
                await Task.Delay(500);
                if (App.Weather != null)
                {
                    if (TimerUpdate()||App.Weather.Name=="Earth")
                    {
                        await GetResourceValue();
                        if (App.Weather != null)
                        {
                            SaveResourceValues();
                        }
                    }
                    IsBusy = false;
                    LoadingFragment();
                    FillBackground();
                    FillInfo();
                    
                }
                else
                {
                    MainInitialization();
                }
                MasterDetail.IsNavigable = true;
            }
            catch (Exception error)
            {

                if (IsBusy) await DisplayAlert("Error", "We can't get your position, are you sure about you have this enabled?", "OK");

                Debug.WriteLine(error.Message);
            }
        }

        private void FillBackground()
        {

            if(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)

                switch (App.Weather.LstWeather[0].Visibility)
                {
                    case "Thunderstorm":
                        imgBackground.Source = "w_thunderstorm_background.png";
                        break;
                    case "Drizzle":
                        imgBackground.Source = "w_rain_background.png";
                        break;
                    case "Rain":
                        imgBackground.Source = "w_rain_background.png";
                        break;
                    case "Snow":
                        imgBackground.Source = "w_snow_background.png";
                        break;
                    case "Atmosphere":
                        imgBackground.Source = "w_mist_background.png";
                        break;
                    case "Clear":
                        imgBackground.Source = "w_sunny_background.png";
                        break;
                    case "Clouds":
                        imgBackground.Source = "w_cloudy_background.png";
                        break;
                }

            else

                switch (App.Weather.LstWeather[0].Visibility)
                {
                    case "Thunderstorm":
                        imgBackground.Source = "Assets/img_weather/w_thunderstorm_background.png";
                        break;
                    case "Drizzle":
                        imgBackground.Source = "Assets/img_weather/w_rain_background.png";
                        break;
                    case "Rain":
                        imgBackground.Source = "Assets/img_weather/w_rain_background.png";
                        break;
                    case "Snow":
                        imgBackground.Source = "Assets/img_weather/w_snow_background.png";
                        break;
                    case "Atmosphere":
                        imgBackground.Source = "Assets/img_weather/w_mist_background.png";
                        break;
                    case "Clear":
                        imgBackground.Source = "Assets/img_weather/w_sunny_background.png";
                        break;
                    case "Clouds":
                        imgBackground.Source = "Assets/img_weather/w_cloudy_background.png";
                        break;
                }

        }

        private async void MainInitialization()
        {
            await GetResourceValue();
            IsBusy = false;
            LoadingFragment();
            FillBackground();
            FillInfo();
            SaveResourceValues();
        }
        /// <summary>
        /// This function gets all the info from the App.Weather (attribute), gives it the format that we want, and shows it on the screen.         
        /// </summary>
        private  void FillInfo()
        {
            lstCWeather = new ObservableCollection<MainListWeather>();
            FillList();
            LstView.ItemsSource = lstCWeather;
            lblDate.Text = DateTime.Today.Date.Day.ToString() + " " + DateTimeExtensions.ToMonthName(DateTime.Today) + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            lblLocale.Text = App.Weather.Name + ", " + App.Weather.Country;
            lblWeather.Text = App.Weather.LstWeather[0].Visibility + ", " + App.Weather.LstWeather[0].Description;
            lblMaxTemp.Text = "Max: " + Math.Round(App.getDegScaleTemp(App.Weather.LstWeather[0].MaxTemperature), 0).ToString() + "º↑ • ";
            lblMinTemp.Text = "Min: " + Math.Round(App.getDegScaleTemp(App.Weather.LstWeather[0].MinTemperature), 0).ToString() + "º↓";
            lblTemp.Text = Math.Round(App.getDegScaleTemp(App.Weather.LstWeather[0].Temperature), 0) + (App.DegTempScale == TempScale.celsius ? " ºC" : " ºF");
            if(ToolbarItems.Count == 0) this.ToolbarItems.Add(SearchItem());

        }

        /// <summary>
        /// Get all the data from App.Weather.List, to fill the layout's list with the forecast values. 
        /// </summary>
        private void FillList()
        {
            DateTime date = App.Weather.LstWeather[0].Date;
            MainListWeather cWeather;
            foreach (var item in App.Weather.LstWeather)
            {
                if (TimerUpdate(date, item.Date))
                {
                    date = item.Date;
                     cWeather = new MainListWeather(
                        item.Visibility + ", " + item.Description,
                        item.Icon,
                        item.Date);
                        
                    lstCWeather.Add(cWeather);
                }
            }
        }

        private async Task GetResourceValue()
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                App.Weather = await GetWeatherCore.GetCoordinate(App.Latitude.ToString("0.0000", nfi), App.Longitude.ToString("0.0000", nfi));
            }
            catch (Exception error)
            {
                Debug.WriteLine("Something was wrong with 'GetResourceValue'" + error.Message);
            }
        }

        private bool TimerUpdate(DateTime date, DateTime itemDate)
        {
            bool update = false;
            if (itemDate.Day - date.Day >= 1 && itemDate.Hour>=8) update = true;
            return update;
        }

        protected override void OnAppearing()
        {

            if (isDenied) this.DisplayAlert("Need location", "We need location for show data", "OK");

            if (App.Weather != null)
            {
                App.Update = false;
                lstCWeather = new ObservableCollection<MainListWeather>();
                FillInfo();
                FillBackground();
                this.BackgroundColor = Color.FromHex("#A8C8FF");
            }
        }
        private bool TimerUpdate()
        {
            bool update = false;
            string app = App.Weather.Now;
            //if ((DateTime.Now - Convert.ToDateTime(App.Weather.Now)).Hours >= 1) update = true;
            if ((DateTime.Now - DateTime.ParseExact(App.Weather.Now, "dd-MM-yyyy HH:mm:ss", null)).Hours >= 1) update = true;
            return update;
        }

        private async void GetLocalValues()
        {
            App.Weather = null;
            App.Weather = await GetWeatherCore.GetStoredWeather(FILENAME, FOLDER);
        }

        /// <summary>
        /// Save the info into the device using a DataService.SerializeWeather function.
        /// </summary>
        private void SaveResourceValues()
        {
            DataService.SerializeWeather(FOLDER, App.Weather, FILENAME);
        }

        private void GetPermissions()
        {

            switch(Device.RuntimePlatform)
            {

                case Device.Android:
                    GetPermissionsDroid();
                    break;

                case Device.iOS:
                    GetPermissionsIos();
                    break;

                case Device.UWP:
                    GetPermissionsUWP();
                    break;

            }            

        }

        private async void GetPermissionsIos()
        {
            Xamarin.Essentials.Location location = await InternalGetLocation();
            if (location != null)
            {
                if (requestLocationItem != null)
                {
                    ToolbarItems.Remove(requestLocationItem);
                    (mainGrid.Children[0] as StackLayout).Children.Remove(lblLocError);
                    IsBusy = true;
                    LoadingFragment();
            
                }
                App.Latitude = location.Latitude;
                App.Longitude = location.Longitude;
                ShowInfo();
        
            }
            else ReqLocationToolbarItem();
    
        }

        private bool isDenied = false;
        private async Task GetPermissionsDroid()
        {

            Plugin.Permissions.Abstractions.PermissionStatus status = PermissionStatus.Unknown;
            bool beforeNotLet = false;

            try
            {
                status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {

                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        beforeNotLet = true;
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location)) status = results[Permission.Location];

                }

                if (status == PermissionStatus.Granted)
                {

                    if (beforeNotLet)
                    {

                        ToolbarItems.Remove(requestLocationItem);
                        (mainGrid.Children[0] as StackLayout).Children.Remove(lblLocError);
                        IsBusy = true;
                        LoadingFragment();

                    }

                    Xamarin.Essentials.Location results = await InternalGetLocation();

                    App.Latitude = results.Latitude;
                    App.Longitude = results.Longitude;
                    ShowInfo();

                }
                else if(status == PermissionStatus.Denied)
                {

                    ReqLocationToolbarItem();

                }
                else if (status == PermissionStatus.Unknown)
                {
                    
                    ReqLocationToolbarItem();

                }
                else
                {
                    await DisplayAlert("Error", "Error not expected", "OK");                    
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Error: " + ex, "55", "55");

            }

        }

        private async void GetPermissionsUWP()
        {

            Xamarin.Essentials.Location location = await InternalGetLocation();
            if (location != null)
            {
                if (requestLocationItem != null)
                {
                    ToolbarItems.Remove(requestLocationItem);
                    (mainGrid.Children[0] as StackLayout).Children.Remove(lblLocError);
                    IsBusy = true;
                    LoadingFragment();
                }
                App.Latitude = location.Latitude;
                App.Longitude = location.Longitude;
                ShowInfo();
                
            }
            else ReqLocationToolbarItem();

            #region code
            /*
            await Permissions.RequireAsync(PermissionType.LocationWhenInUse);

            var geolocator = new Geolocator
            {
                DesiredAccuracyInMeters = request.PlatformDesiredAccuracy
            };

            CheckStatus(geolocator.LocationStatus);

            cancellationToken = Utils.TimeoutToken(cancellationToken, request.Timeout);

            var location = await geolocator.GetGeopositionAsync().AsTask(cancellationToken);

            return location?.Coordinate?.ToLocation();

            void CheckStatus(PositionStatus status)
            {
                switch (status)
                {
                    case PositionStatus.Disabled:
                    case PositionStatus.NotAvailable:
                        throw new FeatureNotEnabledException("Location services are not enabled on device.");
                }
            }
            */
            #endregion

        }


        ToolbarItem requestLocationItem;
        Label lblLocError;
        private void ReqLocationToolbarItem()
        {

            if (ToolbarItems.Contains(requestLocationItem)) return;

            string iconSource = "";

            if (Device.RuntimePlatform == Device.UWP) iconSource += "Assets/";
            iconSource += "ic_location_off_white_24dp.png";

            requestLocationItem = new ToolbarItem()
            {

                Icon = iconSource,
                Text = "Location",

            };

            lblLocError = new Label();
            IsBusy = false;
            LoadingFragment();

            lblLocError.Text = "Active location for show data";
            lblLocError.FontSize = 20;
            lblLocError.HorizontalOptions = LayoutOptions.FillAndExpand;
            lblLocError.VerticalOptions = LayoutOptions.FillAndExpand;
            lblLocError.HorizontalTextAlignment = TextAlignment.Center;
            lblLocError.VerticalTextAlignment = TextAlignment.Center;

            (mainGrid.Children[0] as StackLayout).Children.Add(lblLocError);

            requestLocationItem.Clicked += RequestLocationItem_Clicked;
            ToolbarItems.Add(requestLocationItem);

        }

        private void RequestLocationItem_Clicked(object sender, EventArgs e)
        {
            GetPermissions();
        }

        private async Task<Xamarin.Essentials.Location> InternalGetLocation()
        {

            MasterDetail.statusPermissions = new Utils.StatusPermissions();

            if (MasterDetail.statusPermissions.CheckConnection())
            {

                Xamarin.Essentials.Location results = null;

                try
                {

                    Xamarin.Essentials.GeolocationRequest geoRequest = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Medium);
                    results = await Xamarin.Essentials.Geolocation.GetLocationAsync(geoRequest);

                }
                catch (Exception ex)
                {

                    await this.DisplayAlert("Need location", "Active location sensor", "OK");

                }

                return results;

            }
            else return null; ;

        }

    }

    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }

}