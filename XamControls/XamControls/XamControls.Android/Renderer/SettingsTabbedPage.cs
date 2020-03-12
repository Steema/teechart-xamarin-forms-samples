using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.CustomCharts.Settings;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomChartSettingsPage), typeof(SettingsTabbedPage))]
namespace XamControls.Droid.Renderer
{
    
    public class SettingsTabbedPage : Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer
    {

        private TabLayout TabsLayout { get; set; }
        private AndroidX.ViewPager.Widget.ViewPager PagerLayout { get; set; }
        private TabbedPage CurrentTabbedPage { get; set; }


        public SettingsTabbedPage(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {

            base.OnElementChanged(e);

            /*
            if (e.OldElement != null)
            {
                //cleanup here
            }

            if (e.NewElement != null)
            {

                CurrentTabbedPage = (TabbedPage)e.NewElement;

            }
            else
                

            //find the pager and tabs
            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if (view is TabLayout)
                    TabsLayout = (TabLayout)view;
                else
                if (view is ViewPager) PagerLayout = (ViewPager)view;

            }
        */
        }
        /*
        protected override void OnLayout(bool changed, int l, int t, int r, int b)    
        {
            TabsLayout.Visibility = ViewStates.Gone;

            base.OnLayout(changed, l, t, r, b);
        }
        */

        public override void OnViewAdded(Android.Views.View child)
        {

            base.OnViewAdded(child);

            var tabLayout = child as TabLayout;
            if (tabLayout != null)
            {
                tabLayout.TabMode = TabLayout.ModeScrollable;
            }

        }

    }
}