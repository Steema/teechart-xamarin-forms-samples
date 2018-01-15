using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
	public class ProductShipments : ContentPage
	{
        private ChartView tChart1;
        private Steema.TeeChart.Styles.Points points1;
        private Steema.TeeChart.Styles.Points points2;
        private Steema.TeeChart.Functions.Smoothing smoothing1;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Functions.Average average1;
        private Steema.TeeChart.Styles.Line line2;
                
		public ProductShipments ()
		{
            this.Title = "Product Shipments";

            this.tChart1 = new ChartView();
            tChart1.WidthRequest = 400;
            tChart1.HeightRequest = 300;

            this.points1 = new Steema.TeeChart.Styles.Points();
            this.points2 = new Steema.TeeChart.Styles.Points();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.average1 = new Steema.TeeChart.Functions.Average();
            this.smoothing1 = new Steema.TeeChart.Functions.Smoothing();
            this.line2 = new Steema.TeeChart.Styles.Line();
            // tChart1
            this.tChart1.Chart.Aspect.Elevation = 350;
            this.tChart1.Chart.Aspect.Perspective = 55;
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Axes.Bottom.AxisPen.Visible = false;
            this.tChart1.Chart.Axes.Bottom.AxisPen.Width = 0;
            this.tChart1.Chart.Axes.Bottom.Grid.Visible = false;
            this.tChart1.Chart.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Bottom.Labels.Font.Size = 24;
            this.tChart1.Chart.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Bottom.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Chart.Axes.Depth.Title.Font.Size = 13;
            this.tChart1.Chart.Axes.DepthTop.Title.Font.Size = 13;
            this.tChart1.Chart.Axes.Left.AxisPen.Visible = false;
            this.tChart1.Chart.Axes.Left.AxisPen.Width = 0;
            this.tChart1.Chart.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Left.Labels.Font.Size = 24;
            this.tChart1.Chart.Axes.Left.MinimumOffset = 10;
            this.tChart1.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Chart.Axes.Left.Ticks.Length = 7;
            this.tChart1.Chart.Axes.Right.AxisPen.Width = 0;
            this.tChart1.Chart.Axes.Right.Grid.Visible = false;
            this.tChart1.Chart.Axes.Right.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Right.Labels.Font.Size = 31;
            this.tChart1.Chart.Axes.Right.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Right.Ticks.Visible = false;
            this.tChart1.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart1.Chart.Header.Alignment = TextAlignment.Start;
            this.tChart1.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Font.Shadow.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Font.Shadow.SmoothBlur = 2;
            this.tChart1.Chart.Header.Font.Size = 33;
            this.tChart1.Chart.Header.Lines = new string[] {"Product shipments"};
            this.tChart1.Chart.Legend.Font.Size = 19;
            this.tChart1.Chart.Legend.Pen.Visible = false;
            this.tChart1.Chart.Legend.Shadow.Visible = false;
            this.tChart1.Chart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart1.Chart.Panel.Bevel.Width = 2;
            this.tChart1.Chart.Panel.BevelWidth = 2;
            this.tChart1.Chart.Panel.Brush.Color = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Series.Add(this.points1);
            this.tChart1.Chart.Series.Add(this.points2);
            this.tChart1.Chart.Series.Add(this.line1);
            this.tChart1.Chart.Series.Add(this.line2);
            this.tChart1.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Walls.Back.Pen.Visible = false;
            this.tChart1.Chart.Walls.Bottom.Brush.Gradient.EndColor = Color.Silver;
            this.tChart1.Chart.Walls.Bottom.Brush.Gradient.StartColor = Color.Gray;
            this.tChart1.Chart.Walls.Bottom.Brush.Gradient.Visible = true;
            this.tChart1.Chart.Walls.Bottom.Pen.Color = Color.Gray;
            this.tChart1.Chart.Walls.Bottom.Transparent = true;
            this.tChart1.Chart.Walls.Left.Brush.Gradient.EndColor = Color.Silver;
            this.tChart1.Chart.Walls.Left.Brush.Gradient.StartColor = Color.Gray;
            this.tChart1.Chart.Walls.Left.Brush.Gradient.Visible = true;
            this.tChart1.Chart.Walls.Left.Pen.Color = Color.Gray;
            this.tChart1.Chart.Walls.Left.Transparent = true;
            this.tChart1.Chart.Walls.Right.Transparent = true;
            this.tChart1.Chart.Walls.Visible = false;
            // points1
            this.points1.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.points1.ColorEach = false;
            this.points1.LinePen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.points1.Pointer.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.points1.Pointer.Brush.Gradient.StartColor = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.points1.Pointer.SizeDouble = 0D;
            this.points1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.points1.Title = "points1";
            this.points1.XValues.DataMember = "X";
            this.points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.points1.YValues.DataMember = "Y";
            // points2
            this.points2.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.points2.ColorEach = false;
            this.points2.LinePen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.points2.Pointer.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.points2.Pointer.Brush.Gradient.StartColor = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.points2.Pointer.SizeDouble = 0D;
            this.points2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.points2.Title = "points2";
            this.points2.XValues.DataMember = "X";
            this.points2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.points2.YValues.DataMember = "Y";
            // line1
            this.line1.Brush.Color = Color.FromRgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.line1.Color = Color.FromRgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.line1.ColorEach = false;
            this.line1.DataSource = new object[] {
        ((object)(this.points1)),
        ((object)(this.points2))};
            this.line1.Function = this.average1;
            this.line1.LinePen.Color = Color.FromRgb(((int)(((byte)(145)))), ((int)(((byte)(46)))), ((int)(((byte)(12)))));
            this.line1.Pointer.SizeDouble = 0D;
            this.line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.line1.Title = "line1";
            this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // average1
            this.average1.Period = 2D;
            // smoothing1
            this.smoothing1.Factor = 8;
            this.smoothing1.Period = 1D;
            // line2
            this.line2.Brush.Color = Color.FromRgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(168)))));
            this.line2.Color = Color.FromRgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(168)))));
            this.line2.ColorEach = false;
            this.line2.LinePen.Color = Color.FromRgb(((int)(((byte)(47)))), ((int)(((byte)(91)))), ((int)(((byte)(101)))));
            this.line2.LinePen.Width = 2;
            this.line2.Pointer.SizeDouble = 0D;
            this.line2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.line2.Title = "line2";
            this.line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

            int[] Yarr1 = new int[] { 5, 3, 2, 7, 1, 6, 4, 5, 1, 0, 10, 7, 11, 15, 12, 21, 17, 15, 19, 24, 21, 11, 15, 21, 19, 17, 20, 23 };
            int[] Yarr2 = new int[] { 7, 1, 5, 1, 0, 10, 6, 3, 2, 7, 11, 4, 5, 3, 4, 5, 1, 5, 11, 15, 16, 14, 14, 13, 12, 15, 17, 19 };

            DateTime[] Xarr = new DateTime[] {new DateTime(2012, 9, 1),new DateTime(2012, 9, 15),new DateTime(2012, 10, 1),new DateTime(2012, 10, 15),new DateTime(2012, 11, 1)
                  ,new DateTime(2012, 11, 15),new DateTime(2012, 12, 1),new DateTime(2012, 12, 15),new DateTime(2013, 1, 1),new DateTime(2013, 1, 15)
				  ,new DateTime(2013, 2, 1),new DateTime(2013, 2, 15),new DateTime(2013, 3, 1),new DateTime(2013, 3, 15)
				  ,new DateTime(2013, 4, 1),new DateTime(2013, 4, 15),new DateTime(2013, 5, 1),new DateTime(2013, 5, 15),new DateTime(2013, 6, 1)
                  ,new DateTime(2013, 6, 15),new DateTime(2013, 7, 1),new DateTime(2013, 7, 15),new DateTime(2013, 8, 1),new DateTime(2013, 8, 15)
				  ,new DateTime(2013, 9, 1),new DateTime(2013, 9, 15),new DateTime(2013, 10, 1),new DateTime(2013, 10, 15)};

            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart1.Chart.Walls.Back.Visible = false;

            tChart1.Chart[0].Title = "Apples";
            tChart1.Chart[1].Title = "Pears";
            tChart1.Chart[2].Title = "Average";
            tChart1.Chart[0].Add(Xarr, Yarr1);
            tChart1.Chart[1].Add(Xarr, Yarr2);

            tChart1.Chart[0].XValues.DateTime = true;
            tChart1.Chart[1].XValues.DateTime = true;

            points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
            points2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
            points1.Pointer.Pen.Visible = false;
            points2.Pointer.Pen.Visible = false;

            line1.LinePen.Visible = false;
            line1.Legend.Visible = false;
            line1.CheckDataSource();

            line2.DataSource = line1;
            line2.Smoothed = true;
            line2.CheckDataSource();

            tChart1.Chart.Header.Font.Size = 16;
            tChart1.Chart.SubHeader.Font.Size = 10;
            tChart1.Chart.SubHeader.Alignment = TextAlignment.Start;
            tChart1.Chart.Axes.Left.StartPosition = 8;

            this.tChart1.Chart.Aspect.ZoomText = true;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
					tChart1
				}
            };
        }
	}
}


