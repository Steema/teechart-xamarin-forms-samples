using Steema.TeeChart.Styles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Components.SettingsPanel.DataStore;

namespace XamControls.Components.SettingsPanel.BaseComponent
{
    public class SettingsPanel : ScrollView
    {

				private StackLayout settingsPanel;
				private ArrayList contentRoot;
				private DataStore.DataStore data;
				
				public SettingsPanel()
				{

						settingsPanel = new StackLayout();
						contentRoot = new ArrayList();
						data = new DataStore.DataStore();
						
						this.Margin = 0;
						this.Padding = 0;
						this.WidthRequest = 300;
						this.HorizontalOptions = LayoutOptions.FillAndExpand;
						this.VerticalOptions = LayoutOptions.FillAndExpand;
						this.Content = settingsPanel;

						settingsPanel.Margin = new Thickness(0, 15, 0, 0);
						settingsPanel.Padding = 0;
						settingsPanel.HorizontalOptions = LayoutOptions.FillAndExpand;
						settingsPanel.VerticalOptions = LayoutOptions.FillAndExpand;
			
				}

				// Establece unas propiedades básicas para todos los elementos
				private void VisualStackLayout(StackLayout stackLayout)
				{

						stackLayout.Margin = 0;
						//stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
						//stackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
						stackLayout.Margin = new Thickness(0, 5, 0, 10);

				}

				/// <summary>
				/// Permite añadir una barra de separación en el inferior del item
				/// </summary>
				/// <param name="stackLayout"></param>
				/// <param name="separation"></param>
				public void AddSeparation(StackLayout stackLayout, bool separation)
				{

						if(separation) { stackLayout.Children.Add(new StackLayout() { BackgroundColor = Color.FromRgb(200, 200, 200), HorizontalOptions = LayoutOptions.FillAndExpand, WidthRequest = 100, HeightRequest = 1, Margin = new Thickness(0, 5, 0, 4) }); }

				}

				// Elimina todos los elementos del componente
				private void RemoveAllChildren()
				{

						for(int i = 0; i < contentRoot.Count; i++) { settingsPanel.Children.RemoveAt(i); }

				}

				/// <summary>
				/// Actualitza la lista de elementos que se encuentran en el componente
				/// </summary>
				public void Repaint()
				{

						if(settingsPanel.Children.Count != 0) { RemoveAllChildren(); }

						for (int i = 0; i < contentRoot.Count; i++) { settingsPanel.Children.Add((StackLayout)contentRoot[i]); }

				}

				/// <summary>
				/// Permite obtener el "Array" donde se encuentran todos los "stackLayouts"
				/// </summary>
				public ArrayList SeeChildren { get { return contentRoot; } }

				/// <summary>
				/// Permite añadir un nuevo "stackLayout" al componente
				/// </summary>
				public StackLayout AddChildren
				{

						set
						{

							VisualStackLayout(value);
							contentRoot.Add(value);

						}

				}

				/// <summary>
				/// Devuelve una instancia de DataStore
				/// </summary>
				public new DataStore.DataStore Children
				{

						get { return data; }

				}

		}

}
