using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StandardSeriesXFormsSTD;

namespace StandardSeriesXFormsSTD
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {

			Image logo = new Image
			{
				Source = "steema_50x50.png"
            };

			Label header = new Label
			{
				Text = "Standard Series",
				TextColor = Color.Black,		
				Font = Font.SystemFontOfSize(20),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			var Cabecera = new StackLayout
			{
				Spacing = 6,
                HeightRequest = 70,
				BackgroundColor = Color.FromRgb(199, 221,241),
				Orientation = StackOrientation.Horizontal,
				Children = { logo, header }
			};

			StackLayout stack = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, Device.OnPlatform<int>(0, 0, 0), 0, 0),
				Children = {
					Cabecera,
                    new MainLink( "Home" ),
                    new Label{ Text = " Lines", TextColor = Color.Gray, BackgroundColor = Color.LightGray},
                    new MainLink( "StockMonitoring" ),					
                    new Label{ Text = " Bars", TextColor = Color.Gray, BackgroundColor = Color.LightGray},
					new MainLink( "SalesFigures"),
					new MainLink( "StackedBars"),
					new MainLink( "ServerStatus"),
                    new Label{ Text = " Areas",  TextColor = Color.Gray, BackgroundColor = Color.LightGray},
					new MainLink( "VegetationGrowth"),
                    new Label{ Text = " Pie and Donut", TextColor = Color.Gray, BackgroundColor = Color.LightGray},
					new MainLink( "PieSalesFigures"),
					new MainLink( "MultiPies"),
					new MainLink( "MultiDonuts"),
                    new Label{ Text = " Points", TextColor = Color.Gray, BackgroundColor = Color.LightGray},
					new MainLink( "ProductShipments"),
                    new Label{ Text = " Gantt", TextColor = Color.Gray, BackgroundColor = Color.LightGray},
					new MainLink( "ProjectPlanner"),
                }
            };
			Title = "Menu";
			BackgroundColor = Color.White; //.WithLuminosity(0.9);
                                           //Opacity = 0.5;
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;

            Content =  new ScrollView () 
            {
                Content = stack
            };
		}
    }
}