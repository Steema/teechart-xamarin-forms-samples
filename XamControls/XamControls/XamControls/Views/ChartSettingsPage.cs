using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamControls.ViewModels;
using Xamarin.Forms;
using Steema.TeeChart;
using XamControls.Views;
using XamControls.CustomRenders;

namespace XamControls.Views
{
	public class ChartSettingsPage : ContentPage
	{

		public ChartSettingsViewModel tView;

		public ChartSettingsPage() {  }

		public ChartSettingsPage(ChartView BaseChart, string titleChart)
		{

				tView = new ChartSettingsViewModel(BaseChart, titleChart);
                
				this.Content = tView.GetTableView;
				this.Padding = 0;
				this.Title = "Chart Settings";

		}

		public ChartView GetChart { get { return tView.GetChart; } }

	};
}