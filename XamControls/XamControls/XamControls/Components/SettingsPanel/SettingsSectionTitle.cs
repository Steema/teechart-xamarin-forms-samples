using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.SettingsPanel
{
		public class SettingsSectionTitle : Label
		{

				public SettingsSectionTitle()
				{

						this.HorizontalTextAlignment = TextAlignment.Start;
						this.TextColor = Color.FromRgb(30, 110, 240);
						this.FontSize = 15;
						this.Margin = new Thickness(15, 0, 0, 0);
						//this.BackgroundColor = Color.Pink;

				}

		}
}
