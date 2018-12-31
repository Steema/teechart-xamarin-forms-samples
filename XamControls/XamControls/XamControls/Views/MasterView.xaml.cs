	using XamControls.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.ViewModels;
using Xamarin.Forms.Xaml;
using System.Threading;
using XamControls.Services;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XamControls.CustomRenders;

namespace XamControls.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : MasterDetailPage
	{

		private HomePage home;
        CustomNavigationPage navigationPage;

		public MasterView()
		{
			InitializeComponent();

            home = new HomePage();

            Menu.lView.ItemSelected += ListView_ItemSelected;

			home.SetMaster = this;
			home.CrearContenido();
			home.Title = "Home";

            if (Device.RuntimePlatform == Device.Android)
            {
                navigationPage = new CustomNavigationPage(home, TransitionType.Fade);
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ListView.SetIsFastScrollEnabled(this, true);
            }
            else
            {
                navigationPage = new CustomNavigationPage(home, TransitionType.Fade)
                {
                    BarBackgroundColor = Color.FromRgb(33, 150, 244),
                    Icon = "ic_menu_white_24dp.png",
                    BarTextColor = Color.White
                };
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            }

            Detail = navigationPage;

            home.Title = "XamControls";
            home.Appearing += Home_Appearing;
        }

        private void Home_Appearing(object sender, EventArgs e)
        {
            home.GetListView.IsRefreshing = true;
            home.GetListView.EndRefresh();
            navigationPage.Elevation = 8;
            home.Elevation = 8;
        }

        private void BottomTabPage_Appearing(object sender, EventArgs e)
        {
            home.GetListView.IsRefreshing = true;
            home.GetListView.EndRefresh();
            navigationPage.Elevation = 8;
            home.Elevation = 8;
        }

		private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
		{
            if (Device.RuntimePlatform == Device.Android) home.ChangePage = 1;
        }

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterViewMenuItem;

			if (item == null)
				return;
			if (item.Id == 1) { Device.OpenUri(new Uri("https://www.steema.com/product/forms")); }
			else if (item.Id == 2) { Device.OpenUri(new Uri("https://github.com/Steema/teechart-xamarin-forms-samples?files=1")); }
			else if (item.Id == 3) { Device.OpenUri(new Uri("http://www.teechart.net/docs/TeeChartNETFormsReference.htm ")); }
			else
			{
				if (item.BackgroundColor != Color.FromRgb(238, 238, 238))
				{
					var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
					if (item.Id != 4)	{

						if(item.Id == 0)
                        {
                            if (Device.RuntimePlatform == Device.Android) { Detail = new CustomNavigationPage(home, Services.TransitionType.Fade); }
                            else { Detail = new CustomNavigationPage(home, Services.TransitionType.Fade) { BarBackgroundColor = Color.FromRgb(33, 150, 244), Icon = "ic_menu_white_24dp.png", BarTextColor = Color.White }; }
                        }
						else
                        {
                            if (Device.RuntimePlatform == Device.Android) Detail = new CustomNavigationPage(page, Services.TransitionType.Fade);
                            else Detail = new CustomNavigationPage(page, Services.TransitionType.Fade) { BarBackgroundColor = Color.FromRgb(33, 150, 244), Icon = "ic_menu_white_24dp.png", BarTextColor = Color.White };
                        }						
					}
					else
					{
						Detail = new CustomNavigationPage(page, Services.TransitionType.Fade) { BarBackgroundColor = Color.FromRgb(101, 128, 146), BarTextColor = Color.White, };
					}
                    home.Elevation = 8;
                    if(Device.RuntimePlatform == Device.Android) navigationPage = (CustomNavigationPage)Detail;
                }
			}
			IsPresented = false;
			Menu.lView.SelectedItem = null;
		}

		public void Mostrar()
		{
			if (IsPresented) { IsPresented = true; }
			else { IsPresented = false; }
		}

        /// <summary>
        /// Devuelve la navigationPage
        /// </summary>
        public CustomNavigationPage GetNavigationPage { get { return navigationPage; } }

        protected override void OnDisappearing()
        {

            base.OnDisappearing();

        }


        public override bool ShouldShowToolbarButton()
        {
            if (Device.RuntimePlatform == Device.Android) home.ChangePage = 1;
            return base.ShouldShowToolbarButton();
        }


    }
}