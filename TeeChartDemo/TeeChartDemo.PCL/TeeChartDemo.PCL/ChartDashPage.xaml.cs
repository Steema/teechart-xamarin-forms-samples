using System;
using System.Collections.Generic;
using Steema.TeeChart.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Steema.TeeChart.Editors.Tools;
using Steema.TeeChart.Themes;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace TeeChartDemo.PCL
{
  public partial class ChartDashPage
  {
    public ChartDashPage(string dash)
    {
      InitializeComponent();

      Steema.TeeChart.Chart chart1 = new Steema.TeeChart.Chart();
      Steema.TeeChart.Chart chart2 = new Steema.TeeChart.Chart();

      ChartView chartView1 = new ChartView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        WidthRequest = 400,
        HeightRequest = dash.Equals(AppResources.DashDigital) ? 150 : 250
      };

      ChartView chartView2 = new ChartView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,

        WidthRequest = 400,
        HeightRequest = dash.Equals(AppResources.DashDigital) ? 200 : 250
      };

      ChartView chartView3 = new ChartView
      {
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,

        WidthRequest = 400,
        HeightRequest = 150
      };


      InitializeChart(chart1);
      InitializeChart(chart2);

      if (dash.Equals(AppResources.DashGeographic))
      {
        DoDashGeographic(chart1, chart2, Color.White);
      }
      else if (dash.Equals(AppResources.DashDigital))
      {
        Steema.TeeChart.Chart chart3 = new Steema.TeeChart.Chart();
        InitializeChart(chart3);

        DoDashDigital(chart1, chart2, chart3, Color.White);

        chartView3.Model = chart3;
      }
      else if (dash.Equals(AppResources.DashExposure))
      {
        DoDashExposure(chart1, chart2, Color.White);
      }
      else if (dash.Equals(AppResources.DashTrend))
      {
        DoDashTrend(chart1, chart2);
      }

      chartView1.Model = chart1;
      chartView2.Model = chart2;

      if (dash.Equals(AppResources.DashDigital))
      {
        Content = new StackLayout
        {
          Children = { chartView1, chartView3, chartView2 }
        };
      }
      else
      {
        Content = new StackLayout
        {
          Children = { chartView1, chartView2 }
        };
      }
    }

    private void InitializeChart(Chart tChart)
    {

      tChart.Panel.Transparent = true;
      tChart.Header.Visible = false;
      tChart.Axes.Left.Grid.Visible = true;
      tChart.Aspect.View3D = false;
      tChart.Legend.Visible = false;

      //if (App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark)
      //{
      BlackIsBackTheme theme = new BlackIsBackTheme(tChart.Chart);
      Steema.TeeChart.Themes.Theme.ApplyChartTheme(theme, tChart.Chart);
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart.Chart, Theme.OnBlackPalette);

      Color drawPenColor1 = Color.White;
      //backImage.Opacity = 30;
      tChart.Walls.Back.Transparency = 40;
      tChart.Walls.Left.Transparency = 40;
      tChart.Walls.Bottom.Transparency = 40;
      //}
      //else
      //{
      //  drawPenColor1 = Colors.Black;
      //  tChart.Walls.Back.Transparency = 95;
      //  tChart.Walls.Left.Transparency = 95;
      //  tChart.Walls.Bottom.Transparency = 95;
      //  Uri uri = new Uri("Images/teeWPbackNeg.png", UriKind.Relative);
      //  ImageSource imgSource = new System.Windows.Media.Imaging.BitmapImage(uri);
      //  backImage.ImageSource = imgSource;
      //  backImage.Opacity = 30;
      //}

      tChart.Chart.Axes.Left.Labels.Font.Color = drawPenColor1;
      tChart.Chart.Axes.Top.Labels.Font.Color = drawPenColor1;
      tChart.Chart.Axes.Right.Labels.Font.Color = drawPenColor1;
      tChart.Chart.Axes.Bottom.Labels.Font.Color = drawPenColor1;
      tChart.Axes.Left.Title.Font.Color = drawPenColor1;
      tChart.Axes.Bottom.Title.Font.Color = drawPenColor1;

      tChart.Axes.Left.Title.Font.Size = 18;
      tChart.Axes.Left.Title.Font.Size = 18;

      tChart.Axes.Left.Labels.Font.Size = 14;
      tChart.Axes.Bottom.Labels.Font.Size = 14;

      tChart.Chart.Legend.Font.Color = drawPenColor1;
    }

    private void DoDashExposure(Chart tChart1, Chart tChart2, Color drawPenColor1)
    {
      tChart1.Series.Clear();
      tChart2.Series.Clear();

      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart1.Chart, Theme.OperaPalette);
      Steema.TeeChart.Styles.Donut pie1 = new Steema.TeeChart.Styles.Donut();
      tChart1.Series.Add(pie1);

      pie1.Add(20, AppResources.Currency);
      pie1.Add(70, AppResources.Fixed + Utils.NewLine + AppResources.Public);
      pie1.Add(10, AppResources.Variable);
      pie1.Add(12, AppResources.Indexed);
      pie1.Add(23, AppResources.Fixed + Utils.NewLine + AppResources.Private);
      pie1.Marks.Visible = true;

      pie1.Marks.Style = MarksStyles.LabelPercent;
      pie1.Marks.MultiLine = true;

      pie1.Marks.Callout.Brush.Color = drawPenColor1;
      pie1.Marks.Callout.Distance = 0;
      pie1.Marks.Callout.Draw3D = false;
      pie1.Marks.Callout.Length = -18;
      pie1.Marks.Callout.Pen.Width = 3;
      pie1.Marks.Transparency = 25;
      pie1.Marks.Shadow.Visible = false;
      pie1.Marks.Pen.Color = Color.Gray;
      pie1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
      pie1.Marks.Font.Size = 14;
      pie1.Marks.Font.Color = drawPenColor1;

      pie1.MarksPie.LegSize = 0;
      pie1.MarksPie.VertCenter = false;

      pie1.RotationAngle = 220;

      pie1.BevelPercent = 1;
      pie1.Pen.Visible = false;
      pie1.EdgeStyle = Steema.TeeChart.Drawing.EdgeStyles.Flat;
      pie1.Circled = true;
      pie1.ExplodeBiggest = 10;

      tChart1.Panel.MarginLeft = 0;
      tChart1.Panel.MarginTop = 0;
      tChart1.Panel.MarginRight = 0;
      tChart1.Panel.MarginBottom = 0;
      tChart1.Aspect.Zoom = 110;

      tChart1.Header.Text = AppResources.CurrentPosition;
      tChart1.Header.Font.Color = drawPenColor1;
      tChart1.Header.Font.Size = 16;
      tChart1.Header.Visible = true;
      tChart1.Legend.Visible = false;
      tChart1.Legend.Pen.Visible = false;
      tChart1.Legend.Shadow.Visible = false;
      //tChart1.Legend.ResizeChart = false;
      tChart1.Legend.Font.Size = 15;
      tChart1.Legend.Transparency = 30;
      tChart1.Legend.Alignment = LegendAlignments.Bottom;
      //tChart1.Aspect.VertOffset = -20;

      tChart2.Panel.MarginLeft = 0;
      tChart2.Panel.MarginTop = 0;
      tChart2.Panel.MarginRight = 0;
      tChart2.Panel.MarginBottom = 0;

      Steema.TeeChart.Styles.Darvas darvas = new Steema.TeeChart.Styles.Darvas();
      tChart2.Series.Add(darvas);
      tChart2.Header.Text = AppResources.RecentMovement;
      tChart2.Header.Visible = true;
      tChart2.Header.Font.Color = drawPenColor1;
      tChart2.Header.Font.Size = 16;
      darvas.FillSampleValues(40);

      Candle candle = ((Candle)(darvas));
      candle.LinePen.Width = 3;
      candle.Pen.Color = drawPenColor1;
      candle.LinePen.Color = drawPenColor1;
      candle.DownCloseColor = Color.Fuschia;

      tChart2.Walls.Visible = false;
      tChart2.Axes.Bottom.Labels.Angle = 90;
    }

    private void DoDashDigital(Chart tChart1, Chart tChart2, Chart tChart3, Color drawPenColor1)
    {
      tChart1.Aspect.View3D = false;
      tChart2.Aspect.View3D = false;
      tChart3.Aspect.View3D = false;

      tChart1.Series.Clear();
      tChart2.Series.Clear();
      tChart3.Series.Clear();

      //NumericGauge Chart
      Steema.TeeChart.Styles.NumericGauge nGauge = new Steema.TeeChart.Styles.NumericGauge();
      Random rand = (new Random());
      nGauge.Value = 30 + rand.Next(150);
      //if ((this.Orientation == PageOrientation.Landscape) ||
      //       (this.Orientation == PageOrientation.LandscapeLeft) ||
      //       (this.Orientation == PageOrientation.LandscapeRight))
      //{
      //  nGauge.Markers[0].Shape.Font.Size = 30;
      //  nGauge.Markers[1].Shape.Font.Size = 10;
      //  nGauge.Markers[2].Shape.Font.Size = 10;
      //  nGauge.CustomBounds = new Rect(30, 10, 280, 100);
      //}
      //else
      //{
      tChart1.Panel.MarginTop = 0;
      tChart1.Panel.MarginBottom = 0;
      nGauge.Markers[0].Shape.Font.Size = 20;
      nGauge.Markers[1].Shape.Font.Size = 8;
      nGauge.Markers[2].Shape.Font.Size = 8;
      //}

      //tChart1.Panel.Transparent = false;            
      tChart1.Series.Add(nGauge);

      tChart1.Footer.Font.Color = drawPenColor1;
      tChart1.Footer.Text = AppResources.SigFrequency + Utils.NewLine + AppResources.BelowSignal;
      tChart1.Footer.Font.Size = 12;
      tChart1.Footer.Visible = true;

      //BarChart
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart2.Chart, 16);

      Steema.TeeChart.Styles.Bar bar = new Steema.TeeChart.Styles.Bar(tChart2.Chart);
      Steema.TeeChart.Styles.Points point = new Steema.TeeChart.Styles.Points(tChart2.Chart);

      bar.Marks.Visible = false;
      point.Marks.Visible = false;
      point.Color = bar.Color;
      point.Pointer.VertSize = 4;
      point.Pointer.HorizSize = 8;
      bar.Gradient.Visible = true;
      bar.Gradient.EndColor = Utils.FromArgb(0, 255, 255, 255);
      bar.Gradient.StartColor = bar.Color;
      //bar.Brush.Transparency = 20;
      bar.CustomBarWidth = 1 + (point.Pointer.HorizSize / bar.BarWidthPercent * 100);

      rand = new Random();
      for (int i = 0; i < 10; i++)
      {
        bar.Add(rand.Next(10));
        point.Add(bar.YValues.Last + rand.Next(5));
      }

      tChart2.Axes.Left.Labels.ValueFormat = "#00.000";
      tChart2.Axes.Left.SetMinMax(0, point.MaxYValue() + 1);

      //LinearGauge Chart
      Steema.TeeChart.Styles.LinearGauge lGauge1 = new Steema.TeeChart.Styles.LinearGauge(tChart3.Chart);
      Steema.TeeChart.Styles.LinearGauge lGauge2 = new Steema.TeeChart.Styles.LinearGauge(tChart3.Chart);

      foreach (LinearGauge lGauge in tChart3.Series)
      {
        lGauge.Frame.Visible = false;
        lGauge.Value = 20 + rand.Next(70);

        tChart3.Axes.Bottom.Increment = 20;
        tChart3.Axes.Bottom.Labels.Font.Size = 14;
        lGauge.Hand.VertSize = 50;

        int index = tChart3.Series.IndexOf(lGauge);
        lGauge.CustomBounds = new Rectangle(0, index * 60 + 10, 350, 70 + (index * 70));
        lGauge.FaceBrush.Transparency = 100;
        lGauge.Hand.VertSize = 30;
        lGauge.Hand.Transparency = 0;
        lGauge.Hand.Gradient.StartColor = Color.Yellow;
        lGauge.Hand.Gradient.EndColor = Color.Green;
        lGauge.Hand.Gradient.Visible = true;
        lGauge.Hand.Brush.Gradient.Visible = true;

        lGauge.GreenLine.VertSize = 15;
        lGauge.GreenLine.Gradient.StartColor = Color.Green;
        lGauge.GreenLine.Gradient.EndColor = Color.Gray;
        lGauge.RedLine.VertSize = 15;
        lGauge.RedLine.Gradient.StartColor = Color.Gray;
        lGauge.RedLine.Gradient.EndColor = Color.Red;
      }
    }

    private void DoDashTrend(Chart tChart1, Chart tChart2)
    {
      tChart1.Panel.MarginLeft = 10;
      tChart2.Panel.MarginLeft = 10;

      tChart1.Axes.Left.Title.Text = AppResources.Participation;
      tChart1.Axes.Left.Labels.Size.Width = 5;
      tChart2.Axes.Left.Labels.Size.Width = 5;
      tChart2.Axes.Left.Title.Text = AppResources.DollarValue;
      tChart1.Series.Clear();
      tChart2.Series.Clear();
      Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line();
      Steema.TeeChart.Styles.Line line2 = new Steema.TeeChart.Styles.Line();
      tChart1.Series.Clear();
      tChart1.Series.Add(line1);
      tChart1.Series.Add(line2);
      line1.LinePen.Width = 4;
      line2.LinePen.Width = 4;
      line1.FillSampleValues(20);
      line2.FillSampleValues(20);

      line1.Smoothed = true;
      line2.Smoothed = true;

      Steema.TeeChart.Styles.Area area1 = new Steema.TeeChart.Styles.Area();
      Steema.TeeChart.Styles.Area area2 = new Steema.TeeChart.Styles.Area();
      Steema.TeeChart.Styles.Line movAvg = new Steema.TeeChart.Styles.Line();

      Steema.TeeChart.Functions.MovingAverage movAvgFunc =
        new Steema.TeeChart.Functions.MovingAverage(tChart2.Chart);

      movAvgFunc.PeriodStyle = Steema.TeeChart.Functions.PeriodStyles.NumPoints;
      movAvgFunc.Period = 4;
      movAvg.Function = movAvgFunc;
      movAvg.DataSource = area2;
      movAvg.LinePen.Width = 4;
      movAvg.Smoothed = true;

      tChart2.Series.Add(area1);
      tChart2.Series.Add(area2);
      tChart2.Series.Add(movAvg);

      //tChart2.AfterDraw+=new PaintChartEventHandler(tChart2_AfterDraw);

      movAvg.AfterDrawValues += new PaintChartEventHandler(movAvg_AfterDrawValues);

      area1.Transparency = 35;
      area2.Transparency = 35;
      area1.FillSampleValues(20);
      area2.FillSampleValues(20);

      //if ((this.Orientation == PageOrientation.Landscape) ||
      //       (this.Orientation == PageOrientation.LandscapeLeft) ||
      //       (this.Orientation == PageOrientation.LandscapeRight))
      //  tChart2.Legend.Visible = false;
      //else
      //{
      tChart2.Legend.Visible = true;
      tChart2.Legend.Font.Size = 12;
      tChart2.Legend.LegendStyle = LegendStyles.Values;
      tChart2.Legend.MaxNumRows = 2;
      tChart2.Legend.Alignment = LegendAlignments.Bottom;
      //}
    }

    private void movAvg_AfterDrawValues(object sender, Steema.TeeChart.Drawing.Graphics3D g)
    {
      Series series = sender as Series;
      Chart tChart2 = series.Chart;

      if ((tChart2.Series.Count > 2) && (sender == tChart2.Series[2]) && (tChart2.Series[2].Function is Steema.TeeChart.Functions.MovingAverage))
      {
        g.Font.Color = Color.White;
        g.Font.Size = 16;
        Steema.TeeChart.Drawing.PointDouble point =
          new Steema.TeeChart.Drawing.PointDouble(tChart2.Series[2].CalcXPos(3), tChart2.Series[2].CalcYPos(3));
        string seriesLabel = AppResources.DeltaAverage;
        double textWidth = g.TextWidth(seriesLabel);
        double textHeight = g.TextHeight(seriesLabel);
        g.Brush.Color = Color.Black;
        g.Brush.Transparency = 40;
        g.Pen.Color = tChart2.Series[2].Color;
        g.Pen.Width = 2;
        g.Pen.Visible = true;
        g.Rectangle(point.X - 4, point.Y, point.X + textWidth + 4, point.Y + textHeight + 4);
        g.TextAlign = TextAlignment.Start;
        g.TextOut(point.X, point.Y, seriesLabel);
      }
    }

    private void DoDashGeographic(Chart tChart1, Chart tChart2, Color drawPenColor1)
    {
      World world1;
      tChart1.Series.Add(world1 = new World());

      Steema.TeeChart.Styles.CustomBar wbar;

      //if ((this.Orientation == PageOrientation.Landscape) ||
      //        (this.Orientation == PageOrientation.LandscapeLeft) ||
      //        (this.Orientation == PageOrientation.LandscapeRight))
      //{
      //  wbar = new Steema.TeeChart.Silverlight.Styles.HorizBar(tChart2.Chart);

      //  tChart2.Axes.Left.Labels.Separation = 1;
      //  tChart1.Footer.TextAlign = TextAlignment.Right; //map
      //  tChart2.Footer.Text = AppResources.MarketCost;
      //  tChart2.Footer.Font.Color = drawPenColor1;
      //  tChart2.Footer.TextAlign = TextAlignment.Left;
      //  tChart2.Footer.Font.Size = 14;
      //  tChart2.Footer.Visible = true;
      //  //tChart2.Footer = title as Steema.TeeChart.Silverlight.Footer;
      //}
      //else
      //{
      wbar = new Steema.TeeChart.Styles.Bar(tChart2.Chart);

      tChart2.Axes.Bottom.Labels.Angle = 90;
      tChart2.Axes.Bottom.Labels.Separation = 1;
      tChart1.Footer.TextAlign = TextAlignment.Start;  //map
      tChart2.Header.Text = AppResources.MarketCost;
      tChart2.Header.Font.Color = drawPenColor1;
      tChart2.Header.TextAlign = TextAlignment.Start;
      tChart2.Header.Font.Size = 14;
      tChart2.Header.Visible = true;
      //}

      wbar.Marks.Visible = false;

      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart2, Theme.OperaPalette);

      world1.Map = Steema.TeeChart.Styles.WorldMapType.Europe15;
      tChart1.Walls.Visible = false;
      tChart1.Panel.Transparent = true;

      //tChart1.GetLegendRect += new GetLegendRectEventHandler(tChart1_GetLegendRect);

      tChart1.Legend.Visible = true;
      tChart1.Legend.Font.Size = 12;
      tChart1.Legend.Symbol.Position = LegendSymbolPosition.Right;
      world1.ValueFormat = "0.0";

      tChart1.Axes.Visible = false;

      tChart1.Footer.Font.Color = drawPenColor1;
      tChart1.Footer.Text = AppResources.EUIndex + Utils.NewLine + AppResources.OrganicFood;
      tChart1.Footer.Font.Size = 13;
      tChart1.Footer.Visible = true;

      //world1.StartColor = Color.FromArgb(255,255,128,64);
      world1.StartColor = Utils.FromArgb(255, 215, 70, 0);
      world1.EndColor = Utils.FromArgb(255, 255, 233, 0);
      wbar.Color = Utils.FromArgb(255, 255, 128, 64); // world1.StartColor;
      int[] territories = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
      for (int i = 0; i < world1.Shapes.Count; i++)
      {
        if (((String)(world1.Labels[i])) == "Austria")
        {
          world1.ZValues[i] = 89;
          if (territories[0] == 0)
          {
            wbar.Add(4.5, (String)(world1.Labels[i]));
            territories[0] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == "Denmark")
        {
          world1.ZValues[i] = 107;
          if (territories[1] == 0)
          {
            wbar.Add(4, (String)(world1.Labels[i]));
            territories[1] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Finland"))
        {
          world1.ZValues[i] = 78;
          if (territories[2] == 0)
          {
            wbar.Add(7.5, (String)(world1.Labels[i]));
            territories[2] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Luxembourg"))
        {
          world1.ZValues[i] = 86;
          if (territories[3] == 0)
          {
            wbar.Add(4.2, (String)(world1.Labels[i]));
            territories[3] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Belgium"))
        {
          world1.ZValues[i] = 71;
          if (territories[4] == 0)
          {
            wbar.Add(9.1, (String)(world1.Labels[i]));
            territories[4] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Netherlands"))
        {
          world1.ZValues[i] = 78;
          if (territories[5] == 0)
          {
            wbar.Add(3.9, (String)(world1.Labels[i]));
            territories[5] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Germany"))
        {
          world1.ZValues[i] = 64;
          if (territories[6] == 0)
          {
            wbar.Add(1.2, (String)(world1.Labels[i]));
            territories[6] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Sweden"))
        {
          world1.ZValues[i] = 53;
          if (territories[7] == 0)
          {
            wbar.Add(6.0, (String)(world1.Labels[i]));
            territories[7] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("UK"))
        {
          world1.ZValues[i] = 42;
          if (territories[8] == 0)
          {
            wbar.Add(4.7, (String)(world1.Labels[i]));
            territories[8] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Ireland"))
        {
          world1.ZValues[i] = 24;
          if (territories[9] == 0)
          {
            wbar.Add(-0.2, (String)(world1.Labels[i]));
            territories[9] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Italy"))
        {
          world1.ZValues[i] = 32;
          if (territories[10] == 0)
          {
            wbar.Add(6.1, (String)(world1.Labels[i]));
            territories[10] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("France"))
        {
          world1.ZValues[i] = 30;
          if (territories[11] == 0)
          {
            wbar.Add(7.9, (String)(world1.Labels[i]));
            territories[11] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Spain"))
        {
          world1.ZValues[i] = 13;
          if (territories[12] == 0)
          {
            wbar.Add(3.9, (String)(world1.Labels[i]));
            territories[12] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Greece"))
        {
          world1.ZValues[i] = 7;
          if (territories[13] == 0)
          {
            wbar.Add(2.1, (String)(world1.Labels[i]));
            territories[13] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Portugal"))
        {
          world1.ZValues[i] = 11;
          if (territories[14] == 0)
          {
            wbar.Add(0.5, (String)(world1.Labels[i]));
            territories[14] = 1;
          }
        }
        else if (((String)(world1.Labels[i])) == ("Poland"))
        {
          world1.ZValues[i] = 1;
          if (territories[15] == 0)
          {
            wbar.Add(1.9, (String)(world1.Labels[i]));
            territories[15] = 1;
          }
        }
      }

      world1.Pen.Color = Color.Black;
      world1.Pen.Width = 1;
      world1.Pen.Visible = true;
    }
  }
}
