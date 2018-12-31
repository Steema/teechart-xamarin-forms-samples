using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Android.Net;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Graphics.Drawable;
using XamControls.Views;
using XamControls.Droid;
using Android.Graphics.Drawables;
using XamControls.CustomRenders;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(MySearchBarRenderer))]
namespace XamControls.Droid.Renderer
{
	public class MySearchBarRenderer : SearchBarRenderer

	{

		private SearchView searchView;
		private Android.Views.View icon;
		private Context context;

		LinearLayout linearLayout;

		public MySearchBarRenderer(Context context) : base(context)
		{

			this.context = context;
			
		}

		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{

			base.OnElementChanged(e);

			searchView = Control;
			//linearLayout = Control;

			if (Control != null)
			{
				searchView.Iconified = false;
				searchView.SetIconifiedByDefault(false);
				searchView.BaselineAligned = false;
				searchView.BaselineAlignedChildIndex = 0;

				/*
				linearLayout.RemoveAllViews();
				TextView label = new TextView(context);
				label.Text = "hola";
				linearLayout.AddView(label);
				Toolbar toolbar = new Toolbar(context);
				toolbar.AddView(new RadioButton(context));
				linearLayout.AddView(toolbar);

				*/

				//searchView.RemoveAllViews();
				//FormsTextView label = new FormsTextView(context);
				//label.Text = "holaaa";
				//searchView.AddView(label);

				// (Resource.Id.search_mag_icon); is wrong / Xammie bug

				//(icon as ImageView).SetImageResource(Resource.Drawable.search);

				//int cancelIconId = Context.Resources.GetIdentifier("android:id/search_close_btn", null, null);
				//var eicon = searchView.FindViewById(cancelIconId);
				//(eicon as ImageView).SetImageResource(Resource.Drawable.search);

				
				LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
				linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
				linearLayout = linearLayout.GetChildAt(1) as LinearLayout;

				linearLayout.Background = null; //removes underline

				AutoCompleteTextView textView = linearLayout.GetChildAt(0) as AutoCompleteTextView; //modify for text appearance customization
				
				int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
				icon = searchView.FindViewById(searchIconId);
				icon.Visibility = ViewStates.Invisible;
				icon.RemoveFromParent();

				var textView2Id = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
				var textView2 = (searchView.FindViewById(textView2Id) as EditText);
				if (textView == null) return;
				textView.SetTextColor(global::Android.Graphics.Color.Black);

				IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
				IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
				JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Layout.design_layout_tab_text); // replace 0 with a Resource.Drawable.my_cursor

				Android.Widget.Button buttonFilter = new Android.Widget.Button(context);
				//buttonFilter.SetBackgroundResource(Resource.Drawable.ic_filter_list_black_24dp);
				//buttonFilter.SetBackgroundColor(Android.Graphics.Color.Transparent);
				//Toolbar toolbar = new Toolbar(context); toolbar = (toolbar.FindViewById(Resource.Layout.Toolbar) as Toolbar);

				//linearLayout.AddView(buttonFilter); <! IMPORTANTE !>

				//var editViewId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
				//var editView = (searchView.FindViewById(editViewId) as )

				//LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
				//linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
				//linearLayout = linearLayout.GetChildAt(1) as LinearLayout;

				//AutoCompleteTextView textView = linearLayout.GetChildAt(0) as AutoCompleteTextView;
				//textView.SetTextColor(Android.Graphics.Color.Blue);


			}
			if (e.OldElement != null) { }
			if(e.NewElement != null) { }
			
			/*
			if (e.NewElement == null)
			{

				GradientDrawable gd = new GradientDrawable();
				gd.SetStroke(0, Android.Graphics.Color.Transparent);

				linearLayout.Background = gd;

				
				textView.SetBackgroundColor(Android.Graphics.Color.Red);

				//ImageView icon = linearLayout.GetChildAt(1) as ImageView;
				//icon.Visibility = ViewStates.Invisible;

			}
			*/
		}

	}
}