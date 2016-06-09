using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeeChartDemo.PCL
{
  public class App : Application
  {
    public App()
    {

      Variables.AddSeries();
      Variables.AddTools();
      Variables.AddThemes();
      Variables.AddDash();

      var mainTab = new TabbedPage()
      {
        Title = "TeeChart Xamarin Forms",
      };

      var mainPage = new NavigationPage(mainTab);
      var charts = GetChartStylesPage(mainPage);
      var tools = GetChartToolsPage(mainPage);
      var dash = GetChartDashPage(mainPage);

      mainTab.Children.Add(charts);
      mainTab.Children.Add(tools);
      mainTab.Children.Add(dash);

      MainPage = mainPage;
    }

    public static DataTemplate Cell { get; private set; }

    /// <summary>
    /// Gets the Chart Styles page.
    /// </summary>
    /// <param name="mainPage">The main page.</param>
    /// <returns>Content Page.</returns>
    private static ContentPage GetChartStylesPage(VisualElement mainPage)
    {
      var controls = new ContentPage
      {
        Title = AppResources.PivotItemSeries,
        Icon =  "bar-chart-32.png"
      };


      var lstControls = new ListView();

      lstControls.ItemsSource = Variables.SeriesList;

      Cell = new DataTemplate(typeof(TextCell));

      Cell.SetBinding(TextCell.TextProperty, "Description");
      Cell.SetBinding(TextCell.DetailProperty, "Summary");      

      lstControls.ItemTemplate = Cell;

      lstControls.ItemSelected += async (sender, e) =>
      {
        ElementWrapper obj = e.SelectedItem as ElementWrapper;
        await mainPage.Navigation.PushAsync(new ChartStylesPage(obj.ElementType));
      };

      controls.Content = lstControls;
      return controls;
    }

    /// <summary>
    /// Gets the Chart Tools page.
    /// </summary>
    /// <param name="mainPage">The main page.</param>
    /// <returns>Content Page.</returns>
    private static ContentPage GetChartToolsPage(VisualElement mainPage)
    {
      var controls = new ContentPage
      {
        Title = AppResources.PivotItemTools,
        Icon = "tools-32.png"
      };

      var lstControls = new ListView();

      lstControls.ItemsSource = Variables.ToolsList;

      Cell = new DataTemplate(typeof(TextCell));

      Cell.SetBinding(TextCell.TextProperty, "Description");
      Cell.SetBinding(TextCell.DetailProperty, "Summary");

      lstControls.ItemTemplate = Cell;

      lstControls.ItemSelected += async (sender, e) =>
      {
        ElementWrapper obj = e.SelectedItem as ElementWrapper;
        await mainPage.Navigation.PushAsync(new ChartToolsPage(obj.ElementType));
      };
      controls.Content = lstControls;
      return controls;
    }


    /// <summary>
    /// Gets the Chart Dash page.
    /// </summary>
    /// <param name="mainPage">The main page.</param>
    /// <returns>Content Page.</returns>
    private static ContentPage GetChartDashPage(VisualElement mainPage)
    {
      var controls = new ContentPage
      {
        Title = AppResources.PivotItemDashboard,
        Icon = "dashboard-32.png"
      };

      var lstControls = new ListView
      {
        ItemsSource = Variables.DashList
      };

      lstControls.ItemSelected += async (sender, e) =>
      {
        ElementWrapper obj = e.SelectedItem as ElementWrapper;
        await mainPage.Navigation.PushAsync(new ChartDashPage(obj.ToString()));
      };
      controls.Content = lstControls;
      return controls;
    }

  }
}
