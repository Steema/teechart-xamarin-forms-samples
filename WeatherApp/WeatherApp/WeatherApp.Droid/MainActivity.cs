using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.CurrentActivity;
using Android.Locations;
using Android.Content;
using Android;
using System.Threading.Tasks;
using Android.Support.Design.Widget;

namespace WeatherApp.Droid
{
    [Activity(Label = "WeatherApp", Icon = "@drawable/iconSteemaWeather", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string[] PermissionsLocation=
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        const int RequestLocationId = 0;
        LocationManager locMgr;
        Location location;
        Bundle bundle;
        private bool isGpsEnabled = false;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            this.bundle = bundle;

            isGpsEnabled = ServiceGpsEnabled();

            if (!isGpsEnabled)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage("We need your location, active it.");
                builder.Show();
                Action actionWaitGpsEnabled = new Action(() => WaitToGpsEnabled());
                Task.Run(actionWaitGpsEnabled);
            }
            else
            {
                Forms.Init(this, bundle);
                LoadApplication(new App());
            }
        }

        private void WaitToGpsEnabled()
        {
            bool isEnabled = false;
            LocationManager locationManager = (LocationManager)GetSystemService(Context.LocationService);
            while (!isEnabled)
            {
                if (!locationManager.IsProviderEnabled(LocationManager.GpsProvider)) isEnabled = false;
                else isEnabled = true;
                Task.Delay(1000);
            }
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                Forms.Init(this, bundle);
                LoadApplication(new App());
            });         
        }


        private bool ServiceGpsEnabled()
        {
            LocationManager locationManager = (LocationManager)GetSystemService(Context.LocationService);

            if (!locationManager.IsProviderEnabled(LocationManager.GpsProvider)) return false;
            else return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {

            if (!isGpsEnabled)
            {

                isGpsEnabled = ServiceGpsEnabled();

                if (isGpsEnabled)
                {
                    Forms.Init(this, bundle);
                    LoadApplication(new App());
                }

            }

            base.OnResume();
        }

    }

}

