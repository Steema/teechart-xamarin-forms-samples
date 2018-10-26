using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Components.Popup.Elements;
using XamControls.Components.Popup.Views;

namespace XamControls.Components.Popup.Styles
{
		public class PopupBasicStyle : PopupBaseLayout
    {

				private Label _titlePopup;
				private ScrollView _scrollViewContent;
				private Label _labelDescription;
				private Button _okButton;

				public PopupBasicStyle()
				{

						_titlePopup = new PopupTitleElement();
						_scrollViewContent = new ScrollView();
						_labelDescription = new Label();
						_okButton = new Button() { HorizontalOptions = LayoutOptions.End };

						_scrollViewContent.Content = _labelDescription;

						this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.2, GridUnitType.Star) });
						this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
						this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.2, GridUnitType.Star) });
						this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

						this.Children.Add(_titlePopup, 0, 0);
						this.Children.Add(_scrollViewContent, 0, 1);
						this.Children.Add(_okButton, 0, 2);

						_okButton.Clicked += OkButton_Clicked;

				}

				// Evento al hacer "click" en el okButton
				private void OkButton_Clicked(object sender, EventArgs e)
				{

						PopupNavigation.Instance.PopAsync();

				}

				public String Title
				{

						get { return _titlePopup.Text; }
						set { _titlePopup.Text = value; }

				}

		}
}
