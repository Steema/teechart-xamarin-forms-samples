using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StandardSeriesDemo;

namespace StandardSeriesDemo
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {

			Image logo = new Image
			{
				Source = "rose.png"
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
                HeightRequest = 80,
				BackgroundColor = Color.White,
				Orientation = StackOrientation.Horizontal,
				Children = { logo, header }
			};

			StackLayout stack = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				//Orientation = ScrollOrientation.Vertical,
				Padding = new Thickness(0, Device.OnPlatform<int>(0, 0, 0), 0, 0),
				Children = {
					Cabecera,
                    new Label{ Text = "Lines", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.StockMonitoring() ),
					new MainLink( new StandardSeriesDemo.WebAnalytics()),
                    new Label{ Text = "Bars", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.SalesFigures()),
					new MainLink( new StandardSeriesDemo.StackedBars()),
					new MainLink( new StandardSeriesDemo.ServerStatus()),
                    new Label{ Text = "Areas",  TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.VegetationGrowth()),
                    new Label{ Text = "Pie and Donut", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.PieSalesFigures()),
					new MainLink( new StandardSeriesDemo.MultiPies()),
					new MainLink( new StandardSeriesDemo.MultiDonuts()),
                    new Label{ Text = "Points", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.ProductShipments()),
                    new Label{ Text = "Gantt", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.ProjectPlanner()),
                    new Label{ Text = "Bubbles", TextColor = Color.White, BackgroundColor = Color.Navy},
					new MainLink( new StandardSeriesDemo.PopularLanguages()),
                    //new Label{ Text = "Miscellaneous", TextColor = Color.White, BackgroundColor = Color.Navy},
					//new MainLink( new StandardSeriesDemo.ScrollerChart()),
				}
			};
			Title = "Menu";
			BackgroundColor = Color.FromRgb(65,65,65); //.WithLuminosity(0.9);
			//Opacity = 0.5;
			Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;

            Content =  new ScrollView () 
            {
                Content = stack
            };
		}
    }
}