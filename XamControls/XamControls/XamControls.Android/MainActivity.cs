using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Essentials;
using Android.Graphics;
using Naxam.Controls.Platform.Droid;
using Xamarin.Forms;
using Android.Provider;
using Naxam.Controls.Forms;
using Naxam.Controls.Platform.Droid.Utils;
using XamControls.Components;
using Android.Support.V7.App;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Speech;
using static Android.App.ActionBar;

namespace XamControls.Droid
{
	[Activity(Label = "XamControls", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        public static Android.Support.V7.Widget.Toolbar ToolBar { get; set; }
        public static AndroidX.ViewPager.Widget.ViewPager ViewPager { get; set; }

        const int ShareImageId = 1000;

		protected override void OnCreate(Bundle bundle)
		{

            TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            ToolBar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Layout.Toolbar);
            ViewPager = (AndroidX.ViewPager.Widget.ViewPager)FindViewById(Resource.Layout.Tabbar);

            base.OnCreate(bundle);

			SetUpBottomBar();
                
			Rg.Plugins.Popup.Popup.Init(this, bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
			global::Xamarin.Essentials.Platform.Init(this, bundle);
            //if(Device.RuntimePlatform == Device.Android) { var next_activity = new Intent(this, typeof(ActivityB)); this.StartActivity(next_activity); }

            //MessagingCenter.Subscribe<ImageSource>(this, "Share", Share, null);

            App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

        }

        async void Share(ImageSource imageSource)
		{
			var intent = new Intent(Intent.ActionSend);
			intent.SetType("image/png");

			var handler = new ImageLoaderSourceHandler();
			var bitmap = await handler.LoadImageAsync(imageSource, this);

			var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads
					+ Java.IO.File.Separator + "logo.png");

			using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
			{
				bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
			}

			intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));

			var intentChooser = Intent.CreateChooser(intent, "Share via");

			StartActivityForResult(intentChooser, ShareImageId);

		}

		//Android.Widget.ShareActionProvider actionProvider;
		/*public override bool OnCreateOptionsMenu(IMenu menu)
		{
			this.MenuInflater.Inflate(Resource.Menu.NativeShare, menu);

			var shareItem = menu.FindItem(Resource.Id.action_share);
			actionProvider = shareItem.ActionProvider.JavaCast<Android.Widget.ShareActionProvider>();

			var intent = new Intent(Intent.ActionSend);
			intent.SetType("text/plain");
			intent.PutExtra(Intent.ExtraText, "Time to share some text!");

			actionProvider.SetShareIntent(intent);


			return base.OnCreateOptionsMenu(menu);

		}*/


		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public override void OnBackPressed()
		{
			if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
			{
				// Do something if there are some pages in the `PopupStack`
			}
			else
			{
				// Do something if there are not any pages in the `PopupStack`
			}
		}

		public void SetUpBottomBar()
		{

			var stateList = new Android.Content.Res.ColorStateList(
			new int[][] {

							new int[] { Android.Resource.Attribute.StateChecked },
							new int[] { Android.Resource.Attribute.StateEnabled }
			},

			new int[] {

							Android.Graphics.Color.Rgb(73, 132, 232), //Selected
							Android.Graphics.Color.Rgb(123, 123, 123) //Normal

			});

			BottomTabbedRenderer.VisibleTitle = true;
			BottomTabbedRenderer.BackgroundColor = new Android.Graphics.Color(255, 255, 255);
			BottomTabbedRenderer.FontSize = 11;
			BottomTabbedRenderer.IconSize = 30;
			BottomTabbedRenderer.ItemTextColor = stateList;
			BottomTabbedRenderer.ItemIconTintList = stateList;
			BottomTabbedRenderer.Typeface = Typeface.SansSerif;
			BottomTabbedRenderer.ItemSpacing = 4;
			//BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(6);
			BottomTabbedRenderer.BottomBarHeight = 0; //60
			BottomTabbedRenderer.ItemAlign = ItemAlignFlags.Center;

		}

	}
}

