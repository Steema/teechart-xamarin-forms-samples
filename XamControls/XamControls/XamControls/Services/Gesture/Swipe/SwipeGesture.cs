using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamControls.ViewModels.Base;

namespace XamControls.Services.Gesture.Swipe
{
    public class SwipeGesture
    {

				public SwipeGesture(Label label) {

						var tapGestureRecognizer = new TapGestureRecognizer();
						tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
						label.GestureRecognizers.Add(tapGestureRecognizer);

				}

				private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
				{
					
						

				}

		}
}
