using System;
using System.Windows.Input;

using Xamarin.Forms;
using XamControls.ViewModels.Base;

namespace XamControls.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.steema.com")));
						FacebookCommand = new Command(() => Device.OpenUri(new Uri("https://www.facebook.com/SteemaSoftware")));
						TwitterCommand = new Command(() => Device.OpenUri(new Uri("https://twitter.com/SteemaSoftware")));
						GoogPlusCommand = new Command(() => Device.OpenUri(new Uri("https://plus.google.com/+Steema")));
						LinkCommand = new Command(() => Device.OpenUri(new Uri("https://www.linkedin.com/company/steema-software")));

		}

        public ICommand OpenWebCommand { get; }
		public ICommand FacebookCommand { get; }
		public ICommand TwitterCommand { get; }
		public ICommand GoogPlusCommand { get; }
		public ICommand LinkCommand { get; }

	}
}