using XamControls.Models;
using XamControls.Utils;
using XamControls.ViewModels;
using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using XamControls.ViewModels.Base;
using XamControls.CustomRenders;
using Steema.TeeChart.Styles;
using XamControls.Services.Gesture.Swipe;
using XamControls.Services.Gesture.Swipe.Views;

namespace XamControls.Views
{

	// Página de "Charts" sin TabbedPage

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartContentPage : ContentPage
	{
		
		private ChartViewBase vChart;
		private Variables.Variables var = new Variables.Variables();
		private MenuInferior menuInferior;
		private StackLayout stackLayoutChart;
		private Grid grid;
		private int valorInicial;

		// Constructor
		public ChartContentPage(int ValorInicial)
		{

			InitializeComponent();
			this.valorInicial = ValorInicial;
			this.BackgroundColor = Color.White;
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
			CrearPaginaInicial();

		}

		// Inicializar el item configuration para la toolbar
		private ToolbarItem InicialitzarConfigToolBar()
		{

            ToolbarItem toolbar = new ToolbarItem();

            toolbar.Icon = (FileImageSource)ImageSource.FromFile("ic_build_white_24dp.png");
            toolbar.Text = "Settings";
            toolbar.Clicked += Settings_ClickedAsync;

			return toolbar;

		}

		private async void Settings_ClickedAsync(object sender, EventArgs e)
		{

            clearChart = false;

            ChartSettingsPage chartSettPage = new ChartSettingsPage(vChart.GetChart, this.Title);
			await Navigation.PushAsync(chartSettPage);
			vChart.SetChart = chartSettPage.GetChart as ChartViewRender;

		}

		// Crear las dos páginas principales
		private void CrearPaginaInicial()
		{

			// Pantalla estructura
			this.BackgroundColor = Color.White;

			CrearChart1VegadaPagina();

		}

		private void CrearChart1VegadaPagina()
		{

			grid = new Grid();
			stackLayoutChart = new StackLayout();

			this.ToolbarItems.Add(InicialitzarAboutChartToolbar());
			if (valorInicial != 5 && valorInicial != 7 && valorInicial != 8 && valorInicial != 9 && valorInicial != 11 && valorInicial != 12 && valorInicial != 13)
			{

				this.ToolbarItems.Add(InicialitzarConfigToolBar());

			}   

			// StackLayout del "Chart"
			stackLayoutChart.Margin = 0;
			stackLayoutChart.VerticalOptions = LayoutOptions.FillAndExpand;
			stackLayoutChart.HorizontalOptions = LayoutOptions.FillAndExpand;

			// "Grid" de la pestaña Types

			grid.HorizontalOptions = LayoutOptions.FillAndExpand;
			grid.VerticalOptions = LayoutOptions.FillAndExpand;
			grid.ColumnSpacing = 0;
			grid.RowSpacing = 0;
			grid.Margin = 0;

			switch (valorInicial)
			{

				case 3:
					menuInferior = new MenuInferior(var.GetCircularGaugesNomButtons);
					break;

				case 4:
					menuInferior = new MenuInferior(var.GetMapsNomButtons);
					break;

				case 5:
					menuInferior = new MenuInferior(var.GetTreeMapNomButtons);
					break;

				case 6:
					menuInferior = new MenuInferior(var.GetKnobGaugeNomButtons);
					break;

				case 7:
					menuInferior = new MenuInferior(var.GetClockNomButtons);
					break;

				case 8:
					menuInferior = new MenuInferior(var.GetOrganizationalNomButtons);
					break;

				case 9:
					menuInferior = new MenuInferior(var.GetNumericGaugeNomButtons);
					break;

				case 10:
					menuInferior = new MenuInferior(var.GetLinearGaugeNomButtons);
					break;

				case 11:
					menuInferior = new MenuInferior(var.GetCalendarNomButtons);
					break;

				case 12:
					menuInferior = new MenuInferior(var.GetSparkLinesNomButtons);
					break;

				case 13:
					menuInferior = new MenuInferior(var.GetTagCloudNomButtons);
					break;

				case 14:
					menuInferior = new MenuInferior(var.GetStandardFunctionsNomButtons);
					break;

			}

			this.Title = menuInferior.GetNomButtons[0];

			switch(valorInicial) {

                case 5: case 8: case 9: case 13:

					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
					vChart = new ChartViewBase(this.Title);
					stackLayoutChart.Children.Add(vChart.GetChart);
					grid.Children.Add(stackLayoutChart, 0, 0);
					break;

				case 11:

					LabelSwipe labelHeader = new LabelSwipe();
                    Button btnBackMonth = new Button();
                    Button btnNextMonth = new Button();

                    btnBackMonth.Text = "<";
                    btnBackMonth.VerticalOptions = LayoutOptions.FillAndExpand;
                    btnBackMonth.HorizontalOptions = LayoutOptions.Start;
                    btnBackMonth.WidthRequest = 50;
                    btnNextMonth.Text = ">";
                    btnNextMonth.VerticalOptions = LayoutOptions.FillAndExpand;
                    btnNextMonth.HorizontalOptions = LayoutOptions.End;
                    btnNextMonth.WidthRequest = 50;

					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.11, GridUnitType.Star) });
					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.79, GridUnitType.Star) });
					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.11, GridUnitType.Star) });
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
					grid.Children.Add(labelHeader, 0, 0);
                    grid.Children.Add(btnBackMonth, 0, 0);
                    grid.Children.Add(btnNextMonth, 0, 0);
					vChart = new ChartViewBase(this.Title, labelHeader);
					stackLayoutChart.Children.Add(vChart.GetChart);
					grid.Children.Add(stackLayoutChart, 0, 1);
					grid.Children.Add(menuInferior.GetScrollView, 0, 2);
					AsignarClickEvent(valorInicial);
					break;

				default:

					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    switch (Device.RuntimePlatform)
                    {

                        case Device.Android:
                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.89, GridUnitType.Star) });
                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.11, GridUnitType.Star) });
                            grid.Children.Add(stackLayoutChart, 0, 0);
                            grid.Children.Add(menuInferior.GetScrollView, 0, 1);
                            break;

                        case Device.iOS:
                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.11, GridUnitType.Star) });
                            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.89, GridUnitType.Star) });
                            grid.Children.Add(stackLayoutChart, 0, 1);
                            grid.Children.Add(menuInferior.GetScrollView, 0, 0);
                            break;

                        default:
                            throw new Exception("Unexpected Case");
                    }

                    vChart = new ChartViewBase(menuInferior.GetButtons[0]);
				    stackLayoutChart.Children.Add(vChart.GetChart);

				    AsignarClickEvent(valorInicial);
				    break;

			}

			this.Content = grid;

		}


        // Inicialitzar el aboutchart item para la toolbar
        private ToolbarItem InicialitzarAboutChartToolbar()
        {

            ToolbarItem toolbar = new ToolbarItem();

            if (Device.RuntimePlatform == Device.Android) toolbar.Icon = (FileImageSource)ImageSource.FromFile("ic_lightbulb_outline_white_24dp.png");
            else toolbar.Icon = (FileImageSource)ImageSource.FromFile("mic_lightbulb_outline_white_36dp.png");
            toolbar.Text = "About Chart";
            toolbar.Clicked += AboutChart_Clicked;

            return toolbar;
                    
        }

        // Evento que muestra una alerta con información del chart
        private void AboutChart_Clicked(object sender, EventArgs e)
        {

            var thisContentPage = ((sender as ToolbarItem).Parent as ContentPage);
            Button btnSelected;
            string txtButton;

            btnSelected = menuInferior.GetSelectedButton;
            txtButton = btnSelected.Text;
            AboutChart(txtButton);


        }

		// Acción que muestra una información según el chart que tengas seleccionado
		private void AboutChart(string txtButton)
		{
                    
			switch(txtButton)
			{

				case "Circular Gauge":
					DisplayAlert("About Circular Gauge Series", "It's a basic circular shaped gauge, this use a pointer and labels to show scaled values.", "OK");
					break;

				case "Car Fuel":
					DisplayAlert("About Car Fuel", "This gauge simulates a car fuel gauge using a pointer, labels to show scaled values, ticks, and a black gradient background.", "OK");
					break;

				case "Custom Hand":
					DisplayAlert("About Custom Hand", "This gauge is shown in 180 degrees. Also, this chart have two hands and you can change the style in chart settings.", "OK");
					break;

				case "Acceleration":
					DisplayAlert("About Acceleration", "This chart change the value when you displace your device (need accelerometer).", "OK");
					break;

				case "Map GIS":
					DisplayAlert("About Map GIS Series", "Map Series is a collection of polygon shapes. Each shape has formatting attributes and a value. The shape color lookups the color palette for the value.", "OK");
					break;

                case "World Map":
                    DisplayAlert("About World Map Series", "This series show a map from different regions. You can change the region in the map icon in toolbar.", "OK");
                    break;

				case "TreeMap":
					DisplayAlert("About Tree Map Series", "Treemaps display hierarchical (tree-structured) data as a set of nested rectangles. Each branch of the tree is given a rectangle, which is then tiled with smaller rectangles representing sub - branches. A leaf node's rectangle has an area proportional to a specified dimension on the data.\nIn specific Add method override, AValue represent node's value, text represents node's text and Superior node's parent.", "OK");
					break;

				case "Knob Gauge":
					DisplayAlert("About Knob Gauge Series", "This gauge imitates a gear and the hand indicate the value. You can change the value in chart settings.", "OK");
					break;

				case "Temperature Knob":
					DisplayAlert("About Temperature Knob", "This gauge imitates a temperature knob. Also, it has two annotations for display cold and hot labels.", "OK");
					break;

				case "Compass":
					DisplayAlert("About Compass", "This chart simulate a compass. Two hands show the orientation where you are pointing with your device (red pointer indicate it, need gyroscope).", "OK");
					break;

				case "Basic Clock":
					DisplayAlert("About Clock Series", "Clock series show the current time. This series have several properties for hands, including border and background attributes, visibility and the percentages of radius, width, height, ending arrow.", "OK");
					break;

				case "Custom Clock":
					DisplayAlert("About Custom Clock", "This chart is a clock customized and have the labels inside the clock.", "OK");
					break;

				case "Organizational Chart":
					DisplayAlert("About Organizational Series", "Organizational Charts display elements in hierarchical structures, such as Company and Employers.", "OK");
					break;

				case "Numeric Gauge":
					DisplayAlert("About Numeric Gauge Series", "This chart show a LED to show the value.", "OK");
					break;

				case "Linear Gauge":
					DisplayAlert("About Linear Gauge Series", "This is a basic linear gauge chart which show a max value pointer.", "OK");
					break;

				case "Scales":
					DisplayAlert("About Scales", "Linear gauge more customized. Have a hand which indicate the value. You can change the value in chart settings.", "OK");
					break;

				case "SubLines":
					DisplayAlert("About Sublines", "Similar to sacales chart but this add two subscales.", "OK");
					break;

				case "Mobile Battery":
					DisplayAlert("About Mobile Battery Chart", "Linear gauge rotated 90 degrees. This chart imitate a mobile battery and the value is detected from your device.", "OK");
					break;

				case "Basic Calendar":
					DisplayAlert("About Calendar Series", "The Calendar series displays monthly calendars. You can click on day cells to change the \"today\" day. Also, you can swipe the title for change the month.", "OK");
					break;

				case "Special Dates":
					DisplayAlert("About Special Dates", "This chart has colored the sundays how special dates. You can click for change the \"today\" day. Also, you can swipe the title for change the month.", "OK");
					break;

				case "TagCloud":
					DisplayAlert("About TagCloud Series", "TagCloud is a visual representation of text data, which is often used to represent data about keywords.", "OK");
					break;

				case "Add":
                    DisplayAlert("About Add Function Series", "The Add function calculates the sum of all points in the data source.\nIt can also be used to calculate sums by every \"n\" number of points.", "OK");
					break;

				case "Substract":
                    DisplayAlert("About Substract Function Series", "The Subtract function uses more than one series as data source. It calculates for each point the difference between the last and first series.", "OK");
					break;

				case "Multiply":
                    DisplayAlert("About Multiply Function Series", "The Multiply function calculates the product of every point of several data source series.", "OK");
                    break;

				case "Divide":
                    DisplayAlert("About Divide Function Series", "The Divide function calculates the division of every point of several data source series.", "OK");
                    break;

				case "Count":
                    DisplayAlert("About Count Function Series", "The Count function calculates the number of points of the data source series.", "OK");
                    break;

				case "Average":
                    DisplayAlert("About Average Function Series", "The Average function calculates the sum of all points in the data source and divides the result by number of points. It can also be used to calculate averages by every \"n\" number of points.\nThe High function calculates the greatest of all points in the data source.It can also be used to calculate the highest value by every \"n\" number of points.\nThe Low function calculates the smallest of all points in the data source.It can also be used to calculate the lowest value by every \"n\" number of points.", "OK");
                    break;

				case "High":
                    DisplayAlert("About High Function Series", "Show the maximum value in this chart using a line.", "OK");
                    break;

				case "Low":
                    DisplayAlert("About Low Function Series", "Show the minimum value in this chart using a line.", "OK");
                    break;

				case "Median Function":
                    DisplayAlert("About Median Function Series", "The Median function calculates the value that is in the middle if the source values were sorted. If two values are in the middle, the function does a simple average on them.\nNull source values can be included or not in the calculation.", "OK");
                    break;

				case "Percent Change":
                    DisplayAlert("About Percent Change Function Series", "A percentage change is a way to express a change in a variable. It represents the relative change between the old value and the new one.", "OK");
                    break;

				default:
                    DisplayAlert("About x Series", "No info for this serie.", "OK");
                    break;

			}

		}

		// Asigna a todos los btnes el "Evento" click
		private void AsignarClickEvent(int valor)
		{

			for (int i = 0; i < menuInferior.GetButtons.Length; i++)
			{

				menuInferior.GetButtons[i].Clicked += BtnInferior_Clicked;

			}

		}

		// BtnInferior "Evento" de click			
		Button selectedButton;
		private void BtnInferior_Clicked(object sender, EventArgs e)
		{

			Button btn = sender as Button;

			if (btn != selectedButton)
			{

				menuInferior.CleanColorButtons();
				vChart.GetChart.Chart.Series.RemoveAllSeries();
				stackLayoutChart = new StackLayout();
				if (valorInicial != 11)
                {

                    vChart.CrearChart(btn);
                    if (Device.RuntimePlatform == Device.Android) { grid.Children.Add(stackLayoutChart, 0, 0); }
                    else { grid.Children.Add(stackLayoutChart, 0, 1); }

                }
				else { vChart.CrearChart(btn, grid.Children.ElementAt(0) as LabelSwipe); grid.Children.Add(stackLayoutChart, 0, 1); }
						
				stackLayoutChart.Children.Add(vChart.GetChart);
				btn.TextColor = Color.FromRgb(60, 100, 220);
						

				this.Title = btn.Text;

				selectedButton = btn;
				menuInferior.BtnSelected(this);

			}

		}

        private bool clearChart = true;
        protected override void OnDisappearing()
        {

            if (clearChart)
            {

                vChart.ClearLastElements();
                        
            }

            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {

            clearChart = true;

            base.OnAppearing();
        }

    }
}