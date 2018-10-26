using Steema.TeeChart;
using Steema.TeeChart.Themes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Services.Gesture.Swipe.Views
{
    public class LabelSwipe : Label
    {

				private Chart theChart;

				public LabelSwipe()
				{ 

						FontSize = 25;
						VerticalOptions = LayoutOptions.FillAndExpand;
						HorizontalOptions = LayoutOptions.FillAndExpand;
						VerticalTextAlignment = TextAlignment.Center;
						HorizontalTextAlignment = TextAlignment.Center;
						Text = "This is a textView";
						TextColor = Color.Black;
						BackgroundColor = Color.White;

				}

				public bool GoNext { get; set; }
				public bool GoLast { get; set; }
				public Chart GetChart { get; set; }


    }
}
