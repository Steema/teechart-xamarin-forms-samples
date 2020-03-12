using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;
using XamControls.Variables;
using XamControls.Views;

namespace XamControls.Tools
{
    public class DataPointSelection
    {

        private int IndexPointerSelected = -1;
        private ChartView BaseChart;
        private Series LastSeries;
        private Variables.Variables var;

        public DataPointSelection(ChartView BaseChart)
        {

            this.BaseChart = BaseChart;
            var = new Variables.Variables();

        }

        // Line GetSeriesMark
        public void Serie_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
        {

            if (((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as ChartTabPage).chartSettPage != null && ((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as ChartTabPage).chartSettPage.tView.GetSwitchMarks.firstTime && series.Marks.Visible && IndexPointerSelected != -1 && ((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as ChartTabPage).chartSettPage.tView.GetSwitchMarks.IsToggled) { series.Marks.Visible = true; }
            else
            {

                if (IndexPointerSelected != -1)
                {

                    if (e.ValueIndex == IndexPointerSelected) { series.Marks.Visible = true; }
                    else { series.Marks.Visible = false; }

                }
                LastSeries = series;

            }

        }

        // Line PointClick
        public void PointValue_Click(CustomPoint series, int valueIndex, double x, double y)
        {

            if (IndexPointerSelected == valueIndex && LastSeries == series)
            {

                ClearMarks(series);

            }
            else
            {

                ClearMarks();
                series.Marks.Visible = true;
                IndexPointerSelected = valueIndex;
                series.Repaint();
            }
            if (((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as ChartTabPage).chartSettPage != null) { ((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as ChartTabPage).chartSettPage.tView.GetSwitchMarks.firstTime = false; }


        }

        // Kagi GetSeriesMark
        public void Kagi_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
        {

            if (IndexPointerSelected == e.ValueIndex) { series.Marks.Visible = true; }
            else { series.Marks.Visible = true; }

        }

        // Kagi ClickSeries
        public void KagiChart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
        {

            if (IndexPointerSelected == valueIndex)
            {

                ClearMarks(s);

            }
            else
            {

                ClearMarks();
                s.Marks.Visible = true;
                IndexPointerSelected = valueIndex;
                s.Repaint();


            }

        }

        // ErrorBar GetSeriesMark
        public void SerieErrorBar_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
        {

            if (IndexPointerSelected != -1)
            {

                if (e.ValueIndex == IndexPointerSelected) { series.Marks.Visible = true; }
                else { series.Marks.Visible = false; ClearColorErrorBar(series); }

            }

        }

        // ErrorBar BarClick
        public void ErrorBarSeries_Click(object sender, Series s, int valueIndex, MouseEventArgs e)
        {

            if (IndexPointerSelected == valueIndex)
            {

                s[valueIndex].Color = var.GetPaletteBasic[valueIndex];
                ClearMarks(s);

            }
            else
            {

                ClearColorErrorBar(s);
                ClearMarks();
                s.Marks.Visible = true;
                IndexPointerSelected = valueIndex;
                s[valueIndex].Color = var.GetPaletteBasic[valueIndex].AddLuminosity(-0.15);
                s.Repaint();


            }

        }

        // Histogram GetSeriesMark
        public void SerieHistogram_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
        {

            if (IndexPointerSelected != -1)
            {

                if (e.ValueIndex == IndexPointerSelected) { series.Marks.Visible = true; }
                else { series.Marks.Visible = false; ClearColorHisto(series); }

            }

        }

        // Clear HistoColor for bug
        private void ClearColorErrorBar(Series s)
        {

            for (int i = 0; i < s.Count; i++) { s[i].Color = var.GetPaletteBasic[i]; }

        }

        // Histogram BarClick
        public void HistoSeries_Click(object sender, Series s, int valueIndex, MouseEventArgs e)
        {

            if (IndexPointerSelected == valueIndex)
            {

                s[valueIndex].Color = var.GetPaletteBasic[0];
                ClearMarks(s);

            }
            else
            {

                ClearColorHisto(s);
                ClearMarks();
                s.Marks.Visible = true;
                IndexPointerSelected = valueIndex;
                s[valueIndex].Color = var.GetPaletteBasic[0].AddLuminosity(-0.15);
                s.Repaint();


            }

        }

        // Clear HistoColor for bug
        private void ClearColorHisto(Series s)
        {

            for (int i = 0; i < s.Count; i++) { s[i].Color = var.GetPaletteBasic[0]; }

        }

        // Clear Marks "Nuevo item"
        private void ClearMarks()
        {

            for (int i = 0; i < BaseChart.Chart.Series.Count; i++) { BaseChart.Chart.Series[i].Marks.Visible = false; }

        }

        // Clear Marks "Viejo item"
        private void ClearMarks(Series series)
        {

            series.Marks.Visible = false;
            IndexPointerSelected = -1;
            series.Repaint();

        }

        int lastValueIndex = -1;
        public void PieChart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
        {

            Pie pie = (Pie)BaseChart.Chart.Series[0];
            for (int i = 0; i < pie.Count; i++) { pie.ExplodedSlice[i] = 0; }

            if (lastValueIndex != valueIndex) { pie.ExplodedSlice[valueIndex] = 10; lastValueIndex = valueIndex; }
            else { lastValueIndex = -1; }
            s.Repaint();

        }

        public void DonutChart_ClickSeries(object sender, Series s, int valueIndex, MouseEventArgs e)
        {

            Donut donut = (Donut)BaseChart.Chart.Series[0];
            for (int i = 0; i < donut.Count; i++) { donut.ExplodedSlice[i] = 0; }

            if (lastValueIndex != valueIndex) { donut.ExplodedSlice[valueIndex] = 10; lastValueIndex = valueIndex; }
            else { lastValueIndex = -1; }
            s.Repaint();

        }

    }

}
