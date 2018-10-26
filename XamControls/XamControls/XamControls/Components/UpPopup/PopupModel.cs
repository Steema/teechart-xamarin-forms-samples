using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.UpPopup
{
		public class PopupModel : PopupPage, IPopupModel
		{

				StackLayout _page;

				public void DefaultPopup()
				{

						_page = new StackLayout();

						this.Content = _page;
						
						_page.BackgroundColor = Xamarin.Forms.Color.White;
						LayoutBounds();

				}
				~PopupModel() { }

				public virtual void LayoutBounds()
				{

						_page.WidthRequest = 300;
						_page.HeightRequest = 200;
						_page.HorizontalOptions = LayoutOptions.Center;
						_page.VerticalOptions = LayoutOptions.Center;

				}

				/// <summary>
				/// Permite añadir una view al "Popup"
				/// </summary>
				/// <param name="view"></param>
				/// <returns></returns>
				public void AddView(View view)
				{

						_page.Children.Add(view);

				}

		}
}
