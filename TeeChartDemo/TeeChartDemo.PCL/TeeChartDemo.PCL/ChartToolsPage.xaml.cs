using System;
using System.Collections.Generic;
using Steema.TeeChart.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart.Editors.Tools;
using Steema.TeeChart.Themes;

namespace TeeChartDemo.PCL
{
  public partial class ChartToolsPage
  {
    public ChartToolsPage(Type toolsType)
    {
      InitializeComponent();

      Steema.TeeChart.Chart chart = new Steema.TeeChart.Chart();

      ToolsGalleryDemos toolsDemos = new ToolsGalleryDemos(chart, typeof(BlackIsBackTheme));

      ChartView chartView = new ChartView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,

        WidthRequest = 400,
        HeightRequest = 500
      };


      chart.Aspect.View3D = false;
      chart.Panel.Bevel.Inner = BevelStyles.None;
      chart.Panel.Bevel.Outer = BevelStyles.None;
      chart.Panel.Gradient.Visible = false;
      chart.Panel.Color = Color.White;

      chart.Zoom.Active = false;
      chart.Touch.Style = Steema.TeeChart.TouchStyle.InChart;

      toolsDemos.CreateGallery(toolsType);

      chartView.Model = chart;

      Content = new StackLayout
      {
        Children = {
					  chartView,
				  }
      };
    }
  }
}
