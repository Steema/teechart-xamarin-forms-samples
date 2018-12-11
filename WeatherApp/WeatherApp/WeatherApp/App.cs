
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    public enum TempScale { celsius, fahrenheit }

    public class App : Application
    {
        private static double longitude = 0;
        private static double latitude = 0;
        private static bool update = false;
        private static ActualWeather weather;

        private static TempScale _tempScale = TempScale.celsius;

        public static TempScale DegTempScale
        {
            get
            {
                return _tempScale;
            }

            set
            {
                _tempScale = value;
            }
        }

        public static double getDegScaleTemp(double celsiusTemp)
        {
            return App.DegTempScale == TempScale.fahrenheit ? Math.Round(ConvertTemp.ConvertCelsiusToFahrenheit(celsiusTemp), 2) : celsiusTemp;
        }

        public static ActualWeather Weather
        {
            get
            {
                return weather;
            }

            set
            {
                weather = value;
                Update = true;
            }
        }

        public static bool Update
        {
            get
            {
                return update;
            }

            set
            {
                update = value;
            }
        }

        public static double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public static double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public App()
        {

            MainPage = new MasterDetail();

        }

        protected override void OnStart()
        {
            // await Task.Run(() => GetCoordinatesValues());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {



        }

    }
}
