using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesDemo
{
	public class PieSalesFigures : ContentPage
	{
        private Steema.TeeChart.Chart tChart1;
        private Steema.TeeChart.Chart tChart2;
        private Steema.TeeChart.Chart tChart3;
        private Steema.TeeChart.Styles.NumericGauge numericGauge1;
        private Steema.TeeChart.Styles.Pie pie1;
        private Steema.TeeChart.Styles.NumericGauge numericGauge2;

        public ChartView chartView1;
        public ChartView chartView2;
        public ChartView chartView3;
        public PieSalesFigures()
		{
            this.tChart3 = new Steema.TeeChart.Chart();
            this.numericGauge2 = new Steema.TeeChart.Styles.NumericGauge();
            this.tChart2 = new Steema.TeeChart.Chart();
            this.numericGauge1 = new Steema.TeeChart.Styles.NumericGauge();
            this.tChart1 = new Steema.TeeChart.Chart();
            this.pie1 = new Steema.TeeChart.Styles.Pie();
            // tChart3
            this.tChart3.Aspect.ColorPaletteIndex = 19;
            this.tChart3.Aspect.Elevation = 350;
            this.tChart3.Aspect.ElevationFloat = 350D;
            this.tChart3.Aspect.Perspective = 55;
            this.tChart3.Aspect.View3D = false;
            this.tChart3.Axes.Bottom.AxisPen.Visible = false;
            this.tChart3.Axes.Bottom.AxisPen.Width = 0;
            this.tChart3.Axes.Bottom.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart3.Axes.Bottom.Grid.Visible = false;
            this.tChart3.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart3.Axes.Bottom.Labels.Font.Name = "Verdana";
            this.tChart3.Axes.Bottom.Labels.Font.Size = 24;
            this.tChart3.Axes.Bottom.MinorTicks.Length = 1;
            this.tChart3.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart3.Axes.Bottom.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart3.Axes.Bottom.Ticks.Length = 20;
            this.tChart3.Axes.Bottom.Title.Font.Name = "Verdana";
            this.tChart3.Axes.Depth.Title.Font.Name = "Verdana";
            this.tChart3.Axes.Depth.Title.Font.Size = 13;
            this.tChart3.Axes.DepthTop.Title.Font.Name = "Verdana";
            this.tChart3.Axes.DepthTop.Title.Font.Size = 13;
            this.tChart3.Axes.Left.AxisPen.Visible = false;
            this.tChart3.Axes.Left.AxisPen.Width = 0;
            this.tChart3.Axes.Left.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart3.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart3.Axes.Left.Labels.Font.Name = "Verdana";
            this.tChart3.Axes.Left.Labels.Font.Size = 24;
            this.tChart3.Axes.Left.MinorTicks.Visible = false;
            this.tChart3.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart3.Axes.Left.Ticks.Length = 7;
            this.tChart3.Axes.Left.Title.Font.Name = "Verdana";
            this.tChart3.Axes.Right.AxisPen.Width = 0;
            this.tChart3.Axes.Right.Grid.Visible = false;
            this.tChart3.Axes.Right.Labels.Font.Brush.Color = Color.Gray;
            this.tChart3.Axes.Right.Labels.Font.Name = "Verdana";
            this.tChart3.Axes.Right.Labels.Font.Size = 31;
            this.tChart3.Axes.Right.MinorTicks.Visible = false;
            this.tChart3.Axes.Right.Ticks.Visible = false;
            this.tChart3.Axes.Right.Title.Font.Name = "Verdana";
            this.tChart3.Axes.Top.Title.Font.Name = "Verdana";
            this.tChart3.Footer.Font.Brush.Color = Color.Blue;
            this.tChart3.Header.Alignment = TextAlignment.Start;
            this.tChart3.Header.Font.Bold = true;
            this.tChart3.Header.Font.Brush.Color = Color.Black;
            this.tChart3.Header.Font.Name = "Verdana";
            this.tChart3.Header.Font.Shadow.Brush.Color = Color.Gray;
            this.tChart3.Header.Font.Shadow.SmoothBlur = 2;
            this.tChart3.Header.Font.Size = 47;
            this.tChart3.Header.Lines = new string[] {""};
            this.tChart3.Header.Visible = false;
            this.tChart3.Legend.Font.Name = "Verdana";
            this.tChart3.Legend.Font.Size = 19;
            this.tChart3.Legend.Pen.Visible = false;
            this.tChart3.Legend.Shadow.Visible = false;
            this.tChart3.Legend.Visible = false;
            this.tChart3.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart3.Panel.Bevel.Width = 2;
            this.tChart3.Panel.BevelWidth = 2;
            this.tChart3.Panel.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.tChart3.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Panel.Brush.Gradient.StartColor = Color.Silver;
            this.tChart3.Panel.Brush.Gradient.Visible = false;
            this.tChart3.Series.Add(this.numericGauge2);
            this.tChart3.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Walls.Back.Pen.Visible = false;
            this.tChart3.Walls.Bottom.Brush.Gradient.EndColor = Color.Silver;
            this.tChart3.Walls.Bottom.Brush.Gradient.StartColor = Color.Gray;
            this.tChart3.Walls.Bottom.Brush.Gradient.Visible = true;
            this.tChart3.Walls.Bottom.Pen.Color = Color.Gray;
            this.tChart3.Walls.Bottom.Transparent = true;
            this.tChart3.Walls.Left.Brush.Color = Color.White;
            this.tChart3.Walls.Left.Brush.Gradient.EndColor = Color.Silver;
            this.tChart3.Walls.Left.Brush.Gradient.StartColor = Color.Gray;
            this.tChart3.Walls.Left.Brush.Gradient.Visible = true;
            this.tChart3.Walls.Left.Pen.Color = Color.Gray;
            this.tChart3.Walls.Left.Transparent = true;
            this.tChart3.Walls.Right.Transparent = true;
            // numericGauge2
            this.numericGauge2.Color = Color.FromRgb(((int)(((byte)(229)))), ((int)(((byte)(181)))), ((int)(((byte)(51)))));
            this.numericGauge2.ColorEach = false;
            this.numericGauge2.ColorLineEndValues.Add(0D);
            this.numericGauge2.ColorLineEndValues.Add(0D);
            this.numericGauge2.ColorLineStartValues.Add(0D);
            this.numericGauge2.ColorLineStartValues.Add(0D);
            this.numericGauge2.Frame.Circled = false;
            this.numericGauge2.GaugeColorPalette = new Color[] {
        Color.FromRgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.FromRgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(10))))),
        Color.FromRgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))),
        Color.FromRgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))))};
            this.numericGauge2.GreenLine.Brush.Gradient.UseMiddle = false;
            this.numericGauge2.GreenLine.Position = 0;
            this.numericGauge2.GreenLine.SizeDouble = 0D;
            this.numericGauge2.GreenLine.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge2.GreenLine.Spiralled = false;
            this.numericGauge2.GreenLine.VertSize = 5;
            this.numericGauge2.GreenLine.Visible = true;
            this.numericGauge2.GreenLineEndValue = 0D;
            this.numericGauge2.GreenLineStartValue = 0D;
            this.numericGauge2.Hand.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(76)))));
            this.numericGauge2.Hand.Position = 0;
            this.numericGauge2.Hand.SizeDouble = 0D;
            this.numericGauge2.Hand.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge2.Hand.Spiralled = false;
            this.numericGauge2.Hand.Visible = true;
            this.numericGauge2.Legend.Visible = false;
            this.numericGauge2.Maximum = double.PositiveInfinity;
            this.numericGauge2.Minimum = 0D;
            this.numericGauge2.MinorTicks.Brush.Color = Color.Transparent;
            this.numericGauge2.MinorTicks.HorizSize = 1;
            this.numericGauge2.MinorTicks.Position = 0;
            this.numericGauge2.MinorTicks.SizeDouble = 0D;
            this.numericGauge2.MinorTicks.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge2.MinorTicks.Spiralled = false;
            this.numericGauge2.MinorTicks.VertSize = 1;
            this.numericGauge2.MinorTicks.Visible = true;
            this.numericGauge2.RedLine.Position = 0;
            this.numericGauge2.RedLine.SizeDouble = 0D;
            this.numericGauge2.RedLine.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge2.RedLine.Spiralled = false;
            this.numericGauge2.RedLine.VertSize = 5;
            this.numericGauge2.RedLine.Visible = true;
            this.numericGauge2.RedLineEndValue = 0D;
            this.numericGauge2.RedLineStartValue = 0D;
            this.numericGauge2.ShowInLegend = false;
            this.numericGauge2.Ticks.Brush.Color = Color.Transparent;
            this.numericGauge2.Ticks.Position = 0;
            this.numericGauge2.Ticks.SizeDouble = 0D;
            this.numericGauge2.Ticks.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge2.Ticks.Spiralled = false;
            this.numericGauge2.Ticks.VertSize = 20;
            this.numericGauge2.Ticks.Visible = true;
            this.numericGauge2.Title = "numericGauge1";
            this.numericGauge2.Value = 980.18847917215362D;
            this.numericGauge2.ValueFormat = "N";
            this.numericGauge2.XValues.DataMember = "X";
            this.numericGauge2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.numericGauge2.YValues.DataMember = "Y";
            // tChart2
            this.tChart2.Aspect.Chart3DPercent = 0;
            this.tChart2.Aspect.ClipPoints = false;
            this.tChart2.Aspect.ColorPaletteIndex = 19;
            this.tChart2.Aspect.Elevation = 350;
            this.tChart2.Aspect.ElevationFloat = 350D;
            this.tChart2.Aspect.Orthogonal = false;
            this.tChart2.Aspect.Perspective = 55;
            this.tChart2.Aspect.View3D = false;
            this.tChart2.Aspect.Zoom = 293;
            this.tChart2.Aspect.ZoomFloat = 293D;
            this.tChart2.Axes.Bottom.AxisPen.Visible = false;
            this.tChart2.Axes.Bottom.AxisPen.Width = 0;
            this.tChart2.Axes.Bottom.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart2.Axes.Bottom.Grid.Visible = false;
            this.tChart2.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart2.Axes.Bottom.Labels.Font.Name = "Verdana";
            this.tChart2.Axes.Bottom.Labels.Font.Size = 24;
            this.tChart2.Axes.Bottom.MinorTicks.Length = 1;
            this.tChart2.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart2.Axes.Bottom.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart2.Axes.Bottom.Ticks.Length = 20;
            this.tChart2.Axes.Bottom.Title.Font.Name = "Verdana";
            this.tChart2.Axes.Depth.Title.Font.Name = "Verdana";
            this.tChart2.Axes.Depth.Title.Font.Size = 13;
            this.tChart2.Axes.DepthTop.Title.Font.Name = "Verdana";
            this.tChart2.Axes.DepthTop.Title.Font.Size = 13;
            this.tChart2.Axes.Left.AxisPen.Visible = false;
            this.tChart2.Axes.Left.AxisPen.Width = 0;
            this.tChart2.Axes.Left.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart2.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart2.Axes.Left.Labels.Font.Name = "Verdana";
            this.tChart2.Axes.Left.Labels.Font.Size = 24;
            this.tChart2.Axes.Left.MinorTicks.Visible = false;
            this.tChart2.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart2.Axes.Left.Ticks.Length = 7;
            this.tChart2.Axes.Left.Title.Font.Name = "Verdana";
            this.tChart2.Axes.Right.AxisPen.Width = 0;
            this.tChart2.Axes.Right.Grid.Visible = false;
            this.tChart2.Axes.Right.Labels.Font.Brush.Color = Color.Gray;
            this.tChart2.Axes.Right.Labels.Font.Name = "Verdana";
            this.tChart2.Axes.Right.Labels.Font.Size = 31;
            this.tChart2.Axes.Right.MinorTicks.Visible = false;
            this.tChart2.Axes.Right.Ticks.Visible = false;
            this.tChart2.Axes.Right.Title.Font.Name = "Verdana";
            this.tChart2.Axes.Top.Title.Font.Name = "Verdana";
            this.tChart2.Axes.Visible = false;
            this.tChart2.Footer.Font.Brush.Color = Color.Blue;
            this.tChart2.Header.Alignment = TextAlignment.Start;
            this.tChart2.Header.Font.Bold = true;
            this.tChart2.Header.Font.Brush.Color = Color.Black;
            this.tChart2.Header.Font.Name = "Verdana";
            this.tChart2.Header.Font.Shadow.Brush.Color = Color.Gray;
            this.tChart2.Header.Font.Shadow.SmoothBlur = 2;
            this.tChart2.Header.Font.Size = 47;
            this.tChart2.Header.Lines = new string[] {""};
            this.tChart2.Header.Visible = false;
            this.tChart2.Legend.Font.Name = "Verdana";
            this.tChart2.Legend.Font.Size = 19;
            this.tChart2.Legend.Pen.Visible = false;
            this.tChart2.Legend.Shadow.Visible = false;
            this.tChart2.Legend.Visible = false;
            this.tChart2.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart2.Panel.Bevel.Width = 2;
            this.tChart2.Panel.BevelWidth = 2;
            this.tChart2.Panel.Brush.Color = Color.FromRgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.tChart2.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart2.Panel.Brush.Gradient.StartColor = Color.Silver;
            this.tChart2.Panel.Brush.Gradient.Visible = false;
            this.tChart2.Panel.MarginBottom = 0D;
            this.tChart2.Panel.MarginLeft = 0D;
            this.tChart2.Panel.MarginRight = 0D;
            this.tChart2.Panel.MarginTop = 0D;
            this.tChart2.Series.Add(this.numericGauge1);
            this.tChart2.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart2.Walls.Back.Pen.Visible = false;
            this.tChart2.Walls.Bottom.Brush.Gradient.EndColor = Color.Silver;
            this.tChart2.Walls.Bottom.Brush.Gradient.StartColor = Color.Gray;
            this.tChart2.Walls.Bottom.Brush.Gradient.Visible = true;
            this.tChart2.Walls.Bottom.Pen.Color = Color.Gray;
            this.tChart2.Walls.Bottom.Transparent = true;
            this.tChart2.Walls.Left.Brush.Color = Color.White;
            this.tChart2.Walls.Left.Brush.Gradient.EndColor = Color.Silver;
            this.tChart2.Walls.Left.Brush.Gradient.StartColor = Color.Gray;
            this.tChart2.Walls.Left.Brush.Gradient.Visible = true;
            this.tChart2.Walls.Left.Pen.Color = Color.Gray;
            this.tChart2.Walls.Left.Transparent = true;
            this.tChart2.Walls.Right.Transparent = true;
            this.tChart2.Walls.Visible = false;
            // numericGauge1
            this.numericGauge1.Color = Color.FromRgb(((int)(((byte)(229)))), ((int)(((byte)(181)))), ((int)(((byte)(51)))));
            this.numericGauge1.ColorEach = false;
            this.numericGauge1.ColorLineEndValues.Add(0D);
            this.numericGauge1.ColorLineEndValues.Add(0D);
            this.numericGauge1.ColorLineStartValues.Add(0D);
            this.numericGauge1.ColorLineStartValues.Add(0D);
            this.numericGauge1.Frame.Circled = false;
            this.numericGauge1.GaugeColorPalette = new Color[] {
        Color.FromRgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.FromRgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(30)))), ((int)(((byte)(200)))), ((int)(((byte)(30))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(200)))), ((int)(((byte)(115)))), ((int)(((byte)(60))))),
        Color.FromRgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(10))))),
        Color.FromRgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130))))),
        Color.FromRgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130))))),
        Color.Transparent,
        Color.FromRgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30))))),
        Color.FromRgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100))))),
        Color.FromRgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))))};
            //this.numericGauge1.GreenLine.Brush.Gradient.Sigma = true;
            //this.numericGauge1.GreenLine.Brush.Gradient.SigmaFocus = 0F;
            this.numericGauge1.GreenLine.Brush.Gradient.UseMiddle = false;
            this.numericGauge1.GreenLine.Position = 0;
            this.numericGauge1.GreenLine.SizeDouble = 0D;
            this.numericGauge1.GreenLine.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge1.GreenLine.Spiralled = false;
            this.numericGauge1.GreenLine.VertSize = 5;
            this.numericGauge1.GreenLine.Visible = true;
            this.numericGauge1.GreenLineEndValue = 0D;
            this.numericGauge1.GreenLineStartValue = 0D;
            this.numericGauge1.Hand.Brush.Color = Color.FromRgba(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(76)))));
            this.numericGauge1.Hand.Position = 0;
            this.numericGauge1.Hand.SizeDouble = 0D;
            this.numericGauge1.Hand.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge1.Hand.Spiralled = false;
            this.numericGauge1.Hand.Visible = true;
            this.numericGauge1.Legend.Visible = false;
            this.numericGauge1.Maximum = double.PositiveInfinity;
            this.numericGauge1.Minimum = 0D;
            this.numericGauge1.MinorTicks.Brush.Color = Color.Transparent;
            this.numericGauge1.MinorTicks.HorizSize = 1;
            this.numericGauge1.MinorTicks.Position = 0;
            this.numericGauge1.MinorTicks.SizeDouble = 0D;
            this.numericGauge1.MinorTicks.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge1.MinorTicks.Spiralled = false;
            this.numericGauge1.MinorTicks.VertSize = 1;
            this.numericGauge1.MinorTicks.Visible = true;
            this.numericGauge1.RedLine.Position = 0;
            this.numericGauge1.RedLine.SizeDouble = 0D;
            this.numericGauge1.RedLine.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge1.RedLine.Spiralled = false;
            this.numericGauge1.RedLine.VertSize = 5;
            this.numericGauge1.RedLine.Visible = true;
            this.numericGauge1.RedLineEndValue = 0D;
            this.numericGauge1.RedLineStartValue = 0D;
            this.numericGauge1.ShowInLegend = false;
            this.numericGauge1.Ticks.Brush.Color = Color.Transparent;
            this.numericGauge1.Ticks.Position = 0;
            this.numericGauge1.Ticks.SizeDouble = 0D;
            this.numericGauge1.Ticks.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.numericGauge1.Ticks.Spiralled = false;
            this.numericGauge1.Ticks.VertSize = 20;
            this.numericGauge1.Ticks.Visible = true;
            this.numericGauge1.Title = "numericGauge1";
            this.numericGauge1.Value = 478.53749267688835D;
            this.numericGauge1.ValueFormat = "N";
            this.numericGauge1.XValues.DataMember = "X";
            this.numericGauge1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.numericGauge1.YValues.DataMember = "Y";
            // tChart1
            this.tChart1.Aspect.ColorPaletteIndex = 19;
            this.tChart1.Aspect.Elevation = 315;
            this.tChart1.Aspect.ElevationFloat = 315D;
            this.tChart1.Aspect.Orthogonal = false;
            this.tChart1.Aspect.Perspective = 0;
            this.tChart1.Aspect.Rotation = 360;
            this.tChart1.Aspect.RotationFloat = 360D;
            this.tChart1.Aspect.View3D = false;
            this.tChart1.Axes.Bottom.AxisPen.Visible = false;
            this.tChart1.Axes.Bottom.AxisPen.Width = 0;
            this.tChart1.Axes.Bottom.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart1.Axes.Bottom.Grid.Visible = false;
            this.tChart1.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Axes.Bottom.Labels.Font.Name = "Verdana";
            this.tChart1.Axes.Bottom.Labels.Font.Size = 24;
            this.tChart1.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart1.Axes.Bottom.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Bottom.Title.Font.Name = "Verdana";
            this.tChart1.Axes.Depth.Title.Font.Name = "Verdana";
            this.tChart1.Axes.Depth.Title.Font.Size = 13;
            this.tChart1.Axes.DepthTop.Title.Font.Name = "Verdana";
            this.tChart1.Axes.DepthTop.Title.Font.Size = 13;
            this.tChart1.Axes.Left.AxisPen.Visible = false;
            this.tChart1.Axes.Left.AxisPen.Width = 0;
            this.tChart1.Axes.Left.Grid.Color = Color.FromRgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tChart1.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Axes.Left.Labels.Font.Name = "Verdana";
            this.tChart1.Axes.Left.Labels.Font.Size = 24;
            this.tChart1.Axes.Left.MinorTicks.Visible = false;
            this.tChart1.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Left.Ticks.Length = 7;
            this.tChart1.Axes.Left.Title.Font.Name = "Verdana";
            this.tChart1.Axes.Right.AxisPen.Width = 0;
            this.tChart1.Axes.Right.Grid.Visible = false;
            this.tChart1.Axes.Right.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Axes.Right.Labels.Font.Name = "Verdana";
            this.tChart1.Axes.Right.Labels.Font.Size = 31;
            this.tChart1.Axes.Right.MinorTicks.Visible = false;
            this.tChart1.Axes.Right.Ticks.Visible = false;
            this.tChart1.Axes.Right.Title.Font.Name = "Verdana";
            this.tChart1.Axes.Top.Title.Font.Name = "Verdana";
            this.tChart1.Footer.Font.Brush.Color = Color.Blue;
            this.tChart1.Header.Font.Brush.Color = Color.Silver;
            this.tChart1.Header.Font.Name = "Segoe UI";
            this.tChart1.Header.Font.Shadow.Brush.Color = Color.FromRgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.tChart1.Header.Font.Shadow.SmoothBlur = 2;
            this.tChart1.Header.Font.Size = 23;
            this.tChart1.Header.Lines = new string[] {"Percentage of world population"};
            this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart1.Legend.Font.Brush.Color = Color.Silver;
            this.tChart1.Legend.Font.Name = "Segoe UI";
            this.tChart1.Legend.Font.Size = 19;
            this.tChart1.Legend.Pen.Visible = false;
            this.tChart1.Legend.Shadow.Visible = false;
            this.tChart1.Legend.Transparent = true;
            this.tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart1.Panel.Bevel.Width = 2;
            this.tChart1.Panel.BevelWidth = 2;
            this.tChart1.Panel.Brush.Color = Color.White;
            this.tChart1.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Panel.Brush.Gradient.StartColor = Color.Silver;
            this.tChart1.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Panel.MarginRight = 18D;
            this.tChart1.Series.Add(this.pie1);
            this.tChart1.SubHeader.Font.Brush.Color = Color.Silver;
            this.tChart1.SubHeader.Font.Name = "Segoe UI";
            this.tChart1.SubHeader.Font.Shadow.Brush.Color = Color.Gray;
            this.tChart1.SubHeader.Font.Size = 14;
            this.tChart1.SubHeader.Lines = new string[] {"actively using social media"};
            this.tChart1.SubHeader.Visible = true;
            this.tChart1.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Walls.Back.Pen.Visible = false;
            this.tChart1.Walls.Bottom.Brush.Gradient.EndColor = Color.Silver;
            this.tChart1.Walls.Bottom.Brush.Gradient.StartColor = Color.Gray;
            this.tChart1.Walls.Bottom.Brush.Gradient.Visible = true;
            this.tChart1.Walls.Bottom.Pen.Color = Color.Gray;
            this.tChart1.Walls.Bottom.Transparent = true;
            this.tChart1.Walls.Left.Brush.Color = Color.White;
            this.tChart1.Walls.Left.Brush.Gradient.EndColor = Color.Silver;
            this.tChart1.Walls.Left.Brush.Gradient.StartColor = Color.Gray;
            this.tChart1.Walls.Left.Brush.Gradient.Visible = true;
            this.tChart1.Walls.Left.Pen.Color = Color.Gray;
            this.tChart1.Walls.Left.Transparent = true;
            this.tChart1.Walls.Right.Transparent = true;
            // pie1
            this.pie1.Brush.Color = Color.FromRgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.pie1.Circled = true;
            this.pie1.Color = Color.FromRgb(((int)(((byte)(229)))), ((int)(((byte)(181)))), ((int)(((byte)(51)))));
            this.pie1.Frame.Circled = true;
            this.pie1.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.pie1.Frame.OuterBand.Gradient.UseMiddle = false;
            this.pie1.LabelMember = "Labels";
            this.pie1.Marks.Arrow.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pie1.Marks.Brush.Color = Color.FromRgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.pie1.Marks.Font.Brush.Color = Color.FromRgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.pie1.Marks.Font.Name = "Segoe UI";
            this.pie1.Marks.Font.Size = 14;
            this.pie1.Marks.FontSeriesColor = true;
            this.pie1.Marks.Pen.Visible = false;
            this.pie1.Marks.Shadow.Visible = false;
            this.pie1.Marks.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
            this.pie1.MarksPie.LegSize = 0;
            this.pie1.MarksPie.VertCenter = false;
            this.pie1.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.pie1.OtherSlice.Color = Color.Transparent;
            this.pie1.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.pie1.OtherSlice.Text = "";
            this.pie1.OtherSlice.Value = 0D;
            this.pie1.Title = "pie1";
            this.pie1.UniqueCustomRadius = true;
            this.pie1.XValues.DataMember = "Angle";
            this.pie1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.pie1.YValues.DataMember = "Pie";
            this.tChart1.Panel.Color = Color.FromRgb(0, 0, 230);

            pie1.Add(19, "Facebook");
            pie1.Add(14, "Tencent");
            pie1.Add(9, "WhatsApp");
            pie1.Add(5, "LinkedIn");
            pie1.Add(4, "Twitter");

            pie1.MarksPie.LegSize = 20;
            pie1.Marks.FontSeriesColor = true;

            tChart2.Panel.Gradient.Visible = false;
            tChart3.Panel.Gradient.Visible = false;

            //numericGauges
            setGauge(numericGauge1);
            numericGauge1.Markers[1].Text = "Highest";
            numericGauge1.Markers[2].Text = "Facebook";

            setGauge(numericGauge2);
            numericGauge2.Markers[1].Text = "Lowest";
            numericGauge2.Markers[2].Text = "Twitter";

            this.tChart1.Aspect.ZoomText = true;
            this.tChart2.Aspect.ZoomText = true;
            this.tChart3.Aspect.ZoomText = true;

            chartView1 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 25,
                HeightRequest = 25
            };
            chartView1.Model = tChart1;

            chartView2 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 25,
                HeightRequest = 25
            };
            chartView2.Model = tChart2;

            chartView3 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 25,
                HeightRequest = 25
            };
            chartView3.Model = tChart3;

            Content = new StackLayout
            {
                Children = {
					chartView1
				}
            };
        }

        private void setGauge(Steema.TeeChart.Styles.NumericGauge nGauge)
        {
            nGauge.FaceBrush.Transparency = 100;

            foreach (Steema.TeeChart.Tools.Marker mark in nGauge.Markers)
            {
                mark.UsePalette = false;
                mark.Shape.Font.Name = "Segoe UI";
            }

            nGauge.Markers[0].Shape.Font.Color = Color.White;
            nGauge.Markers[0].Shape.Transparent = true;
            nGauge.Markers[0].Shape.Font.Bold = false;
            nGauge.Markers[0].Shape.Font.Size = 55;
            nGauge.Markers[0].Left = 35;
            nGauge.Markers[0].Top = 5;

            nGauge.Markers[1].Shape.Font.Color = Color.FromRgb(70, 95, 152);
            nGauge.Markers[1].Shape.Font.Bold = false;
            nGauge.Markers[1].Shape.Font.Size = 11;
            nGauge.Markers[1].Left = 5;
            nGauge.Markers[1].Top = 5;

            nGauge.Markers[2].Shape.Color = Color.White;
            nGauge.Markers[2].Shape.Font.Color = Color.White;
            nGauge.Markers[2].Shape.Font.Brush.Color = Color.White;
            nGauge.Markers[2].Shape.Transparent = true;
            nGauge.Markers[2].Shape.Font.Size = 16;
            nGauge.Markers[2].Left = 186;
            nGauge.Markers[2].Top = 80;
        }
	}
}


