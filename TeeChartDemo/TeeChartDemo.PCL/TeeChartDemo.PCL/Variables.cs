#if PORTABLE
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Themes;
using Steema.TeeChart.Tools;
using Styles = Steema.TeeChart.Styles;
using Drawing = Steema.TeeChart.Drawing;
using Languages = Steema.TeeChart.Languages;
using Themes = Steema.TeeChart.Themes;
using Tools = Steema.TeeChart.Tools;
using Xamarin.Forms;
#else
using Steema.TeeChart.Silverlight;
using Steema.TeeChart.Silverlight.Styles;
using Steema.TeeChart.Silverlight.Drawing;
using Steema.TeeChart.Silverlight.Tools;
using Steema.TeeChart.Silverlight.Themes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TeeChartForWindowsPhone.Resources;
using Microsoft.Phone.Controls;
using Styles = Steema.TeeChart.Silverlight.Styles;
using Drawing = Steema.TeeChart.Silverlight.Drawing;
using Languages = Steema.TeeChart.Silverlight.Languages;
using Themes = Steema.TeeChart.Silverlight.Themes;
using Tools = Steema.TeeChart.Silverlight.Tools;
#endif
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows;

#if PORTABLE
namespace TeeChartDemo.PCL
#else
namespace TeeChartForWindowsPhone
#endif
{
  public static class Variables
  {
    static Variables()
    {
      Series = Tool = Theme = Dash = null;
      ForceThreeD = ThreeD = false;
      Points = 0;
      GestureStyle = 0;
      FromSeriesToolORTheme = 0;
      SeriesList = new List<ElementWrapper>();
      ToolsList = new List<ElementWrapper>();
      ThemesList = new List<ElementWrapper>();
      DashList = new List<ElementWrapper>();
    }

    public static List<ElementWrapper> SeriesList { get; set; }
    public static List<ElementWrapper> ToolsList { get; set; }
    public static List<ElementWrapper> ThemesList { get; set; }
    public static List<ElementWrapper> DashList { get; set; }
    public static ElementWrapper Series { get; set; }
    public static ElementWrapper Tool { get; set; }
    public static ElementWrapper Theme { get; set; }
    public static ElementWrapper Dash { get; set; }
    public static bool ThreeD { get; set; }
    public static bool ForceThreeD { get; set; }
    public static int Points { get; set; }
    public static int GestureStyle { get; set; }
    public static int FromSeriesToolORTheme { get; set; }

#if PORTABLE
    public delegate TOutput Converter<TInput, TOutput>(TInput input);
#endif


#if PORTABLE
    public static void ModifySeries(Chart tChart1, Color drawPenColor1)
#else
    public static void ModifySeries(Chart tChart1, Color drawPenColor1, PageOrientation orientation) 
#endif
    {
      if (tChart1[0] is Steema.TeeChart.Styles.Circular)
      {
        (tChart1[0] as Steema.TeeChart.Styles.Circular).Circled = true;
      }

      if (tChart1.Series[0] is Clock)
      {
        Clock clock = ((Clock)(tChart1.Series[0]));

#if PORTABLE
        tChart1.Touch.Options = TouchOptions.None;
#else
        tChart1.Aspect.GestureOptions = Drawing.Aspect.Gestures.None;
#endif
        tChart1.Aspect.RenderSeriesAsImage = false;

        clock.GetVertAxis.Grid.Visible = false;
#if PORTABLE
        clock.CircleLabelsFont.Color = Color.Black;
#else
        clock.CircleLabelsFont.Color = Colors.White;
#endif
      }

      if (tChart1.Series[0] is Area)
      {
        if (tChart1.Series[0] is HorizArea)
        {
            tChart1.Header.Text = "HorizArea - Pinch and drag to Vertical Scroll and Zoom";
          // Gesture options to vertical
          tChart1.Zoom.Direction = ZoomDirections.Vertical;
          tChart1.Panning.Allow = ScrollModes.Vertical;
            
          tChart1.Series.Add(new Styles.HorizArea());
          tChart1.Series.Add(new Styles.HorizArea());
          tChart1.Series.Add(new Styles.HorizArea());

          foreach (Series s in tChart1.Series)
          {
              ((Styles.HorizArea)s).Transparency = 35;
              ((Styles.HorizArea)s).AreaLines.Transparency = 35;
              ((Styles.HorizArea)s).LinePen.Visible = false;
              ((Styles.HorizArea)s).AreaLines.Visible = false;
              ((Styles.HorizArea)s).FillSampleValues(50);
          }
        }
        else
        {
          tChart1.Header.Text = "Area - Pinch and drag to Horizontal Scroll and Zoom";

          // Gesture options to horizontal
          tChart1.Zoom.Direction = ZoomDirections.Horizontal;
          tChart1.Panning.Allow = ScrollModes.Horizontal;

          tChart1.Series.Add(new Styles.Area());
          tChart1.Series.Add(new Styles.Area());
          tChart1.Series.Add(new Styles.Area());

          foreach (Series s in tChart1.Series)
          {
              ((Styles.Area)s).Transparency = 35;
              ((Styles.Area)s).AreaLines.Transparency = 35;
              ((Styles.Area)s).LinePen.Visible = false;
              ((Styles.Area)s).AreaLines.Visible = false;
              ((Styles.Area)s).FillSampleValues(50);
              ((Styles.Area)s).Stacked = CustomStack.Stack;
          }
        }
      }

      if ((tChart1.Series[0] is CustomBar) && !(tChart1.Series[0] is Bar3D))
      {
        CustomBar bar = ((CustomBar)(tChart1.Series[0]));
        bar.Brush.Transparency = 25;
        bar.MarksOnBar = true;

#if !PORTABLE
        if ((App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark))
          bar.Marks.Font.Color = Colors.Black;
#endif
        bar.Pen.Visible = false;
        if (tChart1.Series[0] is HorizBar)
          bar.Marks.Font.Size = 18;
        else
          bar.Marks.Font.Size = 16;
        bar.CustomBarWidth = 50;
        Random r = new Random();
        bar.Clear();
        for (int i = 0; i < 5; i++)
          bar.Add(r.Next(999));
      }

#if !PORTABLE
      if (tChart1.Series[0] is Bar3D)
      {
        CustomBar bar = ((CustomBar)(tChart1.Series[0]));
        if (!(App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark))
        {
          bar.Brush.Transparency = 25;
          bar.Marks.Arrow.Color = Colors.Black;
          bar.Marks.Font.Color = Colors.Black;
        }
      }
#endif

      if (tChart1.Series[0] is Bubble)
      {
        Bubble bubble = ((Bubble)(tChart1.Series[0]));
        bubble.Pointer.Gradient.Visible = true;
        bubble.Pointer.Brush.Gradient.Direction = GradientDirection.Radial;
      }

      if (tChart1.Series[0] is Styles.Line)
      {
          tChart1.Header.Text += " - Pinch or Drag for Zoom or Scroll";
          if (tChart1.Series[0] is Styles.HorizLine)
          {
              tChart1.Series.Add(new Styles.HorizLine());
          }
          else
          {
              tChart1.Series.Add(new Styles.Line());
              tChart1.Series.Add(new Styles.Line());
              tChart1.Series.Add(new Styles.Line());
          }

        foreach (Series s in tChart1.Series)
        {
          if (s is Styles.Line)
            ((Styles.Line)s).LinePen.Width = 4;
            ((Styles.Line)s).Pointer.Visible = true;
            ((Styles.Line)s).Pointer.Pen.Visible = false;
            s.FillSampleValues();
        }
      }

      if (tChart1.Series[0] is Styles.Bezier)
      {
        Bezier bezier = ((Bezier)(tChart1.Series[0]));
        bezier.LinePen.Width = 3;
      }

      if (tChart1.Series[0] is Styles.Candle)
      {
        Candle candle = ((Candle)(tChart1.Series[0]));
        candle.LinePen.Width = 3;
        candle.Pen.Color = Color.Black;
        candle.LinePen.Color = Color.Black;
#if PORTABLE
        candle.DownCloseColor = Color.Fuschia;
#else
        candle.DownCloseColor = Colors.Orange;
#endif
      }

      if (tChart1.Series[0] is Styles.CircularGauge)
      {
        CircularGauge cGauge = ((CircularGauge)(tChart1.Series[0]));
        if (!(tChart1.Series[0] is Styles.KnobGauge))
#if PORTABLE
          cGauge.Axis.Labels.Font.Color = Color.Black;
#else
          cGauge.Axis.Labels.Font.Color = Colors.White;
#endif
        else
        {
#if PORTABLE          
            tChart1.Touch.Options = TouchOptions.Drag;
#else
          tChart1.Aspect.GestureOptions = Drawing.Aspect.Gestures.DragOnly;
#endif
          tChart1.Aspect.RenderSeriesAsImage = false;
          ((KnobGauge)tChart1.Series[0]).ValueChanged += new GaugesChangeHandler(KnobGauge_ValueChanged);
        }
      }

      if (tChart1.Series[0] is Styles.Pyramid)
      {
        Pyramid pyramid = ((Pyramid)(tChart1.Series[0]));
        tChart1.Axes.Bottom.SetMinMax(-1, 1);
      }

      if (tChart1.Series[0] is Styles.Shape)
      {
        tChart1.Series.Add(new Styles.Shape());
        foreach (Series s in tChart1.Series)
        {
          Styles.Shape shape = ((Styles.Shape)s);
          shape.Brush.Transparency = 30;
        }
      }

      if (tChart1.Series[0] is Styles.Contour)
      {
        Contour contour = ((Contour)(tChart1.Series[0]));
        contour.NumLevels = 20;
        contour.Pen.Width = 2;
        tChart1.Aspect.View3D = false;
        tChart1.Walls.Back.Transparency = 10;
      }

      if (tChart1.Series[0] is Styles.Darvas)
      {
        Darvas darvas = ((Darvas)(tChart1.Series[0]));
        darvas.Brush.Transparency = 40;
        tChart1.Axes.Bottom.Labels.Angle = 90;
      }

      if (tChart1.Series[0] is Styles.Pie)
      {
        tChart1.Header.Text = "Pie - Touch a slice to explode it";
        Pie pie = ((Pie)(tChart1.Series[0]));
        pie.Marks.Visible = false;
        pie.BevelPercent = 25;
        pie.Pen.Visible = false;
        pie.EdgeStyle = EdgeStyles.Flat;
        pie.Circled = true;        
        pie.FillSampleValues(6);
        tChart1.Legend.Visible = true;
        tChart1.Legend.Font.Size = 15;
        tChart1.Legend.Transparency = 30;
        tChart1.Legend.Alignment = LegendAlignments.Bottom;
        tChart1.Aspect.View3D = true;
        tChart1.Aspect.VertOffset = -20;

        if (!(tChart1.Series[0] is Donut))
        {
          tChart1.Aspect.Chart3DPercent = 30;
          pie.BevelPercent = 15;
          tChart1.Legend.Transparent = true;
          tChart1.Legend.Font.Size = 16;
        }

        tChart1.ClickSeries += tChart1_ClickSeries;

#if !PORTABLE
        if ((orientation == PageOrientation.Landscape) ||
           (orientation == PageOrientation.LandscapeLeft) ||
           (orientation == PageOrientation.LandscapeRight))
        {
          tChart1.Legend.Alignment = LegendAlignments.Left;
        }
#endif
      }

      if (tChart1.Series[0] is Styles.CustomError)
      {
        Styles.CustomError error = ((Styles.CustomError)(tChart1.Series[0]));
        error.ErrorPen.Width = 3;
        error.ErrorPen.Color = Color.Black;
      }


      if (tChart1.Series[0] is Styles.Gantt)
      {
        Gantt gantt = ((Styles.Gantt)(tChart1.Series[0]));
        gantt.LinePen.Width = 2;
        gantt.LinePen.Color = Color.Black;
        tChart1.Axes.Bottom.Labels.Angle = 90;
        tChart1.Axes.Bottom.Labels.Font.Size = 8;
      }

      if (tChart1.Series[0] is Styles.HighLow)
      {
        HighLow highLow = ((HighLow)(tChart1.Series[0]));
        highLow.Pen.Width = 2;
#if !PORTABLE
        if (App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark)
        {
          highLow.Pen.Color = Colors.White;
          highLow.LowPen.Color = Colors.White;
          highLow.HighPen.Color = Colors.White;
        }
#endif
        highLow.bBrush.Gradient.Visible = true;
        highLow.HighBrush.Visible = true;
        highLow.HighBrush.Gradient.Visible = true;
        highLow.LowBrush.Visible = true;

        Color[] customColors = Themes.ColorPalettes.GetPalette(13); //Theme.OperaPalette
        highLow.LowPen.Width = 2;
        highLow.LowBrush.Gradient.Visible = true;
        highLow.LowBrush.Gradient.StartColor = customColors[0];
#if PORTABLE
        highLow.LowBrush.Gradient.EndColor = Color.White;
        highLow.HighBrush.Gradient.EndColor = Color.White;
#else
        highLow.LowBrush.Gradient.EndColor = Colors.White;
        highLow.HighBrush.Gradient.EndColor = Colors.White;
#endif
        highLow.HighPen.Width = 2;
        highLow.HighBrush.Gradient.StartColor = customColors[2];
        Random r = new Random();
        highLow.FillSampleValues(15);
        for (int i = 0; i < highLow.Count; i++)
          highLow.LowValues[i] = (highLow.HighValues[i] * 0.7) + r.Next((int)Math.Abs((highLow.HighValues[i] / 2)));
      }

      if (tChart1.Series[0] is Styles.Histogram)
      {
        Histogram histogram = ((Histogram)(tChart1.Series[0]));
        histogram.Transparency = 30;
      }

      if (tChart1.Series[0] is Styles.Kagi)
      {
        Kagi kagi = ((Kagi)(tChart1.Series[0]));
        kagi.LinePen.Width = 3;
      }

      if (tChart1.Series[0] is Styles.IsoSurface)
      {
        IsoSurface isoSurface = ((IsoSurface)(tChart1.Series[0]));
        tChart1.Walls.Visible = false;
        tChart1.Axes.Depth.Visible = false;
        tChart1.Aspect.Zoom = 120;
        isoSurface.Pen.Visible = false;
      }

      //if (tChart1.Series[0] is Styles.NumericGauge)   //pending
      //{
      //    NumericGauge nGauge = ((NumericGauge)(tChart1.Series[0]));
      //}

      if ((tChart1.Series[0] is Styles.Custom3DGrid) ||
          (tChart1.Series[0] is Styles.TriSurface) ||
          (tChart1.Series[0] is Styles.Points3D) ||
          (tChart1.Series[0] is Styles.Vector3D))
      {

#if PORTABLE
          tChart1.Touch.Options = TouchOptions.None;
#endif
        tChart1.Axes.Depth.Visible = true;
        //tChart1.Aspect.Zoom = 75;
        tChart1.Aspect.Chart3DPercent = 70;

        if (tChart1.Series[0] is Styles.Custom3DGrid)
        {
          Custom3DGrid cGrid = ((Custom3DGrid)(tChart1.Series[0]));
          cGrid.UsePalette = true;
          cGrid.UseColorRange = false;
          cGrid.PaletteStyle = PaletteStyles.Pale;

          if (tChart1.Series[0] is Styles.Waterfall)
          {
            //cGrid.Pen.Visible = false;
            ((Waterfall)(cGrid)).WaterLines.Visible = false;
          }

          if ((tChart1.Series[0] is Styles.Surface) &&
              !(tChart1.Series[0] is Styles.Waterfall)
              && !(tChart1.Tools.Count > 0 && tChart1.Tools[0] is Tools.LegendPalette))
          {
            //tChart1.Axes.Left.SetMinMax(-2, 2);
            //tChart1.Axes.Bottom.SetMinMax(0, 3);
            //tChart1.Axes.Depth.SetMinMax(0.5, 5.6);

            cGrid.IrregularGrid = true;

            double[] xval = new double[10];
            double[] zval = new double[10];

            xval[0] = 0.1;
            xval[1] = 0.2;
            xval[2] = 0.3;
            xval[3] = 0.5;
            xval[4] = 0.8;
            xval[5] = 1.1;
            xval[6] = 1.5;
            xval[7] = 2.0;
            xval[8] = 2.2;
            xval[9] = 3.0;

            zval[0] = 0.5;
            zval[1] = 0.6;
            zval[2] = 0.7;
            zval[3] = 0.75;
            zval[4] = 0.8;
            zval[5] = 1.1;
            zval[6] = 1.5;
            zval[7] = 2.0;
            zval[8] = 2.2;
            zval[9] = 5.6;

            // Now add all "Y" points... 
            cGrid.Clear();

            // An irregular grid of 10 x 10 cells
            cGrid.NumXValues = 10;
            cGrid.NumZValues = 10;

            for (int x = 0; x < 10; x++)
              for (int z = 0; z < 10; z++)
              {
                double y = Math.Sin(z * Math.PI / 10.0) * Math.Cos(x * Math.PI / 5.0);  // example Y value
                cGrid.Add(xval[x], y, zval[z]);
              }
          }
          else
          {
            //tChart1.Axes.Left.SetMinMax(-1, 1);
            //tChart1.Axes.Bottom.SetMinMax(0, 10);
            //tChart1.Axes.Depth.SetMinMax(0, 10);
            cGrid.FillSampleValues();
          }
        }
      }

      if (tChart1.Series[0] is Styles.Arrow)
      {
        Arrow arrow = ((Arrow)(tChart1.Series[0]));
        arrow.LinePen.Width = 1;
        arrow.ColorEachPoint = true;
      }

      if (tChart1.Series[0] is Styles.BarJoin)
      {
        BarJoin barJoin = ((BarJoin)(tChart1.Series[0]));
        barJoin.JoinPen.Color = Color.Red;
        barJoin.JoinPen.Width = 2;
      }

      if (tChart1.Series[0] is Styles.Box)
      {
#if PORTABLE
        Color penColor = Color.Black;
#else
        Color penColor = Colors.Black;

        if (App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark)
          penColor = drawPenColor1;
#endif

        Box box = ((Box)(tChart1.Series[0]));
        box.ExtrOut.HorizSize = 3;
      }

      if (tChart1.Series[0] is Styles.OrgSeries)
      {
        OrgSeries org = ((OrgSeries)(tChart1.Series[0]));
        for (int i = 0; i < org.Count; i++)
        {
          ((OrgItem)(org.Items[i])).Format.Transparent = true;
          ((OrgItem)(org.Items[i])).Format.Font.Bold = true;

#if PORTABLE
          ((OrgItem)(org.Items[i])).Format.Font.Size = 10;
#else
          if ((orientation == PageOrientation.Landscape) ||
              (orientation == PageOrientation.LandscapeLeft) ||
              (orientation == PageOrientation.LandscapeRight))
          {
            ((OrgItem)(org.Items[i])).Format.Font.Size = 15;
            tChart1.Aspect.HorizOffset = 5;
          }
          else
          {
            ((OrgItem)(org.Items[i])).Format.Font.Size = 10;
          }
#endif
        }
      }

      if ((tChart1.Series[0] is Styles.Points) &&
          (((Styles.Points)tChart1.Series[0]).Description == Texts.GalleryPoint))
      {
        tChart1.Legend.Transparent = true;
        tChart1.Legend.Font.Color = Color.Black;
        tChart1.Legend.Font.Size = 16;
        tChart1.Legend.Visible = true;
        tChart1.Legend.Alignment = LegendAlignments.Bottom;

        tChart1.Series.Add(new Points());

        foreach (Series s in tChart1.Series)
        {
          if (s is Styles.Points)
          {
            Points points = ((Styles.Points)s);

            points.Pointer.VertSize = 8;
            points.Pointer.HorizSize = 8;
            if (tChart1.Series.IndexOf(points) == 0)
              points.Pointer.Style = PointerStyles.Sphere;
            else
              points.Pointer.Style = PointerStyles.Triangle;

            points.Marks.Visible = false;
            points.Marks.Font.Color = Color.Black;
            points.Marks.Font.Size = 15;
            points.Marks.Transparent = true;
            s.FillSampleValues();
          }
        }
      }

      if (tChart1.Series[0] is Styles.CustomPolar)
      {
        CustomPolar polar = ((Styles.CustomPolar)tChart1.Series[0]);

        if ((tChart1.Series[0] is Styles.PolarGrid) ||
            (tChart1.Series[0] is Styles.Radar))
        {
          polar.Transparency = 30;
          polar.FillSampleValues(7);
        }
        else if (tChart1.Series[0] is Styles.PolarBar)
        {
          polar.Pen.Width = 3;
          polar.FillSampleValues(15);
        }
        else
        {
          polar.FillSampleValues(3);
          polar.Transparency = 30;
        }
      }

      if (tChart1.Series[0] is Styles.Smith)
      {
        Smith smith = ((Styles.Smith)tChart1.Series[0]);

        smith.Pen.Width = 2;
        smith.Pen.Color = Color.Black;
      }

      if (tChart1.Series[0] is Styles.TagCloud)
      {
        TagCloud tag = ((Styles.TagCloud)tChart1.Series[0]);

        tChart1.Panel.Transparent = false;
#if PORTABLE
        tChart1.Panel.Color = Color.Black;
        tChart1.Panel.Gradient.StartColor = Color.Black;
        tChart1.Panel.Gradient.EndColor = Color.Black;
#else
        tChart1.Panel.Color = Colors.Black;
        tChart1.Panel.Gradient.StartColor = Colors.Black;
        tChart1.Panel.Gradient.EndColor = Colors.Black;
#endif
        tChart1.Panel.Gradient.Visible = true;
        tChart1.Panel.Pen.Visible = false;
        tChart1.Panel.Bevel.Width = 0;

#if PORTABLE
        tChart1.Panel.Transparency = 40;
#else
        if (App.CurrentTheme == TeeChartForWindowsPhone.App.Theme.Dark)
          tChart1.Panel.Transparency = 30;
        else
          tChart1.Panel.Transparency = 40;
#endif

        ColorList customColors = new ColorList(Themes.ColorPalettes.GetPalette(3));
        tag.Colors = customColors;
        tag.FillSampleValues(50);
      }

      if (tChart1.Series[0] is Styles.Ternary)
      {
        Ternary ternary = ((Styles.Ternary)tChart1.Series[0]);
        ternary.TernaryStyle = TernaryStyle.Bubble;
        ternary.Pointer.Style = PointerStyles.Circle;
      }

      if (tChart1.Series[0] is Styles.Tower)
      {
        Tower tower = ((Styles.Tower)tChart1.Series[0]);
        tower.FillSampleValues(10);

        tChart1.Aspect.View3D = true;
        tChart1.Aspect.Orthogonal = false;
        tChart1.Aspect.Perspective = 80;
        tChart1.Aspect.Chart3DPercent = 65;
        tChart1.Aspect.Rotation = 330;
        tChart1.Aspect.ZoomFloat = 75;

        tChart1.Header.Text = "Tower Series - Drag to Rotate !";
        tChart1.Header.Font.Size = 20;
        tChart1.Legend.Font.Size = 14;
        tChart1.Axes.Left.Labels.Font.Size = 14;
        tChart1.Axes.Bottom.Labels.Font.Size = 14;
        tChart1.Axes.Depth.Labels.Font.Size = 14;

        tower.UsePalette = true;

        Random r = new Random(1000);

        tower.Clear();
        for (int x = 1; x <= 10; x++)
            for (int z = 1; z <= 10; z++)
                tower.Add(x, r.Next(1000) - 100, z);

        tower.Origin = 500;
        tower.UseOrigin = true;

        tChart1.Tools.Add(typeof(Steema.TeeChart.Tools.Rotate));
      }

      if (tChart1.Series[0] is Styles.Map)
      {
          Map map = ((Styles.Map)tChart1.Series[0]);
          tChart1.Aspect.View3D = false;
      }

      if (tChart1.Series[0] is Styles.LinearGauge)
      {
          LinearGauge lineargauge = ((Styles.LinearGauge)tChart1.Series[0]);
          lineargauge.Axis.Labels.Font.Color = Color.Silver;
      }
    }

    static void tChart1_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
    {
      if (s is Styles.Pie)
      {
        var pie = (Styles.Pie)s;
        pie.ExplodedSlice[valueIndex] = (pie.ExplodedSlice[valueIndex] > 0) ? 0 : 15;
      }
    }

    public static void KnobGauge_ValueChanged(object sender, EventArgs e)
    {
      KnobGauge knob = (KnobGauge)sender;
      knob.FaceBrush.Transparency = Utils.Round(knob.Value);
      knob.Center.Transparency = knob.FaceBrush.Transparency;
    } 

    public static void AddSeries()
    {
      List<Type> list = new List<Type>();

      list = ConvertAll(Utils.SeriesTypesOf, delegate(Type input)
      {
        return input;
      });

      foreach (Type t in list)
      {
        Variables.SeriesList.Add(new ElementWrapper(t));
      }

      try
      {
        Variables.SeriesList.Sort(delegate(ElementWrapper x, ElementWrapper y)
        {
          return String.Compare(x.ToString(), y.ToString());
        });

      }
      catch (Exception ee)
      {
         string s = ee.Message;
      }
    }

    public static void AddTools()
    {
      List<Type> list = new List<Type>();

      list = ConvertAll(Utils.ToolTypesOf, delegate(Type input)
      {
        return input;
      });

      foreach (Type t in list)
      {
        Variables.ToolsList.Add(new ElementWrapper(t));
      }

      Variables.ToolsList.Sort(delegate(ElementWrapper x, ElementWrapper y)
      {
        return String.Compare(x.ToString(), y.ToString());
      });
    }

    public static void AddThemes()
    {
      List<Type> list = new List<Type>();

#if PORTABLE
      list = ConvertAll(Steema.TeeChart.Themes.Theme.ChartThemes, delegate(Type input)
#else
      list = ConvertAll(Themes.Theme.ChartThemes, delegate(Type input)
#endif
      {
        return input;
      });

      foreach (Type t in list)
      {
        Variables.ThemesList.Add(new ElementWrapper(t));
      }

      Variables.ThemesList.Sort(delegate(ElementWrapper x, ElementWrapper y)
      {
        return String.Compare(x.ToString(), y.ToString());
      });
    }

    public static void AddDash()
    {
      List<String> list = new List<String> { AppResources.DashGeographic, AppResources.DashTrend, AppResources.DashExposure, AppResources.DashDigital };

      foreach (String t in list)
      {
        Variables.DashList.Add(new ElementWrapper(t));
      }
    }

    public static List<TOutput> ConvertAll<TInput, TOutput>(List<TInput> AList, Converter<TInput, TOutput> converter)
    {
      List<TOutput> list = new List<TOutput>(AList.Count);
      for (int i = 0; i < AList.Count; i++)
      {
        list.Add(converter(AList[i]));
      }
      return list;
    }
  }


#if PORTABLE
  public class ElementWrapper : View
#else
  public class ElementWrapper
#endif

  {
    String desc, summ;

    public ElementWrapper(Type type)
    {
      this.ElementType = type;
#if PORTABLE
      Summary = GetDescription();
      Description = ToString();
#endif

    }

    public ElementWrapper(String title)
    {
      this.ElementType = null;
      desc = title;
#if PORTABLE
      Summary = GetDescription();
      Description = ToString();
#endif
    }

    public Type ElementType
    {
      get;
      set;
    }

    public override string ToString()
    {
      if (ElementType != null)
      {
        if (instance == null)
        {
#if PORTABLE
          switch (AppResources.Locale().Substring(0, 2))
#else
          switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
#endif
          {
            case "ca":
              Languages.Catalan.Activate();
              break;
            case "es":
              Languages.Spanish.Activate();
              break;
            case "en":
              Languages.English.Activate();
              break;
          }
          instance = Activator.CreateInstance(ElementType);
        }

        if (String.IsNullOrEmpty(desc))
        {
          if (instance is Series)
            desc = ((Series)instance).Description;
          else if (instance is Tool)
            desc = ((Tool)instance).Description;
          else if (instance is Theme)
            desc = ((Theme)instance).ToString();
        }
      }

      return desc;
    }

    private object instance = null;

#if PORTABLE
    public static readonly BindableProperty DescriptionProperty =
      BindableProperty.Create("DescriptionProperty", typeof(String), typeof(ElementWrapper), "");

    public string Description
    {
      get 
      {
        return (string)GetValue(DescriptionProperty); 
      }
      set 
      {
        SetValue(DescriptionProperty, value); 
      }
    }

    public static readonly BindableProperty SummaryProperty =
      BindableProperty.Create("SummaryProperty", typeof(String), typeof(ElementWrapper), "");

    public string Summary
    {
      get
      {
        return (string)GetValue(SummaryProperty);
      }
      set
      {
        SetValue(SummaryProperty, value);
      }
    }

#endif

#if PORTABLE
    public string GetDescription()
#else
    public string Description()
#endif

    {
      if (ElementType != null)
      {
        if (instance == null)
        {
#if PORTABLE
          switch (AppResources.Locale().Substring(0, 2))
#else
          switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
#endif
          {
            case "ca":
              Languages.Catalan.Activate();
              break;
            case "es":
              Languages.Spanish.Activate();
              break;
            case "en":
              Languages.English.Activate();
              break;
          }
          instance = Activator.CreateInstance(ElementType);
        }

        if (String.IsNullOrEmpty(summ))
        {
          if (instance is Tool)
          {
            summ = ((Tool)instance).Summary;
          }
        }
        else
        {
          summ = ToString();
        }
#if PORTABLE
        if (!String.IsNullOrEmpty(summ) && summ.Length >= 45)
        {
          summ = summ.Insert(summ.LastIndexOf(" ", 45) + 1, Utils.NewLine);
        }
#endif
      }


      if (String.IsNullOrEmpty(summ))
        return ToString();
      else
        return summ;
    }
  }
}
