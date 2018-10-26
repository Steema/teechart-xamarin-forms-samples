using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.CustomCharts;
using XamControls.CustomCharts.Settings;

namespace XamControls.Views
{
    public class CustomChartView : ContentPage
    {

        private CustomChart _chart;
        private CustomNavigationPage _navPage;
        private CustomChartSettingsPage _customChartSettingsPage;

        public CustomChartView(CustomChart chart, CustomNavigationPage navPage)
        {

            this.Content = chart.ChartView;
            this.Title = chart.Name;
            this._chart = chart;
            this._navPage = navPage;
            this._customChartSettingsPage = new CustomChartSettingsPage(_chart, _navPage);
            InitializeToolbarItems();
            
        }

        private void InitializeToolbarItems()
        {

            ToolbarItem optionsItem = new ToolbarItem();

            optionsItem.Icon = "ic_build_white_24dp.png";
            optionsItem.Text = "Settings";
            optionsItem.Clicked += OptionsItem_Clicked;

            this.ToolbarItems.Add(optionsItem);

        }

        private void OptionsItem_Clicked(object sender, EventArgs e)
        {

            _navPage.PushAsync(_customChartSettingsPage);

        }

        public CustomNavigationPage NavigationPage
        {

            get { return _navPage; }
            set { _navPage = value; }

        }

        protected override void OnAppearing()
        {

            _navPage.BarBackgroundColor = Color.FromRgb(33, 150, 243);
            _navPage.BarTextColor = Color.White;
            _navPage.BarVisivility = true;
            _navPage.Elevation = 8;

            RepaintValues();

            base.OnAppearing();
        }

        private void RepaintValues()
        {

            if (_chart.Name != this.Title) this.Title = _chart.Name;

        }
    }
}
