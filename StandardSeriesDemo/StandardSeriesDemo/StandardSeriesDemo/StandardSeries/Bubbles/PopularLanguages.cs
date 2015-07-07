using System;
using Steema.TeeChart;
using Xamarin.Forms;

namespace StandardSeriesDemo
{
	public class PopularLanguages : ContentPage
	{
        Chart tChart1;
        public ChartView chartView;
		public PopularLanguages ()
		{
            this.tChart1 = new Steema.TeeChart.Chart();
            // tChart1
            this.tChart1.Aspect.View3D = false;
            this.tChart1.Footer.Alignment = TextAlignment.Start;
            this.tChart1.Footer.Font.Brush.Color = Color.Gray;
            this.tChart1.Header.Font.Brush.Color = Color.Gray;
            this.tChart1.Header.Font.Size = 20;
            this.tChart1.Header.TextAlign = TextAlignment.End;
            this.tChart1.Header.Lines = new string[] {"Most popular coding languages of 2014"};
            this.tChart1.Legend.Font.Brush.Color = Color.Gray;
            this.tChart1.Legend.Font.Size = 12;
            this.tChart1.Legend.Shadow.Visible = false;
            this.tChart1.Legend.TextStyle = Steema.TeeChart.LegendTextStyles.Plain;
            this.tChart1.Panel.Brush.Color = Color.White;
            this.tChart1.Panel.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Walls.Back.Brush.Gradient.EndColor = Color.White;
            this.tChart1.Walls.Back.Visible = false;
            this.tChart1.GetLegendText += new Steema.TeeChart.GetLegendTextEventHandler(this.tChart1_GetLegendText);

            tChart1.Panel.Gradient.Visible = false;

            Steema.TeeChart.Styles.BubbleCloud bCloud = new Steema.TeeChart.Styles.BubbleCloud(tChart1.Chart);

            bCloud.UseColorRange = false;
            bCloud.UsePalette = true;

            bCloud.Rotation = 5;
            bCloud.Separation = 51;
            bCloud.SizeRatio = 1.44;

            bCloud.Add(0, 1175, 30.3, "Python");
            bCloud.Add(0, 1082.5, 22.2, "Java");
            bCloud.Add(0, 1077.5, 13, "C++");
            bCloud.Add(0, 1055, 10.6, "Ruby");
            bCloud.Add(0, 1042.5, 5.2, "JavaScript");
            bCloud.Add(0, 1035, 5, "C#");
            bCloud.Add(0, 1035, 4.1, "C");
            bCloud.Add(0, 1017.5, 3.3, "PHP");
            bCloud.Add(0, 1005, 1.6, "Perl");
            bCloud.Add(0, 975, 1.5, "Go");

            bCloud.Pen.Width = 2;
            bCloud.Pen.Color = Color.FromRgb(169,169,169);

            bCloud.Marks.Font.Color = Color.Black;
            this.tChart1.Aspect.ZoomText = true;

            chartView = new ChartView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 25,
                HeightRequest = 25
            };
            chartView.Model = tChart1;

            Content = new StackLayout
            {
                Children = {
					chartView
				}
            };
        }

        private void tChart1_GetLegendText(object sender, Steema.TeeChart.GetLegendTextEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.Text = e.Text + " 30,3 %";
                    break;
                case 1:
                    e.Text = e.Text + " 22,2 %";
                    break;
                case 2:
                    e.Text = e.Text + " 13 %";
                    break;
                case 3:
                    e.Text = e.Text + " 10,6 %";
                    break;
                case 4:
                    e.Text = e.Text + " 5,2 %";
                    break;
                case 5:
                    e.Text = e.Text + " 5 %";
                    break;
                case 6:
                    e.Text = e.Text + " 4,1 %";
                    break;
                case 7:
                    e.Text = e.Text + " 3,3 %";
                    break;
                case 8:
                    e.Text = e.Text + " 1,6 %";
                    break;
                case 9:
                    e.Text = e.Text + " 1,5 %";
                    break;

            }
        }
	}
}


