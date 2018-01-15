using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
    public class MainLink : Button
    {
		public MainLink(string name)
        {
			//var txt = name.ToString().Substring("StandardSeriesXFormsSTD.".Length);
            switch (name)
            {
                case "VegetationGrowth":
                    Text = "Vegetation Growth"; break;
                case "SalesFigures":
                    Text = "Sales Figures"; break;
                case "ServerStatus":
                    Text = "Server Status"; break;
                case "StackedBars":
                    Text = "Stacked Bars"; break;
                case "ProjectPlanner":
                    Text = "Project Planner"; break;
                case "StockMonitoring":
                    Text = "Stock Monitoring"; break;
                case "MultiDonuts":
                    Text = "Multi Donuts"; break;
                case "MultiPies":
                    Text = "Multi Pies"; break;
                case "PieSalesFigures":
                    Text = "Pie Sales Figures"; break;
                case "ProductShipments":
                    Text = "Product Shipments"; break;
                default:
                    Text = "Home"; break;
            }

            BackgroundColor = Color.FromRgb(245,245,245);
            TextColor = Color.Gray;

            tmpName = name;

            Clicked += MainLink_Clicked;

            /*
			Command = new Command(o =>
			{
				App.MasterDetailPage.Detail = new NavigationPage(name);
				App.MasterDetailPage.IsPresented = false;
			});
            */
        }

        string tmpName;

        private void MainLink_Clicked(object sender, EventArgs e)
        {
            switch (tmpName)
            {
                case "VegetationGrowth":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.VegetationGrowth());
                    break;
                case "SalesFigures":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.SalesFigures());
                    break;
                case "ServerStatus":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.ServerStatus());
                    break;
                case "StackedBars":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.StackedBars());
                    break;
                case "ProjectPlanner":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.ProjectPlanner());
                    break;
                case "StockMonitoring":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.StockMonitoring());
                    break;
                case "MultiDonuts":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.MultiDonuts());
                    break;
                case "MultiPies":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.MultiPies());
                    break;
                case "PieSalesFigures":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.PieSalesFigures());
                    break;
                case "ProductShipments":
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.ProductShipments());
                    break;
                default:
                    App.MasterDetailPage.Detail = new NavigationPage(new StandardSeriesXFormsSTD.Home());
                    break;
            }

            App.MasterDetailPage.IsPresented = Device.OS == TargetPlatform.Windows ? true : false;
        }
    }
}