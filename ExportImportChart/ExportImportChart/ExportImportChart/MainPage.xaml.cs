using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExportImportChart
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        ChartViewExtended _chartViewExtended;
        ChartView _chartView;

        public MainPage()
        {
            InitializeComponent();

            Steema.TeeChart.Styles.Bar bar1 = new Steema.TeeChart.Styles.Bar();
            bar1.FillSampleValues(5);

            _chartView = new ChartView()
            {
                HeightRequest = 500,
                WidthRequest = 500,
                Chart = {
                    Series =
                    {
                        bar1,
                    }
                }
            };
            _chartViewExtended = new ChartViewExtended(_chartView);
            btnExport.Clicked += BtnExport_Clicked;
            stkLayout.Children.Add(_chartViewExtended);
        }

        private async void BtnExport_Clicked(object sender, EventArgs e)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage))[0];
                }

                if (status == PermissionStatus.Granted)
                {
                    _chartViewExtended.SaveChartAsPNG("chart" + DateTime.Now);
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                //Something went wrong
            }

        }
    }
}
