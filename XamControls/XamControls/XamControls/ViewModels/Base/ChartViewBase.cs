using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Steema.TeeChart;
using Xamarin.Forms;
using Steema.TeeChart.Styles;
using XamControls.Variables;
using Steema.TeeChart.Drawing;
using XamControls.Styles;
using XamControls.Charts.Standard;
using XamControls.Charts.TreeMap;
using XamControls.Charts.CircularGauges;
using XamControls.Charts.Maps;
using XamControls.Charts.Pro;
using XamControls.Charts.Knob_Gauge;
using XamControls.Charts.Clock;
using XamControls.Charts.Calendar;
using XamControls.Charts.Numeric_Gauge;
using XamControls.Charts.Linear_Gauge;
using XamControls.Charts.Organizational;
using XamControls.Charts.TagCloud;
using XamControls.Charts.Functions.Standard;
using XamControls.Charts.Functions.Pro.Extended;
using XamControls.Charts.Functions.Pro.Financial;
using Steema.TeeChart.Export;
using Steema.TeeChart.Functions;
using XamControls.Charts.Functions.Pro.Statistical;
using System.Runtime.CompilerServices;
using XamControls.Utils;

namespace XamControls.ViewModels.Base
{

    public class ChartViewBase : ChartView
    {

		private Variables.Variables var = new Variables.Variables();
		public Themes themes;
		private ChartViewRender BaseChart;

		// 
		// {{{ Tipos de "Charts" }}}
		//

