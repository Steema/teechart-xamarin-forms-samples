using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    static class ConvertTemp
    {

    public static double ConvertCelsiusToFahrenheit(double c)
    {
        return ((9.0 / 5.0) * c) + 32;
    }

    public static double ConvertFahrenheitToCelsius(double f)
    {
        return (5.0 / 9.0) * (f - 32);
    }

    }

    public class WeatherData
    {

        private double temperature;
        private double maxTemperature;
        private double minTemperature;
        private double windSpeed;
        private double windDegree;
        private double pressure;
        private double humidity;
        private double seaLevel;
        private double groundLevel;
        private string visibility;
        private string description;
        private string icon;
        private DateTime date;

        public WeatherData(double temperature, double maxTemperature, double minTemperature, double windSpeed, double windDegree,
                    double pressure, double humidity, double seaLevel, double groundLevel, string visibility, string description, string icon, DateTime date)
        {

            this.temperature = temperature;
            this.maxTemperature = maxTemperature;
            this.minTemperature = minTemperature;
            this.windSpeed = windSpeed;
            this.windDegree = windDegree;
            this.pressure = pressure;
            this.humidity = humidity;
            this.seaLevel = seaLevel;
            this.groundLevel = groundLevel;
            this.visibility = visibility;
            this.description = description;
            this.icon = icon;
            this.date = date;

        }

        #region PROPERTIES

        public double Temperature
        {
          get
          {
            return temperature;
          }

          set
          {
            temperature = value;
          }
        }

        public double MaxTemperature
        {
          get
          {
            return maxTemperature;
          }

          set
          {
            maxTemperature = value;
          }
        }

        public double MinTemperature
        {
          get
          {
            return minTemperature;
          }

          set
          {
            minTemperature = value;
          }
        }

        public double WindSpeed
        {
          get
          {
            return windSpeed;
          }

          set
          {
            windSpeed = value;
          }
        }

        public double WindDegree
        {
          get
          {
            return windDegree;
          }

          set
          {
            windDegree = value;
          }
        }

        public double Pressure
        {
          get
          {
            return pressure;
          }

          set
          {
            pressure = value;
          }
        }

        public double Humidity
        {
          get
          {
            return humidity;
          }

          set
          {
            humidity = value;
          }
        }

        public double SeaLevel
        {
          get
          {
            return seaLevel;
          }

          set
          {
            seaLevel = value;
          }
        }

        public double GroundLevel
        {
          get
          {
            return groundLevel;
          }

          set
          {
            groundLevel = value;
          }
        }

        public string Visibility
        {
          get
          {
            return visibility;
          }

          set
          {
            visibility = value;
          }
        }

        public string Description
        {
          get
          {
            return description;
          }

          set
          {
            description = value;
          }
        }

        public string Icon
        {
          get
          {
            return icon;
          }

          set
          {
            icon = value;
          }
        }

        public DateTime Date
        {
          get
          {
            return date;
          }

          set
          {
            date = value;
          }
        }
        #endregion

    }
    public class ActualWeather
    {

        private string now;
        private string name;
        private string country;
        private double latitude;
        private double longitude;
        private List<WeatherData> lstWeather;

        public ActualWeather() { }

        public ActualWeather(string now, string name, string country, double latitude, double longitude, List<WeatherData> lstWeather)
        {

          this.now = now;
          this.name = name;
          this.country = country;
          this.latitude = latitude;
          this.longitude = longitude;
          this.lstWeather = lstWeather;

        }

        #region PROPERTIES

        public string Now
        {
          get
          {
            return now;
          }

          set
          {
            now = value;
          }
        }
        public string Name
        {
          get
          {
            return name;
          }

          set
          {
            name = value;
          }
        }
        public string Country
        {
          get
          {
            return country;
          }

          set
          {
            country = value;
          }
        }
        public double Latitude
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
        public double Longitude
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
        public List<WeatherData> LstWeather
        {
          get
          {
            return lstWeather;
          }

          set
          {
            lstWeather = value;
          }
        }

        #endregion


    }

    public class MainListWeather
    {

        private string weather;
        private string date;
        private string cIcon;

        public MainListWeather(string weather, string Icon, DateTime date)
        {

            Weather = weather;
            Date = date.DayOfWeek + " , " + date.Day + " " + date.ToString("MMM");
            cIcon = Icon;
            UpdateIcon();

        }

        private void UpdateIcon()
        {

            string path = "";

            if(Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP) path += "Assets/img_cardview/";

            switch (weather)
            {

                case "Clouds, scattered clouds":
                    path += "cloud_cardview.jpg";
                    break;

                case "Clear, clear sky":
                    path += "sol_cardview.jpg";
                    break;

                case "Clouds, few clouds":
                    path += "cloud_cardview.jpg";
                    break;

                case "Rain, moderate rain":
                    path += "rain_cardview.jpg";
                    break;

                case "Rain, light rain":
                    path += "lightrain_cardview.jpg";
                    break;

                case "Clouds, overcast clouds":
                    path += "cloud_cardview.jpg";
                    break;

                case "Snow, light snow":
                case "Snow, snow":
                    path += "snow_cardview.jpg";
                    break;

                case "Clouds, broken clouds":
                    path += "cloudsbroken_cardview.jpg";
                    break;

            }

            cIcon = path;

        }

        #region PROPERTIES

        public string Weather
        {
          get
          {
            return weather;
          }

          set
          {
            weather = value;
          }
        }
        public string Date
        {
          get
          {
            return date;
          }

          set
          {
            date = value;
          }
        }
        public string CIcon
        {
          get
          {
            return cIcon;
          }

          set
          {
            cIcon = value;
          }
        }

        #endregion

    }
}