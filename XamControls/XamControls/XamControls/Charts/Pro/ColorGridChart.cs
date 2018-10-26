using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using XamControls.Styles;

namespace XamControls.Charts.Pro
{
    public class ColorGridChart
    {

        private ColorGrid colorGrid;
        private Variables.Variables var;

        public ColorGridChart(ChartView BaseChart)
        {

            colorGrid = new ColorGrid();
            var = new Variables.Variables();

            BaseChart.Chart.Axes.Left.Automatic = true;
            BaseChart.Chart.Axes.Bottom.Automatic = true;
            BaseChart.Chart.Axes.Left.AxisPen.Transparency = 0;
            BaseChart.Chart.Axes.Left.MinorTicks.Transparency = 0;
            BaseChart.Chart.Legend.Visible = false;
            BaseChart.Chart.Title.Text = "Color Grid series";

            //Themes.AplicarTheme(BaseChart);

            colorGrid.FillSampleValues(20);

            colorGrid.UseColorRange = true;
            colorGrid.UsePalette = true;

            colorGrid.StartColor = var.GetPaletteBasic[0];
            colorGrid.MidColor = var.GetPaletteBasic[1];
            colorGrid.EndColor = var.GetPaletteBasic[2];
            colorGrid.ColorEach = true;

            colorGrid.Pen.Color = Color.White;

            //this.colorGrid.Brush.Color = System.Drawing.Color.Red;
            colorGrid.Marks.ArrowLength = 0;
            colorGrid.Marks.Symbol.Shadow.Height = 1;
            colorGrid.Marks.Symbol.Shadow.Visible = true;
            colorGrid.Marks.Symbol.Shadow.Width = 1;
            colorGrid.NumXValues = 25;
            colorGrid.NumZValues = 25;
            colorGrid.PaletteMin = 4;
            colorGrid.PaletteStep = 2;
            colorGrid.Title = "Color Grid";

            colorGrid.XValues.DataMember = "X";
            colorGrid.YValues.DataMember = "Y";
            colorGrid.ZValues.DataMember = "Z";

            BaseChart.Chart.Series.Add(colorGrid);

        }

    }
}
