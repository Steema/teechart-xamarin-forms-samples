using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.PCL.Models;
using XamControls.PCL.ViewModels;

namespace XamControls.PCL.Pages
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            // initialize viewModel and bind it to page
            _mainPageViewModel = new MainPageViewModel();
            InitializeComponent();
            BindingContext = _mainPageViewModel;
            // set visual elements in page
            SetUpPage();
        }

        private void SetUpPage()
        {
            switch(Device.RuntimePlatform)
            {
                case Device.Android:
                    SetUpAndroidPage();
                    break;
                case Device.iOS:
                    SetUpIosPage();
                    break;
                case Device.UWP:
                    SetUpUWPPage();
                    break;
            }
        }        

        void SetUpAndroidPage()
        {
            
        }

        void SetUpIosPage()
        {

        }

        void SetUpUWPPage()
        {

        }

        /// <summary> UWP - 
        /// Navigate to series page. Pass item selected and restart listview item selected
        /// </summary>
        /// <param name="sender">ListView</param>
        /// <param name="e">Event args</param>
        async void LstViewSeriesGroups_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SeriesGroupItem item = (e.Item as SeriesGroupItem);
            SeriesPage seriesPage = new SeriesPage(item);
            await Navigation.PushAsync(seriesPage);
            // Unselect item
            lstViewSeriesGroups.SelectedItem = -1;
        }

        /// <summary> ANDROID & IOS - 
        /// Navigate to series page. Pass item selected and restart item selected in collection view
        /// </summary>
        /// <param name="sender">CollectionView</param>
        /// <param name="e">Event args</param>
        async void ColViewSeriesGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colViewSeriesGroup.SelectedItem != null)
            {
                SeriesGroupItem item = (e.CurrentSelection[0] as SeriesGroupItem);
                SeriesPage seriesPage = new SeriesPage(item);
                await Navigation.PushAsync(seriesPage);
                // unselect item
                colViewSeriesGroup.SelectedItem = null;
            }
        }
    }
}
