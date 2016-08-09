#if PORTABLE
#define DESIGNATTRIBUTES
#endif

#if DESIGNATTRIBUTES

using System;
using System.Text;
using System.ComponentModel;
using Steema.TeeChart;
#if WPF
using Steema.TeeChart.WPF;
using Steema.TeeChart.WPF.Tools;
using Steema.TeeChart.WPF.Themes;
using System.Windows.Controls;
using Steema.TeeChart.WPF.Styles;
using Microsoft.Win32;
using Steema.TeeChart.WPF.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;
#elif SILVERLIGHT
using Steema.TeeChart.Silverlight;
using Steema.TeeChart.Silverlight.Tools;
using Steema.TeeChart.Silverlight.Themes;
using System.Windows.Controls;
using Steema.TeeChart.Silverlight.Styles;
using Microsoft.Win32;
using Steema.TeeChart.Silverlight.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;
#elif PORTABLE
using Steema.TeeChart.Tools;
using Steema.TeeChart.Themes;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Drawing;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Reflection;
#elif STORE
using Steema.TeeChart.Store;
using Steema.TeeChart.Store.Tools;
using Steema.TeeChart.Store.Themes;
using Steema.TeeChart.Store.Styles;
using Steema.TeeChart.Store.Drawing;
using System.Windows.Input;
using System.Windows;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using System.Reflection;
using System.IO;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
#else
using Steema.TeeChart.Tools;
using System.Windows.Forms;
using Steema.TeeChart.Themes;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Drawing;
using System.Drawing;
#endif


