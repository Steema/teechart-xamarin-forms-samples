using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StandardSeriesXFormsSTD
{
    public class LinkPage : ContentPage
    {
        public LinkPage(string name)
        {
            Title = name;
            Content = new StackLayout
            {
                Children = {
                new SubLink(name + ".1"),
                new SubLink(name + ".2"),
                new SubLink(name + ".3"),
            },
            };
        }
    }
}
