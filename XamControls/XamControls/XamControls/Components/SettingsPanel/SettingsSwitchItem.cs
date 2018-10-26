using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.SettingsPanel
{
    public class SettingsSwitchItem : Switch
    {

                public bool firstTime = true;
                
				public SettingsSwitchItem()
				{

						this.IsToggled = false;

				}

    }
}