		// STANDARD
		private LineChart lineChart;
		private ColumnBarChart columnBarChart;
		private AreaChart areaChart;
		private BubbleChart bubbleChart;
		private PieChart pieChart;
		private FastLineChart fastLineChart;
		private HorizontalAreaChart horizAreaChart;
		private HorizontalBarChart horizBarChart;
		private HorizontalLineChart horizLineChart;
		private DonutChart donutChart;
		private GanttChart gantChart;
		private ShapeChart shapeChart;
		private Point_ScatterChart point_scatterChart;
		private InterpolatingChartFeatures interpolatingChart;
		private BarStylesChartFeatures coneBarChart;
		private ZoomPanningChartFeatures zoomPaningArrowChart;
		private GradientBarChartFeatures gradientBarChart;
		private BubbleTransparencyChartFeatures bubbleTranspChart;
		private FLineRealTimeChartFeatures fLineRealTimeChart;
		private StackAreaChartFeatures stackAreaChart;
		private MultiplePiesChartFeatures multiPiesChart;
		private Semi_PieChartFeatures semiPieChart;
		private Semi_DonutChartFeatures semiDonutChart;
		// PRO
		private ArrowChart arrowChart;
		private PolarChart polarChart;
		private RadarChart radarChart;
		private PyramidChart pyramidChart;
		private CandleChart candleChart;
		private HistogramChart histogramChart;
		private ErrorChart errorChart;
		private ErrorBarChart errorBarChart;
		private FunnelChart funnelChart;
		private SmithChart smithChart;
		private BezierChart bezierChart;
		private HighLowChart highLowChart;
        private SpeedTimeChart realTimeChart;
        private WaterfallChart waterfallChart;
        private VolumeChart volumeChart;
        private ColorGridChart colorGridChart;
        private PolarBarChart polarBarChart;
        private InvertedPyramidChart invertedPyramidChart;
        private HorizHistogramChart horizHistogramChart;
		// CIRCULAR GAUGES
		private BasicCircularGaugeChart basicCircGaugeChart;
		private CarFuelChart carFuelChart;
		private CustomPointerChart custPointerGaugeChart;
		private AccelerationCircularGaugeChart accelerationCircularGaugeChart;
		// MAP
		private MapGISChart mapGSIChart;
		private WorldMapChart worldMapChart;
		// TREE MAP
		private TreeMapChart treeMapChart;
		// KNOB GAUGE
		private BasicKnobGaugeChart basicKnobGaugeChart;
		private TemperatureKnobChart temperatureKnobChart;
		private CompassChart compassChart;
		// CLOCK
		private BasicClockChart basicClockChart;
        private CustomClockChart customClockChart;
		// ORGANIZATIONAL
		private BasicOrganizationalChart basicOrganizationalChart;
		// NUMERIC GAUGE
		private NumericGaugeChart numericGaugeChart;
		// LINEAR GAUGE
		private LinearGaugeChart linearGaugeChart;
		private ScalesLinearChart scalesLinearChart;
		private MoreLinesLinearChart moreLinesLinearChart;
		private BatteryLinearChart batteryLinearChart;
		// CALENDAR
		private BasicCalendarChart basicCalendarChart;
		private SpecialDatesChart specialDatesChart;
		// TAGCLOUD
		private TagCloudChart tagCloudChart;
		// STANDARD FUNCTIONS
		private AddStdFunctionsChart addStdFunctionsChart;
		private SubtStdFunctionsChart subtStdFunctionsChart;
		private MultStdFunctionsChart multStdFunctionsChart;
		private DivStdFunctionsChart divStdFunctionsChart;
		private CountStdFunctionsChart countStdFunctionsChart;
		private AvgStdFunctionsChart avgStdFunctionsChart;
		private HighStdFunctionsChart highStdFunctionsChart;
		private LowStdFunctionsChart lowStdFunctionsChart;
		private MedianStdFunctionsChart medianStdFunctionsChart;
		private PercentStdFunctionsChart percentStdFunctionsChart;
		// PRO FUNCTIONS
		// -- FINANCIAL
		private ADXProFunctionChart adxProFunctionChart;
		private ACProFunctionChart acProFunctionChart;
		private AlligatorProFunctionChart alligatorProFunctionChart;
		private AOProFunctionChart aoProFunctionChart;
		private ATRProFunctionChart atrProFunctionChart;
		private BollingerProFunctionChart bollingerProFunctionChart;
		private CCIProFunctionChart cciProFunctionChart;
		private CLVProFunctionChart clvProFunctionChart;
		private CompressionOHLCProFunctionChart compressionOHLCProFunctionChart;
		private ExpAverageProFunctionChart expAverageProFunctionChart;
		private ExpMovAverageProFunctionChart expMovAverageProFunctionChart;
		private GatorOscillProFunctionChart gatorOscillProFunctionChart;
		private KurtosisProFunctionChart kurtosisProFunctionChart;
		private MACDProFunctionChart macdProFunctionChart;
		private MomentumProFunctionChart momentumProFunctionChart;
		private MomentumDivProFunctionChart momentumDivProFunctionChart;
		private MoneyFlowProFunctionChart moneyFlowProFunctionChart;
		private OBVProFunctionChart obvProFunctionChart;
		private PVOProFunctionChart pvoProFunctionChart;
		private RSIProFunctionChart rsiProFunctionChart;
		private RVIProFunctionChart rviProFunctionChart;
		private SlopeProFunctionChart slopeProFunctionChart;
		private SmoothMovAvgProFunctionChart smoothMovAvgProFunctionChart;
		private SARProFunctionChart sarProFunctionChart;
		// -- EXTENDED
		private CrossPointsProFunctionsChart crossPointsProFunctionsChart;
		private CorrelationProFunctionChart correlationProFunctionChart;
		private CumulativeProFunctionChart cumulativeProFunctionChart;
		private CalculateEventProFunctionChart calculateEventProFunctionChart;
		private ExponentialTrendProFunctionChart exponentialTrendProFunctionChart;
		private FittingProFunctionChart fittingProFunctionChart;
		private PerformanceProFunctionChart performanceProFunctionChart;
		private PerimeterProFunctionChart perimeterProFunctionChart;
		private FindCoeffProFunctionChart findCoeffProFunctionChart;
		private DownSamplingProFunctionChart downSamplingProFunctionChart;
		private RMSProFunctionChart rmsProFunctionChart;
		private SmoothingProFunctionChart smoothingProFunctionChart;
		private StdDeviationProFunctionChart stdDeviationProFunctionChart;
		private TrendlineProFunctionChart trendlineProFunctionChart;
		private VarianceProFunctionChart varianceProFunctionChart;
		// -- STATISTICAL
		private SPCProFunctionChart spcProFunctionChart;
		private CumulativeHistogProFunctionChart cumulativeHistogProFunctionChart;
		private SkewnessProFunctionChart skewnessProFunctionChart;

