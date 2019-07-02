using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.PCL.Pages;

namespace XamControls.PCL
{
    public partial class App : Application
    {

        XamControls.PCL.Pages.NavigationPage _navigationPage;

        public App()
        {
            InitializeComponent();
            Current = this;
            _navigationPage = new Pages.NavigationPage(new MainPage());
            MainPage = _navigationPage;
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
