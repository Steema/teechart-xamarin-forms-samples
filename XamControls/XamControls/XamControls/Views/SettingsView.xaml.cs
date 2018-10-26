using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamControls.Models;
using XamControls.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsView : ContentPage
	{

		SettingsView sView;
		public SettingsView(Item item)
		{

			BindingContext = this.sView = new SettingsView();
		}
		
		public SettingsView()
		{

			InitializeComponent();
			var item = new Item
			{

				Text = "Item 1",

			};
			sView = new SettingsView(item);
			BindingContext = sView;

		}

		async void Handle_CloseClickedAsync(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync(true);
		}
	}
}