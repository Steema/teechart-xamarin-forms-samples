using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.CustomRenders;

namespace XamControls.Components.SettingsPanel
{
		public class SettingsSliderItem : SliderRenderer
		{

				public SettingsSliderItem()
				{

						this.Maximum = 100;
						this.Minimum = 0;
						this.Margin = 0;

				}

		}
}
