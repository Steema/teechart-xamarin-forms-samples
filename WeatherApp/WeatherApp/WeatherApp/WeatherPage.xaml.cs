using System;
using Xamarin.Forms;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WeatherApp
{
  public partial class WeatherPage : ContentPage
  {

    public static bool CityChanged = false;    
    //public ObservableCollection<TempScale> tempOps = new ObservableCollection<TempScale>();
    protected override bool OnBackButtonPressed()
    {

       (((this.Parent as NavigationPage).Parent as MasterDetail).Master as WeatherApp.Pages.MenuPage).ClearSelectedItems();
       return base.OnBackButtonPressed();
      
    }

    public const string FOLDER = "WEATHER";
    public WeatherPage()
    {
      InitializeComponent();
      this.Title = "Enter a city";
      TempSelect.SelectedIndex = (int)(App.DegTempScale);
      getWeatherBtn.Clicked += GetWeatherBtn_Clicked;
      TempSelect.SelectedIndexChanged += GetTempStyle_SelectedIndexChanged;
    }

    string filename = "", entry;


    private void GetTempStyle_SelectedIndexChanged(object sender, EventArgs e)
    {
      App.DegTempScale = (TempScale)(TempSelect.SelectedIndex);
      Application.Current.Properties["tempScale"] = App.DegTempScale;
      CityChanged = true;

      saveprops();
    }

    private async void saveprops()
    {
      await Application.Current.SavePropertiesAsync();
    }


    // this void, gets the string of the textbox, and uses it to consult into the device or the OpenWeatherMap's Api if exists a city's info with this name.
    // if it's results, it will show the info on the screen. If not, it will show an error message. 
    private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
    {
      lblError.IsVisible = false;
      grdMain.IsVisible = false;

      if (regionCodeEntry.Text != "" && regionCodeEntry.Text != null)
      {
        entry = FormatEntry(regionCodeEntry.Text);
        filename = entry;
        try
        {
          GetLocalValues();
          if (App.Weather != null)
          {
            if (TimerUpdate())
            {
              await GetResourceValues();
              if (App.Weather != null)
                SaveResourceValues();
            }
            FillInfo();
          }
          else
          {
            await GetResourceValues(); ;
            if (App.Weather != null)
            {
              SaveResourceValues();
              FillInfo();
            }

            else
            {
              grdMain.IsVisible = false;
              lblError.IsVisible = true;
              lblError.Text = "Error not found. Please try it again later. \n Thanks";
            }
          }
        }
        catch (Exception error)
        {
          System.Diagnostics.Debug.WriteLine(error.Message);
        }
      }
      else
      {
        lblError.IsVisible = true;
        lblError.Text = "Please, enter a valid city, or try it again later.\n Thanks.";
      }
    }

    /// <summary>
    /// This function gets the actual time, and looks if have been passed 15 minutes since last time that we look for the same city. 
    /// </summary>
    /// <returns></returns>
    private bool TimerUpdate()
    {
      bool update = false;
      if ((DateTime.Now - Convert.ToDateTime(App.Weather.Now)).Hours >= 1) update = true;
      return update;
    }
    /// <summary>
    /// This function gets all the info from the App.Weather (attribute), gives it the format that we want, and shows it on the screen.         
    /// </summary>
    private void FillInfo()
    {
      BackgroundImage = "Images.cloudy_background.jpg";
      grdMain.IsVisible = true;
      lblLocale.Text = App.Weather.Name + ", " + App.Weather.Country;
      lblWeather.Text = App.Weather.LstWeather[0].Visibility + ", " + App.Weather.LstWeather[0].Description;
      imgLogo.Source = App.Weather.LstWeather[0].Icon;
      lblTemp.Text = App.getDegScaleTemp(App.Weather.LstWeather[0].Temperature) + (App.DegTempScale == TempScale.celsius ? " ºC" : " ºF"); ;
      lblHumidity.Text = App.Weather.LstWeather[0].Humidity + " %";
      lblPressure.Text = App.Weather.LstWeather[0].Pressure + " hPa";
      lblSea.Text = App.Weather.LstWeather[0].SeaLevel + " hPa";
      lblGround.Text = App.Weather.LstWeather[0].GroundLevel + " hPa";
      CityChanged = true;

    }
    /// <summary>
    /// Consult the function from GetWeatherCore.GetStoredWeather, to gets the info from device.
    /// </summary>
    private async void GetLocalValues()
    {
      App.Weather = null;
      App.Weather = await GetWeatherCore.GetStoredWeather(filename, FOLDER);
    }

    /// <summary>
    /// Consult the function from GetWeatherCore.GetStoredWeather, to gets the info from OpenWeatherMap's Api.
    /// </summary>
    private async Task GetResourceValues()
    {
      if (swChange.IsToggled)
      {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";
        string[] values = entry.Split(',');
        double latitude = double.Parse(values[0], nfi);
        double longitude = double.Parse(values[1], nfi);
        App.Weather = await GetWeatherCore.GetCoordinate(latitude.ToString("0.000", nfi), longitude.ToString("0.000", nfi));
      }
      else App.Weather = await GetWeatherCore.GetActualWeather(entry);
    }

    /// <summary>
    /// Save the info into the device using a DataService.SerializeWeather function.
    /// </summary>
    private void SaveResourceValues()
    {
      DataService.SerializeWeather(FOLDER, App.Weather, App.Weather.Name);
    }

    /// <summary>
    /// Gets the string value of the entry, and gives it format, with the first char in Upper-case, and the others in Lower-case. 
    /// So, all the files will have the same format name. 
    /// </summary>
    /// <param name="region">string that we will give format. </param>
    /// <returns></returns>
    private string FormatEntry(string region)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder(region);
      if (sb[0] >= 'a' && sb[0] <= 'z')
      {
        sb[0] = Char.ToUpper(sb[0]);
        for (int i = 1; i < sb.Length; i++)
        {
          sb[i] = Char.ToLower(sb[i]);
        }
      }
      return sb.ToString();
    }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    }
}
