using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Steema.TeeChart.Styles;

namespace XamControls.Variables
{
	public class Variables
	{

		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< PROPIEDADES >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

		// ListView Home
		public string[] GetListViewNoms { get; }
		public string[] GetListViewDescripcion { get; }

		public const int N_ELEMENTS_LVIEW = 14;
		public int GET_N_ELEMENTS_LVIEW => (Device.RuntimePlatform == Device.UWP) ? 1 : N_ELEMENTS_LVIEW;
		// Buttons Menu Inferior
		public string[] GetStandardNomButtonsTypes { get; }
		public string[] GetStandardNomButtonsFeatures { get; }
		public string[] GetProNomButtonsTypes { get; }
		public string[] GetProNomButtonsFeatures { get; }
		public string[] GetCircularGaugesNomButtons { get; }
		public string[] GetMapsNomButtons { get; }
		public string[] GetTreeMapNomButtons { get; }
		public string[] GetKnobGaugeNomButtons { get; }
		public string[] GetClockNomButtons { get; }
		public string[] GetOrganizationalNomButtons { get; }
		public string[] GetNumericGaugeNomButtons { get; }
		public string[] GetLinearGaugeNomButtons { get; }
		public string[] GetCalendarNomButtons { get; }
		public string[] GetSparkLinesNomButtons { get; }
		public string[] GetTagCloudNomButtons { get; }
		public string[] GetStandardFunctionsNomButtons { get; }
		public string[][] GetProFunctionsNomButtons { get; }


		/// <summary>
		/// Standard Gráficos ------------------------------------------------------------------------------------------------------
		/// </summary>

		// Line Gráfico
		public double[] GetValorLine1 { get; }
		public double[] GetValorLine2 { get; }
		public double[] GetValorLineX { get; }

		// Column Gráfico
		public double[] GetValorColumn1 { get; }
		public double[] GetValorColumn2 { get; }
		public double[] GetValorColumn3 { get; }
		public string[] GetValorColumnX { get; }

		// Area Gráfico
		public double[] GetValorArea1 { get; }
		public double[] GetValorArea2 { get; }
		public string[] GetValorAreaX { get; }

		// Bubble Gráfico
		public double[] GetValorBubble1 { get; }
		public double[] GetValorBubbleX { get; }

		// Pie Gráfico
		public double[] GetValorPie1 { get; }

		// HorizontalArea Gráfico
		public double[] GetValorHorizArea1 { get; }
		public string[] GetValorHorizAreaX { get; }

		// HorizontalBar Gráfico
		public double[] GetValorHorizBar1 { get; }
		public double[] GetValorHorizBar2 { get; }
		public double[] GetValorHorizBarX { get; }

		// HorizontalLine Gráfico
		public double[] GetValorHorizLine1 { get; }
		public double[] GetValorHorizLine2 { get; }
		public double[] GetValorHorizLineY { get; }

		// Donut Gráfico
		public double[] GetValorDonut1 { get; }

		// Gantt Gráfico
		public string[] GetValorGantt1 { get; }
		public DateTime[] GetValorTimeSGantt { get; }
		public DateTime[] GetValorTimeEGantt { get; }

		// Shape Gráfico
		public double[] GetValorShape1X { get; }
		public double[] GetValorShape1Y { get; }
		public double[] GetValorShape2X { get; }
		public double[] GetValorShape2Y { get; }
		public double[] GetValorShape3X { get; }
		public double[] GetValorShape3Y { get; }
		public double[] GetValorShape4X { get; }
		public double[] GetValorShape4Y { get; }

		// Point (Scatter) Gráfico
		public double[] GetValorPointScatter1 { get; }
		public double[] GetValorPointScatter2 { get; }
		public double[] GetValorPointScatter3 { get; }
		public double[] GetValorPointScatter4 { get; }

		// Interpolating Line
		public double[] GetValorInterpolLine1 { get; }

		// ConeBar Gráfico
		public double[] GetValorConeBar1 { get; }
		public string[] GetValorConeBarX { get; }

