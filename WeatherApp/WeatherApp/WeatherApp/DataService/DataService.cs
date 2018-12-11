using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using PCLStorage;

namespace WeatherApp
{
    public class DataService
    {
        /// <summary>
        /// This function, call the query that we sent, and get the info from the server's api. 
        /// </summary>
        /// <param name="queryString">The query that we will do into the server. </param>
        /// <returns>A string in json format, with the server's info</returns>
        public static async Task<dynamic> getDataFromService(string queryString)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;
            if (response != null)
            {
                string json = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject(json);
            }
            return data;

        }

        /// <summary>
        /// That void saves into the physical devices, the Weather item that we created with the api's server info
        /// </summary>
        /// <param name="folder">Name of the folder where we want to save the file</param>
        /// <param name="weather">Weather info that we want to save</param>
        /// <param name="fileName">The name that the file will have. </param>
        public static async void SerializeWeather(string folder, ActualWeather weather, string fileName)
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder resourceFolder = await rootFolder.CreateFolderAsync(folder, CreationCollisionOption.OpenIfExists);
                IFile file = await resourceFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                var companiesString = JsonConvert.SerializeObject(weather, Formatting.Indented);
                await file.WriteAllTextAsync(companiesString);
            }
            catch
            {
            }
        }

        /// <summary>
        /// This function reads the weather info from a file, and it serializes her with a json format to use the data. 
        /// </summary>
        /// <param name="fileName">The name of the file where the data are</param>
        /// <param name="folder">The name of the folder where the files is.</param>
        /// <returns></returns>
        public static async Task<dynamic> ReadWeatherFromFile(string fileName, string folder)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder resourceFolder = await rootFolder.CreateFolderAsync(folder, CreationCollisionOption.OpenIfExists);

            if (await (resourceFolder.CheckExistsAsync(fileName)) == ExistenceCheckResult.NotFound)
            {
                return null;
            }
            else
            {
                IFile file = await resourceFolder.GetFileAsync(fileName);
                var json = await file.ReadAllTextAsync();

                if (string.IsNullOrEmpty(json)) return null;

                dynamic weathers = JsonConvert.DeserializeObject<ActualWeather>(json);

                return weathers;
            }
        }
    }
}