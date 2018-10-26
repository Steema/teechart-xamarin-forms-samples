using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Components.Popup.Enums;
using XamControls.Components.Popup.Styles;
using XamControls.Components.Popup.Views;

namespace XamControls.Components.Styles
{
		public class BaseStyles
    {

				private PopupViewStyle _popupStyle;
	
				private PopupBasicStyle _popupBasicStyle;
				private PopupCheckPickerStyle _popupCheckPickerStyle;
				private PopupRadioPickerStyle _popupRadioPickerStyle;

				public BaseStyles() {
			
						_popupStyle = PopupViewStyle.Basic;
						UpdateStyle();						
			
				}

				// Elimina el layout anterior
				private void ClearLastLayout()
				{

						if(_popupBasicStyle != null) { _popupBasicStyle = null; }
						else if(_popupCheckPickerStyle != null) { _popupCheckPickerStyle = null; }
						else { _popupRadioPickerStyle = null; }

				}

				// Actualiza el style del popup según el nuevo valor
				private void UpdateStyle()
				{

					switch(_popupStyle)
					{

						case PopupViewStyle.Basic:
							_popupBasicStyle = new PopupBasicStyle();
							break;

						case PopupViewStyle.CheckPicker:
							_popupCheckPickerStyle = new PopupCheckPickerStyle();
							break;

						case PopupViewStyle.RadioPicker:
							_popupRadioPickerStyle = new PopupRadioPickerStyle();
							break;

					}

				}

				/// <summary>
				/// Actualiza el style del popup
				/// </summary>
				public PopupViewStyle InternalPopupStyle
				{

						get { return _popupStyle; }
						set { ClearLastLayout(); _popupStyle = value; UpdateStyle(); }

				}

				public PopupBasicStyle Element
				{

						get { return _popupBasicStyle; }

				}

		}
}
