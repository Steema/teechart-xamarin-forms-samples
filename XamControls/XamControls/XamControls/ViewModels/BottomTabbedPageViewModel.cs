using Naxam.Controls.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.ViewModels
{
		public class BottomTabbedPageViewModel : BottomTabbedPage
        {

				public BottomTabbedPageViewModel()
				{

						if(Device.RuntimePlatform == Device.Android) NavigationPage.SetHasNavigationBar(this, false);
                        this.Title = "TeeChart DEMO";

				}

        }
}
