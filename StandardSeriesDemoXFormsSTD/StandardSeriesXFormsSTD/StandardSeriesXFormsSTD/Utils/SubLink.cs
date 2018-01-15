using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
    public class SubLink : Button
    {
        public SubLink(string name)
        {
            Text = name;
            Command = new Command(o => App.MasterDetailPage.Detail.Navigation.PushAsync(new LinkPage(name)));
        }
    }
}
