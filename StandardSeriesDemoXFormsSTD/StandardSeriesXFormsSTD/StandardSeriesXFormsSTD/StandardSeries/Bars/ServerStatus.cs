using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
	public class ServerStatus : ContentPage
    {
        ChartView tChart1;
        ChartView tChart2;
        ChartView tChart3;

        private Steema.TeeChart.Styles.Calendar calendar1;
        private Steema.TeeChart.Styles.HorizBar horizBar3;
        private Steema.TeeChart.Styles.HorizBar horizBar4;
        private Steema.TeeChart.Styles.HorizBar horizBar5;
        private Steema.TeeChart.Styles.HorizBar horizBar1;
        private Steema.TeeChart.Styles.HorizBar horizBar2;

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            tChart1.Chart.Graphics3D.TextOut(tChart1.Chart.Axes.Bottom.CalcPosValue(0), horizBar1.CalcYPos(5) - 25, "Memory Usage");
            tChart1.Chart.Graphics3D.TextOut(tChart1.Chart.Axes.Bottom.CalcPosValue(0), horizBar1.CalcYPos(4) - 25, "CPU usage");
            tChart1.Chart.Graphics3D.TextOut(tChart1.Chart.Axes.Bottom.CalcPosValue(0), horizBar1.CalcYPos(3) - 25, "Storage space");
            tChart1.Chart.Graphics3D.TextOut(tChart1.Chart.Axes.Bottom.CalcPosValue(0), horizBar1.CalcYPos(2) - 25, "Apps installed");
            tChart1.Chart.Graphics3D.TextOut(tChart1.Chart.Axes.Bottom.CalcPosValue(0), horizBar1.CalcYPos(1) - 25, "Bandwidth");
        }

        Random rnd1 = new Random();

        private void calendar1_Change(Steema.TeeChart.Styles.Calendar sender, Steema.TeeChart.Styles.Calendar.CalendarChangeEventArgs e)
        {
          Random rnd1 = new Random();
          // Random values for tChart1
          horizBar2.ValuesLists[0].Value[0] = rnd1.Next(100);
          horizBar2.ValuesLists[0].Value[1] = rnd1.Next(100);
          horizBar2.ValuesLists[0].Value[2] = rnd1.Next(100);
          horizBar2.ValuesLists[0].Value[3] = rnd1.Next(100);
          horizBar2.ValuesLists[0].Value[4] = rnd1.Next(100);

          // Random values for tChart3
          horizBar3.ValuesLists[0].Value[0] = rnd1.Next(1000);
          horizBar4.ValuesLists[0].Value[0] = rnd1.Next(1000);
          horizBar5.ValuesLists[0].Value[0] = rnd1.Next(1000);
          horizBar3.ValuesLists[0].Value[1] = rnd1.Next(1000);
          horizBar4.ValuesLists[0].Value[1] = rnd1.Next(1000);
          horizBar5.ValuesLists[0].Value[1] = rnd1.Next(1000);
          horizBar3.ValuesLists[0].Value[2] = rnd1.Next(1000);
          horizBar4.ValuesLists[0].Value[2] = rnd1.Next(1000);
          horizBar5.ValuesLists[0].Value[2] = rnd1.Next(1000);

          horizBar3.ValuesLists[0].Modified = true;
          horizBar4.ValuesLists[0].Modified = true;
          horizBar5.ValuesLists[0].Modified = true;

          tChart1.Chart.Invalidate();
          tChart3.Chart.Invalidate();
        }

		public ServerStatus ()
		{
            this.Title = "Server Status";

            tChart1 = new ChartView();

            this.horizBar1 = new Steema.TeeChart.Styles.HorizBar();
            this.horizBar2 = new Steema.TeeChart.Styles.HorizBar();
            this.tChart2 = new ChartView();
            this.calendar1 = new Steema.TeeChart.Styles.Calendar();
            this.tChart3 = new ChartView();
            this.horizBar3 = new Steema.TeeChart.Styles.HorizBar();
            this.horizBar4 = new Steema.TeeChart.Styles.HorizBar();
            this.horizBar5 = new Steema.TeeChart.Styles.HorizBar();
            // tChart1
            this.tChart1.Chart.Aspect.ColorPaletteIndex = 21;
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Axes.Visible = false;
            this.tChart1.Chart.Header.AdjustFrame = false;
            this.tChart1.Chart.Header.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart1.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Font.Name = "Segoe UI";
            this.tChart1.Chart.Header.Font.Size = 18;
            this.tChart1.Chart.Header.Lines = new string[] {"Server Status"};
            this.tChart1.Chart.Header.Pen.Color = Color.FromRgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChart1.Chart.Header.Transparent = false;
            this.tChart1.Chart.Legend.Visible = false;
            this.tChart1.Chart.Panel.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart1.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart1.Chart.Series.Add(this.horizBar1);
            this.tChart1.Chart.Series.Add(this.horizBar2);
            this.tChart1.Chart.Walls.Visible = false;
            this.tChart1.Chart.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
            // horizBar1
            this.horizBar1.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar1.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.horizBar1.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.horizBar1.ColorEach = false;
            this.horizBar1.Marks.Visible = false;
            this.horizBar1.MultiBar = Steema.TeeChart.Styles.MultiBars.None;
            this.horizBar1.Pen.Color = Color.FromRgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.horizBar1.Title = "horizBar1";
            this.horizBar1.XValues.DataMember = "X";
            this.horizBar1.YValues.DataMember = "Bar";
            this.horizBar1.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;            
            // horizBar2
            this.horizBar2.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar2.Brush.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.horizBar2.Color = Color.FromRgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.horizBar2.ColorEach = true;
            this.horizBar2.Marks.Arrow.Visible = false;
            this.horizBar2.Marks.ArrowLength = -72;
            this.horizBar2.Marks.Brush.Visible = false;
            this.horizBar2.Marks.Font.Bold = true;
            this.horizBar2.Marks.Font.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.horizBar2.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Percent;
            this.horizBar2.Marks.Transparent = true;
            this.horizBar2.Pen.Color = Color.FromRgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.horizBar2.Title = "horizBar2";
            this.horizBar2.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;            
            // tChart2
            this.tChart2.Chart.Aspect.ColorPaletteIndex = 21;
            this.tChart2.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart2.Chart.Header.Visible = false;
            this.tChart2.Chart.Legend.Visible = false;
            this.tChart2.Chart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart2.Chart.Panel.Brush.Color = Color.White;
            this.tChart2.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart2.Chart.Series.Add(this.calendar1);
            this.tChart2.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            // calendar1
            this.calendar1.ColorEach = false;
            this.calendar1.ColorMember = "Colors";
            this.calendar1.Date = new System.DateTime(2015, 3, 9, 0, 0, 0, 0);
            this.calendar1.DayOneColumn = 7;
            this.calendar1.DayOneRow = 3;
            this.calendar1.Legend.Visible = false;
            this.calendar1.Pen.Visible = false;
            this.calendar1.Title = "calendar1";
            this.calendar1.XValues.DataMember = "X";
            this.calendar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.calendar1.YValues.DataMember = "Y";
            this.calendar1.Change += new Steema.TeeChart.Styles.Calendar.CalendarChangeEventHandler(this.calendar1_Change);            
            // tChart3
            this.tChart3.Chart.Aspect.ColorPaletteIndex = 21;
            this.tChart3.Chart.Aspect.View3D = false;
            this.tChart3.Chart.Axes.Bottom.AxisPen.Width = 1;
            this.tChart3.Chart.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Axes.Bottom.Labels.Font.Name = "Segoe UI";
            this.tChart3.Chart.Axes.Left.AxisPen.Visible = false;
            this.tChart3.Chart.Axes.Left.Grid.Visible = false;
            this.tChart3.Chart.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Axes.Left.Labels.Font.Name = "Segoe UI";
            this.tChart3.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart3.Chart.Axes.Left.Ticks.Color = Color.FromRgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart3.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart3.Chart.Header.Alignment = TextAlignment.Start;
            this.tChart3.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart3.Chart.Header.Font.Size = 16;
            this.tChart3.Chart.Header.Lines = new string[] {"Active Servers"};
            this.tChart3.Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            this.tChart3.Chart.Legend.Transparent = true;
            this.tChart3.Chart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            this.tChart3.Chart.Panel.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart3.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Chart.Panel.Brush.Gradient.Visible = false;
            this.tChart3.Chart.Panel.MarginBottom = 1D;
            this.tChart3.Chart.Panel.MarginLeft = 2D;
            this.tChart3.Chart.Panel.MarginRight = 2D;
            this.tChart3.Chart.Panel.MarginTop = 2D;
            this.tChart3.Chart.Series.Add(this.horizBar3);
            this.tChart3.Chart.Series.Add(this.horizBar4);
            this.tChart3.Chart.Series.Add(this.horizBar5);
            this.tChart3.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart3.Chart.Walls.Back.Visible = false;
            // horizBar3
            this.horizBar3.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar3.Brush.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.horizBar3.Color = Color.FromRgb(((int)(((byte)(220)))), ((int)(((byte)(92)))), ((int)(((byte)(5)))));
            this.horizBar3.ColorEach = false;
            this.horizBar3.Marks.Visible = false;
            this.horizBar3.Pen.Color = Color.FromRgb(((int)(((byte)(132)))), ((int)(((byte)(55)))), ((int)(((byte)(3)))));
            this.horizBar3.Title = "Server 1";
            this.horizBar3.XValues.DataMember = "X";
            this.horizBar3.YValues.DataMember = "Bar";
            this.horizBar3.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;            
            // horizBar4
            this.horizBar4.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar4.Brush.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.horizBar4.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.horizBar4.ColorEach = false;
            this.horizBar4.Marks.Visible = false;
            this.horizBar4.Pen.Color = Color.FromRgb(((int)(((byte)(153)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.horizBar4.Title = "Server 2";
            this.horizBar4.XValues.DataMember = "X";
            this.horizBar4.YValues.DataMember = "Bar";
            this.horizBar4.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // horizBar5
            this.horizBar5.BarRound = Steema.TeeChart.Styles.BarRounding.AtValue;
            this.horizBar5.Brush.Color = Color.FromRgb(((int)(((byte)(110)))), ((int)(((byte)(197)))), ((int)(((byte)(184)))));
            this.horizBar5.Color = Color.FromRgb(((int)(((byte)(110)))), ((int)(((byte)(197)))), ((int)(((byte)(184)))));
            this.horizBar5.ColorEach = false;
            this.horizBar5.Marks.Visible = false;
            this.horizBar5.Pen.Color = Color.FromRgb(((int)(((byte)(66)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.horizBar5.Title = "Server 3";
            this.horizBar5.XValues.DataMember = "X";
            this.horizBar5.YValues.DataMember = "Bar";
            this.horizBar5.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

            tChart1.Chart.Panel.Gradient.Visible = false;
            tChart2.Chart.Panel.Gradient.Visible = false;
            tChart3.Chart.Panel.Gradient.Visible = false;

            double[] h1Vals = new double[] { 100, 100, 100, 100, 100 };
            horizBar1.Add(h1Vals);
            double[] h2Vals = new double[] { 60, 85, 40, 55, 50 };
            horizBar2.Add(h2Vals);

            horizBar3.FillSampleValues(3);
            horizBar4.FillSampleValues(3);
            horizBar5.FillSampleValues(3);
            horizBar3.Labels[0] = "Speed";
            horizBar3.Labels[1] = "Time";
            horizBar3.Labels[2] = "Visitors";

            calendar1.FillSampleValues();
            calendar1.Date = DateTime.Now;
            calendar1.Today.Color = Steema.TeeChart.Themes.LookoutTheme.SeawashPalette[9];
            calendar1.Sunday.Color = Steema.TeeChart.Themes.LookoutTheme.SeawashPalette[10];
            calendar1.Sunday.Font.Color = Color.Black;

            this.tChart1.Chart.Aspect.ZoomText = true;
            this.tChart2.Chart.Aspect.ZoomText = true;
            this.tChart3.Chart.Aspect.ZoomText = true;

            this.tChart2.Chart.Panning.Active = true;            

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
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }
            };

            grid.Children.Add(tChart1, 0, 0);
            grid.Children.Add(tChart2, 1, 0);
            grid.Children.Add(tChart3, 0, 2, 1,2);

            // Build the page.
            this.Content = grid;
        }
	}
}


