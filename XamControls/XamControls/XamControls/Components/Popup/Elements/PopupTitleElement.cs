using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.Popup.Elements
{
    public class PopupTitleElement : Label
    {

				public PopupTitleElement()
				{

						this.Text = "Title Popup";
						this.FontSize = 20;
						this.HorizontalOptions = LayoutOptions.StartAndExpand;
						this.VerticalOptions = LayoutOptions.Center;
						this.HorizontalTextAlignment = TextAlignment.Start;
						this.VerticalTextAlignment = TextAlignment.Center;

				}


		}

}
