using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TeeChartDashBoards
{
    public class App : Application
    {

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new Home());
        }
       /*
        public App()
        {
            var tChart1 = new Steema.TeeChart.Chart();

            tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();

            ChartView chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

                WidthRequest = 400,
                HeightRequest = 500
            };

            chartView.Model = tChart1;

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =  { 
            chartView, 
          }
                }
            };
        }
        */
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
