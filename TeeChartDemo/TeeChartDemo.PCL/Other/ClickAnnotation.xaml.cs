using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Steema.TeeChart.Themes;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;

namespace TeeChartDemo.PCL.Other
{
    public partial class ClickAnnotation : ContentPage
    {

        Chart chart1 = new Chart();
        Annotation tool = new Annotation();

        public ClickAnnotation()
        {
            ChartView chartView1 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //WidthRequest = 400,
                //HeightRequest = 
            };

            InitializeChart();

            chartView1.Model = chart1;

            Content = new StackLayout
            {
                Children = { chartView1 }
            };
        }
        


        private void InitializeChart()
        {
            chart1.Series.Add(new Bar());
            chart1.Series[0].FillSampleValues();
            chart1.Aspect.View3D = false;
            chart1.Series[0].ColorEach = true;
            chart1.setTheme(ThemeType.Report);

            // Adding Annotation Tools
            chart1.Tools.Add(new Annotation());
            (chart1.Tools[0] as Annotation).Text = "This is an Annotation tool";
            (chart1.Tools[0] as Annotation).ClipText = false;
            (chart1.Tools[0] as Annotation).Left = 50;
            (chart1.Tools[0] as Annotation).Top = 40;
            (chart1.Tools[0] as Annotation).Shape.Font.Size = 10;
            (chart1.Tools[0] as Annotation).TextAlign = TextAlignment.Center;
            (chart1.Tools[0] as Annotation).Click += ClickAnnotation_Click;

            chart1.Tools.Add(new Annotation());
            (chart1.Tools[1] as Annotation).Text = "Another Annotation";
            (chart1.Tools[1] as Annotation).ClipText = false;
            (chart1.Tools[1] as Annotation).Left = 150;
            (chart1.Tools[1] as Annotation).Top = 80;
            (chart1.Tools[1] as Annotation).Shape.Font.Size = 10;
            (chart1.Tools[1] as Annotation).TextAlign = TextAlignment.Center;
            (chart1.Tools[1] as Annotation).Click += ClickAnnotation_Click1;

        }

        private void ClickAnnotation_Click1(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            (chart1.Tools[1] as Steema.TeeChart.Tools.Annotation).Text = "Clicked!!";

        }

        private void ClickAnnotation_Click(object sender, Steema.TeeChart.Drawing.MouseEventArgs e)
        {
            (chart1.Tools[0] as Steema.TeeChart.Tools.Annotation).Text = "Clicked!!";
        }
    }
}
