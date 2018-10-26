using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		public Label Content { get; internal set; }
	}
}