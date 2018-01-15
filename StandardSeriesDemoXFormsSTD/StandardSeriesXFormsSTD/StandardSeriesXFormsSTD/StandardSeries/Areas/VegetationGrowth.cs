using System;
using Steema.TeeChart;
using Xamarin.Forms;
using Steema.TeeChart.Styles;
 
namespace StandardSeriesXFormsSTD
{
	public class VegetationGrowth : ContentPage
	{
        public ChartView tChart1;
        Area area1;
        Area area2;
        Area area3;

		public VegetationGrowth ()
		{            
            this.Title = "Vegetation Growth";

            tChart1 = new ChartView();


            tChart1.WidthRequest = 400;
            tChart1.HeightRequest = 300;

            area1 = new Area();
            area2 = new Area();
            area3 = new Area();

            this.tChart1.Chart.Aspect.Elevation = 350;
            this.tChart1.Chart.Aspect.ElevationFloat = 350D;
            this.tChart1.Chart.Aspect.Perspective = 55;
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Aspect.ZoomText = true;
            this.tChart1.Chart.Panning.Active = true;
            this.tChart1.Chart.Zoom.Active = true;

            this.tChart1.Chart.Axes.Bottom.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart1.Chart.Axes.Bottom.Grid.Visible = false;
            this.tChart1.Chart.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Bottom.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Chart.Axes.Bottom.Title.Caption = "Days";
            this.tChart1.Chart.Axes.Bottom.Title.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Bottom.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Bottom.Title.Lines = new string[] {"Days"};
            this.tChart1.Chart.Axes.Depth.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.DepthTop.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Left.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart1.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Chart.Axes.Left.Ticks.Length = 7;
            this.tChart1.Chart.Axes.Left.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Right.Grid.Visible = false;
            this.tChart1.Chart.Axes.Right.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Right.Ticks.Visible = false;
            this.tChart1.Chart.Axes.Right.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Top.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Header.Alignment = TextAlignment.Center;
            this.tChart1.Chart.Header.Font.Bold = true;
            this.tChart1.Chart.Header.Font.Brush.Color = Color.Black;
            this.tChart1.Chart.Header.Font.Italic = true;
            this.tChart1.Chart.Header.Font.Name = "Segoe UI";
            this.tChart1.Chart.Header.Font.Shadow.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Font.Shadow.SmoothBlur = 2;
            this.tChart1.Chart.Header.Font.Size = 14;
            this.tChart1.Chart.Header.Lines = new string[] {"Vegetation growth"};
            this.tChart1.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Top;
            this.tChart1.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart1.Chart.Legend.Font.Size = 14;
            this.tChart1.Chart.Legend.Pen.Visible = false;
            this.tChart1.Chart.Legend.Shadow.Visible = false;
            this.tChart1.Chart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart1.Chart.Panel.Bevel.Width = 2;
            this.tChart1.Chart.Panel.BevelWidth = 2;
            this.tChart1.Chart.Panel.Brush.Color = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Series.Add(this.area1);
            this.tChart1.Chart.Series.Add(this.area2);
            this.tChart1.Chart.Series.Add(this.area3);
            this.tChart1.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Walls.Back.Pen.Visible = false;
            this.tChart1.Chart.Walls.Back.Visible = false;
            this.tChart1.Chart.Walls.Bottom.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Walls.Bottom.Pen.Color = Color.Gray;
            this.tChart1.Chart.Walls.Bottom.Transparent = true;
            this.tChart1.Chart.Walls.Left.Brush.Color = Color.White;
            this.tChart1.Chart.Walls.Left.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Walls.Left.Pen.Color = Color.Gray;
            this.tChart1.Chart.Walls.Left.Transparent = true;
            this.tChart1.Chart.Walls.Right.Transparent = true;
            // area1
            this.area1.AreaBrush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
            this.area1.Gradient.StartColor = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.area1.AreaLines.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.area1.AreaLines.Transparency = 64;
            this.area1.AreaLines.Visible = false;
            this.area1.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
            this.area1.TopGradient.Transparency = 64;
            this.area1.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))), ((int)(((byte)(92)))));
            this.area1.ColorEach = false;
            this.area1.LinePen.Color = Color.FromRgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.area1.LinePen.Transparency = 64;
            this.area1.LinePen.Visible = false;
            this.area1.Marks.Arrow.Transparency = 64;
            this.area1.Marks.Arrow.Visible = false;
            this.area1.Marks.ArrowLength = 0;
            this.area1.Marks.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(92)))));
            this.area1.Marks.Brush.Gradient.Transparency = 64;
            this.area1.Marks.Clip = true;
            this.area1.Marks.Font.Brush.Color = Color.FromRgba(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(92)))));
            this.area1.Marks.Font.Brush.Gradient.Transparency = 64;
            this.area1.Marks.Font.Name = "Segoe UI";
            this.area1.Marks.Pen.Transparency = 64;
            this.area1.Marks.Shadow.Brush.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(92)))));
            this.area1.Marks.Shadow.Brush.Gradient.Transparency = 64;
            this.area1.Marks.Transparent = true;
            this.area1.Pointer.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(92)))));
            this.area1.Pointer.Brush.Gradient.Transparency = 64;
            this.area1.Pointer.Pen.Transparency = 64;
            this.area1.Pointer.SizeDouble = 0D;
            this.area1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.area1.Title = "With nutrient";
            this.area1.Transparency = 64;
            this.area1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // area2
            this.area2.AreaBrush.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(76)))));
            this.area2.Gradient.StartColor = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.area2.AreaLines.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.area2.AreaLines.Transparency = 70;
            this.area2.AreaLines.Visible = false;
            this.area2.Brush.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(76)))));
            this.area2.TopGradient.Transparency = 70;
            this.area2.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(76)))));
            this.area2.ColorEach = false;
            this.area2.LinePen.Color = Color.Purple;
            this.area2.LinePen.Transparency = 70;
            this.area2.LinePen.Visible = false;
            this.area2.Marks.Arrow.Transparency = 70;
            this.area2.Marks.Arrow.Visible = false;
            this.area2.Marks.ArrowLength = 0;
            this.area2.Marks.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(76)))));
            this.area2.Marks.Brush.Gradient.Transparency = 70;
            this.area2.Marks.Font.Brush.Color = Color.FromRgba(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(76)))));
            this.area2.Marks.Font.Brush.Gradient.Transparency = 70;
            this.area2.Marks.Font.Name = "Segoe UI";
            this.area2.Marks.Pen.Transparency = 70;
            this.area2.Marks.Shadow.Brush.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(76)))));
            this.area2.Marks.Shadow.Brush.Gradient.Transparency = 70;
            this.area2.Marks.Transparent = true;
            this.area2.Pointer.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(76)))));
            this.area2.Pointer.Brush.Gradient.Transparency = 70;
            this.area2.Pointer.Pen.Transparency = 70;
            this.area2.Pointer.SizeDouble = 0D;
            this.area2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.area2.Title = "No added nutrient";
            this.area2.Transparency = 70;
            this.area2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // area3
            this.area3.AreaBrush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.area3.Gradient.StartColor = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.area3.AreaLines.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.area3.AreaLines.Transparency = 47;
            this.area3.AreaLines.Visible = false;
            this.area3.Brush.Color = Color.FromRgba(((int)(((byte)(135)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.area3.TopGradient.Transparency = 47;
            this.area3.Color = Color.FromRgba(((int)(((byte)(135)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.area3.ColorEach = false;
            this.area3.LinePen.Color = Color.FromRgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.area3.LinePen.Transparency = 47;
            this.area3.LinePen.Visible = false;
            this.area3.Marks.Arrow.Transparency = 47;
            this.area3.Marks.Arrow.Visible = false;
            this.area3.Marks.ArrowLength = 0;
            this.area3.Marks.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(135)))));
            this.area3.Marks.Brush.Gradient.Transparency = 47;
            this.area3.Marks.Font.Brush.Color = Color.FromRgba(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(135)))));
            this.area3.Marks.Font.Brush.Gradient.Transparency = 47;
            this.area3.Marks.Font.Name = "Segoe UI";
            this.area3.Marks.Pen.Transparency = 47;
            this.area3.Marks.Shadow.Brush.Color = Color.FromRgba(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(135)))));
            this.area3.Marks.Shadow.Brush.Gradient.Transparency = 47;
            this.area3.Marks.Transparent = true;
            this.area3.Pointer.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(135)))));
            this.area3.Pointer.Brush.Gradient.Transparency = 47;
            this.area3.Pointer.Pen.Transparency = 47;
            this.area3.Pointer.SizeDouble = 0D;
            this.area3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.area3.Title = "Series2";
            this.area3.Transparency = 47;
            this.area3.Visible = false;
            this.area3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();

            for (int t = 0; t < 15; t++)
            {
                area1.Add(rnd1.Next(100));
                area2.Add(rnd1.Next(60));
                area3.Add(rnd1.Next(30));
            }

            area1.Smoothed = true;
            area2.Smoothed = true;
            area3.Smoothed = true;

            tChart1.Chart.Axes.Bottom.Increment = 3;
            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart1.Chart.Axes.Left.StartPosition = 0;
            Label l = new Label();
            l.Text = "hello";
            tChart1.InvalidateDisplay();
            tChart1.Chart.Invalidate();
            

            Content = new StackLayout
            {
                Children = {
                    tChart1
                },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
		}
	}
}