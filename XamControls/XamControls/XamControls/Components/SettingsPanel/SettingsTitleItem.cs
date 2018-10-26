using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.SettingsPanel
{
		public class SettingsTitleItem : Label
		{

				public SettingsTitleItem()
				{

						this.FontSize = 17;
						this.HorizontalTextAlignment = TextAlignment.Start;
						this.TextColor = Color.Black;
						this.Margin = new Thickness(0, 0, 0, 5);

				}
		}
}
