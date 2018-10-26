using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.CustomRenders;
using XamControls.Models;
using XamControls.Utils;
using XamControls.Views;

namespace XamControls.ViewModels
{
    public class NavigationBarViewModel : StackLayout
    {

        Grid gridMenu;
        Button btnMasterMenu;
        Button btnSearch;
        Button volverAtrasSearch;
        Label labelTitle;
        CustomSearchBar sBar;
        Frame frame;

        MasterView master;
        ListView lView;
        List<ItemsListView> ListItems;

        public NavigationBarViewModel(ListView lView, List<ItemsListView> ListItems, MasterView master)
        {

            this.lView = lView;
            this.ListItems = ListItems;
            this.master = master;

            gridMenu = new Grid();
            labelTitle = new Label();
            sBar = new CustomSearchBar();
            volverAtrasSearch = new Button();
            frame = new Frame();

            frame.Content = gridMenu;
            frame.BackgroundColor = Color.Transparent;
            frame.CornerRadius = 0;
            frame.Margin = 0;
            frame.BorderColor = Color.Transparent;
            frame.Padding = 0;
            frame.HasShadow = true;

            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.18, GridUnitType.Star) });
            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.66, GridUnitType.Star) });
            gridMenu.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.18, GridUnitType.Star) });
            gridMenu.RowDefinitions.Add(new RowDefinition { Height = 56 });
            gridMenu.Margin = 0;

            // Propiedades searchBar
            sBar.IsVisible = false;
            sBar.Placeholder = "Search in TeeChart";
            sBar.TextChanged += sBar_TextChanged;
            sBar.TextColor = Color.FromRgb(80, 80, 80);
            sBar.PlaceholderColor = Color.FromRgb(90, 90, 90);
            sBar.WidthRequest = 500;
            sBar.BackgroundColor = Color.Transparent;
            sBar.CancelButtonColor = Color.FromRgb(110, 110, 110);
            sBar.HorizontalOptions = LayoutOptions.FillAndExpand;
            sBar.VerticalOptions = LayoutOptions.FillAndExpand;
            sBar.FontSize = 15.5;
            gridMenu.Children.Add(sBar, 1, 0);

            // Button "volverAtrasSearch"
            volverAtrasSearch = new Button();
            volverAtrasSearch.Image = "ic_arrow_back_black_24dp.png";
            volverAtrasSearch.Clicked += AtrasSearch_Clicked;
            volverAtrasSearch.BackgroundColor = Color.Transparent;
            volverAtrasSearch.VerticalOptions = LayoutOptions.Center;
            volverAtrasSearch.HorizontalOptions = LayoutOptions.Center;
            volverAtrasSearch.IsVisible = false;
            volverAtrasSearch.CornerRadius = 90;
            volverAtrasSearch.WidthRequest = 35;
            volverAtrasSearch.HeightRequest = 35;

            volverAtrasSearch.Pressed += volverAtrasSearch_Pressed;
            volverAtrasSearch.Released += volverAtrasSearch_Released;

            gridMenu.Children.Add(volverAtrasSearch, 0, 0);

            gridMenu.Children.Add(labelTitle, 1, 0);

            InicialitzarBar();
            AñadirMasterMenuButton();
            AñadirSearchButton();
            this.Children.Add(frame);
            labelTitle.Text = "TeeChart DEMO";
            labelTitle.FontSize = 16.5;
            labelTitle.FontAttributes = FontAttributes.Bold;
            labelTitle.TextColor = Color.White;
            labelTitle.VerticalOptions = LayoutOptions.Center;
            labelTitle.HorizontalTextAlignment = TextAlignment.Start;
            labelTitle.Margin = new Thickness(9, 0, 0, 0);
            labelTitle.VerticalTextAlignment = TextAlignment.Center;

        }

        private void volverAtrasSearch_Released(object sender, EventArgs e)
        {

            volverAtrasSearch.BackgroundColor = Color.Transparent;

        }

        private void volverAtrasSearch_Pressed(object sender, EventArgs e)
        {

            volverAtrasSearch.BackgroundColor = Color.FromRgb(245, 245, 245);

        }

        private async void AtrasSearch_Clicked(object sender, EventArgs e)
        {

            btnMasterMenu.IsVisible = true;
            btnSearch.IsVisible = true;
            labelTitle.IsVisible = true;
            volverAtrasSearch.IsVisible = false;
            sBar.IsVisible = false;
            sBar.Text = "";
            gridMenu.ColumnDefinitions.ElementAt(2).Width = new GridLength(0.18, GridUnitType.Star);
            //this.BackgroundColor = Color.FromRgb(33, 150, 243);
            await Task.WhenAll(
                frame.ColorTo(Color.White, Color.FromRgb(33, 150, 243), c => frame.BackgroundColor = c, 130));

        }

        private void InicialitzarBar()
        {

            this.BackgroundColor = Color.FromRgb(33, 150, 243);
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.HeightRequest = 56;

        }

        private void AñadirMasterMenuButton()
        {

            btnMasterMenu = new Button();
            btnMasterMenu.IsVisible = true;
            btnMasterMenu.Image = "ic_menu_white_24dp.png";
            btnMasterMenu.BackgroundColor = Color.Transparent;
            btnMasterMenu.BorderColor = Color.Transparent;
            btnMasterMenu.HorizontalOptions = LayoutOptions.Center;
            btnMasterMenu.VerticalOptions = LayoutOptions.Center;
            btnMasterMenu.CornerRadius = 90;
            btnMasterMenu.WidthRequest = 35;
            btnMasterMenu.HeightRequest = 35;

            btnMasterMenu.Clicked += BtnMasterMenu_Clicked;
            btnMasterMenu.Pressed += BtnMasterMenu_Pressed;
            btnMasterMenu.Released += BtnMasterMenu_Released;
            gridMenu.Children.Add(btnMasterMenu, 0, 0);

        }

        private void BtnMasterMenu_Released(object sender, EventArgs e)
        {

            btnMasterMenu.BackgroundColor = Color.Transparent;

        }

        private void BtnMasterMenu_Pressed(object sender, EventArgs e)
        {

            btnMasterMenu.BackgroundColor = Color.FromRgb(57, 162, 245);

        }

        private void BtnMasterMenu_Clicked(object sender, EventArgs e)
        {

            if (master.IsPresented) { master.IsPresented = false; }
            else { master.IsPresented = true; }

        }

        private void AñadirSearchButton()
        {

            btnSearch = new Button();
            btnSearch.IsVisible = true;
            btnSearch.Image = "search.png";
            btnSearch.BackgroundColor = Color.Transparent;
            btnSearch.BorderColor = Color.Transparent;
            btnSearch.HorizontalOptions = LayoutOptions.Center;
            btnSearch.VerticalOptions = LayoutOptions.Center;
            btnSearch.CornerRadius = 90;
            btnSearch.WidthRequest = 40;
            btnSearch.HeightRequest = 40;

            btnSearch.Clicked += btnSearch_Clicked;
            btnSearch.Pressed += btnSearch_Pressed;
            btnSearch.Released += btnSearch_Released;
            gridMenu.Children.Add(btnSearch, 2, 0);

        }

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {

            sBar.IsVisible = true;
            labelTitle.IsVisible = false;
            btnSearch.IsVisible = false;
            volverAtrasSearch.IsVisible = true;
            btnMasterMenu.IsVisible = false;
            btnSearch.BackgroundColor = Color.Transparent;
            btnSearch.BorderColor = Color.Transparent;
            btnMasterMenu.BackgroundColor = Color.Transparent;
            btnMasterMenu.BorderColor = Color.Transparent;
            volverAtrasSearch.VerticalOptions = LayoutOptions.Center;
            gridMenu.ColumnDefinitions.ElementAt(2).Width = 0;
            gridMenu.ColumnSpacing = 0;
            sBar.Focus();
            //await frame.FadeTo(90, 250, Easing.BounceIn);
            await Task.WhenAll(
                frame.ColorTo(Color.FromRgb(33, 150, 243), Color.White, c => frame.BackgroundColor = c, 130));

        }

        private void btnSearch_Released(object sender, EventArgs e)
        {

            btnSearch.BackgroundColor = Color.Transparent;

        }

        private void btnSearch_Pressed(object sender, EventArgs e)
        {

            btnSearch.BackgroundColor = Color.FromRgb(57, 162, 245);

        }

        // Buscador que funciona cada vez que modificamos el texto
        private void sBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                lView.ItemsSource = ListItems;
            }

            else
            {
                lView.ItemsSource = ListItems.Where(x => x.Nom.ToUpper().Contains(e.NewTextValue.ToUpper()));
            }
        }

        public MasterView SetMasterView { set { master = value; } }

		}
}
