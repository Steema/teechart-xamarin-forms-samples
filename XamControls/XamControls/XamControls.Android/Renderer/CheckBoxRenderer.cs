using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.CustomRenders;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(CustomCheckBox), typeof(CheckBoxRenderer))]
namespace XamControls.Droid.Renderer
{
	public class CheckBoxRenderer : ButtonRenderer
	{

        public event EventHandler WasChecked;

        public CheckBoxRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			int f = 1;
			if (f == 1)
            {

                var control = new CheckBox(this.Context); control.SetHeight(control.Height + 10);
                (Element as CustomCheckBox).WasCheckedChanged = WasChecked;
                this.SetNativeControl(control);

            }
			else { var control = new RadioButton(this.Context); this.SetNativeControl(control); }

			base.OnElementChanged(e);

		}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if(e.PropertyName == "Checked")
            {

                if((Element as CustomCheckBox).Checked) { (Control as CheckBox).Checked = true; }
                else { (Control as CheckBox).Checked = false; }

            }

            base.OnElementPropertyChanged(sender, e);
        }

        public void Control_Checked(object sender, CompoundButton.CheckedChangeEventArgs e)
        {

            var wasChecked = WasChecked;
            if (wasChecked != null)
            {
                WasChecked(this, (CompoundButton.CheckedChangeEventArgs)EventArgs.Empty);
            }

        }

    }
}