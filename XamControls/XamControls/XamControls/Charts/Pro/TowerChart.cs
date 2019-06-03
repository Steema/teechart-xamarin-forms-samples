using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;

namespace XamControls.Charts.Pro
{
#if !TEE_STD
    public class TowerChart
    {

        Tower _tower;
        ChartView _chartView;
        Steema.TeeChart.Tools.Rotate _rotate;

        public TowerChart(ChartView chartView)
        {
            _chartView = chartView;
            _tower = new Tower(_chartView.Chart);
            _rotate = new Steema.TeeChart.Tools.Rotate(_chartView.Chart);

            var colors = new Variables.Variables().GetPaletteBasic;

            _tower.UseColorRange = false;
            _tower.UsePalette = true;

            _tower.FillSampleValues(6);
            _chartView.Chart.Aspect.View3D = true;
            _tower.Palette.Clear();

            _tower.ClearPalette();
            _tower.AddPalette(1, colors[0]);
            _tower.AddPalette(2, colors[1]);
            _tower.AddPalette(3, colors[2]);
            _tower.AddPalette(4, colors[3]);
            _tower.AddPalette(5, colors[4]);
            _tower.Chart.Aspect.Chart3DPercent = 30;
            _tower.Chart.Walls.Left.Visible = true;
            _tower.Chart.Walls.Bottom.Visible = true;

            _rotate.Active = true;
            _rotate.Style = Steema.TeeChart.Tools.RotateStyles.All;

            _chartView.Chart.Axes.Left.Automatic = true;
            _chartView.Chart.Axes.Bottom.Automatic = true;
        }

    }
#endif
}
