using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeeChartDemo.PCL
{
  public class ChartView : View
  {

    public ChartView()
		{
		}

		public EventHandler OnInvalidateDisplay;

    //public static readonly BindableProperty BackgroundColorProperty =
    //  BindableProperty.Create("BackgroundColor", typeof(Color), typeof(ChartView), Color.Default);

    //public Color BackgroundColor {
    //  get { return (Color)GetValue (BackgroundColorProperty); }
    //  set { SetValue (BackgroundColorProperty, value); } 
    //}

		public static readonly BindableProperty ModelProperty =
      BindableProperty.Create("ModelProperty", typeof(Steema.TeeChart.Chart), typeof(ChartView), null);

		public Steema.TeeChart.Chart Model {
      get { return (Steema.TeeChart.Chart)GetValue(ModelProperty); }
			set { SetValue (ModelProperty, value); } 
		}

		public void InvalidateDisplay () {
			if (OnInvalidateDisplay != null)
				OnInvalidateDisplay (this, null);
		}
  }
}
