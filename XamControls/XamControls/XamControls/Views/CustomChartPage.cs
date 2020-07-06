using Refractored.FabControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamControls.Components.UpPopup.Types;
using XamControls.CustomCharts;

namespace XamControls.Views
{
    public class CustomChartPage : ContentPage
    {

        private StackLayout pageLayout;
        private AbsoluteLayout absolutelayout;
        private ListView lView;
        private MasterView _master;
        private FloatingActionButtonView floatingButton;
        private CustomCharts.Services.ChartController chartService;

        public CustomChartPage()
        {

            chartService = new CustomCharts.Services.ChartController();
            pageLayout = new StackLayout();
            absolutelayout = new AbsoluteLayout();
            lView = InitializeListView();
            floatingButton = InitializeFloatingButton();

            this.IconImageSource = new FileImageSource { File = "ic_pie_chart_black_24dp.png" };
            this.Title = "My Charts";
            this.Content = absolutelayout;

            UpdateLayout();
            AbsoluteLayout.SetLayoutFlags(pageLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(pageLayout, new Rectangle(0f, 0f, 1f, 1f));

            absolutelayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            absolutelayout.VerticalOptions = LayoutOptions.FillAndExpand;
            absolutelayout.Children.Add(pageLayout);
            absolutelayout.Children.Add(floatingButton);

            chartService.Charts.CollectionChanged += CollectionCustomChart_CollectionChanged;

        }

        #region PRIVATE

        private void UpdateLayout()
        {


            if (chartService.Charts.Count != 0 && !(pageLayout.Children[0] is ListView)) { pageLayout.Children.RemoveAt(0); pageLayout.Children.Add(lView); }
            else
            {
                if (pageLayout.Children.Count == 0)
                {
                    StackLayout layoutNotElements = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                    layoutNotElements.Children.Add(new Label() { Text = "Elements not found", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
                    pageLayout.Children.Add(layoutNotElements);
                }

            }

        }

        // Crea el listView y le añade las características básicas
        private ListView InitializeListView()
        {

            ListView listView = new ListView();

            listView.RowHeight = 100;
            listView.SeparatorVisibility = SeparatorVisibility.Default;
            ListViewCachingStrategy.RetainElement.Equals(listView);
            listView.ItemsSource = chartService.Charts;
            listView.ItemTemplate = ListView_ItemTemplate();
            listView.ItemTapped += LView_ItemTapped;
            listView.SeparatorColor = Color.FromRgb(170, 170, 170);
            listView.IsPullToRefreshEnabled = true;

            listView.HorizontalOptions = LayoutOptions.Fill;
            listView.VerticalOptions = LayoutOptions.FillAndExpand;

            return listView;

        }

        // Crea el floatingButton y le añade las características básicas
        private FloatingActionButtonView InitializeFloatingButton()
        {

            FloatingActionButtonView floatingButton = new FloatingActionButtonView();
            EntryPopup entryPopup = new EntryPopup();

            entryPopup.SetOnBackButtonPressed(floatingButton);
            entryPopup.SetOnAppearing(floatingButton);

            floatingButton.ColorNormal = Color.FromRgb(33, 150, 243);
            floatingButton.ColorPressed = floatingButton.ColorNormal.AddLuminosity(0.1);
            floatingButton.ColorRipple = floatingButton.ColorNormal.AddLuminosity(0.2);
            floatingButton.Clicked = (sender, args) =>
            {
                entryPopup.Display(chartService, _master.GetNavigationPage);
            };
            floatingButton.ImageName = "ic_add.png";
            AbsoluteLayout.SetLayoutFlags(floatingButton, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(floatingButton, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            return floatingButton;

        }

        /// <summary>
        /// Método que realiza lo necesario para añadir el chart creado al listView
        /// </summary>
        private void OnChartCreated()
        {

            UpdateLayout();
            NavigateTo(_master.GetNavigationPage, chartService.Charts[chartService.Charts.Count -1].ChartPage);
            lView.BeginRefresh();
            lView.EndRefresh();

        }

        /// <summary>
        /// Método que realiza lo necessario cuando actualizamos la configuración de algun chart
        /// </summary>
        private void OnChartUpdated()
        {



        }
        
        private DataTemplate ListView_ItemTemplate()
        {

            ViewCell vCell;
            StackLayout viewCellLayout;
            Grid gridPrincipal;
            Frame frameImage;
            Image imagenItem;
            Label labelTitle;
            Label labelDescription;
            Label labelDateCreated;

            DataTemplate dataTemplate = new DataTemplate(() =>
            {

                vCell = new ViewCell();
                viewCellLayout = new StackLayout();

                gridPrincipal = new Grid();

                frameImage = new Frame();
                imagenItem = new Image();
                labelTitle = new Label();
                labelDescription = new Label();
                labelDateCreated = new Label();

                // viewCell properties
                vCell.View = viewCellLayout;

                // Layout in viewCell
                viewCellLayout.Padding = new Thickness(0, 0, 0, 0);
                viewCellLayout.Orientation = StackOrientation.Horizontal;
                viewCellLayout.Children.Add(gridPrincipal);
                viewCellLayout.HeightRequest = 130;
                viewCellLayout.WidthRequest = 50;
                viewCellLayout.HorizontalOptions = LayoutOptions.FillAndExpand;

                // "Grid" principal
                gridPrincipal.WidthRequest = 200;
                gridPrincipal.HeightRequest = 100;
                gridPrincipal.VerticalOptions = LayoutOptions.StartAndExpand;
                gridPrincipal.HorizontalOptions = LayoutOptions.FillAndExpand;
                gridPrincipal.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.40, GridUnitType.Star) });
                gridPrincipal.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.60, GridUnitType.Star) });
                gridPrincipal.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                gridPrincipal.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
                gridPrincipal.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });

