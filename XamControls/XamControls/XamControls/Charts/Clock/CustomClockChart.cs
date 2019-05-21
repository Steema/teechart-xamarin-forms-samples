using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Xamarin.Forms;

namespace XamControls.Charts.Clock
{
    public class CustomClockChart
    {
        #if !TEE_STD
        private Steema.TeeChart.Styles.Clock clock;
        
        public CustomClockChart(ChartView BaseChart)
        {

            clock = new Steema.TeeChart.Styles.Clock();

            clock.FillSampleValues();
            clock.Pointer.Color = Color.Black;
            clock.CircleLabelsInside = true;
            clock.ShowInLegend = false;
            clock.Pointer.Style = PointerStyles.Rectangle;
            clock.Pointer.Gradient.Visible = false;
            clock.Circled = true;
            clock.Style = ClockStyles.Decimal;
            clock.Pointer.HorizSize += 5;
            clock.Pointer.VertSize += 5;
            clock.Pointer.Pen.Visible = false;
            clock.Color = Color.Black;
            clock.Brush.Color = Color.Black;
            clock.Font.Size += 8;
            clock.LabelsMargin += 2;
            clock.PenSeconds.Color = Color.Red;
            clock.CircleLabelsFont.Size += 4;

            BaseChart.Chart.Title.Text = "";

            BaseChart.Chart.Series.Add(clock);

        }

        public void RemoveTimer()
        {

            clock.CancelTimer = true;

        }
#endif
    }
}
