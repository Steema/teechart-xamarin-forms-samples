using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
	public class ProjectPlanner : ContentPage
	{
        ChartView tChart1;
        // Pending Animations for Xamarin.Forms
        //private Steema.TeeChart.Tools.SeriesAnimation seriesAnimation1;
        private Steema.TeeChart.Styles.Gantt gantt1;
        //private Steema.TeeChart.Tools.GanttTool ganttTool1;
		public ProjectPlanner ()
		{
            this.Title = "Project Planner";

            tChart1 = new ChartView();
            tChart1.WidthRequest = 400;
            tChart1.HeightRequest = 300;

            this.gantt1 = new Steema.TeeChart.Styles.Gantt();

            //this.ganttTool1 = new Steema.TeeChart.Tools.GanttTool();
            this.tChart1.Chart.Aspect.View3D = false;
            this.tChart1.Chart.Zoom.Active = true;
            this.tChart1.Chart.Panning.Active = true;
            this.tChart1.Chart.Axes.Bottom.Increment = 30D;
            this.tChart1.Chart.Axes.Bottom.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Bottom.Labels.Font.Size = 16;
            this.tChart1.Chart.Axes.Bottom.Title.Caption = "Time";
            this.tChart1.Chart.Axes.Bottom.Title.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Bottom.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Bottom.Title.Lines = new string[] {"Time"};
            this.tChart1.Chart.Axes.Left.AxisPen.Visible = false;
            this.tChart1.Chart.Axes.Left.Labels.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Left.Labels.Font.Size = 13;
            this.tChart1.Chart.Axes.Left.MinorTicks.Visible = false;
            this.tChart1.Chart.Axes.Left.Title.Caption = "Task";
            this.tChart1.Chart.Axes.Left.Title.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Axes.Left.Title.Font.Name = "Segoe UI";
            this.tChart1.Chart.Axes.Left.Title.Lines = new string[] {"Task"};
            this.tChart1.Chart.Footer.Font.Brush.Color = Color.Blue;
            this.tChart1.Chart.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Chart.Header.Font.Size = 21;
            this.tChart1.Chart.Header.Lines = new string[] {"Project Planner"};
            this.tChart1.Chart.Legend.Visible = false;
            this.tChart1.Chart.Panel.Brush.Color = Color.White;
            this.tChart1.Chart.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Series.Add(this.gantt1);
            
            this.tChart1.Chart.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Chart.Walls.Back.Visible = false;
            this.tChart1.Chart.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
            //this.tChart1.Click += new System.EventHandler(this.tChart1_Click);
            // gantt1
            this.gantt1.Color = Color.FromRgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gantt1.ColorEach = true;
            this.gantt1.EndValues.DataMember = "End";
            this.gantt1.EndValues.DateTime = true;
            this.gantt1.LabelMember = "Labels";
            this.gantt1.LinePen.Color = Color.FromRgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.gantt1.Marks.Brush.Visible = false;
            this.gantt1.Marks.Transparent = true;
            this.gantt1.Marks.Visible = true;
            this.gantt1.Pointer.Brush.Gradient.StartColor = Color.FromRgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.gantt1.Pointer.Pen.Visible = false;
            this.gantt1.Pointer.SizeDouble = 0D;
            this.gantt1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.gantt1.StartValues.DataMember = "Start";
            this.gantt1.StartValues.DateTime = true;
            this.gantt1.StartValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            this.gantt1.Title = "gantt1";
            this.gantt1.YValues.DataMember = "Y";
            // ganttTool1
            //this.ganttTool1.Gantt = this.gantt1;
            //this.ganttTool1.Series = this.gantt1;
            /*
            this.ganttTool1.DragBar += new Steema.TeeChart.Tools.GanttDragEventHandler(this.ganttTool1_DragBar);
            this.ganttTool1.ResizeBar += new Steema.TeeChart.Tools.GanttResizeEventHandler(this.ganttTool1_ResizeBar);
            */

            tChart1.Chart.Panel.Gradient.Visible = false;
            gantt1.Add(new DateTime(2014, 6, 7), new DateTime(2014, 9, 23), 0, "Production");
            gantt1.Add(new DateTime(2014, 9, 3), new DateTime(2014, 11, 10), 1, "Marketing");
            gantt1.Add(new DateTime(2014, 3, 13), new DateTime(2014, 3, 31), 2, "Approve");
            gantt1.Add(new DateTime(2014, 5, 7), new DateTime(2014, 6, 5), 3, "Prototype");
            gantt1.Add(new DateTime(2014, 10, 11), new DateTime(2014, 11, 5), 4, "Evaluation");
            gantt1.Add(new DateTime(2014, 4, 2), new DateTime(2014, 4, 29), 5, "Design");

            gantt1.AddMultipleNextTasks(2, 4);
            gantt1.AddMultipleNextTasks(2, 3);

            gantt1.ConnectingPen.Color = Color.FromRgb(49, 44, 59);
            gantt1.ConnectingPen.Width = 2;

            gantt1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            gantt1.Pointer.VertSize = 25;

            this.tChart1.Chart.Aspect.ZoomText = true;
            tChart1.Chart.Axes.Left.StartPosition = 8;

            Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart1.Chart, 21);

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    tChart1
                }
            };
        }

        private void gantt1_GetSeriesMark(Steema.TeeChart.Styles.Series series, Steema.TeeChart.Styles.GetSeriesMarkEventArgs e)
        {
            // Add custom data to display at each gantt bar, for example: "Completion %"
            switch (e.ValueIndex)
            {
                case 0:
                    e.MarkText = "20 %";
                    break;
                case 1:
                    e.MarkText = "40 %";
                    break;
                case 2:
                    e.MarkText = "10 %";
                    break;
                case 3:
                    e.MarkText = "75 %";
                    break;
                case 4:
                    e.MarkText = "55 %";
                    break;
                case 5:
                    e.MarkText = "60 %";
                    break;
                case 6:
                    e.MarkText = "25 %";
                    break;
            }
        }

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            //g.TextOut(10, 10, counter.ToString());
        }

        private void cancelZoom()
        {
            tChart1.Chart.CancelMouse = true;
        }

        /*
        private void ganttTool1_DragBar(object sender, Steema.TeeChart.Tools.GanttDragEventArgs e)
        {
            cancelZoom();
        }

        private void ganttTool1_ResizeBar(object sender, Steema.TeeChart.Tools.GanttResizeEventArgs e)
        {
            cancelZoom();
        }*/

	}
}