                // Frame to imageItem

                frameImage.CornerRadius = 90;
                frameImage.Margin = new Thickness(10, 5, 0, 5);
                frameImage.Padding = new Thickness(0, 0, 0, 30);
                frameImage.IsClippedToBounds = true;
                frameImage.Content = imagenItem;
                frameImage.HasShadow = false;
                frameImage.WidthRequest = 100;
                frameImage.HeightRequest = 100;
                frameImage.HorizontalOptions = LayoutOptions.StartAndExpand;
                frameImage.VerticalOptions = LayoutOptions.FillAndExpand;

                // ImageView to display in left site
                imagenItem.SetBinding(Image.SourceProperty, "ImageSource");
                imagenItem.WidthRequest = 300;
                imagenItem.HeightRequest = 100;
                imagenItem.HorizontalOptions = LayoutOptions.FillAndExpand;
                imagenItem.VerticalOptions = LayoutOptions.FillAndExpand;

                // Title label
                labelTitle.SetBinding(Label.TextProperty, "Name");
                labelTitle.FontSize = 17;
                labelTitle.VerticalOptions = LayoutOptions.Center;
                labelTitle.HorizontalOptions = LayoutOptions.FillAndExpand;
                labelTitle.HorizontalTextAlignment = TextAlignment.Start;
                labelTitle.TextColor = Color.Black;
                labelTitle.Margin = new Thickness(0, 7, 0, 0);

                // Description label
                labelDescription.SetBinding(Label.TextProperty, "Description");
                labelDescription.FontSize = 14;
                labelDescription.VerticalOptions = LayoutOptions.Start;
                labelDescription.HorizontalOptions = LayoutOptions.FillAndExpand;
                labelDescription.HorizontalTextAlignment = TextAlignment.Start;
                labelDescription.TextColor = Color.FromRgb(100, 100, 100);
                labelDescription.Margin = new Thickness(0, 3, 0, 3);

                // DateCreated label
                labelDateCreated.SetBinding(Label.TextProperty, "DateCreated");
                labelDateCreated.FontSize = 11;
                labelDateCreated.VerticalOptions = LayoutOptions.Center;
                labelDateCreated.HorizontalOptions = LayoutOptions.End;
                labelDateCreated.TextColor = Color.FromRgb(120, 120, 120);
                labelDateCreated.Margin = new Thickness(0, 0, 5, 0);

                // Añadir contenido al grid
                gridPrincipal.Children.Add(frameImage, 0, 0);
                gridPrincipal.Children.Add(labelTitle, 1, 0);
                gridPrincipal.Children.Add(labelDescription, 1, 1);
                gridPrincipal.Children.Add(labelDateCreated, 2, 0);
                gridPrincipal.RowSpacing = 5;
                gridPrincipal.ColumnSpacing = 10;
                gridPrincipal.BackgroundColor = Color.White;
                Grid.SetRowSpan(frameImage, 2);

                // Refresh
                lView.IsPullToRefreshEnabled = false;
                lView.Refreshing += RefreshlViewAsync;

                // Devuelve la Cell
                return vCell;

            });

            return dataTemplate;

        }

        private void NavigateTo(CustomNavigationPage navPage, Page page)
        {

            navPage.PushAsync(page);

        }

        #endregion

        #region EVENTS

        // Cuando hay modificaciones de la lista de Charts, este evento se activa
        private void CollectionCustomChart_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            OnChartCreated();

        }

        // Refresca el listView con los nuevos elementos de la collection
        private void RefreshlViewAsync(object sender, EventArgs e)
        {

            lView.ItemTemplate = ListView_ItemTemplate();

        }

        // Navega hacia una nueva página cuando haces click en un elemento
        private void LView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            CustomChart selectedItem = lView.SelectedItem as CustomChart;

            selectedItem.ChartPage.NavigationPage = _master.GetNavigationPage;
            _master.GetNavigationPage.PushAsync(selectedItem.ChartPage);

        }

        #endregion

        #region PROPERTIES

        public MasterView SetMaster
        {

            set { _master = value; }

        }

        #endregion PROPERTIES

        #region OVERRIDE

        // Evento al entrar en esta view
        protected override void OnAppearing()
        {

            lView.BeginRefresh();
            lView.EndRefresh();

            base.OnAppearing();

            floatingButton.Show();

        }

        // Evento al salir de esta view
        protected override void OnDisappearing()
        {

            base.OnDisappearing();

            floatingButton.Hide();

        }

        #endregion

    }

}
