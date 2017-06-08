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
      Variables.AddOther();

      var mainTab = new TabbedPage()
      {
        Title = "TeeChart Xamarin Forms",
      };

      var mainPage = new NavigationPage(mainTab);
      mainPage.BarBackgroundColor = Color.FromRgb(255, 255, 255); // FromRgb(0, 82, 160);
      mainPage.BarTextColor = Color.Black;      

      var charts = GetChartStylesPage(mainPage);
      var tools = GetChartToolsPage(mainPage);
      var dash = GetChartDashPage(mainPage);
      var events = GetChartEventsPage(mainPage);

      mainTab.Children.Add(charts);
      if (!(Device.OS == TargetPlatform.Windows))
        mainTab.Children.Add(tools);
      mainTab.Children.Add(dash);
      if (!(Device.OS == TargetPlatform.Windows))
        mainTab.Children.Add(events);

      mainTab.BarBackgroundColor = Color.FromRgb(255, 255, 255);
      mainTab.BarTextColor = Color.Black;

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
      lstControls.BackgroundColor = Color.FromRgb(255,255,255);
      lstControls.RowHeight = 35;

       Cell = new DataTemplate(typeof(TextCell));

      Cell.SetValue(TextCell.TextColorProperty, Color.Black);
      Cell.SetValue(TextCell.DetailColorProperty, Color.White);

      Cell.SetBinding(TextCell.TextProperty, "Description");            
      // Cell.SetBinding(TextCell.DetailProperty, "Summary");                  

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

      lstControls.BackgroundColor = Color.FromRgb(255, 255, 255);

      Cell.SetBinding(TextCell.TextProperty, "Description");
      Cell.SetBinding(TextCell.DetailProperty, "Summary");

      Cell.SetValue(TextCell.TextColorProperty, Color.Black);
      Cell.SetValue(TextCell.DetailColorProperty, Color.White);

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
    /// Gets the Chart Events page.
    /// </summary>
    /// <param name="mainPage">The main page.</param>
    /// <returns>Content Page.</returns>
    private static ContentPage GetChartEventsPage(VisualElement mainPage)
    {
        var controls = new ContentPage
        {
            Title = AppResources.OtherItem,
            Icon = "project-32.png"  
        };

        var lstControls = new ListView
        {
            ItemsSource = Variables.OtherList
        };

        Cell = new DataTemplate(typeof(TextCell));

        lstControls.BackgroundColor = Color.FromRgb(255, 255, 255);

        Cell.SetBinding(TextCell.TextProperty, "Description");
        Cell.SetBinding(TextCell.DetailProperty, "Summary");

        Cell.SetValue(TextCell.TextColorProperty, Color.Black);
        Cell.SetValue(TextCell.DetailColorProperty, Color.White);

        lstControls.ItemTemplate = Cell;


        lstControls.ItemSelected += async (sender, e) =>
            {
                ElementWrapper obj = e.SelectedItem as ElementWrapper;
                switch (obj.ToString())
                {
                    case "Click Annotation":
                    {
                        await mainPage.Navigation.PushAsync(new Other.ClickAnnotation());
                        break;
                    }
                    case "Snap Cursor ToolTip":
                    {
                        await mainPage.Navigation.PushAsync(new Other.SnapCursorToolTip());
                        break;
                    }
                    case "ScrollPager Tool":
                    {
                        await mainPage.Navigation.PushAsync(new Other.ScrollPagerTool());
                        break;
                    }
                    case "SubChart Tool":
                    {
                        await mainPage.Navigation.PushAsync(new Other.SubChartTool());
                        break;
                    }
                    case "ColorLine Tool":
                    {
                        await mainPage.Navigation.PushAsync(new Other.ColorLineTool());
                        break;
                    }
                }
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

      Cell = new DataTemplate(typeof(TextCell));

      lstControls.BackgroundColor = Color.FromRgb(255, 255, 255);

      Cell.SetBinding(TextCell.TextProperty, "Description");
      Cell.SetBinding(TextCell.DetailProperty, "Summary");

      Cell.SetValue(TextCell.TextColorProperty, Color.Black);
      Cell.SetValue(TextCell.DetailColorProperty, Color.White);

      lstControls.ItemTemplate = Cell;


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
