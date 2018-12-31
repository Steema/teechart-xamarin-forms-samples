using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System.Collections;
using XamControls.Variables;
using XamControls.Components;
using XamControls.Components.SettingsPanel;
using XamControls.Components.SettingsPanel.BaseComponent;
using XamControls.Charts.Standard;
using System.Runtime.CompilerServices;
using XamControls.Charts.Linear_Gauge;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;
using XamControls.Services.Share;
using XamControls.Views;

namespace XamControls.ViewModels
{
    public class ChartSettingsViewModel : ContentPage
	{

		private SettingsPanel settingsPanelComponent;
		private ChartView chart;
		private string titleChart;
		private Variables.Variables var;

		// Arrays
		private PointerStyles[] pointerStyles;
		private LegendAlignments[] legendAlignments;
		private string[] selectAxis;

		// Sections
		private StackLayout seriesSection = new StackLayout();
		private StackLayout axesSection = new StackLayout();
		private StackLayout legendSection = new StackLayout();
		private StackLayout shareSection = new StackLayout();

		// Series Title Section
		private SettingsSectionTitle seriesTitleSection;

		// Series
		private SettingsItem settingSeriesValues = new SettingsItem(TypeItemsGrid.Slider);
		private SettingsItem settingSeriesMarks = new SettingsItem(TypeItemsGrid.Switch);
		private SettingsItem settingSeriesTitle = new SettingsItem(TypeItemsGrid.Entry);
		private SettingsItem settingItemHandStyle = new SettingsItem(TypeItemsGrid.Button);
        private SettingsItem settingSeries3D = new SettingsItem(TypeItemsGrid.Switch);

		// Series Views
		private SettingsSliderItem sliderValues = new SettingsSliderItem();
		private SettingsSwitchItem switchMarks = new SettingsSwitchItem();
		private Picker picker = new Picker();
		private List<PointerStyles> itemsPickerHand = new List<PointerStyles>();
        private SettingsSwitchItem switch3D = new SettingsSwitchItem();

		// Axes Title Section
		private SettingsSectionTitle axesTitleSection = new SettingsSectionTitle();

		// Axes
		private SettingsItem settingAxesSelect = new SettingsItem(TypeItemsGrid.Button);
		private SettingsItem settingAxesVisible = new SettingsItem(TypeItemsGrid.Switch);
		private SettingsItem settingAxesInverted = new SettingsItem(TypeItemsGrid.Switch);
		private SettingsItem settingAxesGrid = new SettingsItem(TypeItemsGrid.Switch);

		// Axes Views
		private Picker pickerSelectAxes = new Picker();
		private SettingsSwitchItem switchVisibleAxes = new SettingsSwitchItem();
		private SettingsSwitchItem switchInvertedAxes = new SettingsSwitchItem();
		private SettingsSwitchItem switchGridAxes = new SettingsSwitchItem();

		// Legend Title Section
		private SettingsSectionTitle legendTitleSection = new SettingsSectionTitle();

		// Legend
		private SettingsItem settingLegendItem1 = new SettingsItem(TypeItemsGrid.Switch);
		private SettingsItem settingLegendItem2 = new SettingsItem(TypeItemsGrid.Button);

		// Legend Views
		private SettingsSwitchItem switchLegendVisible = new SettingsSwitchItem();
		private Picker pickerLegendPosition = new Picker();
		private List<LegendAlignments> itemsPickerLegendAlignments = new List<LegendAlignments>();

		// Share Title Section
		private SettingsSectionTitle shareTitleSection = new SettingsSectionTitle();

		// Share
		private SettingsItem settingShareItem1 = new SettingsItem(TypeItemsGrid.Button);

				