		// Constructor
		public ChartViewBase(Button button)
		{

				BaseChart = new ChartViewRender();
				InitializeChart();
				CrearChart(button);

		}

		public ChartViewBase(string title)
		{

			BaseChart = new ChartViewRender();
			InitializeChart();
			CrearChart(new Button { Text = title });

		}

		public ChartViewBase(string title, Label label)
		{

			BaseChart = new ChartViewRender();
			InitializeChart();
			CrearChart(new Button { Text = title }, label);

		}

		// Bases del "Chart"		
		private void InitializeChart()
		{

				themes = new Themes(BaseChart);
				Themes.valorTheme = 1;
				Themes.AplicarTheme(BaseChart);

		}

		// Acción que determina que clase utilitzar para crear los "Charts"
		public void CrearChart(Button button, Label label = null)
		{

				ClearLastElements();

				BaseChart.Chart.Series.RemoveAllSeries();

                //Themes.RefreshTheme();
                Themes.BasicAxes(BaseChart.Chart.Axes.Left, BaseChart.Chart.Axes.Right);
                Themes.AplicarTheme(BaseChart);

                switch (button.Text)
                {

                    case "Line":
                        lineChart = new LineChart(BaseChart);
                        break;

                    case "Column Bar":
                        columnBarChart = new ColumnBarChart(BaseChart);
                        break;

                    case "Area":
                        areaChart = new AreaChart(BaseChart);
                        break;

                    case "Pie":
                        pieChart = new PieChart(BaseChart);
                        break;

                    case "Fast Line":
                        fastLineChart = new FastLineChart(BaseChart);
                        break;

                    case "Horizontal Area":
                        horizAreaChart = new HorizontalAreaChart(BaseChart);
                        break;

                    case "Horizontal Bar":
                        horizBarChart = new HorizontalBarChart(BaseChart);
                        break;

                    case "Horizontal Line":
                        horizLineChart = new HorizontalLineChart(BaseChart);
                        break;

                    case "Donut":
                        donutChart = new DonutChart(BaseChart);
                        break;

                    case "Bubble":
                        bubbleChart = new BubbleChart(BaseChart);
                        break;

                    case "Shape":
                        shapeChart = new ShapeChart(BaseChart);
                        break;

                    case "Gantt":
                        gantChart = new GanttChart(BaseChart);
                        break;

                    case "Point/Scatter":
                        point_scatterChart = new Point_ScatterChart(BaseChart);
                        break;

                    case "Interpolating Line":
                        interpolatingChart = new InterpolatingChartFeatures(BaseChart);
                        break;

                    case "Bar Styles":
                        coneBarChart = new BarStylesChartFeatures(BaseChart);
                        break;

                    case "Zoom & Panning":
                        zoomPaningArrowChart = new ZoomPanningChartFeatures(BaseChart);
                        break;

                    case "Bar Gradient":
                        gradientBarChart = new GradientBarChartFeatures(BaseChart);
                        break;

                    case "Bubble Transparent":
                        bubbleTranspChart = new BubbleTransparencyChartFeatures(BaseChart);
                        break;

                    case "Real Time":
                        fLineRealTimeChart = new FLineRealTimeChartFeatures(BaseChart);
                        break;

                    case "Stack Area":
                        stackAreaChart = new StackAreaChartFeatures(BaseChart);
                        break;

                    case "Multiple Pies":
                        multiPiesChart = new MultiplePiesChartFeatures(BaseChart);
                        break;

                    case "Semi-Pie":
                        semiPieChart = new Semi_PieChartFeatures(BaseChart);
                        break;

                    case "Semi-Donut":
                        semiDonutChart = new Semi_DonutChartFeatures(BaseChart);
                        break;

                    case "Arrow":
                        arrowChart = new ArrowChart(BaseChart);
                        break;

                    case "Polar":
                        polarChart = new PolarChart(BaseChart);
                        break;

                    case "Radar":
                        radarChart = new RadarChart(BaseChart);
                        break;

                    case "Pyramid":
                        pyramidChart = new PyramidChart(BaseChart);
                        break;

                    case "Candle":
                        candleChart = new CandleChart(BaseChart);
                        break;

                    case "Histogram":
                        histogramChart = new HistogramChart(BaseChart);
                        break;

                    case "Error":
                        errorChart = new ErrorChart(BaseChart);
                        break;

                    case "ErrorBar":
                        errorBarChart = new ErrorBarChart(BaseChart);
                        break;

                    case "Funnel":
                        funnelChart = new FunnelChart(BaseChart);
                        break;

                    case "Smith":
                        smithChart = new SmithChart(BaseChart);
                        break;

                    case "Bezier":
                        bezierChart = new BezierChart(BaseChart);
                        break;

                    case "HighLow":
                        highLowChart = new HighLowChart(BaseChart);
                        break;

                    case "Speed Time":
                        realTimeChart = new SpeedTimeChart(BaseChart);
                        break;

                    case "Waterfall":
                        waterfallChart = new WaterfallChart(BaseChart);
                        break;

                    case "Volume":
                        volumeChart = new VolumeChart(BaseChart);
                        break;

                    case "Color Grid":
                        colorGridChart = new ColorGridChart(BaseChart);
                        break;

                    case "Polar Bar":
                        polarBarChart = new PolarBarChart(BaseChart);
                        break;

                    case "Inverted Pyramid":
                        invertedPyramidChart = new InvertedPyramidChart(BaseChart);
                        break;

                    case "Horizontal Histogram":
                        horizHistogramChart = new HorizHistogramChart(BaseChart);
                        break;

                    case "Circular Gauge":
                        basicCircGaugeChart = new BasicCircularGaugeChart(BaseChart);
                        break;

                    case "Car Fuel":
                        carFuelChart = new CarFuelChart(BaseChart);
                        break;

                    case "Custom Hand":
                        custPointerGaugeChart = new CustomPointerChart(BaseChart);
                        break;

                    case "Acceleration":
                        accelerationCircularGaugeChart = new AccelerationCircularGaugeChart(BaseChart);
                        break;

                    case "Knob Gauge":
                        basicKnobGaugeChart = new BasicKnobGaugeChart(BaseChart);
                        break;

                    case "Temperature Knob":
                        temperatureKnobChart = new TemperatureKnobChart(BaseChart);
                        break;

                    case "Compass":
                        try { compassChart = new CompassChart(BaseChart); }
                        catch(Exception e) {  }
                        break;

                    case "Map GIS":
                        mapGSIChart = new MapGISChart(BaseChart);
                        break;

                    case "World Map":
                        worldMapChart = new WorldMapChart(BaseChart);
                        break;

                    case "TreeMap":
                        treeMapChart = new TreeMapChart(BaseChart);
                        break;

                    case "Basic Clock":
                        basicClockChart = new BasicClockChart(BaseChart);
                        break;

                    case "Custom Clock":
                        customClockChart = new CustomClockChart(BaseChart);
                        break;

                    case "Organizational Chart":
                        basicOrganizationalChart = new BasicOrganizationalChart(BaseChart);
                        break;

                    case "Numeric Gauge":
                        numericGaugeChart = new NumericGaugeChart(BaseChart);
                        break;

                    case "Linear Gauge":
                        linearGaugeChart = new LinearGaugeChart(BaseChart);
                        break;

                    case "Scales":
                        scalesLinearChart = new ScalesLinearChart(BaseChart);
                        break;

                    case "SubLines":
                        moreLinesLinearChart = new MoreLinesLinearChart(BaseChart);
                        break;

                    case "Mobile Battery":
                        batteryLinearChart = new BatteryLinearChart(BaseChart);
                        break;

                    case "Basic Calendar":
                        basicCalendarChart = new BasicCalendarChart(BaseChart, label);
                        break;

                    case "Special Dates":
                        specialDatesChart = new SpecialDatesChart(BaseChart, label);
                        break;

                    case "TagCloud":
                        tagCloudChart = new TagCloudChart(BaseChart);
                        break;

                    case "Add":
                        addStdFunctionsChart = new AddStdFunctionsChart(BaseChart);
                        break;

                    case "Subtract":
                        subtStdFunctionsChart = new SubtStdFunctionsChart(BaseChart);
                        break;

                    case "Multiply":
                        multStdFunctionsChart = new MultStdFunctionsChart(BaseChart);
                        break;

                    case "Divide":
                        divStdFunctionsChart = new DivStdFunctionsChart(BaseChart);
                        break;

                    case "Count":
                        countStdFunctionsChart = new CountStdFunctionsChart(BaseChart);
                        break;

                    case "Average":
                        avgStdFunctionsChart = new AvgStdFunctionsChart(BaseChart);
                        break;

                    case "High":
                        highStdFunctionsChart = new HighStdFunctionsChart(BaseChart);
                        break;

                    case "Low":
                        lowStdFunctionsChart = new LowStdFunctionsChart(BaseChart);
                        break;

                    case "Median Function":
                        medianStdFunctionsChart = new MedianStdFunctionsChart(BaseChart);
                        break;

                    case "Percent Change":
                        percentStdFunctionsChart = new PercentStdFunctionsChart(BaseChart);
                        break;

                    case "ADX":
                        adxProFunctionChart = new ADXProFunctionChart(BaseChart);
                        break;

                    case "AC":
                        acProFunctionChart = new ACProFunctionChart(BaseChart);
                        break;

                    case "Alligator":
                        alligatorProFunctionChart = new AlligatorProFunctionChart(BaseChart);
                        break;

                    case "AO":
                        aoProFunctionChart = new AOProFunctionChart(BaseChart);
                        break;

                    case "ATR":
                        atrProFunctionChart = new ATRProFunctionChart(BaseChart);
                        break;

                    case "Bollinger Bands":
                        bollingerProFunctionChart = new BollingerProFunctionChart(BaseChart);
                        break;

                    case "CCI":
                        cciProFunctionChart = new CCIProFunctionChart(BaseChart);
                        break;

                    case "CLV":
                        clvProFunctionChart = new CLVProFunctionChart(BaseChart);
                        break;

                    case "Compression OHLC":
                        compressionOHLCProFunctionChart = new CompressionOHLCProFunctionChart(BaseChart);
                        break;

                    case "Exp. Average":
                        expAverageProFunctionChart = new ExpAverageProFunctionChart(BaseChart);
                        break;

                    case "Exp. Moving Average":
                        expMovAverageProFunctionChart = new ExpMovAverageProFunctionChart(BaseChart);
                        break;

                    case "Gator Oscillator":
                        gatorOscillProFunctionChart = new GatorOscillProFunctionChart(BaseChart);
                        break;

                    case "Kurtosis":
                        kurtosisProFunctionChart = new KurtosisProFunctionChart(BaseChart);
                        break;

                    case "MACD":
                        macdProFunctionChart = new MACDProFunctionChart(BaseChart);
                        break;

                    case "Momentum":
                        momentumProFunctionChart = new MomentumProFunctionChart(BaseChart);
                        break;

                    case "Momentum Div.":
                        momentumDivProFunctionChart = new MomentumDivProFunctionChart(BaseChart);
                        break;

                    case "Money Flow":
                        moneyFlowProFunctionChart = new MoneyFlowProFunctionChart(BaseChart);
                        break;

                    case "OBV":
                        obvProFunctionChart = new OBVProFunctionChart(BaseChart);
                        break;

                    case "PVO":
                        pvoProFunctionChart = new PVOProFunctionChart(BaseChart);
                        break;

                    case "RSI":
                        rsiProFunctionChart = new RSIProFunctionChart(BaseChart);
                        break;

                    case "RVI":
                        rviProFunctionChart = new RVIProFunctionChart(BaseChart);
                        break;

                    case "Slope":
                        slopeProFunctionChart = new SlopeProFunctionChart(BaseChart);
                        break;

                    case "Smoothed Mov Avg":
                        smoothMovAvgProFunctionChart = new SmoothMovAvgProFunctionChart(BaseChart);
                        break;

                    case "S.A.R.":
                        sarProFunctionChart = new SARProFunctionChart(BaseChart);
                        break;

                    case "Cross Point":
                        crossPointsProFunctionsChart = new CrossPointsProFunctionsChart(BaseChart);
                        break;

                    case "Correlation":
                        correlationProFunctionChart = new CorrelationProFunctionChart(BaseChart);
                        break;

                    case "Cumulative":
                        cumulativeProFunctionChart = new CumulativeProFunctionChart(BaseChart);
                        break;

                    case "Custom Function":
                        calculateEventProFunctionChart = new CalculateEventProFunctionChart(BaseChart);
                        break;

                    case "Exponential Trend":
                        exponentialTrendProFunctionChart = new ExponentialTrendProFunctionChart(BaseChart);
                        break;

                    case "Fitting Linearizable":
                        fittingProFunctionChart = new FittingProFunctionChart(BaseChart);
                        break;

                    case "Performance":
                        performanceProFunctionChart = new PerformanceProFunctionChart(BaseChart);
                        break;

                    case "Perimeter":
                        perimeterProFunctionChart = new PerimeterProFunctionChart(BaseChart);
                        break;

                    case "Finding Coefficients":
                        findCoeffProFunctionChart = new FindCoeffProFunctionChart(BaseChart);
                        break;

                    case "Down Sampling":
                        downSamplingProFunctionChart = new DownSamplingProFunctionChart(BaseChart);
                        break;

                    case "RMS":
                        rmsProFunctionChart = new RMSProFunctionChart(BaseChart);
                        break;

                    case "Smoothing Function":
                        smoothingProFunctionChart = new SmoothingProFunctionChart(BaseChart);
                        break;

                    case "Standard Deviation":
                        stdDeviationProFunctionChart = new StdDeviationProFunctionChart(BaseChart);
                        break;

                    case "Trendline":
                        trendlineProFunctionChart = new TrendlineProFunctionChart(BaseChart);
                        break;

                    case "Variance":
                        varianceProFunctionChart = new VarianceProFunctionChart(BaseChart);
                        break;

                    case "SPC":
                        spcProFunctionChart = new SPCProFunctionChart(BaseChart);
                        break;

                    case "Cumulative Histogram":
                        cumulativeHistogProFunctionChart = new CumulativeHistogProFunctionChart(BaseChart);
                        break;

                    case "Skewness":
                        skewnessProFunctionChart = new SkewnessProFunctionChart(BaseChart);
                        break;

                }

                Themes.AplicarOptions(BaseChart);

        }