		// BarGradient Gráfico
		public double[] GetValorGradientBar1 { get; }
		public double[] GetValorGradientBar2 { get; }
		public string[] GetValorGradientBarX { get; }

		// Bubble Transparency Gráfico
		public double[] GetValorBubbleTrans1 { get; }
		public double[] GetValorBubbleTransX { get; }
		// PieMulti Gráfico
		public double[] GetValorMultiPie1 { get; }
		public double[] GetValorMultiPie2 { get; }
		public double[] GetValorMultiPie3 { get; }
		public double[] GetValorMultiPie4 { get; }
		public string[] GetValorMultiPieItems { get; }
		// Semi-Pie Gráfico
		public double[] GetValorSemiPie1 { get; }

		/// <summary>
		/// Pro Gráficos --------------------------------------------------------------------------------------------------------
		/// </summary>

		// Arrow Gráfico
		public double[] GetValorArrow1X { get; }
		public double[] GetValorArrow1Y { get; }
		public double[] GetValorArrow1endX { get; }
		public double[] GetValorArrow1endY { get; }

        // Polar Gráfico
        public double[,] GetValorPolar1 { get; }
        public double[,] GetValorPolar2 { get; }

        // Pyramid Gráfico
        public double[] GetValorPyramidX { get; }
		public double[] GetValorPyramidY { get; }
		public string[] GetValorPyramidName { get; }

		// Candle Gráfico
		public DateTime[] GetValorCandleTime { get; }
		public double[,] GetValorsCandle { get; }

		// Kagi Gráfico
		public DateTime[] GetValorKagiTime { get; }
		public double[,] GetValorsKagi { get; }

		// Histogram Gráfico
		public double [,] GetValorsHistogram { get; }

		// Error Gráfico
		public string[] GetValorErrorLabels { get; }
		public double[,] GetValorsError { get; }

		// ErrorBar Gráfico
		public double[,] GetValorsErrorBar { get; }

		// Funnel Gráfico
		public double[,] GetValorsFunnel { get; }
		public string[] GetValorFunnelLabels { get; }

		/// <summary>
		/// TreeMap Gráficos
		/// </summary>

		// TreeMap Gráfico 1
		public double[] GetValorTreeMap1Type1 { get; }
		public double[] GetValorTreeMap2Type1 { get; }
		public string[] GetValorTreeMapXType1 { get; }

		/// <summary>
		/// KnobGauges
		/// </summary>

		// Compass Gráfico
		public string[] GetCompassAxisLabels { get; }

		/// <summary>
		/// Standard Functions
		/// </summary>

		// Add Gráfico
		public double[] GetValorStdAdd1 { get; }

		// Subs Gráfico
		public double[] GetValorStdSubs1 { get; }
		public double[] GetValorStdSubs2 { get; }

		// Mult Gráfico
		public double[] GetValorStdMult1 { get; }
		public double[] GetValorStdMult2 { get; }

		// Div Gráfico
		public double[] GetValorStdDiv1 { get; }
		public double[] GetValorStdDiv2 { get; }

		// Count Gráfico
		public double[] GetValorStdCount1 { get; }

		// Avg Gráfico
		public double[] GetValorStdAvg1 { get; }

		// High Gráfico
		public double[] GetValorStdHigh1 { get; }

		// Low Gráfico
		public double[] GetValorStdLow1 { get; }

		// Median Gráfico
		public double[] GetValorStdMedian1 { get; }

		// Percent Gráfico
		public double[] GetValorStdPercent1 { get; }

		/// <summary>
		/// Palettes
		/// </summary>			

