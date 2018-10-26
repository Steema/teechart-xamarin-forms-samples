using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamControls.CustomCharts.Services
{
    public class ChartController
    {

        private ObservableCollection<CustomChart> _customCharts;

        public ChartController()
        {

            _customCharts = new ObservableCollection<CustomChart>();

        }

        #region PUBLIC FUNCTIONS
        /// <summary>
        /// Permet afegir un nou chart
        /// </summary>
        /// <param name="chart">CustomChart que es vol afegir</param>
        public void Add(CustomChart chart)
        {

            try { _customCharts.Add(chart); }
            catch(Exception exception) { throw new Exception(exception.Message); }

        }
        /// <summary>
        /// Permet eliminar un chart
        /// </summary>
        /// <param name="chart">CustomChart que es vol eliminar</param>
        public void Remove(CustomChart chart)
        {

            try { _customCharts.Remove(chart); }
            catch(Exception exception) { throw new Exception(exception.Message); }

        }

        #endregion

        #region PRIVATE FUNCTIONS

        #endregion

        #region PROPERTIES
        public ObservableCollection<CustomChart> Charts
        {

            get { return _customCharts; }

        }
        #endregion
    }
}
