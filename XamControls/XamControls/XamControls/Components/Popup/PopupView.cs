using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.Components.Popup.Enums;
using XamControls.Components.Popup.Styles;
using XamControls.Components.Popup.Views;
using XamControls.Components.Styles;

namespace XamControls.Components.Popup
{
		public class PopupView : PopupPage
    {

				private BaseStyles _popupBaseStyles;

				public PopupView()
				{

					InitializePopupPage();
					_popupBaseStyles = new BaseStyles();

					this.Content = _popupBaseStyles.Element;

				}

				private void InitializePopupPage()
				{

						

				}

				/// <summary>
				/// Muestra el popup
				/// </summary>
				public void Show()
				{

					PopupNavigation.Instance.PushAsync(this);

				}

				/// <summary>
				/// Permite modificar el style del popup
				/// </summary>
				public PopupViewStyle PopupStyle
				{

					get { return _popupBaseStyles.InternalPopupStyle; }
					set { _popupBaseStyles.InternalPopupStyle = value; }

				}

				public List<PopupBaseLayout> Element
				{

						get { return new List<PopupBaseLayout> { _popupBaseStyles.Element }; }

				}

		}
}
