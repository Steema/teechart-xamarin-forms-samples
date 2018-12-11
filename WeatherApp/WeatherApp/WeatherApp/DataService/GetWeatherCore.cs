
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class GetWeatherCore
    {
        public string FileName { get; set; }

        public static async Task<ActualWeather> GetCoordinate(string latitude, string longitude)
        {
            string key = "c8a760683089adad086eef5d6a85e5a3";
            string queryString = String.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&APPID={2}", latitude, longitude, key);
            dynamic results = await DataService.getDataFromService(queryString);
            
            if (results.cod != 502)
            {
                try
                {

                    List<WeatherData> lstWeather = new List<WeatherData>();
                    foreach (var item in results.list)
                    {
                        WeatherData weather = new WeatherData(
                            (double)item.main.temp,
                            (double)item.main.temp_max,
                            (double)item.main.temp_min,
                            (double)item.wind.speed,
                            (double)item.wind.deg,
                            (double)item.main.pressure,
                            (double)item.main.humidity,
                            (double)item.main.sea_level,
                            (double)item.main.grnd_level,
                            (string)item.weather[0].main,
                            (string)item.weather[0].description,
                            (string)"http://openweathermap.org/img/w/" + item.weather[0].icon + ".png",
                            (DateTime)item.dt_txt);
                        lstWeather.Add(weather);
                    }
                    
                    ActualWeather actuWeather = new ActualWeather(
                        (string)DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        (string)results.city.name,
                        (string)results.city.country,
                        (double)results.city.coord.lat,
                        (double)results.city.coord.lon,
                        lstWeather
                    ); 
                    return actuWeather;
                }
                catch
                {
                    return null;
                }
            }
            else return null;
        }
        /// <summary>
        /// Get the weather from WeatherOpenMap Source
        /// </summary>
        /// <param name="city">City where we want to know its weather</param>
        /// <returns>An object from ActualWeather class, whith the actual weather and the forecast of 5 days</returns>
        public static async Task<ActualWeather> GetActualWeather(string city)
        {
            string key = "c8a760683089adad086eef5d6a85e5a3";
            string queryString = String.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&APPID={1}", city, key);
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            if (results.cod != 502)
            {
                try
                {
                    List<WeatherData> lstWeather = new List<WeatherData>();
                    foreach (var item in results.list)
                    {
                        WeatherData weather = new WeatherData(
                            (double)item.main.temp,
                            (double)item.main.temp_max,
                            (double)item.main.temp_min,
                            (double)item.wind.speed,
                            (double)item.wind.deg,
                            (double)item.main.pressure,
                            (double)item.main.humidity,
                            (double)item.main.sea_level,
                            (double)item.main.grnd_level,
                            (string)item.weather[0].main,
                            (string)item.weather[0].description,
                            (string)"http://openweathermap.org/img/w/" + item.weather[0].icon + ".png",
                            (DateTime)item.dt_txt);
                        lstWeather.Add(weather);
                    }
                    ActualWeather actuWeather = new ActualWeather(
                        (string)DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                        (string)results.city.name,
                        (string)results.city.country,
                        (double)results.city.coord.lat,
                        (double)results.city.coord.lon,
                        lstWeather
                        );
                    return actuWeather;
                }
                catch
                {
                    return null;
                }
            }
            else return null;
        }
        /// <summary>
        /// Get the weather info, from a file that we have on the physical device. 
        /// </summary>
        /// <param name="city">name of the city where we search the info, also is the filename.</param>
        /// <param name="folder">folder where we have the files with the info</param>
        /// <returns>An object from ActualWeather class, whith the actual weather and the forecast of 5 days</returns>
        public static async Task<ActualWeather> GetStoredWeather(string city, string folder)
        {
            dynamic results = await DataService.ReadWeatherFromFile(city, folder);
            if (results != null)
            {
                try
                {
                    ActualWeather actuWeather = results;
                    return actuWeather;
                }
                catch
                {
                    return null;
                }
            }
            else return null;
        }
    }
}