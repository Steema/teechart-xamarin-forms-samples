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

                // ** Obsoleto
                private IEnumerable<Grouping<string, MasterViewMenuItem>> iEnumerableItems;
				//private List<Grouping<string, MasterViewMenuItem>> listItems;
                // **
                public ListView lView = new ListView(ListViewCachingStrategy.RecycleElementAndDataTemplate);
				private MasterViewModel masterViewModel;

				// Constructor
				public MenuView()
				{

					InitializeComponent();

					// Inicializar variables
                    Grid grid = new Grid();
                    StackLayout sLayoutSuper = new StackLayout();
                    Image image = new Image();
                    Label labelDescripcio = new Label();
                    StackLayout sLayoutlView = new StackLayout();
                    grouped = new ObservableCollection<GroupeditemsMasterViewModel>();

                    grouped = IniciListItems();

                    // Definir grid principal
                    grid.RowSpacing = 0;
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.32, GridUnitType.Star) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.68, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

					// Layout de la imagen y la descripción
                    sLayoutSuper.BackgroundColor = Color.FromHex("4da6ff");
                    sLayoutSuper.HorizontalOptions = LayoutOptions.FillAndExpand;
					sLayoutSuper.VerticalOptions = LayoutOptions.FillAndExpand;
                    sLayoutSuper.MinimumHeightRequest = 160;
                    sLayoutSuper.Margin = new Thickness(0, 0, 0, 0);
                    sLayoutSuper.Padding = new Thickness(0, 0, 0, 10);
                    sLayoutSuper.Spacing = 0;
                    sLayoutSuper.Children.Add(image);
                    sLayoutSuper.Children.Add(labelDescripcio);

					// Propiedades imagen
                    image.Source = ImageSource.FromFile("hamburgTitlePhoto.png");
                    image.HeightRequest = 60;
                    image.MinimumHeightRequest = 40;
                    image.WidthRequest = 300;
                    image.Margin = new Thickness(0, 20, 0, 20);

					// Propiedades descripción
                    labelDescripcio.HeightRequest = 100;
                    labelDescripcio.MinimumHeightRequest = 80;
                    labelDescripcio.Text = "This is a TeeChart DEMO which offers a series of components for different graphics oriented to sectors such as financial or statistical...";
                    labelDescripcio.TextColor = Color.White;
                    labelDescripcio.Margin = new Thickness(20, 0, 12, 0);
					labelDescripcio.FontSize = 14;
					labelDescripcio.HorizontalOptions = LayoutOptions.FillAndExpand;
					labelDescripcio.VerticalTextAlignment = TextAlignment.Center;
					labelDescripcio.HorizontalTextAlignment = TextAlignment.Start;

					// Layout del "listView" del menú
                    sLayoutlView.BackgroundColor = Color.White;
                    sLayoutlView.HeightRequest = 330;
					sLayoutlView.Children.Add(lView);
                    sLayoutlView.Spacing = 0;

					// Propiedades del "listView"
					lView.SeparatorVisibility = SeparatorVisibility.None;
					lView.ItemsSource = grouped;
					lView.IsGroupingEnabled = true;
					lView.GroupDisplayBinding = new Binding("groupName");
					//lView.GroupShortNameBinding = new Binding("shortName");
					//lView.ItemTapped += MarcarPage;
                    ContentTemplate();

					// Añadir elementos al grid principal
					grid.Children.Add(sLayoutSuper, 0, 0);
					grid.Children.Add(sLayoutlView, 0, 1);

                    this.Content = grid;

				}

                /*
				// Acción que marca la página en la que te encuentras
				private void MarcarPage(object sender, ItemTappedEventArgs e)
				{
		
					int valorActualTop = -1;
					int valorActualUnder = -1;
					bool trobat = false;
						
					while (valorActualTop < listItems.Count() - 1 && !trobat)
					{

							valorActualTop++;

							while (valorActualUnder < listItems[valorActualTop].Count - 1 && !trobat)
							{

									valorActualUnder++;
									if (listItems[valorActualTop][valorActualUnder] == e.Item) { trobat = true; }
										

							}

							valorActualUnder = 0;

					}

					if (!(listItems[valorActualTop][valorActualUnder].Id == 1 || listItems[valorActualTop][valorActualUnder].Id == 2 || listItems[valorActualTop][valorActualUnder].Id == 3))
					{

							ShowTransparent();
							if (listItems[valorActualTop][valorActualUnder] == e.Item) { listItems[valorActualTop][valorActualUnder].BackgroundColor = Color.FromRgb(238, 238, 238); }
							ContentTemplate();

					}
						
				}
                */
        /*

        // Acción que desmarca las páginas
        private void ShowTransparent()
        {

            for (int i = 0; i < listItems.Count(); i++)
            {

                    for (int b = 0; b < listItems[i].Count; b++)
                    {

                        listItems[i][b].BackgroundColor = Color.Transparent;

                    }

            }

        }
        */

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

				/*
                async void DisplayQRShareCode(object sender, System.EventArgs e)
				{

						await Navigation.PushModalAsync(new ShareView(), true);

				}
				*/

				// Propiedad para obtener "ListItems"
				public IEnumerable<Grouping<string, MasterViewMenuItem>> GetSetListItems { get { return iEnumerableItems; } set { iEnumerableItems = value; } }


    }
}