#if SILVERLIGHT
namespace Steema.TeeChart.Silverlight.Editors.Tools
#elif WPF
namespace Steema.TeeChart.WPF.Editors.Tools
#elif STORE
namespace Steema.TeeChart.Store.Editors.Tools
#else
namespace Steema.TeeChart.Editors.Tools 
#endif
{
#if DESIGNATTRIBUTES
#if !SILVERLIGHT && !STORE && !PORTABLE
  [DesignTimeVisible(false), ToolboxItem(false)]
#endif
#endif
#if WPF || SILVERLIGHT || STORE || PORTABLE
  public class ToolsGalleryDemos
#else
  public class ToolsGalleryDemos : System.Windows.Forms.Panel
#endif
  {
#if POCKET
    private Pocket.TChart chart;
#elif STORE || PORTABLE
    private Chart chart;
#else
        private TChart chart;
#endif

#if WPF || SILVERLIGHT || STORE || PORTABLE
    private Type themeType;
#if !PORTABLE
    private UIElementCollection children;
#endif


#if STORE || PORTABLE
    public ToolsGalleryDemos() { }

#if PORTABLE
    public ToolsGalleryDemos(Chart c, Type t)
#else
    public ToolsGalleryDemos(Chart c, Type t, UIElementCollection ch)
#endif
#else
    public ToolsGalleryDemos(TChart c, Type t, UIElementCollection ch)
#endif
    {
      chart = c;
      themeType = t;
#if !PORTABLE
      children = ch;
#endif
    }
#else
    public ToolsGalleryDemos()
    {
      BackColor = Color.FromArgb(196, 196, 196);
#if !POCKET
      BorderStyle = BorderStyle.FixedSingle;
#endif
    }
#endif


    public void chart_DoubleClick(object sender, EventArgs e)
    {

    }

    public bool View3D
    {
      get { return chart.Aspect.View3D; }
      set { chart.Aspect.View3D = value; }
    }

    public void CreateChart(Type ATool)
    {
      CreateChart(ATool, "", null);
    }

    public void CreateChart(Type ATool, string ATitle)
    {
      CreateChart(ATool, ATitle, null);
    }

    public void CreateChart(Type ATool, string ATitle, Type ASeries)
    {
#if SILVERLIGHT || STORE 
      if (iControls.Count > 0 && children != null)
      {
        foreach (var item in iControls) children.Remove(item);
        iControls.Clear();
      }
#elif WPF
      chart.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(chart_DoubleClick);
#elif POCKET
      chart = new Pocket.TChart();
			chart.IsToolDemoChart = true;
			chart.Dock = DockStyle.Fill;
#elif !PORTABLE
      chart = new TChart();
      chart.Dock = DockStyle.Fill;
      chart.DoubleClick += new EventHandler(chart_DoubleClick);
#endif

      chart.Legend.Visible = false;
      chart.Header.Text = "";

#if !WPF && !SILVERLIGHT && !STORE && !PORTABLE
      Controls.Clear();
      Controls.Add(chart);
#endif
      if (ATool != null)
      {
        chart.Tools.Add(ATool);
      }

      if (ASeries == null)
      {
#if STORE || PORTABLE
        if (chart.Tools[0] is ToolAxis)
        {
          chart.Series.Add(GetSeriesWithAxis());
        }
        else if (chart.Tools[0] is ToolSeries)
        {
          chart.Series.Add(GetSeriesWithAxis());
        }
        else
        {
          chart.Series.Add(GetSeriesWithOutAxis());
        }
#else
        chart.Series.Add(new Line());
#endif
      }
      else
      {
        chart.Series.Add(ASeries);
      }

      chart[0].FillSampleValues();
      chart.Header.Text = ATitle;


#if WPF || SILVERLIGHT || STORE || PORTABLE
      if (themeType != null)
      {
        Theme.ApplyChartTheme(themeType, chart.Chart);
        if (themeType.Equals(typeof(BlackIsBackTheme)))
          chart.Chart.Header.Font.Size = 18;
      }
#else
      Steema.TeeChart.Themes.WebTheme theme = new Steema.TeeChart.Themes.WebTheme(chart.Chart);
      theme.Apply();
#endif

#if !POCKET && !WPF && !SILVERLIGHT && !STORE && !PORTABLE
      BorderStyle = BorderStyle.None;
#endif
    }


#if STORE || PORTABLE
    List<Series> allSeries;
    List<Type> seriesWithAxis = new List<Type>();
    List<Type> seriesWithoutAxis = new List<Type>();
    int countAxisSeries, countNonAxisSeries;

    private void FillSeriesLists()
    {
      if (allSeries == null)
      {
        countAxisSeries = countNonAxisSeries = 0;
        allSeries = new List<Series>();
        foreach (var item in Utils.SeriesTypesOf)
        {
          allSeries.Add(Series.CreateNewSeries(null, item, null));
          if (allSeries.Last().UseAxis)
          {
            seriesWithAxis.Add(item);
          }
          else
          {
            seriesWithoutAxis.Add(item);
          }
        }
      }
    }

    private Type GetSeriesWithOutAxis()
    {
      FillSeriesLists();

      if (countNonAxisSeries >= seriesWithoutAxis.Count) countNonAxisSeries -= seriesWithoutAxis.Count;
      Type result = seriesWithoutAxis[countNonAxisSeries];
      countNonAxisSeries++;
      return result;
    }

    private Type GetSeriesWithAxis()
    {
      FillSeriesLists();

      if (countAxisSeries >= seriesWithAxis.Count) countAxisSeries -= seriesWithAxis.Count;
      Type result = seriesWithAxis[countAxisSeries];
      countAxisSeries++;
      return result;
    }

#if PORTABLE
    private void Transpose3DSeries(object sender, EventArgs e)
#else
    private void Transpose3DSeries(object sender, RoutedEventArgs e)
#endif
#else
    private void Transpose3DSeries(object sender, EventArgs e)
#endif
    {
#if !STORE && !PORTABLE
      ((sender as Button).Tag as GridTranspose).Transpose();
#endif
    }

#if STORE
    private void OutlineChecked(object sender, RoutedEventArgs e)
#else
    private void OutlineChecked(object sender, EventArgs e)
#endif
    {
#if !PORTABLE
#if WPF || SILVERLIGHT || STORE
      ((sender as CheckBox).Tag as Rotate).Pen.Visible = (sender as CheckBox).IsChecked == true;
#else
      ((sender as CheckBox).Tag as Rotate).Pen.Visible = (sender as CheckBox).Checked;
#endif
#endif
    }

#if STORE
       private void Animation(object sender, RoutedEventArgs e)
#else
        private void Animation(object sender, EventArgs e)
#endif
        {
#if !STORE && !PORTABLE
      ((sender as Button).Tag as SeriesAnimation).Execute();
#endif
        }


#if !WINDOWS_PHONE && !STORE && !PORTABLE
    private void PlayChartVideo(object sender, EventArgs e)
    {
      string tmpName = "";

#if WPF || SILVERLIGHT || STORE
      OpenFileDialog dialog = new OpenFileDialog();
#else
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
#endif
        dialog.Filter = Texts.AVIFile + " (*.avi)|*.avi";
#if !SILVERLIGHT && !STORE
        dialog.DefaultExt = "avi";
#endif

#if WPF || SILVERLIGHT || STORE
        if (dialog.ShowDialog() == true)
#else
        if (dialog.ShowDialog() == DialogResult.OK)
#endif
        {
#if SILVERLIGHT || STORE
          tmpName = dialog.File.FullName;
#else
          tmpName = dialog.FileName;
#endif
        }
#if !WPF && !SILVERLIGHT && !STORE
      }
#endif

      if (tmpName != "")
      {
#if WPF || SILVERLIGHT || STORE
        ((Button)sender).IsEnabled = false;
#else
        ((Button)sender).Enabled = false;
#endif
        IVideoPlayer v = ((Button)sender).Tag as IVideoPlayer;
        v.FileName = tmpName;
        v.Play();
      }
    }
#endif

#if STORE
    private void RecordChartVideo(object sender, RoutedEventArgs e)
#else
        private void RecordChartVideo(object sender, EventArgs e)
#endif
    {
      Button b = (Button)sender;
#if !STORE  && !PORTABLE
      IVideoCreator v = b.Tag as IVideoCreator;
      SeriesAnimation a = (SeriesAnimation)v.GetChart().Tools[1];
      a.Tag = v;
      v.Tag = b;
#endif

#if WPF || SILVERLIGHT || STORE
      if (b.Content.ToString() == Texts.Stop)
#else
      if (b.Text == Texts.Stop)
#endif
      {
#if !STORE  && !PORTABLE
        StopRecordVideo(a, EventArgs.Empty);
#endif
      }
      else
      {
        string tmpName = "";

#if !SILVERLIGHT && !STORE && !PORTABLE
#if WPF
        SaveFileDialog dialog = new SaveFileDialog();
#else
        using (SaveFileDialog dialog = new SaveFileDialog())
        {
#endif
          dialog.Filter = Texts.AVIFile + " (*.avi)|*.avi";
          dialog.DefaultExt = "avi";

#if WPF
          if (dialog.ShowDialog() == true)
#else
          if (dialog.ShowDialog() == DialogResult.OK)
#endif
          {
            tmpName = dialog.FileName;
          }
#if !WPF
        }
#endif
#endif

        if (tmpName != "")
        {
#if WPF || SILVERLIGHT || STORE
          b.Content = Texts.Stop;
#else
          b.Text = Texts.Stop;
#endif
#if !STORE && !PORTABLE
          v.StartRecording(tmpName);
          a.Step += new AnimationStepEventHandler(StepAnimation);
          a.Stopped += new EventHandler(StopRecordVideo);
          a.Execute();
#endif
        }
      }
    }

#if !STORE && !PORTABLE
    private void StepAnimation(object sender, AnimationStepEventArgs e)
    {
      Pie p = ((SeriesAnimation)sender).Series as Pie;
      p.RotationAngle += 5;
    }
#endif

    private void StopRecordVideo(object sender, EventArgs e)
        {
#if !STORE && !PORTABLE
      SeriesAnimation a = (SeriesAnimation)sender;
      a.Stop();
      IVideoCreator v = (IVideoCreator)a.Tag;
      v.StopRecording();
#if WPF || SILVERLIGHT || STORE
      ((Button)v.Tag).Content = Texts.RecordVideo;
#else
      ((Button)v.Tag).Text = Texts.RecordVideo;
#endif
#endif
        }


#if !POCKET && !STORE && !PORTABLE
    private void FadeChart(object sender, EventArgs e)
    {
      ((sender as Button).Tag as FaderTool).Start();
    }
#endif

#if STORE
    private void SeriesTranspose(object sender, RoutedEventArgs e)
#else
    private void SeriesTranspose(object sender, EventArgs e)
#endif
    {
#if !STORE && !PORTABLE
      ((sender as Button).Tag as SeriesTranspose).Transpose();
#endif
    }

#if STORE
    private void DrawBehindSeriesChecked(object sender, RoutedEventArgs e)
#else
        private void DrawBehindSeriesChecked(object sender, EventArgs e)
#endif
    {
#if !PORTABLE
#if WPF || SILVERLIGHT || STORE
      ((sender as CheckBox).Tag as SeriesRegionTool).DrawBehindSeries = (sender as CheckBox).IsChecked == true;
#else
      ((sender as CheckBox).Tag as SeriesRegionTool).DrawBehindSeries = (sender as CheckBox).Checked;
#endif
#endif
    }

#if STORE
    private void BannerScrollChecked(object sender, RoutedEventArgs e)
#else
        private void BannerScrollChecked(object sender, EventArgs e)
#endif
        {
#if !PORTABLE
#if WPF || SILVERLIGHT || STORE
      ((sender as CheckBox).Tag as BannerTool).Scroll = (sender as CheckBox).IsChecked == true;
#else
          ((sender as CheckBox).Tag as BannerTool).Scroll = (sender as CheckBox).Checked;
#endif
#endif
        }

#if STORE
    private void BannerBlinkChecked(object sender, RoutedEventArgs e)
#else
        private void BannerBlinkChecked(object sender, EventArgs e)
#endif
        {
#if !PORTABLE
#if WPF || SILVERLIGHT || STORE
      ((sender as CheckBox).Tag as BannerTool).Blink = (sender as CheckBox).IsChecked == true;
#else
          ((sender as CheckBox).Tag as BannerTool).Blink = (sender as CheckBox).Checked;
#endif
#endif
        }

    public void CreateGallery(Type tool)
    {
      CreateGallery(tool, "", null);
    }


#if STORE || PORTABLE
    public void CreateGallery(Type tool, Chart chart, Type themeType)
    {
      this.chart = chart;
      this.themeType = themeType;
      CreateGallery(tool);
    }
#endif


    public void CreateGallery(Type tool, string title, Type series)
    {
      double tmpY;
      int tmpRange;

      if (tool == null)
      {
        CreateChart(tool, title, series);
      }
      else
      {
        if (tool == typeof(Annotation))
        {
          CreateChart(tool, title, series);
          (chart.Tools[0] as Annotation).Text = "This is an Annotation tool";
          (chart.Tools[0] as Annotation).ClipText = false;
          chart.Tools.Add(new Annotation());
          (chart.Tools[1] as Annotation).Text = "Another Annotation";
          (chart.Tools[1] as Annotation).ClipText = false;
          (chart.Tools[1] as Annotation).Left = 150;
          (chart.Tools[1] as Annotation).Top = 80;
          (chart.Tools[1] as Annotation).Shape.Font.Size = 18;
          (chart.Tools[1] as Annotation).Shape.Gradient.Visible = true;
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(ChartImage))
        {
          CreateChart(tool, "Drag chart to scroll axes and image", series);
          chart.Aspect.View3D = false;
#if WPF || SILVERLIGHT || STORE
          chart[0].Color = Colors.Green;
#else
          chart[0].Color = Color.Green;
#endif
          (chart.Tools[0] as ChartImage).Series = chart[0];
#if WPF
          (chart.Tools[0] as ChartImage).Image = GetBitmapResource("WPFDemo.Images.A.png");
#elif SILVERLIGHT
          (chart.Tools[0] as ChartImage).Image = GetBitmapResource("Images/A.png");
#elif STORE
          //(chart.Tools[0] as ChartImage).Image = GetBitmapResource("WindowsStoreDemo.Assets.A.png").Result;
          (chart.Tools[0] as ChartImage).Image = GetBitmapResource("WindowsStoreDemo.Assets.A.png");
#else
          using (BrushEditor brush = new BrushEditor())
          {
            Image tmpI = brush.BrushImages.Images[1];
            (chart.Tools[0] as ChartImage).Image = tmpI;
          }
#endif
        }
#endif
        else if (tool == typeof(ExtraLegend))
        {
          CreateChart(tool, "Show additional Legend panels", series != null ? series : typeof(Bar));
          chart.Series.Add(series != null ? series : typeof(Bar));
          chart[1].FillSampleValues();
          chart.Legend.Visible = true;
          chart.Legend.LegendStyle = LegendStyles.Values;
          chart.Legend.Title.Visible = true;
          chart.Legend.Title.Font = chart.Legend.Font.Clone() as ChartFont;
          chart.Legend.Title.Font.Bold = true;
          chart.Legend.Title.Text = Texts.Legend;
          chart.Legend.Title.Transparent = true;
          (chart.Tools[0] as ExtraLegend).Series = chart[1];
          (chart.Tools[0] as ExtraLegend).Legend.Title.Visible = true;
          (chart.Tools[0] as ExtraLegend).Legend.Title.Text = "Extra Legend";
#if !WPF && !WINDOWS_PHONE && !STORE && !PORTABLE
          (chart.Tools[0] as ExtraLegend).Legend.Left = chart.Width - 200;
#endif
          (chart.Tools[0] as ExtraLegend).Legend.Top = 100;
        }
        else if (tool == typeof(GridBand))
        {
          CreateChart(tool, "Two bands fill axes grid lines space", series);
          (chart.Tools[0] as GridBand).Axis = chart.Axes.Left;
          (chart.Tools[0] as GridBand).Band1.Color = RandomTheme.RandomColor;
          (chart.Tools[0] as GridBand).Band2.Color = RandomTheme.RandomColor;
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(GridTranspose))
        {
          CreateChart(tool, "Swaps 3D Series data, rows by columns", series != null ? series : typeof(Surface));
          (chart[0] as Surface).HideCells = true;
          (chart.Tools[0] as GridTranspose).Series = (chart[0] as Surface);
          chart.Aspect.Orthogonal = false;
          chart.Aspect.Perspective = 100;
          chart.Aspect.Chart3DPercent = 75;
          chart.Aspect.Zoom = 75;
          chart.Axes.Depth.Visible = true;
          chart.Tools.Add(typeof(Rotate));

#if WPF || SILVERLIGHT || STORE
          AddButton("&Transpose", new RoutedEventHandler(Transpose3DSeries));
#else
          AddButton("&Transpose", new EventHandler(Transpose3DSeries));
#endif
        }
        else if (tool == typeof(MarksTip))
        {
          CreateChart(tool, "Move mouse over Series points to display hints", series);
          chart[0].FillSampleValues(5);
          if (chart[0] is Line) (chart[0] as Line).Pointer.Visible = true;
          (chart.Tools[0] as MarksTip).Series = chart[0];
          (chart.Tools[0] as MarksTip).MouseAction = MarksTipMouseAction.Move;
          //#if !POCKET
#if STORE
          chart[0].Cursor = new CoreCursor(CoreCursorType.Hand, 1);
#else
                    chart[0].Cursor = Cursors.Hand;
#endif
          //#endif
          chart.Axes.Bottom.MaximumOffset = 20;
          chart.Axes.Bottom.MinimumOffset = 20;
        }
        else if (tool == typeof(NearestPoint))
        {
          CreateChart(tool, "Move the mouse over Series points", series);
          chart[0].FillSampleValues(8);
          if (chart[0] is Line) (chart[0] as Line).Pointer.Visible = true;
          (chart.Tools[0] as NearestPoint).Series = chart[0];
          (chart.Tools[0] as NearestPoint).Pen.Width = 2;
#if WPF || SILVERLIGHT || STORE
          (chart.Tools[0] as NearestPoint).Pen.Color = Colors.Blue;
#else
          (chart.Tools[0] as NearestPoint).Pen.Color = Color.Blue;
#endif
        }
        else if (tool == typeof(PageNumber))
        {
          CreateChart(tool, "Shows Page numbering", series != null ? series : typeof(Bar));
          chart[0].FillSampleValues(25);
          chart.Page.MaxPointsPerPage = 5;
          //(chart.Tools[0] as PageNumber).ShowButtons() //CDI TODO
        }
        else if (tool == typeof(PieTool))
        {
          CreateChart(tool, "Move mouse over Pie slices", typeof(Pie));
          chart.Aspect.Chart3DPercent = 70;
          (chart.Tools[0] as PieTool).Series = chart[0];
          (chart.Tools[0] as PieTool).Style = PieToolStyle.Explode;
#if WPF || SILVERLIGHT || STORE
          (chart[0] as Pie).Pen.Color = Colors.DarkGray;
#else
          (chart[0] as Pie).Pen.Color = Color.DarkGray;
#endif
          //chart.Tools.Add(typeof(AntiAliasTool)); //CDI TODO
        }
        else if (tool == typeof(Rotate))
        {
#if WINDOWS_PHONE || PORTABLE
                    CreateChart(tool, "Touch and drag to rotate", series);
#else
          CreateChart(tool, "Click and drag to rotate", series);
#endif
          //(chart.Tools[0] as Rotate).Inertia = 75; //CDI TODO
          chart.Aspect.Orthogonal = false;
          chart.Aspect.Perspective = 100;
          chart.Aspect.Chart3DPercent = 75;

#if WPF || SILVERLIGHT || STORE
          AddCheck("OutLine", new RoutedEventHandler(OutlineChecked));
#elif !PORTABLE
          AddCheck("OutLine", new EventHandler(OutlineChecked)).Left = 4;
#endif
        }
        else if (tool == typeof(LegendScrollBar))
        {
          CreateChart(tool, "Displays scrollbar at Legend", series);
          chart.Legend.Visible = true;
          chart[0].FillSampleValues(50);
          (chart.Tools[0] as LegendScrollBar).Gradient.Visible = true;
          (chart.Tools[0] as LegendScrollBar).ThumbBrush.Gradient.Visible = true;
#if WPF || SILVERLIGHT || STORE
          (chart.Tools[0] as LegendScrollBar).ThumbBrush.Gradient.StartColor = Colors.Red;
          (chart.Tools[0] as LegendScrollBar).ThumbBrush.Gradient.EndColor = Colors.Green;
#else
          (chart.Tools[0] as LegendScrollBar).ThumbBrush.Gradient.StartColor = Color.Red;
          (chart.Tools[0] as LegendScrollBar).ThumbBrush.Gradient.EndColor = Color.Green;
#endif
        }
        else if (tool == typeof(SeriesAnimation))
        {
          CreateChart(tool, "Series points display animated", series != null ? series : typeof(Bar));
          chart[0].ColorEach = true;
          (chart.Tools[0] as SeriesAnimation).Series = chart[0];
          (chart.Tools[0] as SeriesAnimation).StartValue = 0;
          (chart.Tools[0] as SeriesAnimation).StartAtMin = false;
          (chart.Tools[0] as SeriesAnimation).Steps = 100;
          (chart.Tools[0] as SeriesAnimation).DrawEvery = 1;

#if WPF || SILVERLIGHT || STORE
          AddButton("&Animate!", new RoutedEventHandler(Animation));
#else
          AddButton("&Animate!", new EventHandler(Animation));
#endif

        }
        else if (tool == typeof(SurfaceNearestTool))
        {
          CreateChart(tool, "Move mouse over Surface to highlight cells", typeof(Surface));
          chart.Aspect.Orthogonal = false;
          chart.Aspect.Perspective = 100;
          chart.Aspect.Chart3DPercent = 75;
          chart.Aspect.Zoom = 75;

          (chart[0] as Surface).HideCells = true;
          chart[0].FillSampleValues(20);
          (chart.Tools[0] as SurfaceNearestTool).Series = chart[0];

          chart.Tools.Add(typeof(Rotate));
          chart.Walls.Left.Visible = false;
          chart.Walls.Back.Visible = false;
        }
#endif
        else if (tool == typeof(CursorTool))
        {
          CreateChart(tool, "Click and drag cursor lines", series);
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(DragMarks))
        {
          CreateChart(tool, "Click Series Marks to drag", series);
          chart[0].FillSampleValues(5);
          chart[0].Marks.Visible = true;
          chart[0].Marks.Font.Size = 14;
          chart[0].Marks.Callout.Visible = true;
#if WPF || SILVERLIGHT || STORE
          chart[0].Marks.Callout.Arrow.Color = Colors.Black;
#else
          chart[0].Marks.Callout.Arrow.Color = Color.Black;
#endif
          (chart.Tools[0] as DragMarks).Series = chart[0];
          chart.Axes.Left.MaximumOffset = 20;
          chart.Axes.Left.MinimumOffset = 20;
          chart.Axes.Bottom.MaximumOffset = 20;
          chart.Axes.Bottom.MinimumOffset = 20;
        }
        else if (tool == typeof(AxisArrow))
        {
          CreateChart(tool, "Click axes arrow to scroll", series);
          chart.Aspect.View3D = false;
          (chart.Tools[0] as AxisArrow).Length = 60;
          //(chart.Tools[0] as AxisArrow).HeadWidth = 30; CDI TODO
          (chart.Tools[0] as AxisArrow).Axis = chart.Axes.Bottom;
        }
#endif
        else if (tool == typeof(ColorLine))
        {
          CreateChart(tool, "Several Color lines displayed" + "\n" + "at random positions", series);
          tmpY = chart[0].mandatory.Minimum;
          tmpRange = Utils.Round(chart[0].mandatory.Range);
          RandomColorLine(chart.Tools[0] as ColorLine, ref tmpY, tmpRange);
          chart.Tools.Add(typeof(ColorLine));
          RandomColorLine(chart.Tools[1] as ColorLine, ref tmpY, tmpRange);
          chart.Tools.Add(typeof(ColorLine));
          RandomColorLine(chart.Tools[2] as ColorLine, ref tmpY, tmpRange);
        }
        else if (tool == typeof(ColorBand))
        {
          CreateChart(tool, "Color bands to fill axes background", series);
          chart.Aspect.View3D = false;
          tmpY = chart[0].mandatory.Minimum;
          tmpRange = Utils.Round(chart[0].mandatory.Range);
          RandomColorBand(chart.Tools[0] as ColorBand, ref tmpY, tmpRange);
          int index = chart.Tools.Add(typeof(ColorBand));
          RandomColorBand(chart.Tools[index] as ColorBand, ref tmpY, tmpRange);
          index = chart.Tools.Add(typeof(ColorBand));
          RandomColorBand(chart.Tools[index] as ColorBand, ref tmpY, tmpRange);
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(DrawLine))
        {
          CreateChart(tool, "Click and drag to draw lines", series);
          tmpY = (chart[0].mandatory.Minimum + chart[0].mandatory.Maximum) * 0.5;
          DrawLineItem line = new DrawLineItem(chart.Tools[0] as DrawLine);
          line.StartPos = new PointDouble(1.5, tmpY);
          line.EndPos = new PointDouble(2.8, tmpY - (tmpY * 0.5));
          (chart.Tools[0] as DrawLine).Selected = line;
        }
        else if (tool == typeof(DragPoint))
        {
          CreateChart(tool, "Click and drag Series points", series != null ? series : typeof(Points));
          chart[0].FillSampleValues(10);
          chart[0].ColorEach = true;
#if STORE
          chart[0].Cursor = new CoreCursor(CoreCursorType.Hand, 1);
#else
                    chart[0].Cursor = Cursors.Hand;
#endif
          (chart.Tools[0] as DragPoint).Series = chart[0];
        }
        else if (tool == typeof(GanttTool))
        {
          CreateChart(tool, "Click Gantt bars to drag and resize", typeof(Gantt));
          chart.Aspect.View3D = false;
#if !WINDOWS_PHONE && !STORE
          chart.Zoom.Direction = ZoomDirections.None;
#endif
          chart[0].FillSampleValues(10);
          (chart[0] as Gantt).Pointer.VertSize = 10;
          (chart.Tools[0] as GanttTool).Series = chart[0];
        }
        else if (tool == typeof(AxisScroll))
        {
          CreateChart(tool, "Drag axes to scroll", series);
          chart.Aspect.View3D = false;
          (chart.Tools[0] as AxisScroll).Axis = chart.Axes.Left;
          chart.Tools.Add(typeof(AxisScroll));
          (chart.Tools[1] as AxisScroll).Axis = chart.Axes.Bottom;
        }
#endif
#if !POCKET
#if !WPF && !SILVERLIGHT && !STORE && !PORTABLE
        else if(tool == typeof(SeriesHotspot))
        {
          //Tools.SeriesHotspot
          CreateChart(typeof(Annotation), "Series Hotspot");
          (chart.Tools[0] as Annotation).Text = "No preview is currently available";
          (chart.Tools[0] as Annotation).Left = 150;
          (chart.Tools[0] as Annotation).Top = 80;
          chart.Series.Clear(true);
        }
#if !CLIENTPROFILE && !REPORTINGSERVICES
        else if(tool == typeof(ZoomTool))
        {
          //Tools.ZoomTool
          CreateChart(typeof(Annotation), "Zoom Tool");
          (chart.Tools[0] as Annotation).Text = "No preview is currently available";
          (chart.Tools[0] as Annotation).Left = 150;
          (chart.Tools[0] as Annotation).Top = 80;
          chart.Series.Clear(true);
        }
        else if(tool == typeof(ScrollTool))
        {
          //Tools.ScrollTool
          CreateChart(typeof(Annotation), "Scroll Tool");
          (chart.Tools[0] as Annotation).Text = "No preview is currently available";
          (chart.Tools[0] as Annotation).Left = 150;
          (chart.Tools[0] as Annotation).Top = 80;
          chart.Series.Clear(true);
        }
#endif
#endif
#if !STORE && !PORTABLE
        else if (tool == typeof(LightTool))
        {
          CreateChart(tool, "2D Lighting", series);

          (chart.Tools[0] as LightTool).FollowMouse = true;
          (chart.Tools[0] as LightTool).Style = LightStyle.SpotLight;

          chart.Tools.Add(typeof(Rotate));
        }
#endif
#endif
        else if (tool == typeof(FibonacciTool))
        {
          CreateChart(tool, "Financial Data Analysis", typeof(Candle));
          chart[0].FillSampleValues(40);
          (chart.Tools[0] as FibonacciTool).Series = chart[0];
          (chart.Tools[0] as FibonacciTool).StartX = (chart[0] as Candle).DateValues[0];
          (chart.Tools[0] as FibonacciTool).StartY = (chart[0] as Candle).CloseValues[0];
          (chart.Tools[0] as FibonacciTool).EndX = (chart[0] as Candle).DateValues[10];
          (chart.Tools[0] as FibonacciTool).EndY = (chart[0] as Candle).CloseValues[10];
        }
#if !POCKET
#if !STORE && !PORTABLE
        else if (tool == typeof(SubChartTool))
        {
          CreateChart(tool, "Multiple Charts inside a Chart", series);
          chart.Axes.Left.Grid.Visible = false;
          chart.Walls.Visible = false;
          AddSeries((chart.Tools[0] as SubChartTool).Charts.AddChart("Chart1"), typeof(Line));
#if !WINDOWS_PHONE
          AddSeries((chart.Tools[0] as SubChartTool).Charts.AddChart("Chart2"), typeof(Bar));
          (chart.Tools[0] as SubChartTool).Charts[1].Left = 250;
#if WPF || SILVERLIGHT || STORE
          (chart.Tools[0] as SubChartTool).Charts[1].Chart[0].Color = Colors.Green;
          ((chart.Tools[0] as SubChartTool).Charts[1].Chart[0] as Bar).Pen.Color = Colors.Green;
#else
          (chart.Tools[0] as SubChartTool).Charts[1].Chart[0].Color = Color.Green;
          ((chart.Tools[0] as SubChartTool).Charts[1].Chart[0] as Bar).Pen.Color = Color.Green;
#endif
          AddSeries((chart.Tools[0] as SubChartTool).Charts.AddChart("Chart3"), typeof(Pie));
          (chart.Tools[0] as SubChartTool).Charts[2].Top = 200;
          (chart.Tools[0] as SubChartTool).Charts[2].Chart[0].Marks.Visible = false;
          AddSeries((chart.Tools[0] as SubChartTool).Charts.AddChart("Chart4"), typeof(Area));
          (chart.Tools[0] as SubChartTool).Charts[3].Top = 200;
          (chart.Tools[0] as SubChartTool).Charts[3].Left = 250;
#endif
#if WINDOWS_PHONE
          (chart.Tools[0] as SubChartTool).Charts[0].Chart.Height = 100;
          (chart.Tools[0] as SubChartTool).Charts[0].Chart.Width = 200;
#endif
#if WPF || SILVERLIGHT || STORE
          if (themeType != null) Theme.ApplyChartTheme(themeType, (chart.Tools[0] as SubChartTool).Charts[0].Chart.Chart);
#if !WINDOWS_PHONE
          (chart.Tools[0] as SubChartTool).Charts[3].Chart[0].Color = Colors.Blue;
          if (themeType != null) Theme.ApplyChartTheme(themeType, (chart.Tools[0] as SubChartTool).Charts[1].Chart.Chart);
          if (themeType != null) Theme.ApplyChartTheme(themeType, (chart.Tools[0] as SubChartTool).Charts[2].Chart.Chart);
          if (themeType != null) Theme.ApplyChartTheme(themeType, (chart.Tools[0] as SubChartTool).Charts[3].Chart.Chart);
#endif
#else
          (chart.Tools[0] as SubChartTool).Charts[3].Chart[0].Color = Color.Blue;
#endif
        }
#endif
        else if (tool == typeof(Marker))
        {
          CreateChart(tool, "Specialized Annotation to draw custom fonts.", series);
          (chart.Tools[0] as Marker).Text = "12,896.25";
          (chart.Tools[0] as Marker).IRectangle = Utils.FromLTRB(100, 100, 150, 130);
          (chart.Tools[0] as Marker).Shape.Color = Utils.FromArgb(255, 173, 216, 230);
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(FaderTool))
        {
          CreateChart(tool, "Fade in/out a Chart.", series);
          (chart.Tools[0] as FaderTool).Color = chart.Panel.Color;
          (chart.Tools[0] as FaderTool).Speed = 2;
#if WPF || SILVERLIGHT || STORE
          AddButton("&Fade", new RoutedEventHandler(FadeChart));
#else
          AddButton("&Fade", new EventHandler(FadeChart));
#endif
        }
#endif
#endif
        else if (tool == typeof(RectangleTool))
        {
          CreateChart(tool, "Annotations that can be" + "\n" + "dragged and resized", series);
          (chart.Tools[0] as RectangleTool).AutoSize = false;
          (chart.Tools[0] as RectangleTool).Width = 120;
          (chart.Tools[0] as RectangleTool).Height = 60;
          (chart.Tools[0] as RectangleTool).Text = "Drag and" + "\n" + "resize me";
          (chart.Tools[0] as RectangleTool).ClipText = false;
#if WPF || SILVERLIGHT || STORE
          (chart.Tools[0] as RectangleTool).Shape.Color = Colors.Red;
#else
          (chart.Tools[0] as RectangleTool).Shape.Color = Color.Red;
#endif
          (chart.Tools[0] as RectangleTool).Shape.Font.Size = 16;
          (chart.Tools[0] as RectangleTool).Shape.Transparency = 30;
          (chart.Tools[0] as RectangleTool).Shape.Left = 80;
          (chart.Tools[0] as RectangleTool).Shape.Top = 90;
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(Selector))
        {
          CreateChart(tool, "Click to select Chart items", series != null ? series : typeof(Bar));
          chart.Legend.Visible = true;
          chart[0].FillSampleValues(4);
          chart.Series.Add(series != null ? series : typeof(Bar)).FillSampleValues(4);

          chart.Tools.Add(typeof(Annotation));
          (chart.Tools[1] as Annotation).Text = "Click me!";
          (chart.Tools[1] as Annotation).Position = AnnotationPositions.LeftBottom;

          chart.Header.Transparent = false;
          chart.Footer.Visible = true;
          chart.Footer.Text = "Footer text";
          chart.Footer.Transparent = false;

          ChartClickedPart part = (chart.Tools[0] as Selector).Part;
          part.Part = ChartClickedPartStyle.Legend;
        }
#endif
        else if (tool == typeof(SeriesRegionTool))
        {
          CreateChart(tool, "Fills region between series and value.", typeof(Line));
          chart[0].FillSampleValues(10);
          (chart.Tools[0] as SeriesRegionTool).Series = chart[0];
          (chart.Tools[0] as SeriesRegionTool).Transparency = 30;
#if WPF || SILVERLIGHT || STORE || PORTABLE
          (chart.Tools[0] as SeriesRegionTool).Brush.Color = Utils.HexToColor("ffdeb887");
#else
          (chart.Tools[0] as SeriesRegionTool).Brush.Color = Color.BurlyWood;
#endif
          (chart.Tools[0] as SeriesRegionTool).AutoBound = false;
          (chart.Tools[0] as SeriesRegionTool).LowerBound = chart[0].XValues[3];
          (chart.Tools[0] as SeriesRegionTool).UpperBound = chart[0].XValues[7];
          (chart.Tools[0] as SeriesRegionTool).UseOrigin = false;
#if WPF || SILVERLIGHT || STORE
          AddCheck("Draw behind", new RoutedEventHandler(DrawBehindSeriesChecked)).IsChecked = true;
#elif !PORTABLE
          AddCheck("Draw behind", new EventHandler(DrawBehindSeriesChecked)).Checked = true;
#endif
        }
#if !STORE && !WINDOWS_PHONE && !PORTABLE
        else if (tool == typeof(LegendPalette))
        {
          CreateChart(tool, "Displays legend of Series color palettes.", typeof(Surface));
          chart.Aspect.Orthogonal = false;
          chart.Aspect.Perspective = 100;
          chart.Aspect.Chart3DPercent = 75;
          chart.Aspect.Zoom = 75;
          chart.Panel.MarginLeft = 20;

          (chart[0] as Surface).HideCells = true;
          (chart[0] as Surface).PaletteStyle = PaletteStyles.Rainbow;

          chart[0].FillSampleValues(20);
          (chart.Tools[0] as LegendPalette).Series = chart[0];
          (chart.Tools[0] as LegendPalette).Top = 100;
          (chart.Tools[0] as LegendPalette).Smooth = true;

          chart.Axes.Left.PositionUnits = PositionUnits.Pixels;
          chart.Axes.Left.RelativePosition = 2;
          chart.Axes.Right.PositionUnits = PositionUnits.Pixels;
          chart.Axes.Right.RelativePosition = -2;
        }
#endif
        else if (tool == typeof(SeriesStats))
        {
          CreateChart(tool, "Calculates series statistics", series != null ? series : typeof(Line));
          chart[0].FillSampleValues(10);
          (chart.Tools[0] as SeriesStats).Series = chart[0];
          chart.Tools.Add(typeof(Annotation));
          Annotation at = (chart.Tools[1] as Annotation);
          at.Shape.Transparency = 10;
          at.Left = 80;
          at.Top = 50;
          at.Text = (chart.Tools[0] as SeriesStats).Statistics;
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(SeriesTranspose))
        {
          CreateChart(tool, "Swap series rows and columns.", series != null ? series : typeof(Bar));
          chart.Aspect.Chart3DPercent = 75;
          chart[0].FillSampleValues();
          (chart[0] as Bar).MultiBar = MultiBars.None;
#if WPF || SILVERLIGHT || STORE
          AddButton("Transpose", new RoutedEventHandler(SeriesTranspose));
#else
            AddButton("Transpose", new EventHandler(SeriesTranspose));
#endif
        }
#endif
        else if (tool == typeof(DataTableTool))
        {
          CreateChart(tool, "Displays a grid with Series data.", series != null ? series : typeof(Bar));
          chart.Series.Add(series != null ? series : typeof(Bar));
          chart[0].FillSampleValues(4);
          chart[1].FillSampleValues(4);
          chart[0].ValueFormat = "#.00";
          chart[1].ValueFormat = chart[0].ValueFormat;
          // (chart.Tools[0] as DataTableTool).Brush.Color = Color.Cornsilk;
        }
#if !STORE && !PORTABLE
        else if (tool == typeof(ClipSeries))
        {
          CreateChart(tool, "Drag chart to show series\r\nthat does not display outside axes", series != null ? series : typeof(Line));
          chart.Aspect.View3D = false;
#if !WINDOWS_PHONE && !STORE
          chart.Panning.Allow = ScrollModes.Both;
#endif
          chart.Axes.Left.StartPosition = 20;
          chart.Axes.Left.EndPosition = 80;
          chart.Axes.Bottom.StartPosition = 25;
          chart.Axes.Bottom.EndPosition = 70;
          (chart.Tools[0] as ClipSeries).Series = chart[0];
        }
#endif
#if !PORTABLE
        else if (tool == typeof(BannerTool))
        {
          CreateChart(tool, "Text scrolling and/or\r\n blinking.", series);
          (chart.Tools[0] as BannerTool).Text = "Scrolling text";
#if WPF || SILVERLIGHT || STORE
          AddCheck("Blinking", new RoutedEventHandler(BannerBlinkChecked));
          CheckBox cbox = AddCheck("Scrolling", new RoutedEventHandler(BannerScrollChecked));
#else
          AddCheck("Blinking", new EventHandler(BannerBlinkChecked));
          CheckBox cbox = AddCheck("Scrolling", new EventHandler(BannerScrollChecked));
#endif
#if WPF || SILVERLIGHT || STORE
          Thickness margins = cbox.Margin;
#if SILVERLIGHT || STORE
          double width = 90;
          margins.Right -= (width + 5);
#else
          double width = 54;
          margins.Right += (width + 5);
#endif
          margins.Left += (width + 5);
          cbox.Margin = margins;
          cbox.IsChecked = true;
#else
          cbox.Top = cbox.Top - 20;
          cbox.Checked = true;
#endif
        }
#endif
#if !POCKET && !STORE && !PORTABLE
        else if (tool == typeof(Magnify))
        {
          CreateChart(tool, "Magnify a Chart portion under the mouse.", series);
          (chart.Tools[0] as Magnify).Width = 100;
          (chart.Tools[0] as Magnify).Height = 100;
        }
#endif
        else if (tool == typeof(SeriesBandTool))
        {
          CreateChart(tool, "Fill the region between two Series.");
          chart.Aspect.View3D = false;
          chart[0].FillSampleValues();
          chart.Series.Add(typeof(Line));
          for (int i = 0; i < chart[0].Count; i++)
          {
            chart[1].Add(chart[0].XValues[i], chart[0].YValues[i] / 2.0);
          }
          if (chart[0] is Line) (chart[0] as Line).LinePen.Width = 3;
          if (chart[1] is Line) (chart[1] as Line).LinePen.Width = 3;

          (chart.Tools[0] as SeriesBandTool).Series = chart[0];
          (chart.Tools[0] as SeriesBandTool).Series2 = chart[1];
          (chart.Tools[0] as SeriesBandTool).Gradient.Visible = true;
#if WPF || SILVERLIGHT || STORE
          (chart.Tools[0] as SeriesBandTool).Gradient.StartColor = Utils.HexToColor("ffc0c0c0");
#else
          (chart.Tools[0] as SeriesBandTool).Gradient.StartColor = Color.Silver;
#endif
          (chart.Tools[0] as SeriesBandTool).Pen.Visible = true;
          (chart.Tools[0] as SeriesBandTool).DrawBehindSeries = false;
        }
#if !POCKET
#if !WPF && !SILVERLIGHT && !STORE && !PORTABLE
          else if(tool == typeof(CustomHotspot))
          {
            //Tools.CustomHotspot
            CreateChart(typeof(Annotation), "Custom Hotspot");
            (chart.Tools[0] as Annotation).Text = "No preview is currently available";
            (chart.Tools[0] as Annotation).Left = 150;
            (chart.Tools[0] as Annotation).Top = 80;
            chart.Series.Clear(true);
         }
#endif
#if !WINDOWS_PHONE && !STORE && !PORTABLE
        else if (tool == typeof(ScrollPager))
        {
          CreateChart(tool, "Scrolled Paging", typeof(FastLine));
          chart.Aspect.View3D = false;
          chart[0].FillSampleValues(500);
          ((ScrollPager)chart.Tools[0]).Series = chart[0];
#if WPF || SILVERLIGHT || STORE
          if (themeType != null) Theme.ApplyChartTheme(themeType, ((ScrollPager)chart.Tools[0]).SubChartTChart.Chart);
#else
          Steema.TeeChart.Themes.WebTheme theme = new Steema.TeeChart.Themes.WebTheme(((ScrollPager)chart.Tools[0]).SubChartTChart.Chart);
          theme.Apply();
#endif
        }
#endif
        else if (tool == typeof(AxisBreaksTool))
        {
          CreateChart(tool, "Axis breaks", series);
          chart.Aspect.View3D = false;
          chart[0].FillSampleValues();
          //TODO pep
          AxisBreaksTool abt = chart.Tools[0] as AxisBreaksTool;
          AxisBreak ab = new AxisBreak(abt);
          tmpRange = Utils.Round(chart[0].mandatory.Range);
          Random rnd = new Random();
          int tmp1 = Utils.Round(chart[0].mandatory.Minimum) + rnd.Next(tmpRange),
            tmp2 = Utils.Round(chart[0].mandatory.Maximum) - rnd.Next(tmpRange);
          ab.Enabled = true;
          ab.StartValue = tmp1 > tmp2 ? tmp2 : tmp1;
          ab.EndValue = tmp1 > tmp2 ? tmp1 : tmp2;
          abt.GapSize = 10;
          abt.Axis = chart.Axes.Left;
          abt.Breaks.Add(ab);
        }
        //*Note - When adding new tools to list, always move AVI demos to end of list by
        // incrementing their index numbers in this switch.
#if !STORE && !PORTABLE
        else if (tool == typeof(SeriesAnimation))
        {
          CreateChart(tool, "Create AVI video with Chart images.", typeof(Pie));
          (chart[0] as Pie).Circled = true;
          chart.Aspect.Chart3DPercent = 60;
          chart.Tools.Add(typeof(SeriesAnimation));
          (chart.Tools[1] as SeriesAnimation).Series = chart[0];

#if WPF || SILVERLIGHT || STORE
          AddButton(Texts.RecordVideo, new RoutedEventHandler(RecordChartVideo));
#else
          AddButton(Texts.RecordVideo, new System.EventHandler(RecordChartVideo));
#endif
        }

                else if (tool.IsSubclassOf(typeof(IVideoPlayer)))
                {
                    CreateChart(tool, "Play AVI videos inside Chart regions.", series);

                    Annotation anno;
                    chart.Tools.Add(anno = new Annotation());
                    anno.Shape.Transparency = 10;
                    anno.AutoSize = false;
                    anno.Left = 80;
                    anno.Top = 50;
                    anno.Width = 120;
                    anno.Height = 120;

                    ((IVideoPlayer)chart.Tools[0]).Brush = anno.Shape.Brush;
                    ((IVideoPlayer)chart.Tools[0]).Loop = true;

#if !WINDOWS_PHONE && !STORE && !PORTABLE
#if WPF || SILVERLIGHT || STORE
          AddButton(Texts.Play, new RoutedEventHandler(PlayChartVideo));
#else
          AddButton(Texts.Play, new System.EventHandler(PlayChartVideo));
#endif
#endif


                    chart.Tools.Add(typeof(Rotate));
                }
#endif
#endif
      }
    }

    static private System.IO.Stream GetResource(string name)
    {
#if STORE || PORTABLE
        return typeof(ToolsGalleryDemos).GetTypeInfo().Assembly.GetManifestResourceStream(name);
#else
      return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
#endif
    }

#if STORE
    class MemoryRandomAccessStream : IRandomAccessStream
    {
      private Stream m_InternalStream;

      public MemoryRandomAccessStream(Stream stream)
      {
        this.m_InternalStream = stream;
      }

      public MemoryRandomAccessStream(byte[] bytes)
      {
        this.m_InternalStream = new MemoryStream(bytes);
      }

      public IInputStream GetInputStreamAt(ulong position)
      {
        this.m_InternalStream.Seek((long)position, SeekOrigin.Begin);

        return this.m_InternalStream.AsInputStream();
      }

      public IOutputStream GetOutputStreamAt(ulong position)
      {
        this.m_InternalStream.Seek((long)position, SeekOrigin.Begin);

        return this.m_InternalStream.AsOutputStream();
      }

      public ulong Size
      {
        get { return (ulong)this.m_InternalStream.Length; }
        set { this.m_InternalStream.SetLength((long)value); }
      }

      public bool CanRead
      {
        get { return true; }
      }

      public bool CanWrite
      {
        get { return true; }
      }

      public IRandomAccessStream CloneStream()
      {
        throw new NotSupportedException();
      }

      public ulong Position
      {
        get { return (ulong)this.m_InternalStream.Position; }
      }

      public void Seek(ulong position)
      {
        this.m_InternalStream.Seek((long)position, 0);
      }

      public void Dispose()
      {
        this.m_InternalStream.Dispose();
      }

      public Windows.Foundation.IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
      {
        var inputStream = this.GetInputStreamAt(0);
        return inputStream.ReadAsync(buffer, count, options);
      }

      public Windows.Foundation.IAsyncOperation<bool> FlushAsync()
      {
        var outputStream = this.GetOutputStreamAt(0);
        return outputStream.FlushAsync();
      }

      public Windows.Foundation.IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
      {
        var outputStream = this.GetOutputStreamAt(0);
        return outputStream.WriteAsync(buffer);
      }
    }
#endif

#if WPF || SILVERLIGHT || STORE
#if SILVERLIGHT
    static private BitmapImage GetBitmapResource(string name)
#elif STORE
    static private BitmapImage GetBitmapResource(string name)
    //static async private Task<BitmapImage> GetBitmapResource(string name)
#else
    static private BitmapSource GetBitmapResource(string name)
#endif
    {
#if SILVERLIGHT
      Uri uri = new Uri(name, UriKind.Relative);
      BitmapImage result = new BitmapImage();
      result.UriSource = uri;
      return result;
#elif STORE
      System.IO.Stream stream = GetResource(name);
      BitmapImage result = new BitmapImage();
      //await result.SetSourceAsync(new MemoryRandomAccessStream(stream)); //CDI hangs
      return result;
#else
      System.IO.Stream stream = GetResource(name);
      return stream == null ? null : BitmapFrame.Create(stream);
#endif
    }
#endif

    private void RandomColorBand(ColorBand tool, ref double tmpY, int tmpRange)
    {
      Random rnd = new Random();
      tool.Axis = chart.Axes.Left;
      tool.Start = tmpY;
      tool.End = tool.Start + rnd.Next(tmpRange);
      tmpY = tool.End;
      tool.Color = RandomTheme.RandomColor;
      tool.ResizeEnd = true;
      tool.ResizeStart = true;

    }

    private void RandomColorLine(ColorLine tool, ref double tmpY, int tmpRange)
    {
      Random rnd = new Random();
      if(chart[0].mandatory.Equals(chart[0].YValues))
        tool.Axis = chart.Axes.Left;
      else
        tool.Axis = chart.Axes.Bottom;
      tool.Value = tmpY + rnd.Next(tmpRange);
      tmpY = tool.Value;
      tool.Pen.Color = RandomTheme.RandomColor;
      tool.Pen.Width = 2;
    }

#if !PORTABLE
#if WPF || SILVERLIGHT || STORE
    private CheckBox AddCheck(string AText, RoutedEventHandler AEvent)
#else
    private CheckBox AddCheck(string AText, EventHandler AEvent)
#endif
    {
      CheckBox result = AddControl(typeof(CheckBox), AText) as CheckBox;
#if WPF || SILVERLIGHT || STORE
      result.Checked += AEvent;
      result.Unchecked += AEvent;
#else
      result.CheckedChanged += AEvent;
#endif
      return result;
    }
#if WPF || SILVERLIGHT || STORE
    private Button AddButton(string AText, RoutedEventHandler AEvent)
#else
    private Button AddButton(string AText, EventHandler AEvent)
#endif
    {
      Button result = AddControl(typeof(Button), AText) as Button;
      result.Click += AEvent;
      return result;

    }
#endif


#if POCKET
	 private void AddSeries(Pocket.TChart chart, Type seriesType)
#elif PORTABLE
    private void AddSeries(Chart chart, Type seriesType)
#else
    private void AddSeries(TChart chart, Type seriesType)
#endif

    {
      chart.Series.Add(seriesType).FillSampleValues();
    }

#if SILVERLIGHT || STORE 
    private System.Collections.Generic.List<ContentControl> iControls = new System.Collections.Generic.List<ContentControl>();
#endif

#if WPF || SILVERLIGHT || STORE
    private ContentControl AddControl(Type AClass, string AText)
    {
#if SILVERLIGHT || STORE
      ContentControl result = System.Activator.CreateInstance(AClass) as ContentControl;
#else
      ContentControl result = System.Activator.CreateInstance(AClass) as ContentControl;
#endif
      result.Content = AText;
      result.Tag = chart.Tools[0];
#if SILVERLIGHT || STORE
      Thickness margins = new Thickness(500, 118, 220 - (AText.Length * 15), 480);
      result.Foreground = new SolidColorBrush(Colors.White);
      iControls.Add(result);
#else
      Thickness margins = new Thickness(500, 30, 20 + (AText.Length * 6), 30);
#endif
      result.Margin = margins;
      if (children != null) children.Add(result);
      return result;
    }
#elif !PORTABLE
    private Control AddControl(Type AClass, string AText)
    {
      Control result = System.Activator.CreateInstance(AClass) as Control;
      result.Text = AText;
      result.Width = Math.Max(result.Width, AText.Length * 6);
      result.Top = (5 * (chart.Controls.Count + 1)) + ((result.Height + 10) * chart.Controls.Count);
      result.Left = chart.Width - result.Width - 5;
      result.Tag = chart.Tools[0];
      chart.Controls.Add(result);
      return result;
    }
#endif
  }
}
#endif