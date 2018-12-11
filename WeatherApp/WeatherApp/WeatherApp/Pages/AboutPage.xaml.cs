using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {

        private List<AboutUsListItems> _listItems;

        public AboutPage()
        {

            InitializeComponent();

            ICommand FacebookCommand = new Command(() => Device.OpenUri(new Uri("https://www.facebook.com/SteemaSoftware")));
            ICommand TwitterCommand = new Command(() => Device.OpenUri(new Uri("https://twitter.com/SteemaSoftware")));
            ICommand GoogPlusCommand = new Command(() => Device.OpenUri(new Uri("https://plus.google.com/+Steema")));
            ICommand LinkCommand = new Command(() => Device.OpenUri(new Uri("https://www.linkedin.com/company/steema-software")));
            ICommand YoutubeCommand = new Command(() => Device.OpenUri(new Uri("https://www.youtube.com/c/Steema")));
            ICommand GithubCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/Steema")));
            ICommand OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.steema.com")));

            if (Device.RuntimePlatform == Device.UWP)
            {

                _listItems = new List<AboutUsListItems>()
                {

                    new AboutUsListItems("Assets/ic_social_facebook.png", "Facebook", FacebookCommand),
                    new AboutUsListItems("Assets/ic_social_twitter.png", "Twitter", TwitterCommand),
                    new AboutUsListItems("Assets/ic_social_google_plus.png", "Google+", GoogPlusCommand),
                    new AboutUsListItems("Assets/ic_social_linkedin.png", "Linkedin", LinkCommand),
                    new AboutUsListItems("Assets/ic_social_youtube.png", "Youtube", YoutubeCommand),
                    new AboutUsListItems("Assets/ic_social_github.png", "Github", GithubCommand),
                    new AboutUsListItems("Assets/ic_social_web.png", "Web", OpenWebCommand),

                };

            }
            else
            { 

                _listItems = new List<AboutUsListItems>()
                {

                    new AboutUsListItems("ic_social_facebook.png", "Facebook", FacebookCommand),
                    new AboutUsListItems("ic_social_twitter.png", "Twitter", TwitterCommand),
                    new AboutUsListItems("ic_social_google_plus.png", "Google+", GoogPlusCommand),
                    new AboutUsListItems("ic_social_linkedin.png", "Linkedin", LinkCommand),
                    new AboutUsListItems("ic_social_youtube.png", "Youtube", YoutubeCommand),
                    new AboutUsListItems("ic_social_github.png", "Github", GithubCommand),
                    new AboutUsListItems("ic_social_web.png", "Web", OpenWebCommand),

                };

            }

            listView.ItemsSource = _listItems;

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if(e.SelectedItem != null) (e.SelectedItem as AboutUsListItems).Command.Execute(sender);

        }
    }

}