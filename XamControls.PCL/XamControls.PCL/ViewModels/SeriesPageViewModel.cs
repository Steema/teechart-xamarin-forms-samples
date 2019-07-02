using System;
using System.Collections.Generic;
using System.Text;
using XamControls.PCL.Models;

namespace XamControls.PCL.ViewModels
{
    public class SeriesPageViewModel : BaseViewModel
    {

        SeriesGroupItem _seriesGroupItem;

        public SeriesPageViewModel()
        {

        }

        public SeriesGroupItem SeriesGroupItem
        {
            get => _seriesGroupItem;
            set
            {
                if (_seriesGroupItem != value)
                {
                    _seriesGroupItem = value;
                    RaisePropertyChanged();
                }
            }

        }

    }
}
