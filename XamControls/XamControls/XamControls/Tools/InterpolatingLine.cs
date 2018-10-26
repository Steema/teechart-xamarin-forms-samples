using Steema.TeeChart;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamControls.Tools
{
    public class InterpolatingLine
    {

				private Annotation annotation;
				private CursorTool cursor;
				private ChartView BaseChart;

				public InterpolatingLine(ChartView BaseChart)
				{

						annotation = new Annotation();
						cursor = new CursorTool();
						this.BaseChart = BaseChart;

				}
				private void AddCursorTool()
				{

					// Use of the Cursor Tool            
					cursor = new CursorTool(BaseChart.Chart.chart);
					cursor.SnapChange += Cursor_SnapChange;
					cursor.CursorClickTolerance = 1000;
					cursor.Style = CursorToolStyles.Vertical;
					cursor.Pen.Color = Xamarin.Forms.Color.Blue;
					cursor.Snap = true;
					cursor.Series = BaseChart.Chart.Series[0];
					cursor.FollowMouse = false;
					//cursor.FastCursor = true;            
					// In the case to Active the CursorTool Panning ScrollMode has to be set to None            
					//tChart1.Panning.Allow = ScrollModes.None;            
					cursor.Active = true;
					//cursor.Change += Cursor_Change;

				}

				public void RemCursorTool()
				{

					// Use of the Cursor Tool            
					annotation = null;
					BaseChart.Chart.Header.Text = "";
					BaseChart.Chart.Tools.Remove(cursor);

				}

				public void Cursor_SnapChange(object sender, CursorChangeEventArgs e)
				{
					if (e.SnapPoint != -1)
					{
						BaseChart.Chart.Header.Text = "Snap Point : " + e.SnapPoint.ToString();
						annotation.Text = BaseChart.Chart.Series[0].YValues[e.SnapPoint].ToString();
						annotation.Left = e.x - (annotation.Shape.Width / 2); annotation.Top = BaseChart.Chart.Series[0].CalcYPos(e.SnapPoint);
					}
				}

	}
}
