using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.CustomRenders
{
	public class CustomCheckBox : Button
	{

        public static readonly BindableProperty _Checked =
          BindableProperty.Create("Checked", typeof(bool), typeof(CustomCheckBox), false);

        public static BindableProperty _WasCheckedChanged =
            BindableProperty.Create("WasCheckedChanged", typeof(EventArgs), typeof(CustomCheckBox), null);

        public CustomCheckBox()
		{

			this.Text = "Default text";
            this.HorizontalOptions = LayoutOptions.Start;
            this.VerticalOptions = LayoutOptions.Center;

		}

        /// <summary>
        /// Checked propery for this view
        /// </summary>
        public bool Checked
        {
            get { return (bool)GetValue(_Checked); }
            set { SetValue(_Checked, value); }
        }

        public EventHandler WasCheckedChanged
        {

            get { return (EventHandler)GetValue(_WasCheckedChanged); }
            set { SetValue(_WasCheckedChanged, value); }

        }

    }
}
