using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExportImportChart
{
    public class ChartViewExtended : ContentView
    {

        public delegate void DelSavePanelAsPNG(SaveChartEventArgs saveChartEventArgs);
        public event DelSavePanelAsPNG OnSavePanelAsPNG;
        public static readonly BindableProperty ChartViewProperty =
            BindableProperty.Create(nameof(ChartView), typeof(ChartView), typeof(ChartViewExtended));

        public ChartViewExtended(ChartView chartView)
        {
            ChartView = chartView;
            this.Content = ChartView;
        }

        public void SaveChartAsPNG(string fileName)
        {
            string finalFileName = fileName.Replace('/', '-');
            if (OnSavePanelAsPNG != null)
            {
                OnSavePanelAsPNG.Invoke(new SaveChartEventArgs(finalFileName));
            }
        }

        public ChartView ChartView
        {
            get => (ChartView)GetValue(ChartViewProperty);
            set => SetValue(ChartViewProperty, value);
        }

    }

    public class SaveChartEventArgs : EventArgs
    {

        string _fileName;

        public SaveChartEventArgs(string fileName)
        {
            _fileName = fileName;
        }

        public string FileName => _fileName;

    }

}
