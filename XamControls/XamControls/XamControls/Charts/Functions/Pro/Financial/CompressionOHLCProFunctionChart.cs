using Steema.TeeChart;
using Steema.TeeChart.Functions;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamControls.Styles;
using XamControls.Variables;

namespace XamControls.Charts.Functions.Pro.Financial
{
    public class CompressionOHLCProFunctionChart
    {

				private Candle candle;
				private Candle candleSource;
				private CompressOHLC compressOHLC;
				private Variables.Variables var;
				private Picker compressionPicker;
				private ChartView BaseChart;
				private ToolbarItem compressionToolBarItem;

				public CompressionOHLCProFunctionChart(ChartView BaseChart)
				{

						candle = new Candle();
						candleSource = new Candle();
						compressOHLC = new CompressOHLC();
						var = new Variables.Variables();
						this.BaseChart = BaseChart;

						Themes.CandleGodStyle(candle);

						BaseChart.Chart.Series.Add(candle);

						candleSource.FillSampleValues(15);

						candle.Function = compressOHLC;
						candle.DataSource = candleSource;

						compressOHLC.Period = 2;
						compressOHLC.Compress = CompressionPeriod.ocMonth;
						compressOHLC.Series = candleSource;

						BaseChart.Chart.Axes.Left.Automatic = true;
						BaseChart.Chart.Axes.Bottom.Automatic = true;
						BaseChart.Chart.Legend.Visible = false;
						BaseChart.Chart.Axes.Left.Increment = 15;
						BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;

						((((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).Parent as TabbedPage).Title = "Compression";

						AddCompressionToolbarItem();

						BaseChart.Chart.Header.Text = "Compression OHLC - " + compressionPicker.SelectedItem;

				}

				private void AddCompressionToolbarItem()
				{

						compressionToolBarItem = new ToolbarItem();
						compressionToolBarItem.Icon = (FileImageSource)ImageSource.FromFile("ic_extension_white_24dp.png");
						compressionToolBarItem.Text = "Compression";
						compressionToolBarItem.Clicked += Compression_ChangeProperty;

						(((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).ToolbarItems.Add(compressionToolBarItem);

						CreateCompressionPicker();

				}

				private void CreateCompressionPicker()
				{

						compressionPicker = new Picker();
						compressionPicker.ItemsSource = new List<String> { "Daily", "Weekly", "Monthly", "Bi-Monthly", "Quarterly", "Yearly" };
						compressionPicker.SelectedItem = "Monthly";
						compressionPicker.IsVisible = false;
						compressionPicker.Title = "Change candle compression";
						compressionPicker.SelectedIndexChanged += CompressionPicker_SelectedIndexChanged;
						(BaseChart.Parent as StackLayout).Children.Add(compressionPicker);
						ReverseToolbarItems();

				}

				private void CompressionPicker_SelectedIndexChanged(object sender, EventArgs e)
				{

						BaseChart.Chart.Header.Text = "Compression OHLC - " + compressionPicker.SelectedItem;

						switch (compressionPicker.SelectedItem)
						{

								case "Daily":
									compressOHLC.Compress = CompressionPeriod.ocDay;
									break;
								case "Weekly":
									compressOHLC.Compress = CompressionPeriod.ocWeek;
									break;
								case "Monthly":
									compressOHLC.Compress = CompressionPeriod.ocMonth;
									break;
								case "Bi-Monthly":
									compressOHLC.Compress = CompressionPeriod.ocBiMonth;
									break;
								case "Quarterly":
									compressOHLC.Compress = CompressionPeriod.ocQuarter;
									break;
								case "Yearly":
									compressOHLC.Compress = CompressionPeriod.ocYear;
									break;

						}

						BaseChart.Chart.Invalidate();
						
				}

				private void Compression_ChangeProperty(object sender, EventArgs e)
				{

						compressionPicker.Focus();

				}

				public void RemoveCompressionToolBarItem()
				{

						(((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).ToolbarItems.Remove(compressionToolBarItem);

				}

				// Gira la toolbar
				private void ReverseToolbarItems()
				{

					IList<ToolbarItem> toolbar = (((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage).ToolbarItems;
					ToolbarItem[] arrayToolbar = new ToolbarItem[toolbar.Count];
					for(int i = 0; i < toolbar.Count; i++) { arrayToolbar[i] = toolbar[i]; }

					for (int i = toolbar.Count - 1; i >= 0; i--) { toolbar.RemoveAt(i); }
					
					for(int i = arrayToolbar.Length - 1; i >= 0; i--) { toolbar.Add(arrayToolbar[i]); }

				}

	}
}
