using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Data.Series;
using XamControls.PCL.ViewModels;
using XamControls.PCL.Utils;

namespace XamControls.PCL.Models
{
    public class SeriesGroupItem : BaseViewModel
    {

        SeriesGroup _seriesGroup;
        String _description;
        int _seriesCount;
        Xamarin.Forms.ImageSource _imageSource;

        public SeriesGroupItem()
        {
            _seriesGroup = default(SeriesGroup);
        }
        public SeriesGroupItem(SeriesGroup seriesGroup)
        {
            _seriesGroup = seriesGroup;
        }

        public SeriesGroup SeriesGroup
        {
            get => _seriesGroup;
            set
            {
                _seriesGroup = value;
                RaisePropertyChanged();
            }
        }
        public String Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
        public int SeriesCount
        {
            get => _seriesCount;
            set
            {
                _seriesCount = value;
                RaisePropertyChanged();
            }
        }
        public Xamarin.Forms.ImageSource ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                RaisePropertyChanged();
            }
        }

    }
}