        // Elimina todos los elementos de los antiguos charts
		public void ClearLastElements()
		{

				if (interpolatingChart != null) { interpolatingChart.RemCursorTool(); }
				if (pieChart != null) { pieChart.RemoveEvent(); }
				if (donutChart != null) { donutChart.RemoveEvent(); }
				if (coneBarChart != null) { coneBarChart.RemoveEvent(); }
				if (semiPieChart != null) { semiPieChart.RemoveEvent(); }
				if (semiDonutChart != null) { semiDonutChart.RemoveEvent(); }
				if (numericGaugeChart != null) { numericGaugeChart.RemoveMarkTool(); }
				if (batteryLinearChart != null) { batteryLinearChart.RemoveAnnoTool(); }
				if (temperatureKnobChart != null) { temperatureKnobChart.RemoveAnnoTool(); }
				if (compassChart != null) { compassChart.RemoveCompassEvent(); }
				if (fLineRealTimeChart != null) { fLineRealTimeChart.RemoveEvent(); }
                if (realTimeChart != null) { realTimeChart.RemoveEvent(); }
				if (errorBarChart != null) { errorBarChart.RemoveEvent(); }
				if (acProFunctionChart != null || adxProFunctionChart != null || aoProFunctionChart != null || atrProFunctionChart != null || 
					cciProFunctionChart != null || clvProFunctionChart != null)
				{

						BaseChart.Chart.Axes.Custom.RemoveAll();

				}
				if(compressionOHLCProFunctionChart != null) { compressionOHLCProFunctionChart.RemoveCompressionToolBarItem(); }
                if(accelerationCircularGaugeChart != null) { accelerationCircularGaugeChart.RemoveEvent(); }
                if(basicClockChart != null) { basicClockChart.RemoveTimer(); }
                if(customClockChart != null) { customClockChart.RemoveTimer(); }
                if(histogramChart != null) { histogramChart.RemoveEvent(); }
                if(spcProFunctionChart != null) { spcProFunctionChart.RemoveEvent(); }
                if(invertedPyramidChart != null) { invertedPyramidChart.Dispose(); }
 
		}

        public ChartViewRender GetChart { get { return BaseChart; } }
		public ChartViewRender SetChart { set { BaseChart = value; } }

	}
}
