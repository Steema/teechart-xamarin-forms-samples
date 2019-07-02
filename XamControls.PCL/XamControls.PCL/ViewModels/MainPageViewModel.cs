using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamControls.Data.Series;
using XamControls.PCL.Models;

namespace XamControls.PCL.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        ObservableCollection<SeriesGroupItem> _seriesGroupItems;

        public MainPageViewModel()
        {
            _seriesGroupItems = GetData();
        }

        /// <summary>
        /// Get Data for listView
        /// </summary>
        /// <returns>Series groups list view items</returns>
        ObservableCollection<SeriesGroupItem> GetData()
        {
            ObservableCollection<SeriesGroupItem> data = new ObservableCollection<SeriesGroupItem>();
            string[] vSeriesGroup = System.Enum.GetNames(typeof(SeriesGroup));
            // create seriesGroupItem and add it in list
            foreach(string item in vSeriesGroup)
            {
                if (item == "Standard" || item == "Advanced") // Limit listview items in first demo
                {
                    SeriesGroup serieGroup = (SeriesGroup)System.Enum.Parse(typeof(SeriesGroup), item);
                    SeriesGroupItem seriesGroupItem = new SeriesGroupItem(serieGroup)
                    {
                        Description = GetItemDescription(serieGroup),
                        SeriesCount = GetSeriesCount(serieGroup),
                        SeriesGroup = serieGroup,
                        ImageSource = GetImageSource(serieGroup),
                    };
                    data.Add(seriesGroupItem);
                }
            }
            return data;
        }

        /// <summary>
        /// Get image source foreach seriesGroup
        /// </summary>
        /// <param name="seriesGroup">Series group in enum</param>
        /// <returns>Object image source</returns>
        ImageSource GetImageSource(SeriesGroup seriesGroup)
        {
            string standardImageSource = "Assets/bar.png";
            string advancedImageSource = "Assets/contour.png";

            ImageSource imageSource = null;
            switch (seriesGroup)
            {
                case SeriesGroup.Standard:
                    imageSource = standardImageSource;
                    break;
                case SeriesGroup.Advanced:
                    imageSource = advancedImageSource;
                    break;
                case SeriesGroup.CircularGauge:
                    //imageSource = circularGaugeSeriesDescription;
                    break;
                case SeriesGroup.Maps:
                    //imageSource = mapSeriesDescription;
                    break;
                case SeriesGroup.TreeMaps:
                    //imageSource = treeMapSeriesDescription;
                    break;
                case SeriesGroup.KnobGauge:
                    //imageSource = knobGaugeSeriesDescription;
                    break;
                case SeriesGroup.Clock:
                    //imageSource = clockSeriesDescription;
                    break;
                case SeriesGroup.Organizational:
                    //imageSource = organizationalSeriesDescription;
                    break;
                case SeriesGroup.NumericGauge:
                    //imageSource = numericGaugeSeriesDescription;
                    break;
                case SeriesGroup.LinearGauge:
                    //imageSource = linearGaugeSeriesDescription;
                    break;
                case SeriesGroup.Calendar:
                    //imageSource = calendarSeriesDescription;
                    break;
                case SeriesGroup.SparkLines:
                    //imageSource = sparkLinesSeriesDescription;
                    break;
                case SeriesGroup.TagCloud:
                    //imageSource = tagCloudSeriesDescription;
                    break;
                case SeriesGroup.StandardFunctions:
                    //imageSource = standardFunctionSeriesDescription;
                    break;
                case SeriesGroup.AdvancedFunctions:
                    //imageSource = advancedFunctionSeriesDescription;
                    break;
            }
            return imageSource;
        }
        /// <summary>
        /// Get Nº series foreach seriesGroup
        /// </summary>
        /// <param name="seriesGroup">Series group item in enum to get description</param>
        /// <returns>int32 of series count</returns>
        int GetSeriesCount(SeriesGroup seriesGroup)
        {
            int seriesCount = 0;
            switch (seriesGroup)
            {
                case SeriesGroup.Standard:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(StandardSeriesTypes));
                    break;
                case SeriesGroup.Advanced:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(AdvancedSeriesTypes));
                    break;
                case SeriesGroup.CircularGauge:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(CircularGaugesSeriesTypes));
                    break;
                case SeriesGroup.Maps:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(MapsSeriesTypes));
                    break;
                case SeriesGroup.TreeMaps:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(TreeMapSeriesTypes));
                    break;
                case SeriesGroup.KnobGauge:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(KnobGaugeSeriesTypes));
                    break;
                case SeriesGroup.Clock:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(ClockSeriesTypes));
                    break;
                case SeriesGroup.Organizational:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(OrganizationSeriesTypes));
                    break;
                case SeriesGroup.NumericGauge:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(NumericGaugeSeriesTypes));
                    break;
                case SeriesGroup.LinearGauge:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(LinearGaugeSeriesTypes));
                    break;
                case SeriesGroup.Calendar:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(CalendarSeriesTypes));
                    break;
                case SeriesGroup.SparkLines:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(SparkLinesSeriesTypes));
                    break;
                case SeriesGroup.TagCloud:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(TagCloudSeriesTypes));
                    break;
                case SeriesGroup.StandardFunctions:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(StandardFunctionSeriesTypes));
                    break;
                case SeriesGroup.AdvancedFunctions:
                    seriesCount = Utils.Helpers.EnumItemsCount(typeof(AdvancedFunctionsSeriesTypes));
                    break;
            }
            return seriesCount;
        }
        /// <summary>
        /// Get description foreach seriesGroup
        /// </summary>
        /// <param name="seriesGroup">Series group item in enum to get description</param>
        /// <returns>Description</returns>
        string GetItemDescription(SeriesGroup seriesGroup)
        {
            // Text to show as a description in listview series group items
            const string standardSeriesDescription = "Show different simple chart types how lineals, bubbles or areas.";
            const string advancedSeriesDescription = "Some charts like the Pyramid or Kagi. These have more customization and are more complex.";
            const string circularGaugeSeriesDescription = "CircularGauge provides a fully configurable and quick drawing circular gauge style.";
            const string mapSeriesDescription = "Show a Map series which is a collection of polygon shapes and differents world maps.";
            const string treeMapSeriesDescription = "Treemaps display hierarchical (tree-structured) data as a set of nested rectangles.";
            const string knobGaugeSeriesDescription = "Knob Gauge uses a needle pointer but it also has a cap of larger radius that imitates a gear.";
            const string clockSeriesDescription = "The Clock series displays live watches. Multiple configuration parameters are available.";
            const string organizationalSeriesDescription = "Organizational Charts display elements in hierarchical structures, such as Company and  Employers.";
            const string numericGaugeSeriesDescription = "Show a numeric data using a gauge.";
            const string linearGaugeSeriesDescription = "Dispay numeric data using a linear element.";
            const string calendarSeriesDescription = "Month-View calendar for selecting dates in order to display different activities.";
            const string sparkLinesSeriesDescription = "A sparkline is a very small line chart, typically drawn without axes or coordinates to show variation about a measurement.";
            const string tagCloudSeriesDescription = "Display different texts in a cloud with a font whose colour and size is relative to that frequency.";
            const string standardFunctionSeriesDescription = "Some functions to charts which are considered basics.";
            const string advancedFunctionSeriesDescription = "More complicated functions for statistical sectors for example financial field.";

            string GetDescription()
            {
                string description = null;
                switch (seriesGroup)
                {
                    case SeriesGroup.Standard:
                        description = standardSeriesDescription;
                        break;
                    case SeriesGroup.Advanced:
                        description = advancedSeriesDescription;
                        break;
                    case SeriesGroup.CircularGauge:
                        description = circularGaugeSeriesDescription;
                        break;
                    case SeriesGroup.Maps:
                        description = mapSeriesDescription;
                        break;
                    case SeriesGroup.TreeMaps:
                        description = treeMapSeriesDescription;
                        break;
                    case SeriesGroup.KnobGauge:
                        description = knobGaugeSeriesDescription;
                        break;
                    case SeriesGroup.Clock:
                        description = clockSeriesDescription;
                        break;
                    case SeriesGroup.Organizational:
                        description = organizationalSeriesDescription;
                        break;
                    case SeriesGroup.NumericGauge:
                        description = numericGaugeSeriesDescription;
                        break;
                    case SeriesGroup.LinearGauge:
                        description = linearGaugeSeriesDescription;
                        break;
                    case SeriesGroup.Calendar:
                        description = calendarSeriesDescription;
                        break;
                    case SeriesGroup.SparkLines:
                        description = sparkLinesSeriesDescription;
                        break;
                    case SeriesGroup.TagCloud:
                        description = tagCloudSeriesDescription;
                        break;
                    case SeriesGroup.StandardFunctions:
                        description = standardFunctionSeriesDescription;
                        break;
                    case SeriesGroup.AdvancedFunctions:
                        description = advancedFunctionSeriesDescription;
                        break;
                }
                return description;
            }

            return GetDescription();
        }

        public ObservableCollection<SeriesGroupItem> SeriesGroupItems => _seriesGroupItems;

    }
}