		public Color[] GetPaletteBasic { get; }
		public Color[] GetPaletteDifferent { get; }
		public Color[] GetPaletteFun { get; }

		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<VALORES>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
		public Variables() {

			// Nom buttons del "menuInferior"
			GetStandardNomButtonsTypes = new string[13] { "Line", "Column Bar", "Area", "Pie", "Fast Line", "Horizontal Area", "Horizontal Bar", "Horizontal Line", "Donut", "Bubble", "Gantt",
                                                          "Shape", "Point/Scatter" }; // 1
			GetStandardNomButtonsFeatures = new string[10] { "Interpolating Line", "Bar Styles", "Zoom & Panning", "Bar Gradient", "Bubble Transparent", "Real Time", "Stack Area", "Multiple Pies", "Semi-Pie", "Semi-Donut" }; // 1
			GetProNomButtonsTypes = new string[17] { "Tower", "Arrow", "Polar", "Radar", "Pyramid", "Candle", //"Point&Figure", 
                                                                                                     //"Kagi",
                                                                                                     //"Renko", 
                "Histogram", "Error", "ErrorBar", "Funnel", //"BoxPlot",
                                                     "Smith", "Bezier", "HighLow", "Speed Time", "Waterfall", "Volume", "Color Grid" }; // 2
			GetProNomButtonsFeatures = new string[3] { "Polar Bar", "Inverted Pyramid", "Horizontal Histogram" }; // 2
			GetCircularGaugesNomButtons = new string[4] { "Circular Gauge", "Car Fuel", "Custom Hand", "Acceleration" }; // 3
			GetMapsNomButtons = new string[2] { "Map GIS", "World Map" 
            }; // 4
			GetTreeMapNomButtons = new string[1] { "TreeMap" }; // 5
			GetKnobGaugeNomButtons = new string[3] { "Knob Gauge", "Temperature Knob", "Compass" }; // 6
			GetClockNomButtons = new string[2] { "Basic Clock", "Custom Clock" }; // 7
			GetOrganizationalNomButtons = new string[1] { "Organizational Chart", //"Custom Elements"
            }; // 8
			GetNumericGaugeNomButtons = new string[1] { "Numeric Gauge", //"Digital Gauge" 
            }; // 9
			GetLinearGaugeNomButtons = new string[4] { "Linear Gauge", "Scales", "SubLines", "Mobile Battery" }; // 10
			GetCalendarNomButtons = new string[2] { "Basic Calendar", "Special Dates", //"Add Events" 
            }; // 11
			GetSparkLinesNomButtons = new string[] { "SparkLine" }; // 12
			GetTagCloudNomButtons = new string[1] { "TagCloud" }; // 13
			GetStandardFunctionsNomButtons = new string[10] { "Add", "Subtract", "Multiply", "Divide", "Count", "Average", "High", "Low", "Median Function", "Percent Change" }; // 14
			GetProFunctionsNomButtons = new string[3][] {
						new string[23] { "ADX", "AC", "Alligator", "AO", "ATR", "Bollinger Bands", "CCI", "CLV", //"Compression OHLC",
                                          "Exp. Average", "Exp. Moving Average", "Gator Oscillator", "Kurtosis", "MACD", "Momentum", "Momentum Div.", "Money Flow", "OBV", "PVO", "RSI", "RVI", "Slope", "Smoothed Mov Avg", "S.A.R." }, // 15.1
						new string[14] { "Cross Point", "Correlation", "Cumulative", "Custom Function", "Exponential Trend", "Fitting Linearizable", "Performance", //"Perimeter",
                                         "Finding Coefficients", "Down Sampling", "RMS", "Smoothing Function", "Standard Deviation", "Trendline", "Variance" }, // 15.2
						new string[3] {  //"Data Histogram",
                            "Cumulative Histogram", 
                            "Skewness", "SPC" }  // 15.3
					}; // 15

			//GetExtendedNomButtonsTypes = new string[11] { "3D Vector", "Contour", "Surface", "Map", "Organizational Charts", "Polar", "Point 3D", "Pyramid", "Radar", "Smith", "Tower" }; // 4
			//GetExtendedNomButtonsFeatures = new string[5] { "3D Contour", "Polar Smooth", "Polar Grid", "Gridding", "Tri. Surface" }; // 4
			//GetStatisticalNomButtons = new string[9] { "Box-Plot", "Color Grid", "Error", "Error Bar", "Funel", "HighLow", "Histogram", "Volume Pipe", "Waterfall" }; // 5

			//GetCanvasNomButtons = new string[7] { "Bar Rotation", "Anti-Alias", "Big Dotted lines", "Events", "Html Text", "Gradient Color", "Truncated Pyramid" }; // 7
			//GetFunctionsNomButtons = new string[4][]; // 8
			//GetFunctionsNomButtons[1] = new string[8] { "ADX", "AC", "Alligator", "AO", "ATR", "Bollinger Bands", "OBV", "Slope" }; // 8
			//GetFunctionsNomButtons[2] = new string[6] { "Cross Point", "Cumulative", "Perimeter", "RMS", "Trendline", "Variance" }; // 8
			//GetFunctionsNomButtons[3] = new string[3] { "SPC", "Skewness", "Histogram and Data" }; // 8
			//GetOthersNomButtons = new string[8] { "Bar 3D", "Bar-Join", "Calendar", "Clock", "ImageBar", "TagCloud", "Wind-Rose", "Realtime charting" }; // 9

			// Elements ListView Principal

			GetListViewNoms = new string[N_ELEMENTS_LVIEW] { "Standard Charts", "Pro Charts", "Circular Gauge", "Maps", "TreeMap", "Knob Gauge",  "Clock", "Organizational Charts", "Numeric Gauge", "Linear Gauge",
																												 "Calendar", //"SparkLines",
                                                            "TagCloud", "Standard Functions", "Pro Functions"};
			GetListViewDescripcion = new string[N_ELEMENTS_LVIEW] { "Show different simple chart types how lineals, bubbles or areas.", "Some charts like the Pyramid or Kagi. These have more customization and are more complex.",
								"CircularGauge provides a fully configurable and quick drawing circular gauge style.", "Show a Map series which is a collection of polygon shapes and differents world maps.", "Treemaps display hierarchical (tree-structured) data as a set of nested rectangles.", "Knob Gauge uses a needle pointer but it also has a cap of larger radius that imitates a gear.",
								"The Clock series displays live watches. Multiple configuration parameters are available. ", "Organizational Charts display elements in hierarchical structures, such as Company and  Employers.", "Show a numeric data using a gauge.", "Dispay numeric data using a linear element.",
								"Month-View calendar for selecting dates in order to display different activities.", //"A sparkline is a very small line chart, typically drawn without axes or coordinates to show variation about a measurement.", 
                                "Display different texts in a cloud with a font whose colour and size is relative to that frequency.",
								"Some functions to charts which are considered basics.", "More complicated functions for statistical sectors for example financial field." };

			// Line Gráfico ----------- https://fotos00.diarioinformacion.com/mmp/2017/12/12/690x278/nacimientos-defunciones-espana.jpg

			GetValorLine1 = new double[8] { 233737 / 1000, 230568 / 1000, 224782 / 1000, 207391 / 1000, 208375 / 1000, 204910 / 1000, 200255 / 1000, 187703 / 1000 };
			GetValorLine2 = new double[8] { 194924 / 1000, 198773 / 1000, 217634 / 1000, 200491 / 1000, 204464 / 1000, 226190 / 1000, 210300 / 1000, 219835 / 1000 };
			GetValorLineX = new double[8] { 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017 };

			// Column Bar Gráfico -------- http://halweb.uc3m.es/esp/Personal/personas/jmmarin/esp/LibroElec/Tema1/diagra4.gif

			GetValorColumn1 = new double[3] { 4, 5, 7 };
			GetValorColumn2 = new double[3] { 7, 9, 6 };
			GetValorColumn3 = new double[3] { 3, 7, 4 };
			GetValorColumnX = new string[3] { "Single", "Married", "Widower" };

			// { CHART GENERAL } --------- https://3.bp.blogspot.com/-PrP-zyPrJ-k/VsEbKmETqTI/AAAAAAAAFTI/vZ0OmwNUzzs/s1600/sueldos-espa%25C3%25B1a.jpg

			//GetValorG = new double[4] { 19735, 19767, 19537, 19514 };
			//GetValorG = new double[4] { 25479, 25667, 25682, 25675 };
			//GetValorG = new double[4] { 2010, 2011, 2012, 2013 };

			// Area Gráfico ----------- https://uploadgerencie.com/medios/grafico-area-100-apilada-7.gif

			GetValorArea1 = new double[5] { 120, 110, 125, 115, 128 };
			GetValorArea2 = new double[5] { 95, 105, 95, 100, 80 };
			GetValorAreaX = new string[5] { "January", "February", "March", "April", "May" };

			// Bubble Gráfico --------- https://support.office.com/es-es/article/presentar-los-datos-en-un-gráfico-de-burbuja-424d7bda-93e8-4983-9b51-c766f3e330d9#ID0EAABAAA=Office_2007_–_2010 + INVENTADO

			GetValorBubble1 = new double[6] { 34000 / 1000, 20000 / 1000, 18200 / 1000, 60000 / 1000, 24400 / 1000, 32000 / 1000 };
			GetValorBubbleX = new double[6] { 8, 2, 16, 19, 22, 24 };

			// Pie Gráfico ------------ http://www.tumaestroweb.com/wp-content/uploads/chart_google-300x247.jpg

			GetValorPie1 = new double[5] { 37.5, 12.5, 12.5, 25, 12.5 };

			// Horizontal Area Gráfico -------- https://es.wikipedia.org/wiki/Anexo:Países_y_territorios_dependientes_por_población && http://www.cyber-wit.com/onlineHelp/Images/horizontalArea.png

			GetValorHorizArea1 = new double[5] { 83047000 / 1000, 65099000 / 1000, 37170000 / 1000, 46618000 / 1000, 66736000 / 1000 };
			GetValorHorizAreaX = new string[5] { "Germany", "France", "Canada", "Spain", "UK" };

			// Horizontal Bar Gráfico --------- https://www.ielts-mentor.com/images/writingsamples/ielts-bar-graph-57-visitors-to-three-london-museums.jpg

			GetValorHorizBar1 = new double[4] { 8, 9, 11, 11 };
			GetValorHorizBar2 = new double[4] { 6, 6, 7, 12 };
			GetValorHorizBarX = new double[4] { 2008, 2009, 2010, 2011 };

			// Horizontal Line Gráfico -------- http://www.mathscore.com/math/free/lessons/mathTips/lineGraph.gif

			GetValorHorizLine1 = new double[7] { 40, 50, 70, 120, 130, 130, 140 };
			GetValorHorizLine2 = new double[7] { 20, 35, 55, 85, 70, 90, 105 };
			GetValorHorizLineY = new double[7] { 2000, 2001, 2002, 2003, 2004, 2005, 2006 };

			// Donut Gráfico ------------------ http://2.bp.blogspot.com/-RP6oJ0azN7g/V-09-UXRlgI/AAAAAAAAA5Q/WMUD4uzaOYsPgb9cKB1IUuktYD_b-rqfgCK4B/s1600/Screen%2BShot%2B2016-09-28%2Bat%2B17.59.06.png

			GetValorDonut1 = new double[4] { 7, 14, 36, 43 };

			// Gantt Gráfico ------------------ Steema DEMO

			GetValorGantt1 = new string[7] { "Prototyping", "Design", "Development", "Testing", "Debugging", "Sales", "Marketing", };

            GetValorTimeSGantt = new DateTime[7] { DateTime.ParseExact("01/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("07/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("15/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("04/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("14/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("24/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                                                   DateTime.ParseExact("26/06/2018", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) };

            GetValorTimeEGantt = new DateTime[7] { new DateTime(2018, 6, 5, 0, 0, 0), new DateTime(2018, 6, 13, 0, 0, 0), new DateTime(2018, 6, 23, 0, 0, 0),new DateTime(2018, 6, 12, 0, 0, 0),
                                                   new DateTime(2018, 6, 20, 0, 0, 0), new DateTime(2018, 7, 1, 0, 0, 0), new DateTime(2018, 7, 1, 0, 0, 0) };

			// Shape Gráfico ------------------ INVENTADO

			GetValorShape1X = new double[2] { 0, 100 };
			GetValorShape2X = new double[2] { 0, 100 };
			GetValorShape3X = new double[2] { 0, 100 };
			GetValorShape4X = new double[2] { 0, 100 };
			GetValorShape1Y = new double[2] { 0, 100 };
			GetValorShape2Y = new double[2] { 0, 100 };
			GetValorShape3Y = new double[2] { 0, 100 };
			GetValorShape4Y = new double[2] { 0, 100 };

			// Point (Scatter) Gráfico -------- INVENTADO

			GetValorPointScatter1 = new double[12] { 3, 5, 6, 3, 1, 5, 6, 3, 2, 5, 8, 9 };
			GetValorPointScatter2 = new double[10] { 5, 6, 7, 10, 12, 12, 9, 7, 8, 6 };
			GetValorPointScatter3 = new double[11] { 1, 3, 5, 6, 8, 12, 13, 7, 5, 4, 3 };
			GetValorPointScatter4 = new double[9] { 4, 5, 7, 9, 6, 4, 5, 4, 3 };

			// InterpolatingLine Gráfico ------ INVENTADO

			GetValorInterpolLine1 = new double[50] { 45, 46, 49, 50, 54, 48, 45, 50, 53, 56, 58, 57, 56, 53, 59, 56, 59, 62, 63, 67, 64, 61, 66, 69, 71, 74, 77, 73, 75, 79, 73, 68, 62, 58, 52, 56, 50, 47, 42, 44, 48, 40, 37, 35, 33, 30, 34, 32, 36, 38 };

			// ConeBar Gráfico ---------------- INVENTADO

			GetValorConeBar1 = new double[4] { 6, 8, 11, 9 };
			GetValorConeBarX = new string[4] { "2014", "2015", "2016", "2017" };

			// BarGradient Gráfico ------------ http://www.ari-soft.com/docs/arismartcontent/v2/html/lib/column_chart.jpg

			GetValorGradientBar1 = new double[] { 190, 160, 40 };
			GetValorGradientBar2 = new double[] { 120, 90, 20 };
			GetValorGradientBarX = new string[] { "Work", "Hobbies", "Food" };

			// Bubble Transparency Gráfico ----- INVENTADO

			GetValorBubbleTrans1 = new double[7] { 30, 40, 60, 100, 24, 75, 13 };
			GetValorBubbleTransX = new double[7] { 3, 5, 7, 9, 6, 14, 2 };

			// MultiPie Gráfico ---------------- INVENTADO

			GetValorMultiPie1 = new double[3] { 2, 1, 1 };
			GetValorMultiPie2 = new double[3] { 2, 3, 1 };
			GetValorMultiPie3 = new double[3] { 1, 0, 3 };
			GetValorMultiPie4 = new double[3] { 2, 2, 1 };
			GetValorMultiPieItems = new string[3] { "Cars", "Books", "Phones" };

			// SemiPie Gráfico ----------------- INVENTADO

			GetValorSemiPie1 = new double[4] { 35, 15, 20, 30 };

			// Arrow Gráfico ------------------- DE VUESTROS DATOS MODO RANDOM

			GetValorArrow1X = new double[10] { 0, 2.223, 2.373, 5.138, 5.475, 5.53, 5.582, 6.89, 1, 9.036 };
			GetValorArrow1Y = new double[10] { 510.849, 117.205, 1063.087, 838.372, 152.798, 843.537, 1000.023, 514.478, 800, 36.2 };
			GetValorArrow1endX = new double[10] { 6.496, 5.141, 3.58, 6.845, 10.428, 10.364, 7.954, 10.267, 5, 11.062 };
			GetValorArrow1endY = new double[10] { 657.808, 538.49, 633.787, 122.063571, 875.978, 1100.368257, 1382.93, 180.476523, 1100, 814.116 };

            // Polar Gráfico ------------------ INVENTADO

            GetValorPolar1 = new double[,] { { 24, 312 }, { 20, 581 }, { 72, 698 }, { 96, 68 }, { 160, 707 }, { 144, 467 },
                                                 { 168, 769 }, { 192, 494 }, { 216, 543 }, { 240, 294 }, { 264, 830 }, { 270, 856 },
                                                 { 312, 251 }, { 336, 700 }, { 360, 476 } };

            GetValorPolar2 = new double[,] { { 18, 933 }, { 36, 854 }, { 54, 353 }, { 72, 628 }, { 90, 911 }, { 108, 492 }, { 126, 953 },
                                             { 144, 667 }, { 162, 145 }, { 180, 927 }, { 198, 690 }, { 216, 357 }, { 234, 532 },
                                             { 252, 782 }, { 270, 508 }, { 288, 366 }, { 306, 646 }, {324, 346 }, { 360, 291 } };

            // Pyramid Gráfico ---------------- INVENTADO

            GetValorPyramidX = new double[5] { 0, 1, 2, 3, 4 };
			GetValorPyramidY = new double[5] { 100, 100, 150, 150, 200 };
			GetValorPyramidName = new string[5] { "Slave", "Peasants", "Low nobility", "High nobility", "King" };

			// Candle Gráfico ---------------- INVENTADO

			GetValorCandleTime = new DateTime[6] { DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), DateTime.Now.AddDays(5) };
			GetValorsCandle = new double[6, 4] {

					{ 500, 515, 495, 510 },
					{ 530, 538, 503, 510 },
					{ 504, 531, 496, 524 },
					{ 502, 517, 482, 488 },
					{ 460, 488, 450, 479 },
					{ 521, 530, 497, 511 }

			};

			// Kagi Gráfico ----------------- INVENTADO

			GetValorKagiTime = GetValorCandleTime;
			GetValorsKagi = new double[6, 4]
			{

					{ 231, 232, 228, 230 },
					{ 226, 232, 226, 231 },
					{ 218, 229, 214, 224 },
					{ 234, 237, 217, 221 },
					{ 239, 244, 225, 230 },
					{ 225, 245, 221, 240 }

			};

			// Histogram Gráfico ------------ INVENTADO

			GetValorsHistogram = new double[12, 2]
			{

				{ 0, 12 }, { 1, 27 }, { 2, 33 }, { 3, 22 }, { 4, 17 }, { 5, 25 },
				{ 6, 24 }, { 7, 11 }, { 8, 19 }, { 9, 28 }, { 10, 26 }, { 11, 16 }


			};

			// Error Gráfico --------------- INVENTADO

			GetValorErrorLabels = new string[6] { "A", "B", "C", "D", "E", "F" };
			GetValorsError = new double[6, 3]
			{

				{ 0, 30, 20 }, { 1, 80, 25 }, {2, 40, 16 },
				{ 3, 80, 9}, { 4, 44, 12 }, { 5, 35, 19 }

			};

			// ErrorBar Gráfico ------------- INVENTADO

			GetValorsErrorBar = new double[6, 3]
			{

				{ 0, 100, 20  }, { 1, -70, 40 }, { 2, 80, 15 },
				{ 3, -50, 25 }, { 4, -95, 35 }, { 5, 30, 10 }

			};

			// Funnel Gráfico --------------- INVENTADO

			GetValorFunnelLabels = new string[4] { "Visit", "Sign-up", "Selection", "Purchase" };
			GetValorsFunnel = new double[4, 2]
			{

					{ 80, 110 },
					{ 200, 120 },
					{ 110, 150 },
					{ 130, 55 }

			};

			// TreeMap 1 Gráfico -------------- http://irc.cs.sdu.edu.cn/vis/course/assignment/4.png

			GetValorTreeMap1Type1 = new double[15] { 14658, 5459, 3316, 2583, 2247,	2055, 1465, 1410, 5878, 2090, 1574, 1538, 1236, 1039, 1007 };
			GetValorTreeMap2Type1 = new double[15] { 1, 2, 3, 4, 2, 3, 4, 5, 1, 2, 3, 4, 5, 6, 7 };
			GetValorTreeMapXType1 = new string[15] { "United States", "Japan", "Germany", "France", "United Kingdom", "Italy", "Russia", "Spain", "Republic of China", "Brazil", "Canada", "India", "Australia", "Mexico", "South Korea" };

			// CompassKnob Gráfico ------------- https://png.pngtree.com/element_origin_min_pic/16/12/04/421625753862b0a64e4d3e16ea23fea9.jpg

			GetCompassAxisLabels = new string[8] { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };

			// Add Standard Function Gráfico --- INVENTADO

			GetValorStdAdd1 = new double[4] { 250, 320, 400, 350 };

			// Subs Standard Function Gráfico --- INVENTADO

			GetValorStdSubs1 = new double[3] { 28, 20, 26 };
			GetValorStdSubs2 = new double[3] { 21, 11, 6 };

			// Mult Standard Function Gráfico --- INVENTADO

			GetValorStdMult1 = new double[4] { 3, 2, 4, 2 };
			GetValorStdMult2 = new double[4] { 2, 4, 3, 2 };

			// Div Standard Function Gráfico --- INVENTADO

			GetValorStdDiv1 = new double[4] { 5, 3, 5, 10 };
			GetValorStdDiv2 = new double[4] { 8, 2, 3, 4 };

			// Count Standard Function Gráfico --- INVENTADO

			GetValorStdCount1 = new double[5] { 3, 6, 4, 5, 7 };

			// Average Standard Function Gráfico --- INVENTADO

			GetValorStdAvg1 = new double[6] { 120, 164, 202, 185, 147, 128 };

			// High Standard Function Gráfico --- INVENTADO

			GetValorStdHigh1 = new double[6] { 14, 22, 19, 25, 17, 23 };

			// Low Standard Function Gráfico --- INVENTADO

			GetValorStdLow1 = new double[6] { 13, 17, 20, 15, 11, 14 };

			// Median Standard Function Gráfico --- INVENTADO

			GetValorStdMedian1 = new double[11] { 130, 165, 177, 162, 155, 184, 190, 220, 157, 179, 194 };

			// Percent Change Standard Function Gráfico --- INVENTADO

			GetValorStdPercent1 = new double[20] { 300, 310, 323, 337, 357, 380, 390, 380, 357, 350, 343, 340, 330, 320, 310, 300, 294, 290, 294, 300 };

			// Valores de les colores de las palettes

			GetPaletteBasic = new Color[8] { Color.FromRgb(100, 208, 218), Color.FromRgb(224,73,84), Color.FromRgb(255,202,90), Color.FromRgb(147,186,15), Color.FromRgb(51,177,227), Color.FromRgb(254, 145, 42), Color.FromRgb(4,82,129), Color.FromRgb(139,16,62) };
			GetPaletteDifferent = new Color[8] { Color.FromRgb(45,204,112), Color.FromRgb(53,152,219), Color.FromRgb(174,122,196), Color.FromRgb(27,188,155), Color.FromRgb(52,73,94), Color.FromRgb(241,196,15),
															Color.FromRgb(232,76,61), Color.FromRgb(126,140,141), };

			GetPaletteFun = new Color[8] { Color.FromRgb(239, 139, 44), Color.FromRgb(15, 91, 120), Color.FromRgb(235, 200, 68),
						Color.FromRgb(92, 167, 147),  Color.FromRgb(127, 139, 140), Color.FromRgb(141, 56, 171),
						Color.FromRgb(19, 149, 186), Color.FromRgb(192, 46, 29) };

	}
	}
}
