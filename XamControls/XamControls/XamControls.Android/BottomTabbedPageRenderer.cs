using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamControls.CustomRenders;
using XamControls.Droid;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace XamControls.Droid
{
    public class BottomTabbedPageRenderer : TabbedPageRenderer
    {

        private Context _localContext;
        private ActionBar _actionBar;

        public BottomTabbedPageRenderer()
        {



        }

        public BottomTabbedPageRenderer(Context context) : base(context)
        {

            _localContext = context;

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {


            base.OnElementChanged(e);

        }



    }
}