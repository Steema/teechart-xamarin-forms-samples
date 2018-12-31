using XamControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamControls.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using XamControls.Views;
using XamControls.Services;
using XamControls.Utils;
using System.Text.RegularExpressions;

namespace XamControls.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {

        private ObservableCollection<GroupeditemsMasterViewModel> grouped { get; set; }

        private IEnumerable<Grouping<string, MasterViewMenuItem>> iEnumerableItems;
        public ListView lView = new ListView(ListViewCachingStrategy.RecycleElementAndDataTemplate);
		private MasterViewModel masterViewModel;

		// Constructor
		public MenuView()
		{

			InitializeComponent();

            // Main scrollView
            ScrollView mainScrollView = new ScrollView();
            mainScrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
            mainScrollView.VerticalOptions = LayoutOptions.FillAndExpand;

            // MainLayout in scrollView
            StackLayout mainLayout = new StackLayout();
            mainScrollView.Content = mainLayout;
            mainLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            mainLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            mainLayout.Spacing = 0;

            // HeaderMasterLayout
            StackLayout headerMasterLayout = new StackLayout();
            headerMasterLayout.BackgroundColor = Color.FromHex("4da6ff");
            headerMasterLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            headerMasterLayout.VerticalOptions = LayoutOptions.Start;
            headerMasterLayout.Margin = new Thickness(0, 0, 0, 0);
            headerMasterLayout.Padding = new Thickness(0, 0, 0, 10);
            headerMasterLayout.Spacing = 0;

            // HeaderMasterItems
            Image image = new Image();
            image.Source = ImageSource.FromFile("hamburgTitlePhoto.png");
            image.HeightRequest = 60;
            image.MinimumHeightRequest = 40;
            image.WidthRequest = 300;
            image.Margin = new Thickness(0, 20, 0, 20);

            Label labelDescripcio = new Label();
            labelDescripcio.HeightRequest = 100;
            labelDescripcio.MinimumHeightRequest = 80;
            labelDescripcio.Text = "This is a TeeChart DEMO which offers a series of components for different graphics oriented to sectors such as financial or statistical...";
            labelDescripcio.TextColor = Color.White;
            labelDescripcio.Margin = new Thickness(20, 0, 12, 0);
            labelDescripcio.FontSize = 14;
            labelDescripcio.HorizontalOptions = LayoutOptions.FillAndExpand;
            labelDescripcio.VerticalTextAlignment = TextAlignment.Center;
            labelDescripcio.HorizontalTextAlignment = TextAlignment.Start;

            headerMasterLayout.Children.Add(image);
            headerMasterLayout.Children.Add(labelDescripcio);

            //MasterListView
            StackLayout layoutMasterLView = new StackLayout();
            layoutMasterLView.BackgroundColor = Color.White;
            layoutMasterLView.Children.Add(lView);
            layoutMasterLView.Spacing = 0;
            layoutMasterLView.HorizontalOptions = LayoutOptions.FillAndExpand;
            layoutMasterLView.VerticalOptions = LayoutOptions.FillAndExpand;
            layoutMasterLView.Margin = new Thickness(0, 0, 0, 0);
            layoutMasterLView.Spacing = 0;

            grouped = new ObservableCollection<GroupeditemsMasterViewModel>();

            grouped = IniciListItems();

			// Propiedades del "listView"
			lView.SeparatorVisibility = SeparatorVisibility.None;
			lView.ItemsSource = grouped;
			lView.IsGroupingEnabled = true;
			lView.GroupDisplayBinding = new Binding("groupName");
			//lView.GroupShortNameBinding = new Binding("shortName");
			//lView.ItemTapped += MarcarPage;
            ContentTemplate();

            // Añadir elementos al grid principal
            mainLayout.Children.Add(headerMasterLayout);
            mainLayout.Children.Add(layoutMasterLView);

            this.Content = mainLayout;
		}

        // Crear "Cells" de la información necesaria
        private void ContentTemplate()
        {              

            lView.ItemTemplate = new DataTemplate(() =>
            {

				Grid grid = new Grid();
				Image image = new Image();
				Label label = new Label();
				ViewCell vCell = new ViewCell();
				StackLayout viewStackLayout = new StackLayout();
				StackLayout viewStackLayout2 = new StackLayout();

				grid.Padding = new Thickness(15, 10, 0, 10);
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.8, GridUnitType.Star) });
				grid.SetBinding(BackgroundColorProperty, "BackgroundColor");

                image.SetBinding(Image.SourceProperty, "ImageSource");

                label.TextColor = Color.Black;
                label.FontAttributes = FontAttributes.Bold;
                label.FontSize = 14;
                label.SetBinding(Label.TextProperty, "Title");
                if (Device.RuntimePlatform == Device.iOS) label.Margin = new Thickness(0, 4, 0, 0);

                grid.Children.Add(image, 0, 0);
                grid.Children.Add(label, 1, 0);

                // Creación de la "viewCell" y devolverla

                vCell.View = grid;
                viewStackLayout.Padding = new Thickness(0, 0);
                viewStackLayout.Orientation = StackOrientation.Horizontal;
                viewStackLayout.Children.Add(viewStackLayout2);
                viewStackLayout2.VerticalOptions = LayoutOptions.Center;
                viewStackLayout2.Spacing = 0;
                viewStackLayout2.Children.Add(grid);

                // Devuelve la Cell
                return vCell;

            });
		}

        // Inicialización de la lista para el "listView"
        private ObservableCollection<GroupeditemsMasterViewModel> IniciListItems()
		{

			masterViewModel = new MasterViewModel();
			return masterViewModel.GetMenuItems;

		}

		// Propiedad para obtener "ListItems"
		public IEnumerable<Grouping<string, MasterViewMenuItem>> GetSetListItems { get { return iEnumerableItems; } set { iEnumerableItems = value; } }


    }
}