using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StandardSeriesDemo
{
    public class MainLink : Button
    {
		public MainLink(ContentPage name)
        {
			var txt = name.ToString().Substring("StandardSeriesDemo.".Length);
            switch (txt)
            {
                case "VegetationGrowth":
                    Text = "Vegetation Growth"; break;
                case "SalesFigures":
                    Text = "Sales Figures"; break;
                case "ServerStatus":
                    Text = "Server Status"; break;
                case "StackedBars":
                    Text = "Stacked Bars"; break;
                case "PopularLanguages":
                    Text = "Popular Languages"; break;
                case "ProjectPlanner":
                    Text = "Project Planner"; break;
                case "StockMonitoring":
                    Text = "Stock Monitoring"; break;
                case "WebAnalytics":
                    Text = "Web Analytics"; break;
                case "ScrollerChart":
                    Text = "Scroller Chart"; break;
                case "MultiDonuts":
                    Text = "Multi Donuts"; break;
                case "MultiPies":
                    Text = "Multi Pies"; break;
                case "PieSalesFigures":
                    Text = "Pie Sales Figures"; break;
                case "ProductShipments":
                    Text = "Product Shipments"; break;
                default:
                    Text = "Others"; break;
            }

            BackgroundColor = Color.FromRgb(97, 97, 97);
            TextColor = Color.White;

			Command = new Command(o =>
			{
				App.MasterDetailPage.Detail = new NavigationPage(name);
				App.MasterDetailPage.IsPresented = false;
			});
        }
    }
}