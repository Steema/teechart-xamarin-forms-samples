using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace WeatherApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.ButtonBackgroundColor = Windows.UI.ColorHelper.FromArgb(100, 17, 144, 249);
            titleBar.BackgroundColor = Windows.UI.ColorHelper.FromArgb(100, 17, 144, 249);

            this.InitializeComponent();

            LoadApplication(new WeatherApp.App());
        }

    }
}
