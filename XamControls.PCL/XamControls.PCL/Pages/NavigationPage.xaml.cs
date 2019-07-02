using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamControls.PCL.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPage : Xamarin.Forms.NavigationPage
    {
        public NavigationPage()
        {
            InitializeComponent();
        }
        public NavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }

    }
}