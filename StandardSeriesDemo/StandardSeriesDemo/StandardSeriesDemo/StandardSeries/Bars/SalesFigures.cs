using System;
using Steema.TeeChart;
using Xamarin.Forms;
using Steema.TeeChart.Styles;

namespace StandardSeriesDemo
{
	public class SalesFigures : ContentPage
	{
        Chart tChart1;
        public ChartView chartView;
        Bar bar1;
        Bar bar2;
        Steema.TeeChart.Tools.SeriesAnimation seriesAnimation1;
        Steema.TeeChart.Animations.ChartPartAnimation chartPartAnimation1;
        Steema.TeeChart.Animations.EasingFunctions.QuadraticEase quadraticEase1 = new Steema.TeeChart.Animations.EasingFunctions.QuadraticEase();

		public SalesFigures ()
		{
            tChart1 = new Chart();
            tChart1.Aspect.View3D = false;

            this.bar1 = new Bar();
            this.bar2 = new Bar();
            this.seriesAnimation1 = new Steema.TeeChart.Tools.SeriesAnimation();
            this.chartPartAnimation1 = new Steema.TeeChart.Animations.ChartPartAnimation();
            this.tChart1.Animations.Add(this.chartPartAnimation1);
            this.tChart1.Aspect.ColorPaletteIndex = 20;
            this.tChart1.Aspect.View3D = false;
            this.tChart1.Axes.Bottom.Grid.DrawEvery = 2;
            this.tChart1.Axes.Bottom.Grid.Visible = false;
            this.tChart1.Axes.Bottom.Labels.Font.Brush.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Bottom.Labels.Font.Size = 9;
            this.tChart1.Axes.Bottom.Title.Font.Brush.Color = Color.FromRgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Bottom.Title.Font.Size = 11;
            this.tChart1.Axes.Left.AxisPen.Visible = false;
            this.tChart1.Axes.Left.Grid.DrawEvery = 2;
            this.tChart1.Axes.Left.Grid.Style = Steema.TeeChart.Drawing.DashStyle.Solid;
            this.tChart1.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Axes.Left.Labels.Font.Size = 9;
            this.tChart1.Axes.Left.MinorTicks.Visible = false;
            this.tChart1.Axes.Left.Ticks.Visible = false;
            this.tChart1.Axes.Left.Title.Caption = "$ 000s";
            this.tChart1.Axes.Left.Title.Font.Brush.Color = Color.FromRgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Left.Title.Font.Size = 11;
            this.tChart1.Axes.Left.Title.Lines = new string[] {"$ 000s"};
            this.tChart1.Axes.Right.AxisPen.Visible = false;
            this.tChart1.Axes.Right.Labels.Font.Brush.Color = Color.FromRgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Right.Labels.Font.Size = 9;
            this.tChart1.Axes.Top.Labels.Font.Brush.Color = Color.FromRgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Top.Labels.Font.Size = 9;
            this.tChart1.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Header.Font.Size = 12;
            this.tChart1.Header.Lines = new string[] {"Sales Figures"};
            this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart1.Legend.Font.Brush.Color = Color.FromRgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Legend.Font.Size = 9;
            this.tChart1.Legend.Pen.Visible = false;
            this.tChart1.Legend.Shadow.Visible = false;
            this.tChart1.Legend.Transparent = true;
            this.tChart1.Panel.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart1.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Series.Add(this.bar1);
            this.tChart1.Series.Add(this.bar2);
            this.tChart1.Tools.Add(this.seriesAnimation1);
            this.tChart1.Walls.Back.Brush.Visible = false;
            this.tChart1.Walls.Back.Transparent = true;
            this.tChart1.Walls.Back.Visible = false;
            // 
            // bar1
            // 
            this.bar1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar1.BarStyle = Steema.TeeChart.Styles.BarStyles.RoundRectangle;
            this.bar1.RoundSize = 5;
            this.bar1.BarWidthPercent = 80;
            this.bar1.Brush.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.bar1.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.bar1.ColorEach = false;
            this.bar1.Marks.Arrow.Visible = false;
            this.bar1.Marks.ArrowLength = 8;
            this.bar1.Marks.Brush.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.bar1.Marks.FollowSeriesColor = true;
            this.bar1.Marks.Font.Brush.Color = Color.White;
            this.bar1.Marks.Font.Name = "Segoe UI";
            this.bar1.Marks.Pen.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.bar1.Marks.Pen.Visible = false;
            this.bar1.Marks.Shadow.Visible = false;
            this.bar1.Marks.Style = Steema.TeeChart.Styles.MarksStyles.LabelValue;
            this.bar1.OffsetPercent = -10;
            this.bar1.Pen.Color = Color.FromRgb(((int)(((byte)(132)))), ((int)(((byte)(55)))), ((int)(((byte)(3)))));
            this.bar1.Pen.Visible = false;
            this.bar1.Title = "Series0";
            this.bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar1.YValues.DataMember = "Bar";
            // 
            // bar2
            // 
            this.bar2.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar2.BarStyle = Steema.TeeChart.Styles.BarStyles.RoundRectangle;
            this.bar2.RoundSize = 5;
            this.bar2.BarWidthPercent = 80;
            this.bar2.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.bar2.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.bar2.ColorEach = false;
            this.bar2.Marks.Arrow.Visible = false;
            this.bar2.Marks.ArrowLength = 8;
            this.bar2.Marks.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.bar2.Marks.FollowSeriesColor = true;
            this.bar2.Marks.Font.Brush.Color = Color.White;
            this.bar2.Marks.Font.Name = "Segoe UI";
            this.bar2.Marks.Pen.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.bar2.Marks.Pen.Visible = false;
            this.bar2.Marks.Shadow.Visible = false;
            this.bar2.Marks.Style = Steema.TeeChart.Styles.MarksStyles.LabelValue;
            this.bar2.Marks.Symbol.Shadow.Visible = false;
            this.bar2.OffsetPercent = 10;
            this.bar2.Pen.Color = Color.FromRgb(((int)(((byte)(153)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.bar2.Pen.Visible = false;
            this.bar2.Title = "Series1";
            this.bar2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar2.YValues.DataMember = "Bar";
            // 
            // seriesAnimation1
            // 
            this.seriesAnimation1.StartValue = 0D;
            // 
            // chartPartAnimation1
            // 
            this.chartPartAnimation1.Axis = null;
            quadraticEase1.EasingMode = Steema.TeeChart.Animations.EasingFunctions.EasingMode.EaseIn;
            this.chartPartAnimation1.EasingFunction = quadraticEase1;
            this.chartPartAnimation1.EasingMode = Steema.TeeChart.Animations.EasingFunctions.EasingMode.EaseOut;
            this.chartPartAnimation1.Fade = Steema.TeeChart.Animations.TransformFade.In;
            this.chartPartAnimation1.RotateMax = 0F;
            this.chartPartAnimation1.RotateMin = 0F;
            this.chartPartAnimation1.Series = this.bar1;
            this.chartPartAnimation1.Speed = 10000;
            this.chartPartAnimation1.Target = Steema.TeeChart.ChartClickedPartStyle.Series;
            this.chartPartAnimation1.TranslateStyle = Steema.TeeChart.Animations.TransformTranslate.None;
            this.chartPartAnimation1.ZoomStyle = Steema.TeeChart.Animations.TransformZoom.None;

            tChart1.Panel.Gradient.Visible = false;

            //add series and data
            bar1.Title = "Apples";
            bar1.Clear();
            bar1.Add(5, "jan");
            bar1.Add(2, "feb");
            bar1.Add(1, "mar");
            bar1.Add(4, "apr");
            bar1.Add(10, "may");
            bar1.Add(11, "jun");
            bar1.Add(15, "jul");

            bar2.Title = "Pears";
            bar2.Clear();
            bar2.Add(7);
            bar2.Add(5);
            bar2.Add(1);
            bar2.Add(6);
            bar2.Add(2);
            bar2.Add(11);
            bar2.Add(5);

            tChart1.Axes.Bottom.Labels.Style = Steema.TeeChart.AxisLabelStyle.Text;
            tChart1.Axes.Left.Increment = 3;

            tChart1.Axes.Left.SetMinMax(0, 15);

            chartPartAnimation1.Play();


            chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 50,
                HeightRequest = 50
            };
            chartView.Model = tChart1;

            Content = new StackLayout
            {
                Children = {
					chartView
				}
            };
        }
	}
}


