using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
	public class MultiPies : ContentPage
    {        
        private ChartView tChart3;
        private ChartView tChart2;
        private ChartView tChart1;
        private ChartView tChart4;
        private Label label1;
        private ChartView tChart6;
        private ChartView tChart5;
        private ChartView tChart7;
        private Steema.TeeChart.Styles.Bar bar3;
        private Steema.TeeChart.Styles.Bar bar2;
        private Steema.TeeChart.Styles.Pie pie3;
        private Steema.TeeChart.Styles.Pie pie2;
        private Steema.TeeChart.Styles.Pie pie1;
        private Steema.TeeChart.Styles.Bar bar4;
        private Steema.TeeChart.Styles.Bar bar5;
        private Steema.TeeChart.Styles.Bar bar1;

        public MultiPies()
		{
            this.Title = "Multi Pies";

            this.tChart6 = new ChartView();
            this.bar3 = new Steema.TeeChart.Styles.Bar();
            this.tChart5 = new ChartView();
            this.bar2 = new Steema.TeeChart.Styles.Bar();
            this.tChart4 = new ChartView();
            this.tChart3 = new ChartView();
            this.pie3 = new Steema.TeeChart.Styles.Pie();
            this.tChart2 = new ChartView();
            this.pie2 = new Steema.TeeChart.Styles.Pie();
            this.tChart1 = new ChartView();
            this.pie1 = new Steema.TeeChart.Styles.Pie();
            this.tChart7 = new ChartView();
            this.bar4 = new Steema.TeeChart.Styles.Bar();
            this.bar5 = new Steema.TeeChart.Styles.Bar();
            this.label1 = new Label();
            this.bar1 = new Steema.TeeChart.Styles.Bar();
            // tChart6
            this.tChart6.Chart.Aspect.Elevation = 315;
            this.tChart6.Chart.Aspect.ElevationFloat = 315D;
            this.tChart6.Chart.Aspect.Orthogonal = false;
            this.tChart6.Chart.Aspect.Perspective = 0;
            this.tChart6.Chart.Aspect.Rotation = 360;
            this.tChart6.Chart.Aspect.RotationFloat = 360D;
            this.tChart6.Chart.Aspect.View3D = false;
            this.tChart6.Chart.Axes.Bottom.Visible = false;
            this.tChart6.Chart.Axes.Left.AxisPen.Color = Color.FromRgb(((int)(((byte)(192)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.tChart6.Chart.Axes.Left.AxisPen.Width = 1;
            this.tChart6.Chart.Axes.Left.Grid.Visible = false;
            this.tChart6.Chart.Axes.Left.Increment = 20D;
            this.tChart6.Chart.Axes.Left.Labels.Font.Brush.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tChart6.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart6.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart6.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart6.Chart.Header.Lines = new string[] {"Evening Class"};
            this.tChart6.Chart.Header.Visible = false;
            this.tChart6.Chart.Legend.Visible = false;
            this.tChart6.Chart.Panel.Brush.Color = Color.White;
            this.tChart6.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart6.Chart.Panel.MarginBottom = 6D;
            this.tChart6.Chart.Series.Add(this.bar3);
            this.tChart6.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart6.Chart.Walls.Visible = false;
            // bar3
            this.bar3.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar3.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar3.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar3.ColorEach = true;
            this.bar3.Marks.Arrow.Visible = false;
            this.bar3.Marks.ArrowLength = -34;
            this.bar3.Marks.Pen.Visible = false;
            this.bar3.Marks.Shadow.Visible = false;
            this.bar3.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.bar3.Pen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.bar3.Title = "bar1";
            this.bar3.XValues.DataMember = "X";
            this.bar3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar3.YValues.DataMember = "Bar";
            // tChart5
            this.tChart5.Chart.Aspect.Elevation = 315;
            this.tChart5.Chart.Aspect.ElevationFloat = 315D;
            this.tChart5.Chart.Aspect.Orthogonal = false;
            this.tChart5.Chart.Aspect.Perspective = 0;
            this.tChart5.Chart.Aspect.Rotation = 360;
            this.tChart5.Chart.Aspect.RotationFloat = 360D;
            this.tChart5.Chart.Aspect.View3D = false;
            this.tChart5.Chart.Axes.Bottom.Visible = false;
            this.tChart5.Chart.Axes.Left.AxisPen.Color = Color.FromRgb(((int)(((byte)(192)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.tChart5.Chart.Axes.Left.AxisPen.Width = 1;
            this.tChart5.Chart.Axes.Left.Grid.Visible = false;
            this.tChart5.Chart.Axes.Left.Increment = 20D;
            this.tChart5.Chart.Axes.Left.Labels.Font.Brush.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.tChart5.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart5.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart5.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart5.Chart.Header.Lines = new string[] {"Afternoon Class"};
            this.tChart5.Chart.Header.Visible = false;
            this.tChart5.Chart.Legend.Visible = false;
            this.tChart5.Chart.Panel.Brush.Color = Color.White;
            this.tChart5.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart5.Chart.Panel.MarginBottom = 6D;
            this.tChart5.Chart.Series.Add(this.bar2);
            this.tChart5.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart5.Chart.Walls.Visible = false;
            // bar2
            this.bar2.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar2.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar2.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar2.ColorEach = true;
            this.bar2.Marks.Arrow.Visible = false;
            this.bar2.Marks.ArrowLength = -34;
            this.bar2.Marks.Pen.Visible = false;
            this.bar2.Marks.Shadow.Visible = false;
            this.bar2.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.bar2.Pen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.bar2.Title = "bar1";
            this.bar2.XValues.DataMember = "X";
            this.bar2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar2.YValues.DataMember = "Bar";
            // tChart4
            this.tChart4.Chart.Aspect.Elevation = 315;
            this.tChart4.Chart.Aspect.ElevationFloat = 315D;
            this.tChart4.Chart.Aspect.Orthogonal = false;
            this.tChart4.Chart.Aspect.Perspective = 0;
            this.tChart4.Chart.Aspect.Rotation = 360;
            this.tChart4.Chart.Aspect.RotationFloat = 360D;
            this.tChart4.Chart.Aspect.View3D = false;
            this.tChart4.Chart.Axes.Bottom.Visible = false;
            this.tChart4.Chart.Axes.Left.AxisPen.Width = 1;
            this.tChart4.Chart.Axes.Left.Grid.Visible = false;
            this.tChart4.Chart.Axes.Left.Increment = 20D;
            this.tChart4.Chart.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart4.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart4.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart4.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart4.Chart.Header.Lines = new string[] {"Morning Class"};
            this.tChart4.Chart.Header.Visible = false;
            this.tChart4.Chart.Legend.Visible = false;
            this.tChart4.Chart.Panel.Brush.Color = Color.White;
            this.tChart4.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart4.Chart.Panel.MarginBottom = 6D;
            this.tChart4.Chart.Series.Add(this.bar1);
            this.tChart4.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart4.Chart.Walls.Visible = false;
            // tChart3
            this.tChart3.Chart.Aspect.Elevation = 315;
            this.tChart3.Chart.Aspect.ElevationFloat = 315D;
            this.tChart3.Chart.Aspect.Orthogonal = false;
            this.tChart3.Chart.Aspect.Perspective = 0;
            this.tChart3.Chart.Aspect.Rotation = 360;
            this.tChart3.Chart.Aspect.RotationFloat = 360D;
            this.tChart3.Chart.Aspect.View3D = false;
            this.tChart3.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart3.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Header.Lines = new string[] {"Evening Class"};
            this.tChart3.Chart.Legend.Visible = false;
            this.tChart3.Chart.Panel.Brush.Color = Color.White;
            this.tChart3.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Chart.Series.Add(this.pie3);
            this.tChart3.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // pie3
            this.pie3.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.pie3.Circled = true;
            this.pie3.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.pie3.ExplodeBiggest = 5;
            this.pie3.ExplodedSlice.Add(0);
            this.pie3.ExplodedSlice.Add(5);
            this.pie3.Frame.Circled = true;
            this.pie3.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.pie3.Frame.OuterBand.Gradient.UseMiddle = false;
            this.pie3.LabelMember = "Labels";
            this.pie3.Marks.Visible = false;
            this.pie3.MarksPie.LegSize = 0;
            this.pie3.MarksPie.VertCenter = false;
            this.pie3.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.pie3.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.pie3.OtherSlice.Text = "";
            this.pie3.OtherSlice.Value = 0D;
            this.pie3.RotationAngle = 91;
            pie3.FillSampleValues(2);
            this.pie3.Title = "pie1";
            this.pie3.UniqueCustomRadius = true;
            this.pie3.XValues.DataMember = "Angle";
            this.pie3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.pie3.YValues.DataMember = "Pie";
            // tChart2
            this.tChart2.Chart.Aspect.Elevation = 315;
            this.tChart2.Chart.Aspect.ElevationFloat = 315D;
            this.tChart2.Chart.Aspect.Orthogonal = false;
            this.tChart2.Chart.Aspect.Perspective = 0;
            this.tChart2.Chart.Aspect.Rotation = 360;
            this.tChart2.Chart.Aspect.RotationFloat = 360D;
            this.tChart2.Chart.Aspect.View3D = false;
            this.tChart2.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart2.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart2.Chart.Header.Lines = new string[] {"Afternoon Class"};
            this.tChart2.Chart.Legend.Visible = false;
            this.tChart2.Chart.Panel.Brush.Color = Color.White;
            this.tChart2.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart2.Chart.Series.Add(this.pie2);
            this.tChart2.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // pie2
            this.pie2.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.pie2.Circled = true;
            this.pie2.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.pie2.ExplodeBiggest = 5;
            this.pie2.ExplodedSlice.Add(5);
            this.pie2.Frame.Circled = true;
            this.pie2.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.pie2.Frame.OuterBand.Gradient.UseMiddle = false;
            this.pie2.LabelMember = "Labels";
            this.pie2.Marks.Visible = false;
            this.pie2.MarksPie.LegSize = 0;
            this.pie2.MarksPie.VertCenter = false;
            this.pie2.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.pie2.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.pie2.OtherSlice.Text = "";
            this.pie2.OtherSlice.Value = 0D;
            this.pie2.RotationAngle = 91;
            pie2.FillSampleValues(2);
            this.pie2.Title = "pie1";
            this.pie2.UniqueCustomRadius = true;
            this.pie2.XValues.DataMember = "Angle";
            this.pie2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.pie2.YValues.DataMember = "Pie";
            // tChart1
            this.tChart1.Chart.Aspect.Elevation = 315;
            this.tChart1.Chart.Aspect.ElevationFloat = 315D;
            this.tChart1.Chart.Aspect.Orthogonal = false;
            this.tChart1.Chart.Aspect.Perspective = 0;
            this.tChart1.Chart.Aspect.Rotation = 360;
            this.tChart1.Chart.Aspect.RotationFloat = 360D;
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart1.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Lines = new string[] {"Morning Class"};
            this.tChart1.Chart.Legend.Visible = false;
            this.tChart1.Chart.Panel.Brush.Color = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Series.Add(this.pie1);
            this.tChart1.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // pie1
            this.pie1.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.pie1.Circled = true;
            this.pie1.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.pie1.ExplodeBiggest = 5;
            this.pie1.ExplodedSlice.Add(5);
            this.pie1.Frame.Circled = true;
            this.pie1.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.pie1.Frame.OuterBand.Gradient.UseMiddle = false;
            this.pie1.LabelMember = "Labels";
            this.pie1.Marks.Visible = false;
            this.pie1.MarksPie.LegSize = 0;
            this.pie1.MarksPie.VertCenter = false;
            this.pie1.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.pie1.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.pie1.OtherSlice.Text = "";
            this.pie1.OtherSlice.Value = 0D;
            this.pie1.RotationAngle = 91;
            pie1.FillSampleValues(2);
            this.pie1.Title = "pie1";
            this.pie1.UniqueCustomRadius = true;
            this.pie1.XValues.DataMember = "Angle";
            this.pie1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.pie1.YValues.DataMember = "Pie";
            // tChart7
            this.tChart7.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart7.Chart.Header.Visible = false;
            this.tChart7.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Top;
            this.tChart7.Chart.Legend.Font.Brush.Color = Color.Gray;
            this.tChart7.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart7.Chart.Legend.Font.Size = 14;
            this.tChart7.Chart.Legend.Pen.Visible = false;
            this.tChart7.Chart.Legend.Transparent = true;
            this.tChart7.Chart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart7.Chart.Panel.Brush.Color = Color.White;
            this.tChart7.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart7.Chart.Panel.MarginBottom = 0D;
            this.tChart7.Chart.Panel.MarginTop = 6D;
            this.tChart7.Chart.Series.Add(this.bar4);
            this.tChart7.Chart.Series.Add(this.bar5);
            this.tChart7.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // bar4
            this.bar4.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar4.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar4.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar4.ColorEach = false;
            this.bar4.Marks.Visible = false;
            this.bar4.Pen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.bar4.Pen.Visible = false;
            this.bar4.Title = "Women";
            this.bar4.XValues.DataMember = "X";
            this.bar4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar4.YValues.DataMember = "Bar";
            // bar5
            this.bar5.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar5.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.bar5.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.bar5.ColorEach = false;
            this.bar5.Marks.Visible = false;
            this.bar5.Pen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.bar5.Pen.Visible = false;
            this.bar5.Title = "Men";
            this.bar5.XValues.DataMember = "X";
            this.bar5.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar5.YValues.DataMember = "Bar";
            // label1
            this.label1.Text = "Women are more likely to attend the day classes while men are more commonly found" +
          " in the evening class";
            // bar1
            this.bar1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.bar1.Brush.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar1.Color = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.bar1.ColorEach = true;
            this.bar1.Marks.Arrow.Visible = false;
            this.bar1.Marks.ArrowLength = -34;
            this.bar1.Marks.Pen.Visible = false;
            this.bar1.Marks.Shadow.Visible = false;
            this.bar1.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.bar1.Pen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.bar1.Title = "bar1";
            this.bar1.XValues.DataMember = "X";
            this.bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.bar1.YValues.DataMember = "Bar";

            bar1.Add(pie1.YValues[0]);
            bar1.Add(pie1.YValues[1]);
            bar2.Add(pie2.YValues[0]);
            bar2.Add(pie2.YValues[1]);
            bar3.Add(pie3.YValues[0]);
            bar3.Add(pie3.YValues[1]);

            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart2.Chart.Panel.Gradient.Visible = false;
            tChart3.Chart.Panel.Gradient.Visible = false;
            tChart4.Chart.Panel.Gradient.Visible = false;
            tChart5.Chart.Panel.Gradient.Visible = false;
            tChart6.Chart.Panel.Gradient.Visible = false;
            tChart7.Chart.Panel.Gradient.Visible = false;

            tChart4.Chart[0].Marks.FontSeriesColor = true;
            tChart5.Chart[0].Marks.FontSeriesColor = true;
            tChart6.Chart[0].Marks.FontSeriesColor = true;

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

            //grid.Children.Add(chartView7, 0, 3, 0, 1);
            grid.Children.Add(tChart1, 0, 0);
            grid.Children.Add(tChart2, 1, 0);
            grid.Children.Add(tChart3, 2, 0);
            grid.Children.Add(tChart4, 0, 1);
            grid.Children.Add(tChart5, 1, 1);
            grid.Children.Add(tChart6, 2, 1);

            // Build the page.
            this.Content = grid;
        }
	}
}


