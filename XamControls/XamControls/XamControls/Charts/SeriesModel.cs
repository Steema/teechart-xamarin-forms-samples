using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;

namespace XamControls.Charts
{
	public class SeriesModel : ISeriesModel
	{

		public SeriesModel() { }

        public double MaxValueAxisLeft { get; set; }

        private bool _isRepainted = false;

        private const int _BASE_VALUE_FILLSAMPLEVALUES = 25;
		private const int _BASE_MAXIM_FILLSAMPLEVALUES = 800;
		private const int _BASE_MINIM_FILLSAMPLEVALUES = -200;

		private void InternalFillValues(Series serie, int cantidad = _BASE_VALUE_FILLSAMPLEVALUES, int maximo = _BASE_MAXIM_FILLSAMPLEVALUES, int minimo = _BASE_MINIM_FILLSAMPLEVALUES)
		{

				bool correcte = false;

				while (!correcte)
				{

					serie.FillSampleValues(cantidad);
					int i = 0;
					bool trobat = false;

					while (i < serie.mandatory.Count && !trobat)
					{

						if (serie.mandatory[i] > maximo || serie.mandatory[i] < minimo) { trobat = true; }
						i++;

					}

					if (!trobat) { correcte = true; }

				}

		}
		public virtual void FillSampleValues(Series serie)
		{

				InternalFillValues(serie);

		}
		public virtual void FillSampleValues(Series serie, int cantidad)
		{

				InternalFillValues(serie, cantidad);

		}
		public virtual void FillSampleValues(Series serie, int cantidad, int maximo)
		{

				InternalFillValues(serie, cantidad, maximo);

		}
		public void FillSampleValues(Series serie, int cantidad, int maximo, int minimo)
		{

				InternalFillValues(serie, cantidad, maximo, minimo);

		}

        public virtual void OnAfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {

            if (!_isRepainted)
            {

                var chart = sender as Steema.TeeChart.Chart;
                double maxValue = chart.Axes.Left.MaxYValue + MaxValueAxisLeft;
                chart.Chart.Axes.Left.Automatic = false;
                chart.Axes.Left.SetMinMax(0, maxValue);
                _isRepainted = true;
                chart.Draw();

            }

        }

        public bool IsRepainted { get { return _isRepainted; } set { _isRepainted = value; } }

    }
}
