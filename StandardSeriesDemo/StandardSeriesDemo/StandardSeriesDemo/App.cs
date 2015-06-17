using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StandardSeriesDemo
{
    public class App : Application
    {

        public static MasterDetailPage MasterDetailPage;
        public App()
        {
			var detail = new NavigationPage(new Home());
            detail.BarBackgroundColor = Color.White;

            var nav = detail.Navigation;

			MasterDetailPage = new MasterDetailPage
			{
				Master = new MenuPage(),
                Detail = detail,
			};

			MainPage = MasterDetailPage;
        }

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
