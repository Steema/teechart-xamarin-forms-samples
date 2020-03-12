using Steema.TeeChart;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamControls.ViewModels.Base;
using System.Collections;
using XamControls.ViewModels;
using System.Threading;
using System.Runtime.CompilerServices;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XamControls.Views
{

	// Página de "Charts" con TabbedPage
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartTabPage : Xamarin.Forms.TabbedPage
    {
		
	    private ChartViewBase[] vChart;
	    private Variables.Variables var = new Variables.Variables();
	    private MenuInferior[] menuInferior;
	    private StackLayout[] stackLayoutChart;
	    private Grid[] grid;
	    private ContentPage[] contentPage;
	    private ToolbarItem[] toolbar;
        public ChartSettingsPage chartSettPage;

        private int valorInicial;

        // Constructor
        public ChartTabPage(int ValorInicial)
        {
						
		    InitializeComponent();
                
            this.valorInicial = ValorInicial;
            this.CurrentPageChanged += ChartTabPage_CurrentPageChanged;
		    CrearPaginaInicial();

            if (Device.RuntimePlatform == Device.iOS)
            {
                foreach (Xamarin.Forms.Page page in contentPage)
                {

                    Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(page, true);

                }
            }
            else
            {

                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.VisualElement.SetElevation(this, 0);

            }

            menuInferior[0].UpdateSwipeTabbedPageEnabled(this);
        }
				
        // Inicializar un "toolbarItems"
        private void InicialitzarToolBarItem()
        {

		    toolbar = new ToolbarItem[contentPage.Length];

		    for (int i = 0; i < toolbar.Length; i++)
		    {
			    toolbar[i] = new ToolbarItem();
			    if(Device.RuntimePlatform == Device.Android) toolbar[i].Icon = (FileImageSource)ImageSource.FromFile("ic_lightbulb_outline_white_24dp.png");
                else if(Device.RuntimePlatform == Device.UWP) toolbar[i].Icon = (FileImageSource)ImageSource.FromFile("Assets/ic_lightbulb_outline_white_24dp.png");
                else if(Device.RuntimePlatform == Device.iOS) toolbar[i].Icon = (FileImageSource)ImageSource.FromFile("mic_lightbulb_outline_white_36dp.png");
                toolbar[i].Text = "About";
				toolbar[i].Clicked += AboutChart_Clicked;
				contentPage[i].ToolbarItems.Add(toolbar[i]);
			}

            if (Device.RuntimePlatform != Device.UWP)
            {
                toolbar = new ToolbarItem[contentPage.Length];
                for (int i = 0; i < toolbar.Length; i++)
                {
                    toolbar[i] = new ToolbarItem();
                    toolbar[i].Icon = (FileImageSource)ImageSource.FromFile("ic_build_white_24dp.png");
                    toolbar[i].Text = "Settings";
                    toolbar[i].Clicked += Settings_ClickedAsync;
                    contentPage[i].ToolbarItems.Add(toolbar[i]);
                }
            }

		}

		// Crea la página de configuración
		private async void Settings_ClickedAsync(object sender, EventArgs e)
		{

			int pageSelected = 0;
            clearChart = false;

			if (this.CurrentPage == contentPage[1]) { pageSelected = 1; }
            else if(this.contentPage.Length == 3 && this.CurrentPage == contentPage[2]) { pageSelected = 2; }

			chartSettPage = new ChartSettingsPage(vChart[pageSelected].GetChart, this.Title);
			await Navigation.PushAsync(chartSettPage);
			vChart[pageSelected].SetChart = chartSettPage.GetChart as ChartViewRender;

		}

		// Crear las dos páginas principales
		private void CrearPaginaInicial()
		{

			this.BackgroundColor = Color.FromRgb(240, 240, 240);

			switch (valorInicial)
			{

					case 1: case 2:

						// Pantalla estructura
						contentPage = new ContentPage[2];
						contentPage[0] = new ContentPage();
						contentPage[1] = new ContentPage();

						if (valorInicial == 1) this.Title = var.GetStandardNomButtonsTypes[0];
						else this.Title = var.GetProNomButtonsTypes[0];

						contentPage[0].Title = "TYPES";
						contentPage[1].Title = "FEATURES";

                        this.Children.Add(contentPage[0]);
						this.Children.Add(contentPage[1]);

						break;

					case 15:

						// Pantalla estructura
						contentPage = new ContentPage[3];
						contentPage[0] = new ContentPage();
						contentPage[1] = new ContentPage();
						contentPage[2] = new ContentPage();

						this.Title = var.GetProFunctionsNomButtons[0][0];

						contentPage[0].Title = "FINANCIAL";
						contentPage[1].Title = "EXTENDED";
						contentPage[2].Title = "STATISTICAL";

                        this.Children.Add(contentPage[0]);
						this.Children.Add(contentPage[1]);
						this.Children.Add(contentPage[2]);

						break;

            }

            if (Device.RuntimePlatform == Device.iOS)
            {

                contentPage[0].Icon = "ic_radio_button_checked_white_24dp.png";

                for (int i = 1; i < contentPage.Length; i++)
                {

                    contentPage[i].Icon = "ic_radio_button_unchecked_white_24dp.png";

                }

            }

            this.SelectedItem = contentPage[0];
            

			CrearChart1VegadaPagina();

		}

		// Crear paginas bases
		private void CrearPage(int posicion)
		{

			// Content
			vChart[posicion] = new ChartViewBase(menuInferior[posicion].GetButtons[0]);

			stackLayoutChart[posicion] = new StackLayout();
			stackLayoutChart[posicion].Children.Add(vChart[posicion].GetChart);
			stackLayoutChart[posicion].Margin = 0;
			stackLayoutChart[posicion].VerticalOptions = LayoutOptions.FillAndExpand;
			stackLayoutChart[posicion].HorizontalOptions = LayoutOptions.FillAndExpand;

			// Grid Principal

			grid[posicion].ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			switch (Device.RuntimePlatform)
			{

				case Device.Android:
                case Device.UWP:
					grid[posicion].RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.88, GridUnitType.Star) });
					grid[posicion].Children.Add(stackLayoutChart[posicion], 0, 0);
					grid[posicion].RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.12, GridUnitType.Star) });
					grid[posicion].Children.Add(menuInferior[posicion].GetScrollView, 0, 1);
					break;

				case Device.iOS:
					grid[posicion].RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.08, GridUnitType.Star) });
					grid[posicion].RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.92, GridUnitType.Star) });
					grid[posicion].Children.Add(stackLayoutChart[posicion], 0, 1);
					grid[posicion].Children.Add(menuInferior[posicion].GetScrollView, 0, 0);
					break;

			}

			grid[posicion].HorizontalOptions = LayoutOptions.FillAndExpand;
			grid[posicion].VerticalOptions = LayoutOptions.FillAndExpand;
			grid[posicion].ColumnSpacing = 0;
			grid[posicion].RowSpacing = 0;

			contentPage[posicion].Content = grid[posicion];

			AsignarClickEvent(posicion);

		}

		// Acció que crea el grid amb els objectes necessaris
		private void CrearChart1VegadaPagina()
		{

			switch (valorInicial)
			{

				case 1:case 2:

					grid = new Grid[2];
					stackLayoutChart = new StackLayout[2];
					menuInferior = new MenuInferior[2];
					vChart = new ChartViewBase[2];

					InicialitzarToolBarItem();

					grid[0] = new Grid();
					grid[1] = new Grid();

					CrearMenuInferior();

					break;

				case 15:

					grid = new Grid[3];
					stackLayoutChart = new StackLayout[3];
					menuInferior = new MenuInferior[3];
					vChart = new ChartViewBase[3];

					InicialitzarToolBarItem();

					grid[0] = new Grid();
					grid[1] = new Grid();
					grid[2] = new Grid();

					CrearMenuInferior();

					break;

			}
			for (int i = 0; i < grid.Length; i++) { CrearPage(i); }

		}

		// Crea un MenuInferior según lo indicado
		private void CrearMenuInferior()
		{

			// MenuInferior

			if(valorInicial == 1)
			{

				menuInferior[0] = new MenuInferior(var.GetStandardNomButtonsTypes);
				menuInferior[1] = new MenuInferior(var.GetStandardNomButtonsFeatures);

			}
			else if(valorInicial == 2)
			{

				menuInferior[0] = new MenuInferior(var.GetProNomButtonsTypes);
				menuInferior[1] = new MenuInferior(var.GetProNomButtonsFeatures);

			}
			else
			{
			
				menuInferior[0] = new MenuInferior(var.GetProFunctionsNomButtons[0]);
				menuInferior[1] = new MenuInferior(var.GetProFunctionsNomButtons[1]);
				menuInferior[2] = new MenuInferior(var.GetProFunctionsNomButtons[2]);

			}

		}

		// Asigna a todos los btnes el "Evento" click
		private void AsignarClickEvent(int valor)
		{
			
			for(int i = 0; i < menuInferior[valor].GetButtons.Length; i++)
			{

				menuInferior[valor].GetButtons[i].Clicked += BtnInferior_Clicked;
			
			}

		}

		// BtnInferior "Evento" de click			
		Button selectedButton;
		private void BtnInferior_Clicked(object sender, EventArgs e)
		{

			int valor = 0;
			Button btn = sender as Button;

			if (btn != selectedButton)
			{

				if (menuInferior[0].GetButtons.Contains(btn)) { valor = 0; }
				else if(menuInferior[1].GetButtons.Contains(btn)) { valor = 1; }
				else { valor = 2; }

				menuInferior[valor].CleanColorButtons();
				vChart.ElementAt(valor).GetChart.Chart.Series.RemoveAllSeries();
				vChart[valor].CrearChart(btn);
				stackLayoutChart[valor] = new StackLayout();
				stackLayoutChart[valor].Children.Add(vChart[valor].GetChart);
				btn.TextColor = Color.FromRgb(60, 100, 220);
				if(Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.UWP) grid[valor].Children.Add(stackLayoutChart[valor], 0, 0);
                else grid[valor].Children.Add(stackLayoutChart[valor], 0, 1);

                this.Title = btn.Text;

				selectedButton = btn;
				menuInferior[valor].BtnSelected(this);

			}

		}

		// ToolBarItem "AboutChart" cuando haces "click"
		private void AboutChart_Clicked(object sender, EventArgs e)
		{

			var tabSelected = this.CurrentPage as Xamarin.Forms.Page;
			var thisContentPage = ((sender as ToolbarItem).Parent as ContentPage);
			Button btnSelected;
			string txtButton;
			//((titleChart.Parent) as TabbedPage).Children[1]

			switch(tabSelected.Title)
			{

				case "TYPES":
					btnSelected = menuInferior[0].GetSelectedButton;
					txtButton = btnSelected.Text;
					AboutTypesAsync(txtButton);
					break;

				case "FEATURES":
					btnSelected = menuInferior[1].GetSelectedButton;
					txtButton = btnSelected.Text;
					AboutFeaturesAsync(txtButton);
					break;

				case "FINANCIAL":
					btnSelected = menuInferior[0].GetSelectedButton;
					txtButton = btnSelected.Text;
					AboutFinancialAsync(txtButton);
					break;

				case "EXTENDED":
					btnSelected = menuInferior[1].GetSelectedButton;
					txtButton = btnSelected.Text;
					AboutExtendedAsync(txtButton);
					break;

				case "STATISTICAL":
					btnSelected = menuInferior[2].GetSelectedButton;
					txtButton = btnSelected.Text;
					AboutStatisticalAsync(txtButton);
					break;

			}

		}

		// Muestra un alerta según el chart que sea de la pestaña TYPES
		private async void AboutTypesAsync(string txtButton)
		{

			switch (txtButton)
			{

				case "Line":

					await DisplayAlert("About Chart Line", "Line series displays points drawing one line from each point to the next. You can click points to show its values.", "OK");
					break;

				case "Column Bar":
					await DisplayAlert("About Column Bar", "Column Bar series allow single or multiple bars, with different layouts.", "OK");
					break;

				case "Area":
					await DisplayAlert("About Area Chart", "The Area Chart allow single or multiple areas, with different layouts. You can click points to show its values.", "OK");
					break;

				case "Pie":
					await DisplayAlert("About Pie Chart", "The Pie shows values displayed as slices of a cheese or pie. You can click to disjoin a slice.", "OK");
					break;

				case "Fast Line":
					await DisplayAlert("About Fast Line", "The Fast-Line chart allow to display a lot points. It can be used in real-time applications to plot new added points.", "OK");
					break;

				case "Horizontal Area":
					await DisplayAlert("About Horizontal Area", "The Horizontal Area is an Area Chart displayed in horizontal form. You can clik points to show its values.", "OK");
					break;

				case "Horizontal Bar":
					await DisplayAlert("About Horizontal Bar", "The Horizontal Bar is a Bar Chart displayed in horizontal form. You can clik points to show its values.", "OK");
					break;

				case "Horizontal Line":
					await DisplayAlert("About Horizontal Line", "The Horizontal Line is a Line Chart displayed in horizontal form. You can clik points to show its values.", "OK");
					break;

				case "Donut":
					await DisplayAlert("About Donut Chart", "The Donut Chart shows values display as parts from a donut. You can clik to disjoin the parts from donut.", "OK");
					break;

				case "Bubble":
					await DisplayAlert("About Bubble Chart", "The Bubble Chart display some circles which expand if have a high value. You can clik bubbles to show its values.", "OK");
					break;

				case "Gantt":
					await DisplayAlert("About Gantt Chart", "The Gantt Chart show rectangles which its width represent the time that somebody focus on a work.", "OK");
					break;

				case "Shape":
					await DisplayAlert("About Shape Chart", "The Shape Chart display different figures. Can be a cube, circle, diamond and more.", "OK");
					break;

				case "Point/Scatter":
					await DisplayAlert("About Points Series", "The Point series show a lot of points without line that join its points.", "OK");
					break;

				case "Arrow":
					await DisplayAlert("About Arrow Series", "Each Arrow is represented as a point with Starting and Ending coordinates. This demo changes arrow positions randomly.", "OK");
					break;

				case "Polar":
					await DisplayAlert("About Polar Series", "Polar chart displays data in the form of a two-dimensional chart of more than three variables represented on axes starting from the same point.", "OK");
					break;

				case "Radar":
					await DisplayAlert("About Radar Series", "A Radar series shows each point at a different angle. Several Radar series can be displayed at the same time, each one with different configuration.", "OK");
					break;

				case "Pyramid":
					await DisplayAlert("About Pyramid Series", "The Pyramid series draws points stacked in a vertical pyramid shape.", "OK");
					break;

				case "Candle":
					await DisplayAlert("About Candle Series", "Candle (OHLC) series displays financial data in several ways (Candle, Bar and Stick). Candle colors are calculated based on their Open and Close values. Weekend data can be removed using a sequential index for the X value.", "OK");
					break;

				case "Kagi":
					await DisplayAlert("About Kagi Series", "Kagi charts, at first glance, look like swing charts. Like swing charts, they have no time axis and are made up of a series of vertical lines, however in the case of kagi charts, the vertical lines are based solely on the action of closing prices, not a bar's high and low prices. Another difference is that the thickness of a kagi chart line changes when closing prices penetrate the previous column top or bottom.", "OK");
					break;

				case "Renko":
					await DisplayAlert("About Renko Series", "The Renko chart is a trend following technique. It got its name from a Japanese word \"renga\" meaning bricks. In Renko chart line brick is drawn in the direction of the prior move only if prices move by a minimum amount which is equivalent to the box size that are always equal in size.\nRenko charts are always based on the closing prices.Renko bricks are drawn after comparing, that day’s close with the previous brick(high or low). A \"box size\" which determines the minimum price change to show is specified.", "OK");
					break;

				case "Histogram":
					await DisplayAlert("About Histogram Series", "Histogram Series draws points side-to-side with no gaps.", "OK");
					break;

				case "Error":
					await DisplayAlert("About Error Series", "\"Error\" series uses X,Y and Error coordinate values to display points.", "OK");
					break;

				case "Errorbar":
					await DisplayAlert("About Errorbar Series", "Similar to Error Series but using bars.", "OK");
					break;

				case "Funnel":
					await DisplayAlert("About Funnel Series", "Funnel charts are used to represent stages in a sales process.", "OK");
					break;

				case "Smith":
					await DisplayAlert("About Smith Series", "As name suggests SmithSeries draws Smith charts. Each point is defined with Resistance and Reactance values.", "OK");
					break;

				case "Bezier":
					await DisplayAlert("About Bezier Series", "The Bezier series interpolates points into lines, using the standard 4 point Bézier algorithm. The first Bézier spline is drawn from the first point to the fourth point in the point array. The second and third points are control points that determine the shape of the curve. Each subsequent curve needs exactly three more points: two more control points and an ending point.The ending point of the previous curve is used as the starting point for each additional curve.", "OK");
					break;

				case "HighLow":
					await DisplayAlert("About HighLow Series", "High-Low series draws two lines with High and Low values for each point.", "OK");
					break;

				case "Speed Time":
					await DisplayAlert("About Speed Time Series", "Using line series, adding values in that series and changing axis minimum and maximum values, also you can get this real time charting.", "OK");
					break;

				case "Waterfall":
					await DisplayAlert("About Waterfall Series", "WaterFall series is like a Surface series.  It draws vertical \"slices\", one for each Z row in the surface.", "OK");
					break;

                case "Volume":
                    await DisplayAlert("About Volume Series", "Volume series show the values how a bar graph at the bottom of the chart.", "OK");
                    break;

                case "Color Grid":
                    await DisplayAlert("About Color Grid Series", "ColorGrid series is a 2D surface. Each \"cell\" has a value and an optional color.", "OK");
                    break;

				default:
					await DisplayAlert("About x Series", "No info for this serie.", "OK");
					break;

			}

		}

		// Muestra una alerta según el chart que sea de la pestaña Features
		private async void AboutFeaturesAsync(string txtButton)
		{

			switch (txtButton)
			{

				case "Interpolating Line":
						await DisplayAlert("About Interpolating Line Series", "This is a line series with a feature, you can drag the line for show the points value.", "OK");
						break;

				case "Bar Styles":
						await DisplayAlert("About Bar Styles Series", "This is a column series but the bar have a arrow form. You can click in columns for show more information.", "OK");
						break;

				case "Zoom & Panning":
						await DisplayAlert("About Zoom & Panning Series", "Line series with two features, you can do zooming and panning.", "OK");
						break;

				case "Bar Gradient":
						await DisplayAlert("About Bar Gradient Series", "Column series but the columns have a degradate.", "OK");
						break;

				case "Bubble Transparent":
						await DisplayAlert("About Bubble Transparent Series", "This is a bubble chart. The bubbles are a little transparent.", "OK");
						break;

				case "Real Time":
						await DisplayAlert("About Real Time Series", "This is a fastline series and the graphic is all the time drawing new values.", "OK");
						break;

				case "Stack Area":
						await DisplayAlert("About Stack Area Series", "Two areas stacked in a chart.", "OK");
						break;

				case "Multiple Pies":
						await DisplayAlert("About Multiple Pies Series", "4 pies in the same chart.", "OK");
						break;

				case "Semi-Pie":
						await DisplayAlert("About Semi-Pie Series", "This is a cake that is shown in 180 degrees. You can click for pull apart a slice from pie.", "OK");
						break;

				case "Semi-Donut":
						await DisplayAlert("About Semi-Donut Series", "Similar to Semi-Pie but this have a donut shape.  You can click for pull apart a slice from donut.", "OK");
						break;

                case "Polar Bar":
                        await DisplayAlert("About Polar Bar Series", "The polar bar chart show bars arranged in a polar coordinate system and the length of their segments you can know their values.", "OK");
                        break;

                case "Inverted Pyramid":
                        await DisplayAlert("About Inverted Pyramid Series", "Pyramid series rotated 180 degrees", "OK");
                        break;

                case "Horizontal Histogram":
                        await DisplayAlert("About Horizontal Histogram Series", "This is a histogram rotated 90 degrees.", "OK");
                        break;

				default:
						await DisplayAlert("About x Series", "No info for this serie.", "OK");
						break;

			}

		}

		// Muestra una alerta según el chart que sea de la pestaña Financial
		private async void AboutFinancialAsync(string txtButton)
		{

			switch (txtButton)
			{

				case "ADX":
					await DisplayAlert("About ADX Series", "A.D.X ( Average Directional Change ), is a commonly used indicator function in Financial charting applications. \nThe ADX Function uses a OHLC(Candle) series as datasource, and plots 3 lines: DMI+ , ADX and DMI-. ", "OK");
					break;

				case "AC":
					await DisplayAlert("About AC Series", "A percentage change is a way to express a change in a variable. It represents the relative change between the old value and the new one.", "OK");
					break;

				case "Alligator":
					await DisplayAlert("About Alligator Series", "Alligator Technical Indicator is a combination of Balance Lines (Moving Averages): Alligator's Jaw (dark blue line), Alligator's Teeth (light blue line) and Alligator's Lips (green line). They show the interaction of different time periods. As clear trends can be seen only 15 to 30 per cent of the time, it is essential to follow them and refrain from working on markets that fluctuate only within certain price periods.", "OK");
					break;

				case "AO":
					await DisplayAlert("About AO Series", "Awesome Oscillator (AO) is simply the difference between the 34-period and 5-period simple moving averages of the bar's midpoints (H+L)/2.\nIt determines market momentum at a given time comparing the last 5 bars to the last 34 bars.\nThe AO Function uses a OHLC(Candle) series as datasource.", "OK");
					break;

				case "ATR":
					await DisplayAlert("About ATR Series", "Average True Range Technical Indicator (ATR) is an indicator that shows volatility of the market. \nThe ATR Function uses a OHLC(Candle) series as datasource.", "OK");
					break;

				case "Bollinger Bands":
					await DisplayAlert("About Bollinger Bands Series", "Bollinger bands is a special function used as a financial indicator. \nIt calculates and displays two lines, using a moving average (exponential or not) and the standard deviation.", "OK");
					break;

				case "CCI":
					await DisplayAlert("About CCI Series", "CCI function (Commodity Channel Index), is a financial indicator. \nIt is used to identify cyclical turns in commodities.", "OK");
					break;

				case "CLV":
					await DisplayAlert("About CLV Series", "\"Accumulation / Distribution Line\" function ( CLV ) is a financial indicator. The formula is: \n(Close - Low) - (High - Close)\n------------------------------------------------- x Volume\n(High - Low)\nResults can be optionally acumulated and / or multiplied by a Volume series.", "OK");
					break;

				case "Exp. Average":
					await DisplayAlert("About Exp. Average Series", "The Exponential Average function calculates the average of all the source points using the exponential algorithm.", "OK");
					break;

				case "Exp. Moving Average":
					await DisplayAlert("About Exp. Moving Average Series", "The Exponential Moving Average function calculates the average of all the source candle values using the exponential algorithm.", "OK");
					break;

				case "Gator Oscillator":
					await DisplayAlert("About Gator Oscillator Series", "Gator Oscillator is based on the AlligatorFunction and shows the degree of convergence/divergence of Alligator's \"jaws\", \"teeth\" and \"lips\".", "OK");
					break;

				case "Kurtosis":
					await DisplayAlert("About Kurtosis Series", "Kurtosis is a measure of the \"peakedness\" of the probability distribution of a real-valued random variable.", "OK");
					break;

				case "MACD":
					await DisplayAlert("About MACD Series", "The MACD function (Moving Average Convergence Divergence), used in financial charts.", "OK");
					break;

				case "Momentum":
					await DisplayAlert("About Momentum Series", "The Momentum function calculates the difference between each point in the data source and the \"n\" previous point value.", "OK");
					break;

				case "Momentum Div.":
					await DisplayAlert("About Momentum Division Series", "The Momentum Division function calculates the ratio of a point value compared to the previous N point value. \nThe formula is :   Momentum = 100 * Value / PreviousValue.", "OK");
					break;

				case "Money Flow":
					await DisplayAlert("About Money Flow Series", "The Money Flow Index function determines the strength of money flowing into or out of a security by comparing the volume of upward and downward price changes over a given period of time. Money flow by Marc Chaiken, the formula. \nCMF = SUM(AD, n) / SUM(VOL, n)\nwhere n = Period\nAD = VOL * (CL - OP) / (HI - LO)\nAD stands for Accumulation Distribution.", "OK");
					break;

				case "OBV":
					await DisplayAlert("About OBV Series", "\"On Balance Volume\" function ( OBV ) is a financial indicator. The formula is:\nWhen close price is bigger than open price, volume is added.\nWhen close price is lower or equal than open price, volume is subtracted.", "OK");
					break;

				case "PVO":
					await DisplayAlert("About PVO Series", "PVO function(Percentage Volume Oscillator) is a financial indicator.\nRequires one source series(of any type) and 2 period values.", "OK");
					break;

				case "RSI":
					await DisplayAlert("About RSI Series", "The R.S.I. function (Relative Strength Index) has been improved, now offering a second calculation method. By default, it does the calculation using Open and Close values of the datasource Candle series.The second method uses Close prices only.", "OK");
					break;

				case "RVI":
					await DisplayAlert("About RVI Series", "Relative Vigor Index (RVI) is an indicator that measures the conviction of a recent price action and the likelihood that it will continue. The RVI compares the positioning of a security's closing price relative to its price range. The result is smoothed by calculating a moving average of the values and compared with a 4 - period signal line. The indicator is calculated using the formula: \nRVI = (CLOSE - OPEN) / (HIGH - LOW)\nThe RVI Function uses a OHLC(Candle ) series as datasource.", "OK");
					break;

				case "Slope":
					await DisplayAlert("About Slope Series", "The slope or gradient of a line describes its steepness, incline, or grade. A higher slope value indicates a steeper incline.", "OK");
					break;

				case "Smoothed Mov Avg":
					await DisplayAlert("About Smoothed Mov Avg Series", "The slope or gradient of a line describes its steepness, incline, or grade. A higher slope value indicates a steeper incline.", "OK");
					break;

				case "S.A.R.":
					await DisplayAlert("About S.A.R. Series", "The Parabolic SAR is used to set trailing price stops.", "OK");
					break;

				default:
					await DisplayAlert("About x Series", "No info for this serie.", "OK");
					break;

			}

		}

		// Muestra una alerta según el chart que sea de la pestaña Extended
		private async void AboutExtendedAsync(string txtButton)
		{

			switch(txtButton)
			{

				case "Cross Point":
					await DisplayAlert("About Cross Points Function", "CrossPoints function calculates coordinates for crossing points of source line series.", "OK");
					break;

				case "Correlation":
					await DisplayAlert("About Correlation Function", "Correlation function calculates a coefficient value from -1 to 1 that indicates how well source X and Y values follow the same trend.", "OK");
					break;

				case "Cumulative":
					await DisplayAlert("About Cumulative Function", "The Cumulative function calculates the incremental sum of the data source point values.", "OK");
					break;

				case "Custom Function":
					await DisplayAlert("About Custom Function", "Custom function to calculate y = f(x) values using a CalculateEvent.", "OK");
					break;

				case "Exponential Trend":
					await DisplayAlert("About Exponential Trend", "The Exponential Trend function is similar to Trend, except the calculation fits values using their exponential (e) weights. Compare it to the normal Trend clicking the legend green series.", "OK");
					break;

				case "Fitting Linearizable":
					await DisplayAlert("About Fitting Linearizable", "By using linear regression it's possible to fit data to several linearizable models.", "OK");
					break;

				case "Performance":
					await DisplayAlert("About Performance", "Performance function calculate the percentage of difference between each source point and the first source point. Calculation starts always at zero.", "OK");
					break;

				case "Finding Coefficients":
					await DisplayAlert("About Finding Coefficients", "The PolyFitting function returns the polynomial coefficients by using the Coefficient(int index) method, where index is a value between 0 and PolyDegree-1.", "OK");
					break;

				case "Down Sampling":
					await DisplayAlert("About Down Sampling", "The DownSampling function has a new method, MinMaxFirstLastNull, which for every group of points plots the first, maximum, minimum and last point within it and also includes the first null point of the group in the calculation but without plotting it.", "OK");
					break;

				case "RMS":
					await DisplayAlert("About RMS Function", "The Root Mean Square (RMS) function does the following calculation:\nRMS = Sqrt(Sum(Square(Value))) / NumValues)", "OK");
					break;

				case "Smoothing Function":
					await DisplayAlert("About Smoothing Function", "Smoothing function interpolates points using a B-Spline algorithm. Several properties control the Spline calculation. The smoothed points can optionally pass just exactly over the source points.", "OK");
					break;

				case "Standard Deviation":
					await DisplayAlert("About Standard Deviation", "The StdDeviation function calculates the Standard Deviation using all the data source points.", "OK");
					break;

				case "Trendline":
					await DisplayAlert("About Trendline", "The Trend function calculates the \"best fit\" line using all the data source points.", "OK");
					break;

				case "Variance":
					await DisplayAlert("About Variance", "The Variance function returns how spread out a distribution is. The Standard Deviation function is the square root of the variance.", "OK");
					break;

				default:
					await DisplayAlert("About x Series", "No info for this serie.", "OK");
					break;

			}

		}

		// Muestra una alerta según el chart que sea de la pestaña Statistical
		private async void AboutStatisticalAsync(string txtButton)
		{

			switch(txtButton)
			{

                case "Cumulative Histogram":
                    await DisplayAlert("About Cumulative Histogram Series", "The HistogramFunction does exactly what it's name suggests: It creates a histogram from single series X or Y values.", "OK");
                    break;

				case "Skewness":
					await DisplayAlert("About Skewness Series", "Skewness is a measure of the asymmetry of the probability distribution of a real-valued random variable.", "OK");
					break;

                case "SPC":
                    await DisplayAlert("About SPC Series", "Calculating and charting the Upper and Lower limits of an SPC Quality Control series. \nThis example includes formulae to calculate the SPC upper and lower limits.The Chart displays 2 series, one with the number of \"good\" parts and another with the percent of \"bad\" parts.", "OK");
                    break;

				default:
					await DisplayAlert("About x Series", "No info for this serie.", "OK");
					break;

			}

		}

		// Modifica el título de la página cuando se modifica el tab
		private int indexTabChanged = 0;
		private void ChartTabPage_CurrentPageChanged(object sender, EventArgs e)
		{
					
			if(indexTabChanged > 0) {

				if (CurrentPage == contentPage[0]) { menuInferior[0].BtnSelected(this); this.Title = menuInferior[0].GetSelectedButton.Text; }
				else if (CurrentPage == contentPage[1]) { menuInferior[1].BtnSelected(this); this.Title = menuInferior[1].GetSelectedButton.Text; }
				else { menuInferior[2].BtnSelected(this); this.Title = menuInferior[2].GetSelectedButton.Text; }

                        

                for (int i = 0; i < contentPage.Length; i++)
                {

                    if(CurrentPage != contentPage[i]) contentPage[i].Icon = "ic_radio_button_unchecked_white_24dp.png";
                    else { contentPage[i].Icon = "ic_radio_button_checked_white_24dp.png"; }

                }

            }
			else { indexTabChanged++; }
				
		}


        private bool clearChart = true;
        protected override void OnDisappearing()
        {

            if (clearChart)
            {
                vChart[0].ClearLastElements();
                vChart[1].ClearLastElements();
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