using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Extended
{
    public class PerimeterProFunctionChart
    {

				private Points points;
				private Line line;
				private PerimeterFunction perimeter;
				private Variables.Variables var;

				public PerimeterProFunctionChart(ChartView BaseChart)
				{

						points = new Points();
						line = new Line();
						perimeter = new PerimeterFunction();
						var = new Variables.Variables();

						BaseChart.Chart.Title.Text = "Perimeter";
						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
			/*
						points.FillSampleValues(20);
						points.Color = var.GetPaletteBasic[0];
						points.Pointer.HorizSize += 3;
						points.Pointer.VertSize += 3;
						points.Title = "Points";
						points.UseExtendedNumRange = false;
						points.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;

						line.DataSource = points;
						line.Function = perimeter;
						line.Color = var.GetPaletteBasic[1];
						line.LinePen.Width = 6;
						line.Title = "Perimeter";
						line.YValues.DataMember = "Y";
						line.UseExtendedNumRange = false;
						*/
						points.FillSampleValues();
						this.points.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
						this.points.ColorEach = false;
						this.points.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(92)))), ((int)(((byte)(128)))));
						this.points.Marks.ArrowLength = 10;
						this.points.Marks.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						this.points.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						this.points.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
						this.points.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
						this.points.Marks.Brush.Gradient.UseMiddle = true;
						this.points.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
						this.points.Marks.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(138)))), ((int)(((byte)(193)))));
						this.points.Marks.Shadow.Visible = false;
						this.points.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.Auto;
						this.points.Marks.TailParams.Margin = 0F;
						this.points.Marks.TailParams.PointerHeight = 5D;
						this.points.Marks.TailParams.PointerWidth = 8D;
						this.points.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer;
						this.points.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
						this.points.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
						this.points.Pointer.SizeDouble = 0D;
						this.points.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
						this.points.UseExtendedNumRange = false;
						this.points.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
						this.points.Title = "Points";

						this.line.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(104)))));
						this.line.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(104)))));
						this.line.ColorEach = false;
						this.line.DataSource = this.points;
						this.line.Function = this.perimeter;
						this.line.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(62)))));
						this.line.LinePen.Width = 6;
						this.line.Marks.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						this.line.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
						this.line.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
						this.line.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
						this.line.Marks.Brush.Gradient.UseMiddle = true;
						this.line.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
						this.line.Marks.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(186)))), ((int)(((byte)(94)))));
						this.line.Marks.Shadow.Visible = false;
						this.line.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.Auto;
						this.line.Marks.TailParams.Margin = 0F;
						this.line.Marks.TailParams.PointerHeight = 5D;
						this.line.Marks.TailParams.PointerWidth = 8D;
						this.line.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer;
						this.line.Pointer.SizeDouble = 0D;
						this.line.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
						this.line.Title = "Perimeter";
						this.line.UseExtendedNumRange = false;
						this.line.YValues.DataMember = "Y";

						BaseChart.Chart.Series.Add(points);
						BaseChart.Chart.Series.Add(line);

				}


    }
}
