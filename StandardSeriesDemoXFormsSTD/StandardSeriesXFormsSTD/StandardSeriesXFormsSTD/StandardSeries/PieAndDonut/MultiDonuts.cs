using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
	public class MultiDonuts : ContentPage
	{
        private Steema.TeeChart.ChartView tChart1;
        private Steema.TeeChart.ChartView tChart4;
        private Steema.TeeChart.ChartView tChart3;
        private Steema.TeeChart.ChartView tChart2;
        private Steema.TeeChart.ChartView tChart5;
        private Steema.TeeChart.Styles.Donut donut4;
        private Steema.TeeChart.Styles.Donut donut3;
        private Steema.TeeChart.Styles.Donut donut2;
        private Steema.TeeChart.Styles.Donut donut1;
        private Steema.TeeChart.Styles.HorizBar horizBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;


		public MultiDonuts ()
		{
            this.Title = "Multi Donuts";

            // Pending Animations for Xamarin.Forms
            //Steema.TeeChart.Animations.EasingFunctions.BounceEase bounceEase1 = new Steema.TeeChart.Animations.EasingFunctions.BounceEase();
            //Steema.TeeChart.Animations.EasingFunctions.CircleEase circleEase1 = new Steema.TeeChart.Animations.EasingFunctions.CircleEase();
            this.tChart4 = new ChartView();
            this.donut4 = new Steema.TeeChart.Styles.Donut();
            this.tChart3 = new ChartView();
            this.donut3 = new Steema.TeeChart.Styles.Donut();
            this.tChart2 = new ChartView();
            this.donut2 = new Steema.TeeChart.Styles.Donut();
            this.tChart1 = new ChartView();
            this.donut1 = new Steema.TeeChart.Styles.Donut();
            this.label1 = new Label();
            this.label2 = new Label();
            this.tChart5 = new ChartView();
            this.horizBar1 = new Steema.TeeChart.Styles.HorizBar();

            // tChart4
            this.tChart4.Chart.Aspect.ColorPaletteIndex = 14;
            this.tChart4.Chart.Aspect.Elevation = 315;
            this.tChart4.Chart.Aspect.Orthogonal = false;
            this.tChart4.Chart.Aspect.Perspective = 0;
            this.tChart4.Chart.Aspect.Rotation = 360;
            this.tChart4.Chart.Aspect.View3D = false;
            this.tChart4.Chart.Footer.Font.Bold = true;
            this.tChart4.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart4.Chart.Footer.Lines = new string[] {"WHILE SHOPPING"};
            this.tChart4.Chart.Footer.Visible = true;
            this.tChart4.Chart.Header.Visible = false;
            this.tChart4.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart4.Chart.Legend.Font.Bold = true;
            this.tChart4.Chart.Legend.Font.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.tChart4.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart4.Chart.Legend.Font.Size = 24;
            this.tChart4.Chart.Legend.FontSeriesColor = true;
            this.tChart4.Chart.Legend.LegendStyle = Steema.TeeChart.LegendStyles.LastValues;
            this.tChart4.Chart.Legend.Symbol.Visible = false;
            this.tChart4.Chart.Legend.TopLeftPos = 5;
            this.tChart4.Chart.Legend.Transparent = true;
            this.tChart4.Chart.Legend.VertSpacing = -10;
            this.tChart4.Chart.Panel.Brush.Color = Color.White;
            this.tChart4.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart4.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart4.Chart.Panel.Brush.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart4.Chart.Panel.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart4.Chart.Panel.MarginBottom = 2D;
            this.tChart4.Chart.Series.Add(this.donut4);
            this.tChart4.Chart.SubFooter.Font.Brush.Color = Color.Gray;
            this.tChart4.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // donut4
            this.donut4.AutoPenColor = false;
            this.donut4.Brush.Color = Color.FromRgb(((int)(((byte)(242)))), ((int)(((byte)(192)))), ((int)(((byte)(93)))));
            this.donut4.Circled = true;
            this.donut4.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.donut4.DonutPercent = 60;
            this.donut4.Frame.Circled = true;
            this.donut4.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.donut4.Frame.OuterBand.Gradient.UseMiddle = false;
            this.donut4.Frame.Width = 4;
            this.donut4.LabelMember = "Labels";
            this.donut4.Marks.Visible = false;
            this.donut4.MarksPie.LegSize = 0;
            this.donut4.MarksPie.VertCenter = false;
            this.donut4.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.donut4.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.donut4.OtherSlice.Text = "";
            this.donut4.OtherSlice.Value = 0D;
            this.donut4.Pen.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.donut4.Pen.Width = 3;
            this.donut4.RotationAngle = 91;
            this.donut4.Title = "donut1";
            this.donut4.UniqueCustomRadius = true;
            this.donut4.XValues.DataMember = "Angle";
            this.donut4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.donut4.YValues.DataMember = "Pie";
            // tChart3
            this.tChart3.Chart.Aspect.ColorPaletteIndex = 14;
            this.tChart3.Chart.Aspect.Elevation = 315;
            this.tChart3.Chart.Aspect.Orthogonal = false;
            this.tChart3.Chart.Aspect.Perspective = 0;
            this.tChart3.Chart.Aspect.Rotation = 360;
            this.tChart3.Chart.Aspect.RotationFloat = 360D;
            this.tChart3.Chart.Aspect.View3D = false;
            this.tChart3.Chart.Footer.Font.Bold = true;
            this.tChart3.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Footer.Lines = new string[] {"WHILE HAVING DINNER"};
            this.tChart3.Chart.Footer.Visible = true;
            this.tChart3.Chart.Header.Visible = false;
            this.tChart3.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart3.Chart.Legend.Font.Bold = true;
            this.tChart3.Chart.Legend.Font.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.tChart3.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart3.Chart.Legend.Font.Size = 24;
            this.tChart3.Chart.Legend.FontSeriesColor = true;
            this.tChart3.Chart.Legend.LegendStyle = Steema.TeeChart.LegendStyles.LastValues;
            this.tChart3.Chart.Legend.Symbol.Visible = false;
            this.tChart3.Chart.Legend.TopLeftPos = 5;
            this.tChart3.Chart.Legend.Transparent = true;
            this.tChart3.Chart.Legend.VertSpacing = -10;
            this.tChart3.Chart.Panel.Brush.Color = Color.White;
            this.tChart3.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart3.Chart.Panel.Brush.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart3.Chart.Panel.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart3.Chart.Panel.MarginBottom = 2D;
            this.tChart3.Chart.Series.Add(this.donut3);
            this.tChart3.Chart.SubFooter.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // donut3
            this.donut3.AutoPenColor = false;
            this.donut3.Brush.Color = Color.FromRgb(((int)(((byte)(242)))), ((int)(((byte)(192)))), ((int)(((byte)(93)))));
            this.donut3.Circled = true;
            this.donut3.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.donut3.DonutPercent = 60;
            this.donut3.Frame.Circled = true;
            this.donut3.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.donut3.Frame.OuterBand.Gradient.UseMiddle = false;
            this.donut3.Frame.Width = 4;
            this.donut3.LabelMember = "Labels";
            this.donut3.Marks.Visible = false;
            this.donut3.MarksPie.LegSize = 0;
            this.donut3.MarksPie.VertCenter = false;
            this.donut3.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.donut3.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.donut3.OtherSlice.Text = "";
            this.donut3.OtherSlice.Value = 0D;
            this.donut3.Pen.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.donut3.Pen.Width = 3;
            this.donut3.RotationAngle = 91;
            this.donut3.Title = "donut1";
            this.donut3.UniqueCustomRadius = true;
            this.donut3.XValues.DataMember = "Angle";
            this.donut3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.donut3.YValues.DataMember = "Pie";
            // tChart2
            this.tChart2.Chart.Aspect.ColorPaletteIndex = 14;
            this.tChart2.Chart.Aspect.Elevation = 315;
            this.tChart2.Chart.Aspect.Orthogonal = false;
            this.tChart2.Chart.Aspect.Perspective = 0;
            this.tChart2.Chart.Aspect.Rotation = 360;
            this.tChart2.Chart.Aspect.RotationFloat = 360D;
            this.tChart2.Chart.Aspect.View3D = false;
            this.tChart2.Chart.Footer.Font.Bold = true;
            this.tChart2.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart2.Chart.Footer.Lines = new string[] {"WHILE COMMUTING"};
            this.tChart2.Chart.Footer.Visible = true;
            this.tChart2.Chart.Header.Visible = false;
            this.tChart2.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart2.Chart.Legend.Font.Bold = true;
            this.tChart2.Chart.Legend.Font.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.tChart2.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart2.Chart.Legend.Font.Size = 24;
            this.tChart2.Chart.Legend.FontSeriesColor = true;
            this.tChart2.Chart.Legend.LegendStyle = Steema.TeeChart.LegendStyles.LastValues;
            this.tChart2.Chart.Legend.Symbol.Visible = false;
            this.tChart2.Chart.Legend.TopLeftPos = 5;
            this.tChart2.Chart.Legend.Transparent = true;
            this.tChart2.Chart.Legend.VertSpacing = -10;
            this.tChart2.Chart.Panel.Brush.Color = Color.White;
            this.tChart2.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart2.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart2.Chart.Panel.Brush.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart2.Chart.Panel.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart2.Chart.Panel.MarginBottom = 2D;
            this.tChart2.Chart.Series.Add(this.donut2);
            this.tChart2.Chart.SubFooter.Font.Brush.Color = Color.Gray;
            this.tChart2.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // donut2
            this.donut2.AutoPenColor = false;
            this.donut2.Brush.Color = Color.FromRgb(((int)(((byte)(242)))), ((int)(((byte)(192)))), ((int)(((byte)(93)))));
            this.donut2.Circled = true;
            this.donut2.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.donut2.DonutPercent = 60;
            this.donut2.Frame.Circled = true;
            this.donut2.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.donut2.Frame.OuterBand.Gradient.UseMiddle = false;
            this.donut2.Frame.Width = 4;
            this.donut2.LabelMember = "Labels";
            this.donut2.Marks.Visible = false;
            this.donut2.MarksPie.LegSize = 0;
            this.donut2.MarksPie.VertCenter = false;
            this.donut2.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.donut2.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.donut2.OtherSlice.Text = "";
            this.donut2.OtherSlice.Value = 0D;
            this.donut2.Pen.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.donut2.Pen.Width = 3;
            this.donut2.RotationAngle = 91;
            this.donut2.Title = "donut1";
            this.donut2.UniqueCustomRadius = true;
            this.donut2.XValues.DataMember = "Angle";
            this.donut2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.donut2.YValues.DataMember = "Pie";
            // tChart1
            this.tChart1.Chart.Aspect.ColorPaletteIndex = 21;
            this.tChart1.Chart.Aspect.Elevation = 315;
            this.tChart1.Chart.Aspect.Orthogonal = false;
            this.tChart1.Chart.Aspect.Perspective = 0;
            this.tChart1.Chart.Aspect.Rotation = 360;
            this.tChart1.Chart.Aspect.RotationFloat = 360D;
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Footer.Font.Bold = true;
            this.tChart1.Chart.Footer.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Footer.Lines = new string[] {"LATE AT NIGHT IN BED"};
            this.tChart1.Chart.Footer.Visible = true;
            this.tChart1.Chart.Header.Visible = false;
            this.tChart1.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart1.Chart.Legend.Font.Bold = true;
            this.tChart1.Chart.Legend.Font.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.tChart1.Chart.Legend.Font.Name = "Segoe UI";
            this.tChart1.Chart.Legend.Font.Size = 24;
            this.tChart1.Chart.Legend.FontSeriesColor = true;
            this.tChart1.Chart.Legend.LegendStyle = Steema.TeeChart.LegendStyles.LastValues;
            this.tChart1.Chart.Legend.Symbol.Visible = false;
            this.tChart1.Chart.Legend.TopLeftPos = 5;
            this.tChart1.Chart.Legend.Transparent = true;
            this.tChart1.Chart.Legend.VertSpacing = -10;
            this.tChart1.Chart.Panel.Brush.Color = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Panel.Brush.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart1.Chart.Panel.ImageMode = Steema.TeeChart.Drawing.ImageMode.Center;
            this.tChart1.Chart.Panel.MarginBottom = 2D;
            this.tChart1.Chart.Series.Add(this.donut1);
            this.tChart1.Chart.SubFooter.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // donut1
            this.donut1.AutoPenColor = false;
            this.donut1.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.donut1.Circled = true;
            this.donut1.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.donut1.DonutPercent = 60;
            this.donut1.Frame.Circled = true;
            this.donut1.Frame.FrameElementPercents = new double[] {
        25D,
        60D,
        15D};
            this.donut1.Frame.OuterBand.Gradient.UseMiddle = false;
            this.donut1.Frame.Width = 4;
            this.donut1.LabelMember = "Labels";
            this.donut1.Marks.Visible = false;
            this.donut1.MarksPie.LegSize = 0;
            this.donut1.MarksPie.VertCenter = false;
            this.donut1.MultiPie = Steema.TeeChart.Styles.MultiPies.Automatic;
            this.donut1.OtherSlice.Style = Steema.TeeChart.Styles.PieOtherStyles.None;
            this.donut1.OtherSlice.Text = "";
            this.donut1.OtherSlice.Value = 0D;
            this.donut1.Pen.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.donut1.Pen.Width = 3;
            this.donut1.RotationAngle = 91;
            this.donut1.Title = "donut1";
            this.donut1.UniqueCustomRadius = true;
            this.donut1.XValues.DataMember = "Angle";
            this.donut1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.donut1.YValues.DataMember = "Pie";
            // label1            
            this.label1.Text = "Ericson consumerLab.   2014";
            // label2
            this.label2.Text = "Where do customers watch mobile video content ?";
            // tChart5
            this.tChart5.Chart.Aspect.ColorPaletteIndex = 14;
            this.tChart5.Chart.Aspect.View3D = false;
            this.tChart5.Chart.Axes.Bottom.AxisPen.Visible = false;
            this.tChart5.Chart.Axes.Bottom.Grid.Visible = false;
            this.tChart5.Chart.Axes.Bottom.MinorTicks.Visible = false;
            this.tChart5.Chart.Axes.Bottom.Visible = false;
            this.tChart5.Chart.Axes.Left.AxisPen.Color = Color.Gray;
            this.tChart5.Chart.Axes.Left.AxisPen.Width = 1;
            this.tChart5.Chart.Axes.Left.Grid.Visible = false;
            this.tChart5.Chart.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart5.Chart.Axes.Left.Labels.Font.Name = "Segoe UI";
            this.tChart5.Chart.Axes.Left.Labels.Font.Size = 16;
            this.tChart5.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart5.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart5.Chart.Header.Visible = false;
            this.tChart5.Chart.Legend.Visible = false;
            this.tChart5.Chart.Panel.Brush.Color = Color.White;
            this.tChart5.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart5.Chart.Series.Add(this.horizBar1);
            this.tChart5.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart5.Chart.Walls.Back.Visible = false;
            // horizBar1
            this.horizBar1.BarHeightPercent = 90;
            this.horizBar1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar1.BarStyle = Steema.TeeChart.Styles.BarStyles.RoundRectangle;
            this.horizBar1.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.horizBar1.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(234)))), ((int)(((byte)(141)))));
            this.horizBar1.ColorEach = false;
            this.horizBar1.Marks.Brush.Visible = false;
            this.horizBar1.Marks.Font.Brush.Color = Color.Gray;
            this.horizBar1.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.horizBar1.Marks.Transparent = true;
            this.horizBar1.Pen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(140)))), ((int)(((byte)(85)))));
            this.horizBar1.Pen.Visible = false;
            this.horizBar1.Title = "horizBar1";
            this.horizBar1.ValueFormat = "## %";
            this.horizBar1.XValues.DataMember = "X";
            this.horizBar1.YValues.DataMember = "Bar";
            this.horizBar1.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart2.Chart.Panel.Gradient.Visible = false;
            tChart3.Chart.Panel.Gradient.Visible = false;
            tChart4.Chart.Panel.Gradient.Visible = false;
            tChart5.Chart.Panel.Gradient.Visible = false;

            this.tChart1.Chart.Aspect.ZoomText = true;
            this.tChart2.Chart.Aspect.ZoomText = true;
            this.tChart3.Chart.Aspect.ZoomText = true;
            this.tChart4.Chart.Aspect.ZoomText = true;
            this.tChart5.Chart.Aspect.ZoomText = true;

            initChart();

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
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }
            };

            grid.Children.Add(tChart1, 0, 0);
            grid.Children.Add(tChart2, 1, 0);
            grid.Children.Add(tChart3, 2, 0);
            grid.Children.Add(tChart4, 3, 0);
            grid.Children.Add(tChart5, 0, 4, 1, 2);

            // Build the page.
            this.Content = grid;
        }

        private void initChart()
        {
            donut1.Clear();
            donut1.Add(60, Color.FromRgb(215, 215, 215));
            donut1.Add(40, Color.FromRgb(249, 205, 32));

            donut2.Clear();
            donut2.Add(75, Color.FromRgb(215, 215, 215));
            donut2.Add(25, Color.FromRgb(243, 146, 37));

            donut3.Clear();
            donut3.Add(77, Color.FromRgb(215, 215, 215));
            donut3.Add(23, Color.FromRgb(249, 205, 32));

            donut4.Clear();
            donut4.Add(80, Color.FromRgb(215, 215, 215));
            donut4.Add(20, Color.FromRgb(243, 146, 37));

            horizBar1.Clear();
            horizBar1.Add(0.4, "Late at night in bed", Color.FromRgb(249, 205, 32));
            horizBar1.Add(0.25, "While commuting", Color.FromRgb(243, 146, 37));
            horizBar1.Add(0.23, "While having dinner", Color.FromRgb(249, 205, 32));
            horizBar1.Add(0.20, "While shopping", Color.FromRgb(243, 146, 37));
        }
	}
}


