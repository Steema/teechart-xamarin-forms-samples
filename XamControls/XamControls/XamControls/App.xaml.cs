using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.Views;
using Xamarin.Essentials;
using XamControls.Utils;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamControls
{
	public partial class App : Application
	{

        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

		public App ()
		{
			InitializeComponent();

            CreateAppFiles();
            if(Xamarin.Forms.Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new MasterView();
            }
            else if(Device.RuntimePlatform == Device.UWP)
            {
                MainPage = new UWPHomePage();
            }
			
		}

        // Detecta si es la primera vez que accedes a la app (en el caso que sí, crea los archivos básicos)
        private void CreateAppFiles()
        {
            FileController fileController = new FileController();
            fileController.AppFilesCreated();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts

		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes

		}



	}
}
