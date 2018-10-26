using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamControls.Droid
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);
            Log.Debug("SplashActivity", "OnCreate Event");

		}

        // Lanza el splash
        protected override void OnResume()
        {

            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();

        }

        // Evita que se pueda tirar salir del splash
        public override void OnBackPressed() { }

        // Espera durante el splash y lanza la actividad principal
        async void SimulateStartup() {

            Log.Debug("SplashActivity", "Launch Splash");
            await Task.Delay(2000); // Simulate a bit of startup work.
            Log.Debug("SplashActivity", "Intent Activity");
            StartActivity(typeof(MainActivity));

        }
	}
}