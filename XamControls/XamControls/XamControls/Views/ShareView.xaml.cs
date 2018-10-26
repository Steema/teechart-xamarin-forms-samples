using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamControls.Views
{
	public partial class ShareView : ContentPage
	{
		public ShareView()
		{
			InitializeComponent();
		}

		async void Handle_CloseClickedAsync(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync(true);
		}
	}
}
