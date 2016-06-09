using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.Globalization;

namespace TeeChartDemo.PCL
{
  public interface ILocale
  {
    string GetCurrent();
  }
  public class AppResources
  {
    public static string Locale()
    {
      return DependencyService.Get<ILocale>().GetCurrent();
    }


    private static ResourceManager resourceManager;
    public static ResourceManager ResourceManager 
    {
      get
      {
        if (resourceManager == null)
        {
          resourceManager = new ResourceManager("TeeChartDemo.PCL.Resources.AppResources", typeof(AppResources).GetTypeInfo().Assembly);
        }
        return resourceManager;
      }
    }

    public static CultureInfo ResourceCulture
    {
      get
      {
        return new CultureInfo(Locale());
      }

    }

    /// <summary>
    ///   Looks up a localized string similar to Below left and right signal strength.
    /// </summary>
    public static string BelowSignal
    {
      get
      {
        return ResourceManager.GetString("BelowSignal", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to currency.
    /// </summary>
    public static string Currency
    {
      get
      {
        return ResourceManager.GetString("Currency", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to current position.
    /// </summary>
    public static string CurrentPosition
    {
      get
      {
        return ResourceManager.GetString("CurrentPosition", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to digital.
    /// </summary>
    public static string DashDigital
    {
      get
      {
        return ResourceManager.GetString("DashDigital", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to exposure (fin$).
    /// </summary>
    public static string DashExposure
    {
      get
      {
        return ResourceManager.GetString("DashExposure", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to geographic.
    /// </summary>
    public static string DashGeographic
    {
      get
      {
        return ResourceManager.GetString("DashGeographic", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to trend.
    /// </summary>
    public static string DashTrend
    {
      get
      {
        return ResourceManager.GetString("DashTrend", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Δ avg.
    /// </summary>
    public static string DeltaAverage
    {
      get
      {
        return ResourceManager.GetString("DeltaAverage", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Value $ 000s.
    /// </summary>
    public static string DollarValue
    {
      get
      {
        return ResourceManager.GetString("DollarValue", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to index of eu15.
    /// </summary>
    public static string EUIndex
    {
      get
      {
        return ResourceManager.GetString("EUIndex", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to fixed.
    /// </summary>
    public static string Fixed
    {
      get
      {
        return ResourceManager.GetString("Fixed", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Indexed.
    /// </summary>
    public static string Indexed
    {
      get
      {
        return ResourceManager.GetString("Indexed", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to InChart.
    /// </summary>
    public static string LBGestureStyle1
    {
      get
      {
        return ResourceManager.GetString("LBGestureStyle1", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to FullChart.
    /// </summary>
    public static string LBGestureStyle2
    {
      get
      {
        return ResourceManager.GetString("LBGestureStyle2", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Default.
    /// </summary>
    public static string LBPoints1
    {
      get
      {
        return ResourceManager.GetString("LBPoints1", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to to market cost index.
    /// </summary>
    public static string MarketCost
    {
      get
      {
        return ResourceManager.GetString("MarketCost", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to organic food consumption 2009.
    /// </summary>
    public static string OrganicFood
    {
      get
      {
        return ResourceManager.GetString("OrganicFood", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Participation %.
    /// </summary>
    public static string Participation
    {
      get
      {
        return ResourceManager.GetString("Participation", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to about.
    /// </summary>
    public static string PivotItemAbout
    {
      get
      {
        return ResourceManager.GetString("PivotItemAbout", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to dashboard.
    /// </summary>
    public static string PivotItemDashboard
    {
      get
      {
        return ResourceManager.GetString("PivotItemDashboard", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to empty.
    /// </summary>
    public static string PivotItemEmpty
    {
      get
      {
        return ResourceManager.GetString("PivotItemEmpty", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to series.
    /// </summary>
    public static string PivotItemSeries
    {
      get
      {
        return ResourceManager.GetString("PivotItemSeries", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to settings.
    /// </summary>
    public static string PivotItemSettings
    {
      get
      {
        return ResourceManager.GetString("PivotItemSettings", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to themes.
    /// </summary>
    public static string PivotItemThemes
    {
      get
      {
        return ResourceManager.GetString("PivotItemThemes", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to tools.
    /// </summary>
    public static string PivotItemTools
    {
      get
      {
        return ResourceManager.GetString("PivotItemTools", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to             TEECHART.NET FOR WINDOWS PHONE 8.
    /// </summary>
    public static string PivotTitle
    {
      get
      {
        return ResourceManager.GetString("PivotTitle", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to private.
    /// </summary>
    public static string Private
    {
      get
      {
        return ResourceManager.GetString("Private", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to public.
    /// </summary>
    public static string Public
    {
      get
      {
        return ResourceManager.GetString("Public", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to recent movement.
    /// </summary>
    public static string RecentMovement
    {
      get
      {
        return ResourceManager.GetString("RecentMovement", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to LeftToRight.
    /// </summary>
    public static string ResourceFlowDirection
    {
      get
      {
        return ResourceManager.GetString("ResourceFlowDirection", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to en.
    /// </summary>
    public static string ResourceLanguage
    {
      get
      {
        return ResourceManager.GetString("ResourceLanguage", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Steema Software has been providing developers with tools for charting since 1995. The TeeChart for Windows Phone .
    /// </summary>
    public static string RunText1
    {
      get
      {
        return ResourceManager.GetString("RunText1", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to  Library forms part of ongoing development making available for Phone .
    /// </summary>
    public static string RunText2
    {
      get
      {
        return ResourceManager.GetString("RunText2", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to  application development all of the charting features that form part of the TeeChart Libraries. This preview application shows a few of the possibilities available to developers..
    /// </summary>
    public static string RunText3
    {
      get
      {
        return ResourceManager.GetString("RunText3", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Sig. Frequency.
    /// </summary>
    public static string SigFrequency
    {
      get
      {
        return ResourceManager.GetString("SigFrequency", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Number of Data Points:.
    /// </summary>
    public static string TextBlock1
    {
      get
      {
        return ResourceManager.GetString("TextBlock1", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to Gesture Style:.
    /// </summary>
    public static string TextBlock2
    {
      get
      {
        return ResourceManager.GetString("TextBlock2", ResourceCulture);
      }
    }

    /// <summary>
    ///   Looks up a localized string similar to variable.
    /// </summary>
    public static string Variable
    {
      get
      {
        return ResourceManager.GetString("Variable", ResourceCulture);
      }
    }
  }

}
