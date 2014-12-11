using TeeChartDemo.PCL;
using Xamarin.Forms;
using System.Globalization;

[assembly: Dependency(typeof(TeeChartDemo.PCL.WinPhone.Locale_WinPhone))]

namespace TeeChartDemo.PCL.WinPhone
{
  public class Locale_WinPhone : TeeChartDemo.PCL.ILocale
  {
    public Locale_WinPhone()
    {
      //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ca-ES");
    }

    public string GetCurrent()
    {
      return System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
    }
  }
}
