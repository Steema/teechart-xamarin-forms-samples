using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AreaLineWithPointer
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private Steema.TeeChart.Styles.Area area1;
        private Steema.TeeChart.Tools.ColorLine colorLine1;
        private Steema.TeeChart.Tools.Annotation annotation1;
        ChartView AreaLineChart;

        public MainPage()
	{
	    InitializeComponent();

            AreaLineChart = new ChartView();
            area1 = new Steema.TeeChart.Styles.Area();
            AreaLineChart.Chart.Series.Add(area1);
            colorLine1 = new Steema.TeeChart.Tools.ColorLine();
            annotation1 = new Steema.TeeChart.Tools.Annotation();

            AreaLineChart.Chart.Panning.Allow = ScrollModes.None;

            AreaLineChart.Chart.Panel.Gradient.Visible = false;
            AreaLineChart.Chart.Panel.Color = Color.White;
            AreaLineChart.Chart.Walls.Back.Visible = false;
            AreaLineChart.Chart.Header.Visible = false;

            AreaLineChart.Chart.Legend.Visible = false;
            AreaLineChart.Chart.Aspect.View3D = false;
            area1.AreaBrush.Color = Color.FromRgb(192, 192, 255);

            AreaLineChart.Chart.Axes.Bottom.Labels.Font.Brush.Color = Color.FromRgb(128, 128, 128);
            AreaLineChart.Chart.Axes.Bottom.Labels.Font.Size = 18;
            AreaLineChart.Chart.Axes.Left.Labels.Font.Brush.Color = Color.FromRgb(128, 128, 128);
            AreaLineChart.Chart.Axes.Left.Labels.Font.Size = 18;
            AreaLineChart.Chart.Axes.Left.AxisPen.Visible = false;
            AreaLineChart.Chart.Axes.Left.MaximumOffset = 5;
            AreaLineChart.Chart.Axes.Left.MinimumOffset = 5;
            area1.AreaBrush.Color = Color.FromRgb(192,192,255);
            area1.AreaBrush.Solid = true;
            area1.AreaBrush.Visible = true;            
            area1.AreaLines.Visible = false;
            area1.Brush.Color = Color.FromRgb(192,192,255);
            area1.Brush.Solid = true;
            area1.Color = Color.FromRgb(192, 192, 255);
            area1.LinePen.Width = 6;
            area1.LinePen.Color = Color.Navy;

            AreaLineChart.Chart.Axes.Left.Ticks.Length = 10;
            AreaLineChart.Chart.Axes.Bottom.Ticks.Length = 10;

            AreaLineChart.Chart.Axes.Left.Increment = 100;

            // 
            // colorLine1
            // 
            AreaLineChart.Chart.Tools.Add(colorLine1);            
            colorLine1.Axis = AreaLineChart.Chart.Axes.Bottom;
            colorLine1.Pen.Color = Color.Navy;
            colorLine1.Pen.Width = 6;
            colorLine1.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Dot;
            colorLine1.Value = 10D;
            colorLine1.DragLine += ColorLine1_DragLine;
            colorLine1.DrawBehind = false;
            colorLine1.ColorLineClickTolerance = 15;

            annotation1.Shape.Color = Color.Navy;
            annotation1.Shape.Font.Color = Color.White;
            annotation1.Shape.Font.Size = 25;
            annotation1.Shape.Pen.Visible = false;
            annotation1.Shape.BorderRound = 15;
            annotation1.Shape.BevelInner = Steema.TeeChart.Drawing.BevelStyles.None;
            annotation1.Shape.BevelOuter = Steema.TeeChart.Drawing.BevelStyles.None;
            annotation1.Shape.Shadow.Visible = false;

            annotation1.TextAlign = TextAlignment.Center;
            annotation1.Shape.TextAlign = TextAlignment.Center;            

            AreaLineChart.WidthRequest = 650;
            AreaLineChart.HeightRequest = 350;

            AreaLineChart.Chart.AfterDraw += Chart_AfterDraw;

            AreaLineChart.Chart.Panel.Brush.Solid = true;
            area1.Marks.Visible = false;

            AreaLineChart.Chart.Tools.Add(annotation1);
            annotation1.Active = false;
            area1.FillSampleValues(100);


            Content = new StackLayout
            {
                Children =
                  {
                    AreaLineChart
                  },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        private void ColorLine1_DragLine(object sender, EventArgs e)
        {
            annotation1.Active = true;
        }

        private void Chart_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            annotation1.Shape.AutoSize = false;
            AreaLineChart.Chart.Graphics3D.Pen.Width = 6;
            AreaLineChart.Chart.Graphics3D.Pen.Color = area1.LinePen.Color;
            AreaLineChart.Chart.Graphics3D.Brush.Color = area1.Brush.Color;
            AreaLineChart.Chart.Graphics3D.Pen.Style = Steema.TeeChart.Drawing.DashStyle.Solid;

            var xpos = area1.CalcXPosValue((int)colorLine1.Value);
            var ypos = area1.CalcYPosValue(area1.YValues.Value[(int)colorLine1.Value]);
            AreaLineChart.Chart.Graphics3D.Sphere(xpos, ypos, 0, 20);
            annotation1.Text = area1.YValues.Value[(int)colorLine1.Value].ToString();

            var w = AreaLineChart.Chart.Graphics3D.TextWidth(annotation1.Text);
            annotation1.Width = w + 130;
            if (Device.RuntimePlatform == Device.iOS)
                annotation1.Height = 40;
            else
                annotation1.Height = 100;

            annotation1.Left = xpos - (annotation1.Width / 2);
            annotation1.Top = ypos - 150;
        }
    }
}
