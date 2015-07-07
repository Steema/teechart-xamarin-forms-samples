using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesDemo
{
	public class WebAnalytics : ContentPage
	{
        private Steema.TeeChart.Chart tChart1;
        private Steema.TeeChart.Chart tChart3;
        private Steema.TeeChart.Chart tChart2;
        private Steema.TeeChart.Chart tChart4;
        private Steema.TeeChart.Styles.Donut donut3;
        private Steema.TeeChart.Tools.Annotation annotation3;
        private Steema.TeeChart.Styles.Donut donut2;
        private Steema.TeeChart.Tools.Annotation annotation2;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.Line line2;
        private Steema.TeeChart.Styles.Line line3;
        private Steema.TeeChart.Tools.CursorTool cursorTool1;
        private Steema.TeeChart.Tools.Annotation annotation4;
        private Steema.TeeChart.Tools.CursorTool cursorTool2;
        private Steema.TeeChart.Tools.Annotation annotation6;
        private Steema.TeeChart.Tools.CursorTool cursorTool3;
        private Steema.TeeChart.Tools.Annotation annotation8;
        private Steema.TeeChart.Styles.Donut donut1;
        private Steema.TeeChart.Tools.Annotation annotation1;
        private Steema.TeeChart.Data.TextSource textSource1;
        private double xVal;

        public ChartView chartView1;
        public ChartView chartView2;
        public ChartView chartView3;
        public ChartView chartView4;
		public WebAnalytics ()
		{
              this.tChart3 = new Steema.TeeChart.Chart();
              this.donut3 = new Steema.TeeChart.Styles.Donut();
              this.annotation3 = new Steema.TeeChart.Tools.Annotation();
              this.tChart2 = new Steema.TeeChart.Chart();
              this.donut2 = new Steema.TeeChart.Styles.Donut();
              this.annotation2 = new Steema.TeeChart.Tools.Annotation();
              this.tChart4 = new Steema.TeeChart.Chart();
              this.line1 = new Steema.TeeChart.Styles.Line();
              this.line2 = new Steema.TeeChart.Styles.Line();
              this.line3 = new Steema.TeeChart.Styles.Line();
              this.cursorTool1 = new Steema.TeeChart.Tools.CursorTool();
              this.annotation4 = new Steema.TeeChart.Tools.Annotation();
              this.cursorTool2 = new Steema.TeeChart.Tools.CursorTool();
              this.annotation6 = new Steema.TeeChart.Tools.Annotation();
              this.cursorTool3 = new Steema.TeeChart.Tools.CursorTool();
              this.annotation8 = new Steema.TeeChart.Tools.Annotation();
              this.tChart1 = new Steema.TeeChart.Chart();
              this.donut1 = new Steema.TeeChart.Styles.Donut();
              this.annotation1 = new Steema.TeeChart.Tools.Annotation();
              this.textSource1 = new Steema.TeeChart.Data.TextSource();

              // tChart3
              this.tChart3.Aspect.Elevation = 315;
              this.tChart3.Aspect.Orthogonal = false;
              this.tChart3.Aspect.Perspective = 0;
              this.tChart3.Aspect.Rotation = 360;
              this.tChart3.Aspect.View3D = false;
              this.tChart3.Footer.Font.Brush.Color = Color.Gray;
              this.tChart3.Header.Visible = false;
              this.tChart3.Legend.Visible = false;
              this.tChart3.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
              this.tChart3.Panel.Brush.Color = Color.White;
              this.tChart3.Panel.Brush.Gradient.EndColor = Color.White;
              this.tChart3.Panel.Brush.Gradient.UseMiddle = false;
              this.tChart3.Series.Add(this.donut3);
              this.tChart3.Tools.Add(this.annotation3);
              this.tChart3.Walls.Back.Brush.Gradient.EndColor = Color.White;

              // donut3
              this.donut3.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
              this.donut3.Circled = true;
              this.donut3.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
              this.donut3.DonutPercent = 95;
              this.donut3.Frame.Circled = true;
              this.donut3.Frame.FrameElementPercents = new double[] {
                25D,
                60D,
                15D};
              this.donut3.Frame.OuterBand.Gradient.UseMiddle = false;
              this.donut3.LabelMember = "Labels";
              this.donut3.Marks.Visible = false;
              this.donut3.MarksPie.LegSize = 0;
              this.donut3.MarksPie.VertCenter = false;
              this.donut3.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
              this.donut3.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
              this.donut3.OtherSlice.Text = "";
              this.donut3.OtherSlice.Value = 0D;
              this.donut3.RotationAngle = 180;
              this.donut3.Shadow.Height = 3;
              this.donut3.Shadow.Width = 3;
              this.donut3.Title = "Series0";
              this.donut3.UniqueCustomRadius = true;
              this.donut3.XValues.DataMember = "Angle";
              this.donut3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.donut3.YValues.DataMember = "Pie";

              // annotation3
              this.annotation3.AutoSize = true;
              this.annotation3.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation3.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation3.Callout.ArrowHeadSize = 8;
              this.annotation3.Callout.Brush.Color = Color.Black;
              this.annotation3.Callout.Distance = 0;
              this.annotation3.Callout.Draw3D = false;
              this.annotation3.Callout.SizeDouble = 0D;
              this.annotation3.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation3.Callout.XPosition = 0;
              this.annotation3.Callout.YPosition = 0;
              this.annotation3.Callout.ZPosition = 0;
              this.annotation3.Position = Steema.TeeChart.Tools.AnnotationPositions.Center;
              this.annotation3.Shape.Font.Name = "Segoe UI";
              this.annotation3.Shape.Font.Size = 29;
              this.annotation3.Shape.Lines = new string[] {"$1500"};
              this.annotation3.Shape.Transparent = true;
              this.annotation3.Text = "$1500";

              // tChart2
              this.tChart2.Aspect.Elevation = 315;
              this.tChart2.Aspect.Orthogonal = false;
              this.tChart2.Aspect.Perspective = 0;
              this.tChart2.Aspect.Rotation = 360;
              this.tChart2.Aspect.View3D = false;
              this.tChart2.Footer.Font.Brush.Color = Color.Gray;
              this.tChart2.Header.Visible = false;
              this.tChart2.Legend.Visible = false;
              this.tChart2.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
              this.tChart2.Panel.Brush.Color = Color.White;
              this.tChart2.Panel.Brush.Gradient.EndColor = Color.White;
              this.tChart2.Panel.Brush.Gradient.UseMiddle = false;
              this.tChart2.Series.Add(this.donut2);
              this.tChart2.Tools.Add(this.annotation2);
              this.tChart2.Walls.Back.Brush.Gradient.EndColor = Color.White;

              // donut2
              this.donut2.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
              this.donut2.Circled = true;
              this.donut2.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
              this.donut2.DonutPercent = 95;
              this.donut2.Frame.Circled = true;
              this.donut2.Frame.FrameElementPercents = new double[] {
                25D,
                60D,
                15D};
              this.donut2.Frame.OuterBand.Gradient.UseMiddle = false;
              this.donut2.LabelMember = "Labels";
              this.donut2.Marks.Visible = false;
              this.donut2.MarksPie.LegSize = 0;
              this.donut2.MarksPie.VertCenter = false;
              this.donut2.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
              this.donut2.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
              this.donut2.OtherSlice.Text = "";
              this.donut2.OtherSlice.Value = 0D;
              this.donut2.RotationAngle = 247;
              this.donut2.Shadow.Height = 3;
              this.donut2.Shadow.Width = 3;
              this.donut2.Title = "Series0";
              this.donut2.UniqueCustomRadius = true;
              this.donut2.XValues.DataMember = "Angle";
              this.donut2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.donut2.YValues.DataMember = "Pie";
              // annotation2
              this.annotation2.AutoSize = true;
              this.annotation2.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation2.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation2.Callout.ArrowHeadSize = 8;
              this.annotation2.Callout.Brush.Color = Color.Black;
              this.annotation2.Callout.Distance = 0;
              this.annotation2.Callout.Draw3D = false;
              this.annotation2.Callout.SizeDouble = 0D;
              this.annotation2.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation2.Callout.XPosition = 0;
              this.annotation2.Callout.YPosition = 0;
              this.annotation2.Callout.ZPosition = 0;
              this.annotation2.Position = Steema.TeeChart.Tools.AnnotationPositions.Center;
              this.annotation2.Shape.Font.Name = "Segoe UI";
              this.annotation2.Shape.Font.Size = 29;
              this.annotation2.Shape.Lines = new string[] {"3390"};
              this.annotation2.Shape.Transparent = true;
              this.annotation2.Text = "3390";

              // tChart4
              this.tChart4.Aspect.View3D = false;
              this.tChart4.Axes.Bottom.MinorTicks.Visible = false;
              this.tChart4.Axes.Left.Grid.Visible = false;
              this.tChart4.Axes.Left.Increment = 20D;
              this.tChart4.Axes.Left.MinorTicks.Visible = false;
              this.tChart4.Footer.Font.Brush.Color = Color.Blue;
              this.tChart4.Header.Visible = false;
              this.tChart4.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
              this.tChart4.Legend.Transparent = true;
              this.tChart4.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
              this.tChart4.Panel.Brush.Color = Color.White;
              this.tChart4.Panel.Brush.Gradient.EndColor = Color.White;
              this.tChart4.Panel.Brush.Gradient.UseMiddle = false;
              this.tChart4.Series.Add(this.line1);
              this.tChart4.Series.Add(this.line2);
              this.tChart4.Series.Add(this.line3);
              this.tChart4.Tools.Add(this.cursorTool1);
              this.tChart4.Tools.Add(this.annotation4);
              this.tChart4.Tools.Add(this.cursorTool2);
              this.tChart4.Tools.Add(this.annotation6);
              this.tChart4.Tools.Add(this.cursorTool3);
              this.tChart4.Tools.Add(this.annotation8);
              this.tChart4.Walls.Back.Brush.Gradient.EndColor = Color.White;
              this.tChart4.Walls.Back.Visible = false;
              this.tChart4.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart4_AfterDraw);

              // line1
              this.line1.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
              this.line1.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
              this.line1.ColorEach = false;
              this.line1.ColorMember = "Colors";
              this.line1.LinePen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
              this.line1.LinePen.Width = 4;
              this.line1.Pointer.Pen.Visible = false;
              this.line1.Pointer.SizeDouble = 0D;
              this.line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
              this.line1.Title = "Speed";
              this.line1.XValues.DataMember = "X";
              this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.line1.YValues.DataMember = "Y";

              // line2
              this.line2.Brush.Color = Color.FromRgb(((int)(((byte)(6)))), ((int)(((byte)(191)))), ((int)(((byte)(89)))));
              this.line2.Color = Color.FromRgb(((int)(((byte)(6)))), ((int)(((byte)(191)))), ((int)(((byte)(89)))));
              this.line2.ColorEach = false;
              this.line2.LinePen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
              this.line2.LinePen.Width = 4;
              this.line2.Pointer.Pen.Visible = false;
              this.line2.Pointer.SizeDouble = 0D;
              this.line2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
              this.line2.Title = "Time";
              this.line2.XValues.DataMember = "X";
              this.line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.line2.YValues.DataMember = "Y";

              // line3
              this.line3.Brush.Color = Color.FromRgb(((int)(((byte)(238)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
              this.line3.Color = Color.FromRgb(((int)(((byte)(238)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
              this.line3.ColorEach = false;
              this.line3.ColorMember = "Colors";
              this.line3.LinePen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
              this.line3.LinePen.Width = 4;
              this.line3.Pointer.Pen.Visible = false;
              this.line3.Pointer.SizeDouble = 0D;
              this.line3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.line3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
              this.line3.Title = "Visitors";
              this.line3.XValues.DataMember = "X";
              this.line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.line3.YValues.DataMember = "Y";

              // cursorTool1
              this.cursorTool1.FollowMouse = true;
              this.cursorTool1.Pen.Color = Color.Gray;
              this.cursorTool1.Series = this.line1;
              this.cursorTool1.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;
              this.cursorTool1.Change += new Steema.TeeChart.Tools.CursorChangeEventHandler(this.cursorTool1_Change);

              // annotation4
              this.annotation4.AutoSize = true;
              this.annotation4.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation4.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation4.Callout.ArrowHeadSize = 8;
              this.annotation4.Callout.Brush.Color = Color.Black;
              this.annotation4.Callout.Distance = 0;
              this.annotation4.Callout.Draw3D = false;
              this.annotation4.Callout.SizeDouble = 0D;
              this.annotation4.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation4.Callout.XPosition = 0;
              this.annotation4.Callout.YPosition = 0;
              this.annotation4.Callout.ZPosition = 0;
              this.annotation4.Left = 56;
              this.annotation4.Shape.Bottom = 212;
              this.annotation4.Shape.Brush.Color = Color.FromRgb(((int)(((byte)(238)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
              this.annotation4.Shape.CustomPosition = true;
              this.annotation4.Shape.Font.Brush.Color = Color.White;
              this.annotation4.Shape.Left = 56;
              this.annotation4.Shape.Lines = new string[] {"0"};
              this.annotation4.Shape.Pen.Visible = false;
              this.annotation4.Shape.Right = 75;
              this.annotation4.Shape.Shadow.Visible = false;
              this.annotation4.Shape.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
              this.annotation4.Shape.Top = 194;
              this.annotation4.Shape.Visible = false;
              this.annotation4.Text = "0";
              this.annotation4.Top = 194;

              // cursorTool2
              this.cursorTool2.FollowMouse = true;
              this.cursorTool2.Pen.Color = Color.Gray;
              this.cursorTool2.Series = this.line2;
              this.cursorTool2.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;

              // annotation6
              this.annotation6.AutoSize = true;
              this.annotation6.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation6.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation6.Callout.ArrowHeadSize = 8;
              this.annotation6.Callout.Brush.Color = Color.Black;
              this.annotation6.Callout.Distance = 0;
              this.annotation6.Callout.Draw3D = false;
              this.annotation6.Callout.SizeDouble = 0D;
              this.annotation6.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation6.Callout.XPosition = 0;
              this.annotation6.Callout.YPosition = 0;
              this.annotation6.Callout.ZPosition = 0;
              this.annotation6.Left = -19;
              this.annotation6.Shape.Bottom = 212;
              this.annotation6.Shape.Brush.Color = Color.FromRgb(((int)(((byte)(238)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
              this.annotation6.Shape.CustomPosition = true;
              this.annotation6.Shape.Font.Brush.Color = Color.White;
              this.annotation6.Shape.Left = -19;
              this.annotation6.Shape.Lines = new string[] {"-0,458"};
              this.annotation6.Shape.Pen.Visible = false;
              this.annotation6.Shape.Right = 29;
              this.annotation6.Shape.Shadow.Visible = false;
              this.annotation6.Shape.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
              this.annotation6.Shape.Top = 194;
              this.annotation6.Shape.Visible = false;
              this.annotation6.Text = "-0,458";
              this.annotation6.TextAlign = TextAlignment.Center;
              this.annotation6.Top = 194;

              // cursorTool3
              this.cursorTool3.FollowMouse = true;
              this.cursorTool3.Pen.Color = Color.Gray;
              this.cursorTool3.Series = this.line3;
              this.cursorTool3.Style = Steema.TeeChart.Tools.CursorToolStyles.Vertical;

              // annotation8
              this.annotation8.AutoSize = true;
              this.annotation8.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation8.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation8.Callout.ArrowHeadSize = 8;
              this.annotation8.Callout.Brush.Color = Color.Black;
              this.annotation8.Callout.Distance = 0;
              this.annotation8.Callout.Draw3D = false;
              this.annotation8.Callout.SizeDouble = 0D;
              this.annotation8.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation8.Callout.XPosition = 0;
              this.annotation8.Callout.YPosition = 0;
              this.annotation8.Callout.ZPosition = 0;
              this.annotation8.Left = -19;
              this.annotation8.Shape.Bottom = 212;
              this.annotation8.Shape.Brush.Color = Color.FromRgb(((int)(((byte)(238)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
              this.annotation8.Shape.CustomPosition = true;
              this.annotation8.Shape.Font.Brush.Color = Color.White;
              this.annotation8.Shape.Left = -19;
              this.annotation8.Shape.Lines = new string[] {"-0,458"};
              this.annotation8.Shape.Pen.Visible = false;
              this.annotation8.Shape.Right = 29;
              this.annotation8.Shape.Shadow.Visible = false;
              this.annotation8.Shape.ShapeStyle = Steema.TeeChart.Drawing.TextShapeStyle.RoundRectangle;
              this.annotation8.Shape.Top = 194;
              this.annotation8.Shape.Visible = false;
              this.annotation8.Text = "-0,458";
              this.annotation8.TextAlign = TextAlignment.Center;
              this.annotation8.Top = 194;

              // tChart1
              this.tChart1.Aspect.Elevation = 315;
              this.tChart1.Aspect.Orthogonal = false;
              this.tChart1.Aspect.Perspective = 0;
              this.tChart1.Aspect.Rotation = 360;
              this.tChart1.Aspect.View3D = false;
              this.tChart1.Footer.Font.Brush.Color = Color.Gray;
              this.tChart1.Header.Visible = false;
              this.tChart1.Legend.Visible = false;
              this.tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
              this.tChart1.Panel.Brush.Color = Color.White;
              this.tChart1.Panel.Brush.Gradient.EndColor = Color.White;
              this.tChart1.Panel.Brush.Gradient.UseMiddle = false;
              this.tChart1.Series.Add(this.donut1);
              this.tChart1.Tools.Add(this.annotation1);
              this.tChart1.Walls.Back.Brush.Gradient.EndColor = Color.White;

              // donut1
              this.donut1.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
              this.donut1.Circled = true;
              this.donut1.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
              this.donut1.DonutPercent = 95;
              this.donut1.Frame.Circled = true;
              this.donut1.Frame.FrameElementPercents = new double[] {
                25D,
                60D,
                15D};
              this.donut1.Frame.OuterBand.Gradient.UseMiddle = false;
              this.donut1.LabelMember = "Labels";
              this.donut1.Marks.Visible = false;
              this.donut1.MarksPie.LegSize = 0;
              this.donut1.MarksPie.VertCenter = false;
              this.donut1.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
              this.donut1.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
              this.donut1.OtherSlice.Text = "";
              this.donut1.OtherSlice.Value = 0D;
              this.donut1.RotationAngle = 180;
              this.donut1.Shadow.Height = 3;
              this.donut1.Shadow.Width = 3;
              this.donut1.Title = "Series0";
              this.donut1.UniqueCustomRadius = true;
              this.donut1.XValues.DataMember = "Angle";
              this.donut1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
              this.donut1.YValues.DataMember = "Pie";

              // annotation1
              this.annotation1.AutoSize = true;
              this.annotation1.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
              this.annotation1.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
              this.annotation1.Callout.ArrowHeadSize = 8;
              this.annotation1.Callout.Brush.Color = Color.Black;
              this.annotation1.Callout.Distance = 0;
              this.annotation1.Callout.Draw3D = false;
              this.annotation1.Callout.SizeDouble = 0D;
              this.annotation1.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
              this.annotation1.Callout.XPosition = 0;
              this.annotation1.Callout.YPosition = 0;
              this.annotation1.Callout.ZPosition = 0;
              this.annotation1.Position = Steema.TeeChart.Tools.AnnotationPositions.Center;
              this.annotation1.Shape.Font.Name = "Segoe UI";
              this.annotation1.Shape.Font.Size = 29;
              this.annotation1.Shape.Lines = new string[] {"$750"};
              this.annotation1.Shape.Transparent = true;
              this.annotation1.Text = "$750";

              tChart1.Panel.Gradient.Visible = false;
              tChart2.Panel.Gradient.Visible = false;
              tChart3.Panel.Gradient.Visible = false;
              tChart4.Panel.Gradient.Visible = false;

              donut1.Clear();
              donut1.Add(750, Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163))))));
              donut1.Add(250, Color.Transparent);
              donut1.Pen.Visible = false;

              donut2.Clear();
              donut2.Add(3390, Color.Green);
              donut2.Add(2510, Color.Transparent);
              donut2.Pen.Visible = false;

              donut3.Clear();
              donut3.Add(1500, Color.Red);
              donut3.Add(500, Color.Transparent);
              donut3.Pen.Visible = false;
              donut3.Pen.Color = Color.White;

              double[] vals1 = new double[] { 220, 150, 135, 190, 210, 200 };
              double[] vals2 = new double[] { 100, 70, 100, 150, 110, 24 };
              double[] vals3 = new double[] { 100, 130, 80, 130, 126, 240 };

              line1.Smoothed = true;
              line2.Smoothed = true;
              line3.Smoothed = true;
              line1.Add(vals1);
              line2.Add(vals2);
              line3.Add(vals3);

              annotation4.Shape.Font.Brush.Color = line1.Color;
              annotation6.Shape.Font.Brush.Color = line2.Color;
              annotation8.Shape.Font.Brush.Color = line3.Color;
              cursorTool1_Change(tChart4, new Steema.TeeChart.Tools.CursorChangeEventArgs());

              this.tChart1.Aspect.ZoomText = true;
              this.tChart2.Aspect.ZoomText = true;
              this.tChart3.Aspect.ZoomText = true;
              this.tChart4.Aspect.ZoomText = true;


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

            chartView4 = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 25,
                HeightRequest = 25
            };
            chartView4.Model = tChart4;

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 5,
                RowDefinitions = 
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }
            };

            grid.Children.Add(chartView1, 0, 0);
            grid.Children.Add(chartView2, 1, 0);
            grid.Children.Add(chartView3, 2, 0);
            grid.Children.Add(chartView4, 0, 3, 1, 2);

            // Build the page.
            this.Content = grid;
        }

        private void cursorTool1_Change(object sender, Steema.TeeChart.Tools.CursorChangeEventArgs e)
        {
            xVal = e.XValue;

            annotation4.Text = line1.Title + ": Y(" + e.XValue.ToString("0.00") + ")= ";
            annotation4.Text += InterpolateLineSeries(line1 as Steema.TeeChart.Styles.Custom, e.XValue).ToString("0.00") + "\r\n";
            annotation4.Left = e.x + 10;
            annotation4.Top = tChart4.Axes.Left.IStartPos;

            annotation6.Text = line2.Title + ": Y(" + e.XValue.ToString("0.00") + ")= ";
            annotation6.Text += InterpolateLineSeries(line2 as Steema.TeeChart.Styles.Custom, e.XValue).ToString("0.00") + "\r\n";
            annotation6.Left = e.x + 10;
            annotation6.Top = tChart4.Axes.Left.IStartPos + 18;

            annotation8.Text = line3.Title + ": Y(" + e.XValue.ToString("0.00") + ")= ";
            annotation8.Text += InterpolateLineSeries(line3 as Steema.TeeChart.Styles.Custom, e.XValue).ToString("0.00") + "\r\n";
            annotation8.Left = e.x + 10;
            annotation8.Top = tChart4.Axes.Left.IStartPos + 36;
        }

        private double InterpolateLineSeries(Steema.TeeChart.Styles.Custom series, double xvalue)
        {
            return InterpolateLineSeries(series, series.FirstVisibleIndex, series.LastVisibleIndex, xvalue);
        }

        /// <summary>
        /// Calculate y=y(x) for arbitrary x. Works fine only for line series with ordered x values.
        /// </summary>
        /// <param name="series"></param>
        /// <param name="firstindex"></param>
        /// <param name="lastindex"></param>
        /// <param name="xvalue"></param>
        /// <returns>y=y(xvalue) where xvalue is arbitrary x value.</returns>
        private double InterpolateLineSeries(Steema.TeeChart.Styles.Custom series, int firstindex, int lastindex, double xvalue)
        {
            int index;
            for (index = firstindex; index <= lastindex; index++)
            {
                if (index == -1 || series.XValues.Value[index] > xvalue) break;
            }
            // safeguard
            if (index < 1) index = 1;
            else if (index >= series.Count) index = series.Count - 1;
            // y=(y2-y1)/(x2-x1)*(x-x1)+y1
            double dx = series.XValues[index] - series.XValues[index - 1];
            double dy = series.YValues[index] - series.YValues[index - 1];
            if (dx != 0.0) return dy * (xvalue - series.XValues[index - 1]) / dx + series.YValues[index - 1];
            else return 0.0;
        }

        int posRepainted = 0;
        private void tChart4_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (posRepainted == 0)
            {
                posRepainted = 1;
                tChart4.Invalidate();
            }
            //setup centre positions of titles on chart
            //relative to their text lengths
            tChart1.Invalidate();
            tChart2.Invalidate();
            tChart3.Invalidate();
            posRepainted = 2;

            {
                int xs = Utils.Round(tChart4.Axes.Bottom.CalcXPosValue(xVal));
                int ys;
                g.Brush.Visible = true;
                g.Brush.Solid = true;
                for (int i = 0; i < tChart4.Series.Count; i++)
                    if (tChart4.Series[i] is Steema.TeeChart.Styles.Custom)
                    {
                        ys = Utils.Round(tChart4.Series[i].GetVertAxis.CalcYPosValue(InterpolateLineSeries(tChart4.Series[i] as Steema.TeeChart.Styles.Custom, xVal)));
                        g.Brush.Color = tChart4.Series[i].Color;
                        g.Ellipse(new Rectangle(xs - 4, ys - 4, 8, 8));
                    }
            }
        }
	}
}