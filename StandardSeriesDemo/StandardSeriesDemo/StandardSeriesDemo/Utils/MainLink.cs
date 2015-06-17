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
			Text = name.ToString().Substring("StandardSeriesDemo.".Length);
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