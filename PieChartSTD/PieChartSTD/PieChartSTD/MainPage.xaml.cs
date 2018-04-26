using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart;

namespace PieChartSTD
{
	public partial class MainPage : ContentPage
	{

        private Steema.TeeChart.Styles.Pie pie;
        ChartView PieChart;
        Steema.TeeChart.Tools.Annotation ann = new Steema.TeeChart.Tools.Annotation();

        public MainPage()
		{
			InitializeComponent();

            PieChart = new ChartView();
            pie = new Steema.TeeChart.Styles.Pie();
            PieChart.Chart.ClickSeries += Chart_ClickSeries;
            PieChart.Chart.Series.Add(pie);

            PieChart.Chart.Panning.Allow = ScrollModes.None;

            PieChart.Chart.Panel.Gradient.Visible = false;
            PieChart.Chart.Panel.Color = Color.White;
            PieChart.Chart.Walls.Back.Visible = false;
            PieChart.Chart.Header.Visible = false;

            PieChart.Chart.Legend.Visible = false;
            PieChart.Chart.Aspect.View3D = false;

            PieChart.WidthRequest = 650;
            PieChart.HeightRequest = 350;

            PieChart.Chart.Panel.Brush.Solid = true;
            
            pie.Circled = true;
            pie.AutoPenColor = false;
            pie.Pen.Color = Color.White;
            pie.Pen.Width = 15;
            pie.Marks.Visible = false;

            pie.FillSampleValues(3);

            PieChart.Chart.Tools.Add(ann);
            ann.Active = false;
            ann.Shape.Font.Size = 25;
            ann.Shape.TextAlign = TextAlignment.Center;
            ann.TextAlign = TextAlignment.Center;            
            ann.Shape.Pen.Color = ann.Shape.Color;
            ann.AutoSize = false;
            if (Device.OS == TargetPlatform.iOS)
            {
                ann.Shape.Width = 80;
                ann.Shape.Height = 40;
            }
            else
            {
                ann.Shape.Width = 200;
                ann.Shape.Height = 100;
            }

            Content = new StackLayout
            {
                Children =
                  {
                    PieChart
                  },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        private void Chart_ClickSeries(object sender, Steema.TeeChart.Styles.Series s, int valueIndex, Steema.TeeChart.Drawing.MouseEventArgs e)
        {            
            ann.Active = true;
            ann.Text = pie.PieValues.Value[valueIndex].ToString();
            ann.Left = e.X - ann.Width / 2;
            ann.Top = e.Y- 20;            
        }
    }
}
