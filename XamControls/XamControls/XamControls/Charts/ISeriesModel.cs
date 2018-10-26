using Steema.TeeChart.Styles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace XamControls.Charts
{
    interface ISeriesModel
    {

		void FillSampleValues(Series serie);
		void FillSampleValues(Series serie, int cantidad);
		void FillSampleValues(Series serie, int cantidad, int maximo);
		void FillSampleValues(Series serie, int cantidad, int maximo, int minimo);

    }
}