		public ChartSettingsViewModel(ChartView chart, string titleChart)
		{
				this.chart = chart;
				this.titleChart = titleChart;
				settingsPanelComponent = new SettingsPanel();
				var = new Variables.Variables();

				/*
				tView.Root = tRoot1;
				tView.Intent = TableIntent.Settings;
				TableSection tSection1 = new TableSection();
				tRoot1.Add(tSection1);
				tRoot1.Title = "Hola";
				tSection1.Title = "Display mode";
						
				SwitchCell cell1 = new SwitchCell();
				var lPicker = new List<string>();
				lPicker.Add("None");
				lPicker.Add("Stack");
				lPicker.Add("Stack 100%");
				lPicker.Add("Overlap");
				Picker picker = new Picker();
				picker.Title = "Display:";
				StackLayout layoutPicker = new StackLayout();
				layoutPicker.Children.Add(new Label { Text = "Display:", });
				layoutPicker.Children.Add(picker);
				picker.ItemsSource = lPicker;
				tSection1.Add(cell1);
						
				cell1.Text = "Show Marks";
				cell1.On = false;
				SwitchCell cell2 = new SwitchCell();
				tSection1.Add(cell2);
				cell2.Text = "Show Marks";
				cell2.On = false;
				cell1.OnChanged += cell1_onChanged;

				ViewCell vCell = new ViewCell();
				vCell.View = layoutPicker;
				tSection1.Add(vCell);
				vCell.Height = 100;
				*/

				CrearSettings();
                switchMarks.firstTime = true;



        }

		private Entry entryTitle;
		private void CrearSettings()
		{

				// Declarar variables
						
				settingItemHandStyle = new SettingsItem(TypeItemsGrid.Button);
				switchMarks = new SettingsSwitchItem();
				picker = new Picker();
				itemsPickerHand = new List<PointerStyles>();

				// Sections Propiedades
				seriesSection.VerticalOptions = LayoutOptions.FillAndExpand;

				// Creación de las Sections
				ItemsForEachChart();

				// Vuelve a pintar el componente con las nuevas Sections
				settingsPanelComponent.Repaint();

				switch(titleChart) {

						case "Line":
						case "Column Bar":
						case "Area":
						case "Pie":
						case "Fast Line":
						case "Horizontal Line":
						case "Horizontal Area":
						case "Horizontal Bar":
						case "Donut":
						case "Bubble":
						case "Shape":
						case "Gantt":
						case "Point/Scatter":
						case "Interpolating Line":
						case "Bar Styles":
						case "Zoom & Panning":
						case "Bar Gradient":
						case "Bubble Transparent":
						case "Real Time":
						case "Stack Area":
						case "Multiple Pies":
						case "Semi-Pie":
						case "Semi-Donut":
							break;

						case "Circular Gauge":
						case "Car Fuel":
						case "Custom Hand":
						case "Acceleration":
						case "Knob Gauge":
						case "Temperature Knob":
						case "Compass":
						case "Linear Gauge":
						case "Scales":
						case "SubLines":
						case "Mobile Battery":
						// Series
						if (chart.Chart.Series[0] is CircularGauge)
						{
								settingSeriesMarks.isToogled = ((CircularGauge)chart.Chart.Series[0]).Axis.Labels.Visible;
								sliderValues.Maximum = ((CircularGauge)chart.Chart.Series[0]).Maximum;
								sliderValues.Minimum = ((CircularGauge)chart.Chart.Series[0]).Minimum;
								sliderValues.Value = Math.Round(((CircularGauge)chart.Chart.Series[0]).Value,2);
						}
						else if (chart.Chart.Series[0] is KnobGauge)
						{

								settingSeriesMarks.isToogled = ((KnobGauge)chart.Chart.Series[0]).Axis.Labels.Visible;
								sliderValues.Maximum = ((KnobGauge)chart.Chart.Series[0]).Maximum;
								sliderValues.Minimum = ((KnobGauge)chart.Chart.Series[0]).Minimum;
								sliderValues.Value = Math.Round(((KnobGauge)chart.Chart.Series[0]).Value, 2);

						}
						else if (chart.Chart.Series[0] is LinearGauge)
						{

								settingSeriesMarks.isToogled = ((LinearGauge)chart.Chart.Series[0]).Marks.Visible;
								sliderValues.Maximum = ((LinearGauge)chart.Chart.Series[0]).Maximum;
								sliderValues.Minimum = ((LinearGauge)chart.Chart.Series[0]).Minimum;

								if (titleChart != "Mobile Battery") {

										sliderValues.Value = Math.Round(((LinearGauge)chart.Chart.Series[0]).Value,2);

								}
								else {

										sliderValues.Value = Math.Round(100 - ((LinearGauge)chart.Chart.Series[0]).Value,2);

								}

						}
							sliderValues.ValueChanged += SliderValues_ValueChanged;
							settingSeriesValues.ValueItemText = sliderValues.Value.ToString();

							if(titleChart == "Custom Hand") {

									settingsPanelComponent.AddSeparation(seriesSection, true);
									seriesSection.Children.Add(settingItemHandStyle);

									settingItemHandStyle.TitleText = "Hand Style";
									settingItemHandStyle.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => FocusPicker_OnClick(settingItemHandStyle, picker)) });
									settingItemHandStyle.AddChildrenPicker = picker;
									picker.IsVisible = false;

