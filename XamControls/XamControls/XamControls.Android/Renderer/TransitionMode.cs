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
using Xamarin.Forms.Platform.Android.AppCompat;
using XamControls.Droid.Renderer;
using XamControls.Services;
using System.ComponentModel;
using Android.Support.V4.App;
using Android;
using XamControls.Views;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Android.Support.Design.Widget;

[assembly: ExportRenderer(typeof(XamControls.Views.CustomNavigationPage), typeof(TransitionMode))]
namespace XamControls.Droid.Renderer
{
	public class TransitionMode : NavigationPageRenderer
	{
		private TransitionType _transitionType = TransitionType.Default;
		private Context context;
        private Android.Support.V7.Widget.Toolbar _toolbar;

		public TransitionMode(Context context) : base(context)
		{

			_transitionType = (TransitionType)CustomNavigationPage.TransitionTypeProperty.DefaultValue;
			this.context = context;

		}

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if(child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {

                _toolbar = (Android.Support.V7.Widget.Toolbar)child;

            }

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomNavigationPage.TransitionTypeProperty.PropertyName)
				UpdateTransitionType();
            if (e.PropertyName == CustomNavigationPage.ElevationProperty.PropertyName)
                UpdateElevation();
            if (e.PropertyName == CustomNavigationPage.BarVisibilityProperty.PropertyName)
                VisibilityBar();
		}

        private void UpdateElevation()
        {

            var customNavigationPage = (XamControls.Views.CustomNavigationPage)Element;
            _toolbar.Elevation = customNavigationPage.Elevation;

        }

        private void VisibilityBar()
        {

            bool valueVisibility = ((XamControls.Views.CustomNavigationPage)Element).BarVisivility;
            if(valueVisibility) this._toolbar.Visibility = ViewStates.Visible;
            else this._toolbar.Visibility = ViewStates.Invisible;

        }

        protected override void SetupPageTransition(AndroidX.Fragment.App.FragmentTransaction transaction, bool isPush)
		{
			switch (_transitionType)
			{
				case TransitionType.None:
					return;
				case TransitionType.Default:
					return;
				case TransitionType.Fade:
					if (isPush)
					{
						transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
																						Resource.Animation.enter_left, Resource.Animation.exit_right);
					}
					else
					{
						transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
																						Resource.Animation.enter_right, Resource.Animation.exit_left);
					}
					break;

				default:
					return;
			}
		}

		private void UpdateTransitionType()
		{
			var transitionNavigationPage = (XamControls.Views.CustomNavigationPage)Element;
			_transitionType = transitionNavigationPage.TransitionType;
		}

	}
}