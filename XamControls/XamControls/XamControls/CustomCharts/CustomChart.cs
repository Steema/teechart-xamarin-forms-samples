using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Views;

namespace XamControls.CustomCharts
{
    public class CustomChart
    {

        private ImageSource _image;
        private string _name;
        private string _description;
        private ChartView _chart;
        private string _dateCreated;
        private Views.CustomChartView _chartPage;

        private bool _empty;

        public CustomChart(string chartNombre, CustomNavigationPage navPage)
        {

            this._image = "round_insert_chart_black_48dp.png";
            this._name = chartNombre;
            this._description = "Add your description in the chart properties.";
            this._chart = new ViewModels.Base.ChartViewRender();
            this._dateCreated = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            this._chartPage = new Views.CustomChartView(this, navPage);
            this._empty = true;

        }

        #region PROPERTIES

        /// <summary>
        /// Retorna el string amb el source de la imatge
        /// </summary>
        public ImageSource ImageSource
        {

            get { return _image; }
            set { _image = value; }

        }

        /// <summary>
        /// Retorna el nom del chart
        /// </summary>
        public string Name
        {

            get { return _name; }
            set { _name = value; }

        }

        /// <summary>
        /// Retorna la descripció del chart
        /// </summary>
        public string Description
        {

            get { return _description; }
            set { _description = value; }

        }

        /// <summary>
        /// Retorna el chartView del chart
        /// </summary>
        public ChartView ChartView
        {

            get { return _chart; }
            set { _chart = value; }

        }
        
        /// <summary>
        /// Retorna la data de la creació del objecte
        /// </summary>
        public string DateCreated
        {

            get { return _dateCreated; }

        }

        public Views.CustomChartView ChartPage
        {

            get { return _chartPage; }

        }

        /// <summary>
        /// Permet saber si el chart encara no ha estat configurat
        /// </summary>
        public bool IsEmpty
        {

            get { return _empty; }
            set { _empty = value; }

        }

        #endregion

    }
}
