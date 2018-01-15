using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Steema.TeeChart;

using Xamarin.Forms;

namespace StandardSeriesXFormsSTD.DashBoards
{
    public class Page2 : ContentPage
    {
        public ChartView dashBoard1;
        public Page2()
        {
            // NavigationPage.SetHasNavigationBar(this, false);            

            dashBoard1 = new ChartView();
            dashBoard1.WidthRequest = 400;
            dashBoard1.HeightRequest = 300;

            dashBoard1.Chart.Aspect.View3D = false;

            Steema.TeeChart.Styles.NumericGauge numericGauge = new Steema.TeeChart.Styles.NumericGauge();
            dashBoard1.Chart.Series.Add(numericGauge);
            numericGauge.FillSampleValues();

            dashBoard1.Chart.Panel.Color = numericGauge.FaceBrush.Color;
            dashBoard1.Chart.Panel.Gradient.Visible = false;
            dashBoard1.Chart.Walls.Visible = false;
            dashBoard1.Chart.Title.Text = "Numeric Gauge";
            dashBoard1.Chart.Title.Alignment = TextAlignment.Start;
            dashBoard1.Chart.Title.Font.Size = 12;
            dashBoard1.Chart.Title.Font.Color = Color.White;
            dashBoard1.Chart.Axes.Visible = false;
            dashBoard1.Chart.Legend.Visible = false;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    dashBoard1
                }
            };
        }
    }
}
