using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaugeSpeed
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        ChartView tChart1 = new ChartView
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,

            WidthRequest = 400,
            HeightRequest = 165
        };
        ChartView tChart2 = new ChartView
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,

            WidthRequest = 400,
            HeightRequest = 165
        };
        ChartView tChart3 = new ChartView
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,

            WidthRequest = 400,
            HeightRequest = 165
        };

        Donut donut1 = new Donut();
        Donut donut2 = new Donut();
        Donut donut3 = new Donut();

        Annotation annotation1 = new Annotation();
        Annotation annotationMin1 = new Annotation();
        Annotation annotationMax1 = new Annotation();

        Annotation annotation2 = new Annotation();
        Annotation annotationMin2 = new Annotation();
        Annotation annotationMax2 = new Annotation();

        Annotation annotation3 = new Annotation();
        Annotation annotationMin3 = new Annotation();
        Annotation annotationMax3 = new Annotation();

        private TimerViewModel timer1 = new TimerViewModel();
        private TimerViewModel timer2 = new TimerViewModel();
        private TimerViewModel timer3 = new TimerViewModel();

        //private int oldSpeed = 0;
        private int speed1 = 0;
        private int speed2 = 0;
        private int speed3 = 0;

        private void FillValues()
        {
            /* progressive value
            if ((oldSpeed == 0 )|| (speed >= oldSpeed) || (oldSpeed <= speed))
            {
                var rndspeed = new Random();
                oldSpeed = rndspeed.Next(100);                
            }

            if (oldSpeed > speed)
                speed = speed + 2;
            else
                speed = speed -2;
            */

            var rndspeed1 = new Random();

            speed1 = rndspeed1.Next(100);
            speed2 = rndspeed1.Next(100);
            speed3 = rndspeed1.Next(100);

            double value11 = speed1;
            double value12 = 100 - speed1;
            double value21 = speed2;
            double value22 = 100 - speed2;
            double value31 = speed3;
            double value32 = 100 - speed3;

            donut1.Clear();
            donut1.Add(value12, Color.White);
            donut1.Add(value11, Color.FromHex("#FB004F"));

            donut2.Clear();
            donut2.Add(value22, Color.White);
            donut2.Add(value21, Color.FromHex("#A91399"));

            donut3.Clear();
            donut3.Add(value32, Color.White);
            donut3.Add(value31, Color.FromHex("#5A5AD4"));

            annotation1.Text = speed1.ToString() + " km/h";
            annotationMin1.Text = "0";
            annotationMax1.Text = "100";

            annotation2.Text = speed2.ToString() + " km/h";
            annotationMin2.Text = "0";
            annotationMax2.Text = "100";

            annotation3.Text = speed3.ToString() + " km/h";
            annotationMin3.Text = "0";
            annotationMax3.Text = "100";
        }

        private void ConfigureChart(Chart tChart, Donut donut, Annotation annotation, Annotation annotationMin, Annotation annotationMax)
        {
            tChart.Aspect.View3D = false;
            tChart.Panel.Gradient.Visible = false;
            tChart.Panel.Color = Color.White;
            tChart.Legend.Visible = false;
            tChart.Header.Text = "Speed";
            tChart.Header.Alignment = TextAlignment.End;
            tChart.Panel.MarginBottom -= 50;

            tChart.Series.Add(donut);

            tChart.Tools.Add(annotation);
            tChart.Tools.Add(annotationMin);
            tChart.Tools.Add(annotationMax);

            donut.AngleSize = 180;
            donut.Marks.Visible = false;
            donut.Circled = true;
            donut.Pen.Width = 2;

            annotation.Shape.Transparent = true;
            annotationMin.Shape.Transparent = true;
            annotationMax.Shape.Transparent = true;

            annotation.TextAlign = TextAlignment.Center;
            annotationMin.TextAlign = TextAlignment.Center;
            annotationMax.TextAlign = TextAlignment.Center;

            annotation.Shape.CustomPosition = true;
            annotationMin.Shape.CustomPosition = true;
            annotationMax.Shape.CustomPosition = true;

            tChart.AfterDraw += TChart1_AfterDraw;
        }

        public MainPage()
        {
            ConfigureChart(tChart1.Chart, donut1, annotation1, annotationMin1, annotationMax1);
            ConfigureChart(tChart2.Chart, donut2, annotation2, annotationMin2, annotationMax2);
            ConfigureChart(tChart3.Chart, donut3, annotation3, annotationMin3, annotationMax3);

            FillValues();

            ConfigureTimer(timer1);
            ConfigureTimer(timer2);
            ConfigureTimer(timer3);

            Button button = new Button
            {
                Margin = new Thickness(2),
                HeightRequest = 40,
                BackgroundColor = Xamarin.Forms.Color.Red,
                Text = "STOP ANIMATION !!",
                TextColor = Xamarin.Forms.Color.White,
            };

            button.Clicked += Button_Clicked;

            // The root page of your application
            this.Title = "Gauge Speed Animation with TeeChart";
            this.Content = new StackLayout
            { 
                VerticalOptions = LayoutOptions.Start,
                Children = {
                    tChart1,
                    tChart2,
                    tChart3,
                    button
                },
            };

            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        private void ConfigureTimer(TimerViewModel timer)
        {
            timer.PropertyChanged += Timer1_PropertyChanged;
            timer.TimeLeft = new TimeSpan(0, 0, 0, 0, 1);  //  Interval 

            timer.StartCommand.Execute(null);
        }

        private void Timer1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FillValues();
        }

        private void Donut1_GetSeriesMark(Steema.TeeChart.Styles.Series series, Steema.TeeChart.Styles.GetSeriesMarkEventArgs e)
        {
            // Here we can check if the Mark value is less than...
            //if (series.YValues[e.ValueIndex] < Val)
            /*

            if (e.ValueIndex == 1)  
            {                
                (series as Steema.TeeChart.Styles.Pie).MarksPie.InsideSlice = false;
            }
            else
            {
                (series as Steema.TeeChart.Styles.Pie).MarksPie.InsideSlice = true;
            }
            */
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            timer1.StopCommand.Execute(null);
            timer2.StopCommand.Execute(null);
            timer3.StopCommand.Execute(null);
        }

        private void ConfigureAnnotations(Chart tChart, Annotation annotation, Annotation annotationMin, Annotation annotationMax)
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Device.iOS)
            {
                annotation.Shape.Left = tChart.Width / 2 - annotation.Width / 2;
                annotation.Shape.Top = tChart.Height / 2 + 20;

                annotationMin.Shape.Left = 275;
                annotationMin.Shape.Top = tChart.Height - 30;

                annotationMax.Shape.Left = tChart.Width - 275;
                annotationMax.Shape.Top = tChart.Height - 30;
            }
            else
            {
                annotation.Shape.Left = tChart.Width / 2 - annotation.Width / 2;
                annotation.Shape.Top = tChart.Height / 2 + 20;

                annotationMin.Shape.Left = 275;
                annotationMin.Shape.Top = tChart.Height - 90;

                annotationMax.Shape.Left = tChart.Width - 275;
                annotationMax.Shape.Top = tChart.Height - 90;
            }
        }
        private void TChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            ConfigureAnnotations(tChart1.Chart, annotation1, annotationMin1, annotationMax1);
            ConfigureAnnotations(tChart2.Chart, annotation2, annotationMin2, annotationMax2);
            ConfigureAnnotations(tChart3.Chart, annotation3, annotationMin3, annotationMax3);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.RuntimePlatform == Device.iOS)
                tChart1.Chart.InternalDraw();

            // For Android : iOS and Android different behaviors for OnAppearing , still not find a solution. 
            // Reference : https://forums.xamarin.com/discussion/18781/ios-and-android-different-behaviors-for-onappearing
        }

    }
}
