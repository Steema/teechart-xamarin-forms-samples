using StandardSeriesXFormsSTD.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StandardSeriesXFormsSTD
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage;
        public App()
        {
            InitializeComponent();

            var detail = new NavigationPage(new Home());
           // detail.BarBackgroundColor = Color.FromRgb(199, 221, 241);            

            var nav = detail.Navigation;

            MasterDetailPage = new MasterDetailPage
            {
                Master = new MenuPage(),
                Detail = detail,                
            };

            MainPage = MasterDetailPage;

        }
    }
}
