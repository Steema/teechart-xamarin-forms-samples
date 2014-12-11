using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(TeeChartDemo.PCL.Droid.Locale_Android))]
namespace TeeChartDemo.PCL.Droid
{
  public class Locale_Android : TeeChartDemo.PCL.ILocale
  {
    /// <remarks>
    /// Not sure if we can cache this info rather than querying every time
    /// </remarks>
    public string GetCurrent()
    {
      var androidLocale = Java.Util.Locale.Default;

      //var netLanguage = androidLocale.Language.Replace ("_", "-");
      var netLanguage = androidLocale.ToString().Replace("_", "-");

      //var netLanguage = androidLanguage.Replace ("_", "-");
      Console.WriteLine("ios:" + androidLocale.ToString());
      Console.WriteLine("net:" + netLanguage);

      Console.WriteLine(Thread.CurrentThread.CurrentCulture);
      Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

      return netLanguage;
    }
  }

}