									pointerStyles = (PointerStyles[])MyConvert.ToArray("PointerStyles");

									for (int i = 0; i < pointerStyles.Length; i++) { if (i != 2 && i != 3 && i != 6 && i != 11 && i != 13 && i != 12 && i != 14) { itemsPickerHand.Add(pointerStyles[i]); } }

									picker.Title = "Select a style hand";

									picker.ItemsSource = itemsPickerHand;
									picker.SelectedItem = (PointerStyles)((CircularGauge)(chart.Chart.Series[0])).Hand.Style.Value;
									picker.SelectedIndexChanged += PickerHand_SelectedIndexChanged;
									settingItemHandStyle.ValueItemText = picker.SelectedItem.ToString();

							}
							break;

				}

		}

		// Crea y muestra los elementos necessarios según el tipo de chart
		private void ItemsForEachChart()
		{

				switch(titleChart)
				{

						case "Line": case "Column Bar": case "Area": case "Pie": case "Horizontal Bar": case "Horizontal Line": case "Donut": case "Bubble":
                        case "Zoom & Panning": case "Bar Gradient": case "Bubble Transparent": case "Stack Area":
						case "Semi-Pie": case "Semi-Donut": case "Radar": case "Candle": case "Error": case "ErrorBar":
                        case "Smith": case "Bezier": case "Speed Time": case "Volume": case "Polar Bar": case "Map GIS": case "World Map":

                            CrearSeriesSection(0, true);
							CrearAxesSection();
							CrearLegendSection();
							break;

                        case "Shape": case "Point/Scatter": case "Fast Line": case "Interpolating Line": case "Pyramid": case "Inverted Pyramid":
                        case "Percent Change":

                            CrearSeriesSection(2, true);
                            CrearAxesSection();
                            CrearLegendSection();
                            break;

                        case "Horizontal Area": case "Gantt": case "Bar Styles": case "Multiple Pies": case "Arrow": case "Polar":
                        case "Point&Figure": case "Histogram": case "Horizontal Histogram": case "Funnel": case "BoxPlot": case "HighLow":
                        
                            CrearSeriesSection(0, false);
                            CrearAxesSection();
                            CrearLegendSection();
                            break;

                        case "Real Time":

                            CrearSeriesSection(2, false);
                            CrearAxesSection();
                            CrearLegendSection();
                            break;

                        case "KnobGauge": case "Temperature Knob": case "Linear Gauge": case "Scales": case "Sublines":

                            CrearSeriesSection(1, false);
                            break;

                        case "Organizational Chart": case "Custom Elements":

                            CrearSeriesSection(2, false);
                            break;

                        case "TreeMap": case "TagCloud": case "Numeric Gauge": case "Digital Gauge": case "Basic Calendar": case "Special Dates":
                        case "Add Events":

                            break;

                        case "Add": case "Subtract": case "Multiply": case "Divide": case "Count": case "Average": case "High": case "Low": case "Median Function":
                        case "ADX": case "AC": case "Alligator": case "AO": case "ATR": case "Bollinger Bands": case "CCI": case "CLV":
                        case "Compression OHLC": case "Exp. Average": case "Exp. Moving Average": case "Gator Oscillator": case "Kurtosis": case "MACD": case "Momentum":
                        case "Momentum Div.": case "Money Flow": case "OBV": case "PVO": case "RSI": case "RVI": case "Slope": case "Smoothed Mov Avg": case "S.A.R.":
                        case "Cross Point": case "Correlation": case "Cumulative": case "Custom Function": case "Exponential Trend": case "Fitting Linearizable":
                        case "Performance": case "Perimeter": case "Finding Coefficients": case "Down Sampling": case "RMS": case "Smoothing Function":
                        case "Standard Deviation": case "Trendline": case "Variance": case "SPC": case "Data Histogram": case "Cumulative Histogram": case "Skewness":

                            CrearSeriesSection(0, true);
                            CrearAxesSection();
                            CrearLegendSection();
                            break;

						case "Acceleration": case "Compass": case "Mobile Battery":

							CrearSeriesSection(3, false);
							break;

						default:

							CrearSeriesSection(1, false);
							break;

				}
				//CrearShareSection();

		}

		// Crea una series section
		private void CrearSeriesSection(int valueAboutSlider, bool is3D)
		{

			// Elementos de la Section
			seriesSection = new StackLayout();
			seriesTitleSection = new SettingsSectionTitle();
			settingSeriesValues = new SettingsItem(TypeItemsGrid.Slider);
			settingSeriesMarks = new SettingsItem(TypeItemsGrid.Switch);
			settingSeriesTitle = new SettingsItem(TypeItemsGrid.Entry);
            settingSeries3D = new SettingsItem(TypeItemsGrid.Switch);
			sliderValues = new SettingsSliderItem();
			entryTitle = new Entry();
            switch3D = new SettingsSwitchItem();

			// Add Section
			settingsPanelComponent.AddChildren = seriesSection;

			// Series
			seriesTitleSection.Text = "Series";
			seriesSection.Children.Add(seriesTitleSection);

			if(valueAboutSlider != 3) {

					if (valueAboutSlider == 1)
					{

						seriesSection.Children.Add(settingSeriesValues);
						settingSeriesValues.TitleText = "Values";
						settingSeriesValues.DetailText = "Change the values from this chart";
						settingSeriesValues.AddChildrenSlider = sliderValues;
						settingsPanelComponent.AddSeparation(seriesSection, true);

					}

					if (valueAboutSlider != 2)
					{

						seriesSection.Children.Add(settingSeriesMarks);
						settingsPanelComponent.AddSeparation(seriesSection, true);

					}
			}

            seriesSection.Children.Add(settingSeriesTitle);

            //settingSeriesValues.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => settingSeriesValues.OnClickItem(settingSeriesValues)) });

            settingSeriesMarks.TitleText = "Marks";
            settingSeriesMarks.AddChildrenSwitch = switchMarks;
            settingSeriesMarks.isToogled = chart.Chart.Series[0].Marks.Visible;
            switchMarks.Toggled += SwitchMarks_Toggled;

			settingSeriesTitle.TitleText = "Title";
			settingSeriesTitle.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => SettingItem3_Clicked(settingSeriesTitle)) });
			settingSeriesTitle.AddChildrenEntry = entryTitle;
			settingSeriesTitle.GetButtonEntry.Clicked += GetButtonEntry_Clicked;
			entryTitle.IsVisible = false;

            if (is3D)
            {

                //settingsPanelComponent.AddSeparation(seriesSection, true);

                settingSeries3D.TitleText = "3D View";
                settingSeries3D.AddChildrenSwitch = switch3D;
                settingSeries3D.isToogled = chart.Chart.Aspect.View3D;
                switch3D.Toggled += Switch3D_Toggled;

                //seriesSection.Children.Add(settingSeries3D);

            }

		}

		// Crea una axes section
		private void CrearAxesSection()
		{

				// Elementos de la Section
				axesSection = new StackLayout();
				axesTitleSection = new SettingsSectionTitle();
				settingAxesSelect = new SettingsItem(TypeItemsGrid.Button);
				settingAxesVisible = new SettingsItem(TypeItemsGrid.Switch);
				settingAxesInverted = new SettingsItem(TypeItemsGrid.Switch);
				settingAxesGrid = new SettingsItem(TypeItemsGrid.Switch);
				pickerSelectAxes = new Picker();
				switchVisibleAxes = new SettingsSwitchItem();
				switchInvertedAxes = new SettingsSwitchItem();
				switchGridAxes = new SettingsSwitchItem();

				// Add Section
				settingsPanelComponent.AddChildren = axesSection;

				// Axes
				axesTitleSection.Text = "Axes";
				axesSection.Children.Add(axesTitleSection);
				axesSection.Children.Add(settingAxesSelect);
				settingsPanelComponent.AddSeparation(axesSection, true);
				axesSection.Children.Add(settingAxesVisible);
				settingsPanelComponent.AddSeparation(axesSection, true);
				axesSection.Children.Add(settingAxesInverted);
				settingsPanelComponent.AddSeparation(axesSection, true);
				axesSection.Children.Add(settingAxesGrid);

				settingAxesSelect.TitleText = "Axis";
				settingAxesSelect.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => FocusPicker_OnClick(settingAxesSelect, pickerSelectAxes)) });
				settingAxesSelect.AddChildrenPicker = pickerSelectAxes;
				pickerSelectAxes.IsVisible = false;

				selectAxis = new string[6] { "Left", "Right", "Top", "Bottom", "Depth", "Depth Top" };

				pickerSelectAxes.Title = "Axis";
				pickerSelectAxes.ItemsSource = selectAxis;
				pickerSelectAxes.SelectedItem = selectAxis[0];
				pickerSelectAxes.SelectedIndexChanged += PickerAxis_SelectedIndexChanged;

				settingAxesVisible.TitleText = "Visible";
				settingAxesVisible.AddChildrenSwitch = switchVisibleAxes;
				settingAxesVisible.isToogled = chart.Chart.Axes.Left.Visible;
				switchVisibleAxes.Toggled += SwitchVisibleAxis_Toggled;

				settingAxesInverted.TitleText = "Inverted";
				settingAxesInverted.AddChildrenSwitch = switchInvertedAxes;
				settingAxesInverted.isToogled = chart.Chart.Axes.Left.Inverted;
				switchInvertedAxes.Toggled += SwitchInvertedAxes_Toggled;

				settingAxesGrid.TitleText = "Grid";
				settingAxesGrid.AddChildrenSwitch = switchGridAxes;
				settingAxesGrid.isToogled = chart.Chart.Axes.Left.Grid.Visible;
				switchGridAxes.Toggled += SwitchGridAxes_Toggled;

				axisSelected = chart.Chart.Axes.Left;
				settingAxesSelect.ValueItemText = pickerSelectAxes.SelectedItem.ToString();

		}

		// Crear una legend section
		private void CrearLegendSection()
		{

				// Elementos de la Section
				legendSection = new StackLayout();
				legendTitleSection = new SettingsSectionTitle();
				settingLegendItem1 = new SettingsItem(TypeItemsGrid.Switch);
				settingLegendItem2 = new SettingsItem(TypeItemsGrid.Button);
				switchLegendVisible = new SettingsSwitchItem();
				pickerLegendPosition = new Picker();
				itemsPickerLegendAlignments = new List<LegendAlignments>();

				// Add Section
				settingsPanelComponent.AddChildren = legendSection;

				// Legend
				legendTitleSection.Text = "Legend";
				legendSection.Children.Add(legendTitleSection);
				legendSection.Children.Add(settingLegendItem1);
				settingsPanelComponent.AddSeparation(legendSection, true);
				legendSection.Children.Add(settingLegendItem2);

				settingLegendItem1.TitleText = "Visible";
				settingLegendItem1.AddChildrenSwitch = switchLegendVisible;
				settingLegendItem1.isToogled = chart.Chart.Legend.Visible;
				switchLegendVisible.Toggled += SwitchLegendVisible_Toggled;

				settingLegendItem2.TitleText = "Position";
				settingLegendItem2.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => FocusPicker_OnClick(settingLegendItem2, pickerLegendPosition)) });
				settingLegendItem2.AddChildrenPicker = pickerLegendPosition;
				pickerLegendPosition.IsVisible = false;

				legendAlignments = (LegendAlignments[])MyConvert.ToArray("LegendPosition");

				for (int i = 0; i < legendAlignments.Length; i++) { itemsPickerLegendAlignments.Add(legendAlignments[i]); }

				pickerLegendPosition.Title = "Legend Position";

				pickerLegendPosition.ItemsSource = itemsPickerLegendAlignments;
				pickerLegendPosition.SelectedItem = chart.Chart.Legend.Alignment;
				pickerLegendPosition.SelectedIndexChanged += PickerLegendPosition_SelectedIndexChanged;

				settingLegendItem2.ValueItemText = pickerLegendPosition.SelectedItem.ToString();

		}

		private void CrearShareSection()
		{

				//Elementos de la Section
				shareSection = new StackLayout();
				shareTitleSection = new SettingsSectionTitle();
				settingShareItem1 = new SettingsItem(TypeItemsGrid.Button);

				// Add Section
				settingsPanelComponent.AddChildren = shareSection;

				// Legend
				shareTitleSection.Text = "Share";
				shareSection.Children.Add(shareTitleSection);
				shareSection.Children.Add(settingShareItem1);

				settingShareItem1.TitleText = "Share to other people this chart.";
				settingShareItem1.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => Share_OnClick()) });

		}

		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< EVENTOS

		private void Share_OnClick()
		{

				Image image = new Image();
				image.Source = ImageSource.FromResource("bar.png");
				ShareImage share = new ShareImage();
				share.Source = image.Source;
				BindingContext = share;

		}

        private void Switch3D_Toggled(object sender, ToggledEventArgs e)
        {

                var switchItem = sender as SettingsSwitchItem;

                if(e.Value) {

                    chart.Chart.Aspect.View3D = true;
                    chart.Chart.Aspect.Chart3DPercent = 30;
                    chart.Chart.Aspect.Orthogonal = true;

                }
                else { chart.Chart.Aspect.View3D = false; }

        }

        // Evento al hacer click a alguna de las opciones de LegendPosition
        private void PickerLegendPosition_SelectedIndexChanged(object sender, EventArgs e)
		{

				int index = 0;
				var picker = sender as Picker;
				var itemSelected = (LegendAlignments)picker.SelectedItem;
				while (itemSelected != legendAlignments[index])
				{

					index++;

				}

				chart.Chart.Legend.Alignment = legendAlignments[index];
				settingLegendItem2.ValueItemText = picker.SelectedItem.ToString();

		}

		Axis axisSelected;
		private void PickerAxis_SelectedIndexChanged(object sender, EventArgs e)
		{

				axisSelected = new Axis();
				int index = 0;
				var picker = sender as Picker;
				var aChart = chart.Chart.Axes;
				var itemSelected = (string)picker.SelectedItem;


				while (itemSelected != selectAxis[index])
				{

					index++;

				}

				switch(index)
				{

						case 0:
							axisSelected = chart.Chart.Axes.Left;
							break;
						case 1:
							axisSelected = chart.Chart.Axes.Right;
							break;
						case 2:
							axisSelected = chart.Chart.Axes.Top;
							break;
						case 3:
							axisSelected = chart.Chart.Axes.Bottom;
							break;
						case 4:
							axisSelected = chart.Chart.Axes.Depth;
							break;
						default:
							axisSelected = chart.Chart.Axes.DepthTop;
							break;

				}

				settingAxesVisible.isToogled = axisSelected.Visible;
				settingAxesInverted.isToogled = axisSelected.Inverted;
				settingAxesGrid.isToogled = axisSelected.Grid.Visible;
				settingAxesSelect.ValueItemText = picker.SelectedItem.ToString();

			}

			// Ver leyenda o no
			private void SwitchLegendVisible_Toggled(object sender, ToggledEventArgs e)
			{ chart.Chart.Legend.Visible = e.Value; }

			// Ver grid o no
			private void SwitchGridAxes_Toggled(object sender, ToggledEventArgs e)
			{

					if(axisSelected == chart.Chart.Axes.Left) { chart.Chart.Axes.Left.Grid.Visible = e.Value; }
					else if(axisSelected == chart.Chart.Axes.Right) { chart.Chart.Axes.Right.Grid.Visible = e.Value; }
					else if (axisSelected == chart.Chart.Axes.Top) { chart.Chart.Axes.Top.Grid.Visible = e.Value; }
					else if (axisSelected == chart.Chart.Axes.Bottom) { chart.Chart.Axes.Bottom.Grid.Visible = e.Value; }
					else if (axisSelected == chart.Chart.Axes.Depth) { chart.Chart.Axes.Depth.Grid.Visible = e.Value; }
					else { chart.Chart.Axes.DepthTop.Grid.Visible = e.Value; }

			}

		// Invertira values axis o no
		private void SwitchInvertedAxes_Toggled(object sender, ToggledEventArgs e)
		{

				if (axisSelected == chart.Chart.Axes.Left) { chart.Chart.Axes.Left.Inverted = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Right) { chart.Chart.Axes.Right.Inverted = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Top) { chart.Chart.Axes.Top.Inverted = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Bottom) { chart.Chart.Axes.Bottom.Inverted = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Depth) { chart.Chart.Axes.Depth.Inverted = e.Value; }
				else { chart.Chart.Axes.DepthTop.Inverted = e.Value; }

		}

		// Invisible axis o no
		private void SwitchVisibleAxis_Toggled(object sender, ToggledEventArgs e)
		{

				if (axisSelected == chart.Chart.Axes.Left) { chart.Chart.Axes.Left.Visible = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Right) { chart.Chart.Axes.Right.Visible = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Top) { chart.Chart.Axes.Top.Visible = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Bottom) { chart.Chart.Axes.Bottom.Visible = e.Value; }
				else if (axisSelected == chart.Chart.Axes.Depth) { chart.Chart.Axes.Depth.Visible = e.Value; }
				else { chart.Chart.Axes.DepthTop.Visible = e.Value; }

		}

		// Opción de modificar texto del header, focus al entry cuando haces click
		private void GetButtonEntry_Clicked(object sender, EventArgs e)
		{

				if (entryTitle.Text != null)
				{

					chart.Chart.Header.Text = entryTitle.Text;
					chart.Chart.Header.Visible = true;

				}
			
		}

		// Opción que muestra o no la entry para modificar el título de un chart
		private void SettingItem3_Clicked(SettingsItem item)
		{

				Entry entry = ((Entry)((Grid)item.Children[0]).Children[2]);
				Button button = ((Button)((Grid)item.Children[0]).Children[1]);

				if (!entry.IsVisible) { entry.IsVisible = true; button.IsVisible = true; }
				else { entry.IsVisible = false; button.IsVisible = false; }

		}

		// Abre el picker en el caso de que hagas click a la opción
		private void FocusPicker_OnClick(SettingsItem item, Picker picker)
		{

				picker.Focus();

		}

        bool showMarks = false;
        int cantidadMarks = 0;
		// Muestra o no las marks de los charts
		private void SwitchMarks_Toggled(object sender, ToggledEventArgs e)
		{
				var type = chart.Chart.Series[0];

				if(type is CircularGauge) { ((CircularGauge)chart.Chart.Series[0]).Axis.Labels.Visible = e.Value; }
				else if(type is KnobGauge) { ((KnobGauge)chart.Chart.Series[0]).Axis.Labels.Visible = e.Value; }
				else {

                    for (int i = 0; i < chart.Chart.Series.Count; i++) {

                        chart.Chart.Series[i].GetSeriesMark += SwitchMarks_GetSeriesMark;
                        chart.Chart.Series[i].Marks.Visible = true;
                        chart.Chart.Series[i].Repaint();
                        cantidadMarks += chart.Chart.Series[i].Count;
                        
                    }
                    showMarks = e.Value;
                    enabledSwitchMarksEvent = true;

                }
					
		}

        private bool enabledSwitchMarksEvent = false;
        private void SwitchMarks_GetSeriesMark(Series series, GetSeriesMarkEventArgs e)
        {

            if (enabledSwitchMarksEvent)
            {
                series.Marks.Visible = showMarks;
                cantidadMarks--;
                if (cantidadMarks == 0)
                {

                    for (int i = 0; i < chart.Chart.Series.Count; i++)
                    {

                        enabledSwitchMarksEvent = false;

                    }

                }
            }

        }

        // Modifica el valor de las series
        private void SliderValues_ValueChanged(object sender, ValueChangedEventArgs e)
		{

				var type = chart.Chart.Series[0];
				Type objType = chart.Chart.Series[0].GetType();

				if (type is CircularGauge) { Math.Round(((CircularGauge)chart.Chart.Series[0]).Value = e.NewValue,2); ((CircularGauge)chart.Chart.Series[0]).mandatory[1] = -((CircularGauge)chart.Chart.Series[0]).mandatory[1] + e.NewValue; }
				else if (type is KnobGauge) {

						Math.Round(((KnobGauge)chart.Chart.Series[0]).Value = e.NewValue, 2);

						if (titleChart == "Temperature Knob")
						{

							KnobGauge gauge = (KnobGauge)type;
							if (gauge.Value < 0.25) { gauge.Hand.Color = gauge.GreenLine.Gradient.EndColor; }
							else if (gauge.Value < 0.5) { gauge.Hand.Color = gauge.GreenLine.Gradient.StartColor; }
							else if (gauge.Value == 0.5) { gauge.Hand.Color = Color.White; }
							else if (gauge.Value < 0.75) { gauge.Hand.Color = gauge.RedLine.Gradient.EndColor; }
							else { gauge.Hand.Color = gauge.RedLine.Gradient.StartColor; }

						}

				}
				else if (type is LinearGauge)
				{

						if (titleChart == "Mobile Battery")
						{

							var gauge = ((LinearGauge)chart.Chart.Series[0]);
							gauge.Value = Math.Round(100 - e.NewValue, 2);
							if (e.NewValue >= 0 && e.NewValue < 25) { gauge.ValueAreaBrush.Color = Color.FromRgb(255, 0, 0); }
							else if (e.NewValue >= 25 && e.NewValue < 50) { gauge.ValueAreaBrush.Color = Color.FromRgb(255, 140, 0); }
							else if (e.NewValue >= 50 && e.NewValue < 75) { gauge.ValueAreaBrush.Color = Color.FromRgb(255, 208, 0); }
							else { gauge.ValueAreaBrush.Color = Color.FromRgb(0, 195, 10); }

						}
						else {

							var gauge = ((LinearGauge)chart.Chart.Series[0]);
							gauge.Value = Math.Round(e.NewValue, 2);

							}

				}
						

				settingSeriesValues.ValueItemText = e.NewValue.ToString();

		}

		// Evento SelectedIndex de un picker 
		private void PickerHand_SelectedIndexChanged(object sender, EventArgs e)
		{

				int index = 0;
				var picker = sender as Picker;
				var itemSelected = (PointerStyles)picker.SelectedItem;
				while(itemSelected != pointerStyles[index]) {

						index++;

				}
				((CircularGauge)chart.Chart.Series[0]).Hand.Style = pointerStyles[index];
                ((CircularGauge)chart.Chart.Series[0]).Hands[1].Style = pointerStyles[index];
				settingItemHandStyle.ValueItemText = picker.SelectedItem.ToString();

		}

		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< PROPIEDADES

		public SettingsPanel GetTableView { get { return settingsPanelComponent; } }
		public ChartView GetChart { get { return chart; } }
        public SettingsSwitchItem GetSwitchMarks { get { return switchMarks; } }               

	}
}
