using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using XamControls.Tools;
using XamControls.Variables;
using XamControls.ViewModels.Base;

namespace XamControls.Charts.Pro
{
    public class KagiChart
    {
        #if !TEE_STD
		private Kagi kagi;
		private Variables.Variables var;
        private Axis botAxis;

		public KagiChart(ChartView BaseChart)
		{

			kagi = new Kagi();
			var = new Variables.Variables();
            botAxis = BaseChart.Chart.Axes.Bottom;

			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Bottom.Visible = true;
			BaseChart.Chart.Series.Add(kagi);

			kagi.BuySymbol.Visible = true;
			kagi.SellSymbol.Visible = true;
			kagi.ReversalAmount = 0.06;
			kagi.UpSwing.Visible = true;
			kagi.UpSwing.Color = Color.Green;
			kagi.UpSwing.Width = 3;
			kagi.DownSwing.Color = Color.Red;
			kagi.DownSwing.Width = 2;
			kagi.AbsoluteReversal = true;
			kagi.UpSwing.EndCap = PenLineCap.Round;
			kagi.DownSwing.EndCap = PenLineCap.Square;
			kagi.Pointer.Visible = true;
			kagi.Pointer.HorizSize = 20;
			kagi.Pointer.VertSize = 20;
			kagi.Pointer.Color = Color.Red;
            kagi.ClickableLine = false;


			BaseChart.Chart.Axes.Left.Automatic = true;
			BaseChart.Chart.Axes.Left.AutomaticMaximum = true;
			BaseChart.Chart.Axes.Left.AutomaticMinimum = true;

			for (int i = 0; i < var.GetValorKagiTime.Length; i++)
			{

					kagi.Add(var.GetValorKagiTime[i], var.GetValorsKagi[i, 0], var.GetValorsKagi[i, 1], var.GetValorsKagi[i, 2], var.GetValorsKagi[i, 3]);

			}

			BaseChart.Chart.Axes.Left.Increment = 4;
			BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
			BaseChart.Chart.Axes.Left.Visible = true;
			BaseChart.Chart.Axes.Left.AxisPen.Visible = true;
            BaseChart.Chart.Legend.Visible = false;

			BaseChart.Chart.Axes.Bottom.SetMinMax(0, 2);
			BaseChart.Chart.Axes.Bottom.Increment = 1;

			BaseChart.Chart.Title.Text = "Kagi";

		}
#endif
    }
}
