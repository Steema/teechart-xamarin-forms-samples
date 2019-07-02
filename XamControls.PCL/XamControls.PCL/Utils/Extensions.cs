using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Data.Series;

namespace XamControls.PCL.Utils
{
    public static class Extensions
    {

        /// <summary>
        /// Return a friendly name for the seriesgroup value from SeriesGroup enum passed as argument
        /// </summary>
        /// <param name="seriesGroup">Enum value which we want convert</param>
        /// <returns>Series group friendly name</returns>
        public static String SeriesGroupToFriendlyName(this SeriesGroup seriesGroup)
        {
            string normalizedSeriesGroup = null;
            switch (seriesGroup)
            {
                case SeriesGroup.Standard:
                case SeriesGroup.Maps:
                case SeriesGroup.Advanced:
                case SeriesGroup.Clock:
                case SeriesGroup.Organizational:
                case SeriesGroup.Calendar:
                    normalizedSeriesGroup = System.Enum.GetName(typeof(SeriesGroup), seriesGroup);
                    break;
                case SeriesGroup.CircularGauge:
                    normalizedSeriesGroup = "Circular Gauge";
                    break;
                case SeriesGroup.TreeMaps:
                    normalizedSeriesGroup = "Tree Map";
                    break;
                case SeriesGroup.KnobGauge:
                    normalizedSeriesGroup = "Knob Gauge";
                    break;
                case SeriesGroup.NumericGauge:
                    normalizedSeriesGroup = "Numeric Gauge";
                    break;
                case SeriesGroup.LinearGauge:
                    normalizedSeriesGroup = "Linear Gauge";
                    break;
                case SeriesGroup.SparkLines:
                    normalizedSeriesGroup = "Spark Lines";
                    break;
                case SeriesGroup.TagCloud:
                    normalizedSeriesGroup = "Tag Cloud";
                    break;
                case SeriesGroup.StandardFunctions:
                    normalizedSeriesGroup = "Standard Functions";
                    break;
                case SeriesGroup.AdvancedFunctions:
                    normalizedSeriesGroup = "Advanced Functions";
                    break;
            }
            return normalizedSeriesGroup;
        }


    }
}
