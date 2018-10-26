using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.CustomRenders;
using XamControls.Utils;

namespace XamControls.Components.SettingsPanel
{
		public class SettingsItem : StackLayout
		{

			private Grid gridPosition;
			private Button btnEntryType;

			public SettingsItem(TypeItemsGrid typeGrid)
			{

					this.gridPosition = new Grid();
					this.HorizontalOptions = LayoutOptions.FillAndExpand;
					this.VerticalOptions = LayoutOptions.FillAndExpand;
					this.Children.Add(gridPosition);

					gridPosition.Margin = new Thickness(15, 10, 15, 0);
					gridPosition.ColumnSpacing = 0;
					gridPosition.RowSpacing = 6;
					gridPosition.VerticalOptions = LayoutOptions.FillAndExpand;
					CrearGrid(typeGrid);

			}

			/*
			public async void OnClickItem(SettingsItem item)
			{

					Color firstColor = item.BackgroundColor;

					Task.WaitAll();

					await Task.WhenAll(
							item.ColorTo(item.BackgroundColor, Color.FromRgb(200,200,200), c => item.BackgroundColor = c, 80));

					await Task.WhenAll(
							item.ColorTo(item.BackgroundColor, firstColor, c => item.BackgroundColor = c, 80));

			}
			*/

			private void CrearGrid(TypeItemsGrid typeGrid)
			{

					switch (typeGrid)
					{

						case TypeItemsGrid.Slider:

							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.15, GridUnitType.Auto) });
							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.22, GridUnitType.Auto) });
							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.30, GridUnitType.Auto) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.85, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
							gridPosition.Children.Add(new SettingsTitleItem() { Text = "Title Text" }, 0, 0);
							gridPosition.Children.Add(new SettingsDetailItem() { Text = "Detail Text" }, 0, 1);
							gridPosition.Children.Add(new Label() { Text = "Value Slider", TextColor = Color.FromRgb(33, 150, 244), VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 1, 2);
							break;

						case TypeItemsGrid.Switch:

							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.1, GridUnitType.Auto) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
							gridPosition.Children.Add(new SettingsTitleItem() { Text = "Title Text" }, 0, 0);
							break;

						case TypeItemsGrid.Entry:

							btnEntryType = new Button();
							btnEntryType.Text = "Update";
							btnEntryType.IsVisible = false;

							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.2, GridUnitType.Auto) });
							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.3, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.65, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.35, GridUnitType.Star) });
							gridPosition.Children.Add(new SettingsTitleItem() { Text = "Title Text" }, 0, 0);
							gridPosition.Children.Add(btnEntryType, 1, 1 );
							//Grid.SetRowSpan(btnEntryType, 2)
							break;

						case TypeItemsGrid.Button:
							gridPosition.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
							gridPosition.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
							gridPosition.Children.Add(new SettingsTitleItem() { Text = "Title Text" }, 0, 0);
							gridPosition.Children.Add(new Label() { Text = "Option selected", TextColor = Color.FromRgb(33, 150, 244), VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }, 2, 0);
							break;

					}

			}

			/// <summary>
			/// Permite añadir un ItemView
			/// </summary>
			public SliderRenderer AddChildrenSlider { set { gridPosition.Children.Add(value, 0, 2); } }
			/// <summary>
			/// Permite añadir un SwitchView
			/// </summary>
			public Switch AddChildrenSwitch { set { gridPosition.Children.Add(value, 1, 0); } }
			/// <summary>
			/// Permite añadir una EntryView
			/// </summary>			
			public Entry AddChildrenEntry { set { gridPosition.Children.Add(value, 0, 1); } }
			/// <summary>
			/// Permite añadir un PickerView
			/// </summary>
			public Picker AddChildrenPicker { set { gridPosition.Children.Add(value, 1, 0); } }
			
			/// <summary>
			/// Permite modificar el ButtonView del modo Entry
			/// </summary>
			public Button GetButtonEntry { get { return btnEntryType; } }
			/// <summary>
			/// Permite añadir un TitleText
			/// </summary>
			public String TitleText { set { ((SettingsTitleItem)gridPosition.Children[0]).Text = value; } }
			/// <summary>
			/// Permite añadir un DetailText
			/// </summary>
			public String DetailText { set { ((SettingsDetailItem)gridPosition.Children[1]).Text = value; } }
			/// <summary>
			/// Permite modificar el valor del label referente al slider
			/// </summary>
			public String ValueItemText {

					set {

							if (gridPosition.Children[2] is Label) { ((Label)gridPosition.Children[2]).Text = value; }
							else { ((Label)gridPosition.Children[1]).Text = value; }

						}

			}
			/// <summary>
			/// Permite saber si el switch está toogled
			/// </summary>
			public Boolean isToogled { set { ((SettingsSwitchItem)gridPosition.Children[1]).IsToggled = value; } }

		}
}
