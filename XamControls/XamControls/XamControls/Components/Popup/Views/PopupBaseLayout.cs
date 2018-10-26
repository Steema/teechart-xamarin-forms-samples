using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;
using XamControls.Components.Popup.Enums;
using XamControls.Components.Popup.Styles;

namespace XamControls.Components.Popup.Views
{
    public class PopupBaseLayout : Grid
    {

				public PopupBaseLayout()
				{

						CreatePattern();

				}

				private void CreatePattern()
				{

						this.BackgroundColor = Color.White;
						this.HorizontalOptions = LayoutOptions.Center;
						this.VerticalOptions = LayoutOptions.Center;
						this.HeightRequest = 300;
						this.WidthRequest = 300;

				}

		}
}
