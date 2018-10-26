using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Views;
using XamControls.ViewModels.Base;
using XamControls.CustomRenders;

namespace XamControls.ViewModels
{
			public class MenuInferior : StackLayout
			{

				private readonly int cantidadButtons;
				private StackLayout sLMenuInferior;
				private Frame frame;
				private ScrollView scrollView;
				private string[] nomButtonsMenu;
				private Button[] buttonsMenu;
				private Button selectedButton;

				public MenuInferior(string[] nomButtons)
				{

					sLMenuInferior = new StackLayout();
					frame = new Frame();
					scrollView = new ScrollView();

					this.cantidadButtons = nomButtons.Length;
					this.nomButtonsMenu = nomButtons;
					buttonsMenu = new Button[cantidadButtons];
					nomButtonsMenu = nomButtons;

					InicialitzarMenuInferior();

				}
				private void InicialitzarMenuInferior()
				{

					// "StackLayout" del menú inferior
					sLMenuInferior.Orientation = StackOrientation.Horizontal;
					sLMenuInferior.BackgroundColor = Color.FromRgb(225, 225, 225);
					sLMenuInferior.Padding = 10;
					sLMenuInferior.Margin = 0;
					sLMenuInferior.VerticalOptions = LayoutOptions.EndAndExpand;

					// "Frame" del menú inferior
					frame.Content = sLMenuInferior;
                    frame.Padding = new Thickness(0, 1, 0, 0);
					frame.Margin = 0;
					frame.BorderColor = Color.FromRgb(180, 180, 180);
					frame.VerticalOptions = LayoutOptions.EndAndExpand;

					// "Scroll" del menú inferior
					scrollView.Orientation = ScrollOrientation.Horizontal;
					scrollView.VerticalOptions = LayoutOptions.EndAndExpand;
					scrollView.Content = frame;
					scrollView.Margin = 0;

					CrearButtons(sLMenuInferior);

				}

				// Acción que añade los botones al menú inferior
				private void CrearButtons(StackLayout sL)
				{

					Button buttonMenuInferior = null;

					for (int i = 0; i < cantidadButtons; i++)
					{

						CreacioButton(sL, nomButtonsMenu[i], buttonMenuInferior, i);

					}
					for (int i = 0; i < buttonsMenu.Length; i++)
					{

						sL.Children.Add(buttonsMenu[i]);

					}
					buttonsMenu[0].TextColor = Color.FromRgb(60, 100, 220);
					BtnSelected();

				}

				// Acción que establece las propiedades y crea el botón
				private void CreacioButton(StackLayout sL, string nomButton, Button buttonActual, int posActual)
				{

					buttonActual = new Button();

					buttonActual.BackgroundColor = Color.FromRgb(225, 225, 225);

                    if (App.ScreenHeight < 600) buttonActual.FontSize = 11;
                    else if (App.ScreenHeight < 500) buttonActual.FontSize = 10;
                    else buttonActual.FontSize = 13;

                    buttonActual.Text = nomButton;
					buttonActual.BorderColor = Color.FromRgb(210, 210, 210);
					buttonActual.TextColor = Color.Black;

					buttonsMenu[posActual] = buttonActual;

				}

				// Acción que emite la señal para no tener un btn seleccionado
				public void CleanColorButtons()
				{

					LimpiarColorButtonsMenu();

				}

				// Acción que elimina "ColorText" del btn actual
				private void LimpiarColorButtonsMenu()
				{

					BtnSelected();

					selectedButton.TextColor = Color.Black;

				}

				// Acción que determina el btn seleccionado actualmente

				private void BtnSelected()
				{

					int posicioActual = 0;

					while (posicioActual < buttonsMenu.Length && buttonsMenu[posicioActual].TextColor != Color.FromRgb(60, 100, 220))
					{

						posicioActual++;

					}

					selectedButton = buttonsMenu[posicioActual];


				}

				// Método público que determina el btn seleccionado y actualiza algunas configuraciones
				public void BtnSelected(ChartTabPage tabPage)
				{

					BtnSelected();

					UpdateScrollTabPage(tabPage);

				}

				// Método público que determina el btn seleccionado
				public void BtnSelected(ContentPage contentPage)
				{

					BtnSelected();

				}

				private void UpdateScrollTabPage(ChartTabPage tabPage)
				{

						if (selectedButton.Text == "Interpolating Line" || selectedButton.Text == "Zoom & Panning") { Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(tabPage.On<Xamarin.Forms.PlatformConfiguration.Android>(), false); }
						else { Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(tabPage.On<Xamarin.Forms.PlatformConfiguration.Android>(), true); }

				}

		

				// Propiedad que devuelve el "scrollView"
				public ScrollView GetScrollView { get { return scrollView; } }
				// Propiedad que devuelve todos los botones
				public Button[] GetButtons { get { return buttonsMenu; } }
				// Propiedad que devuelve el botón seleccionado
				public Button GetSelectedButton { get { return selectedButton; } }
				// Propiedad que devuelve el nombre de los botones
				public String[] GetNomButtons { get { return nomButtonsMenu; } }

	}
}
