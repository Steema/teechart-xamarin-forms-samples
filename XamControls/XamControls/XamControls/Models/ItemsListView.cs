using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.Variables;

namespace XamControls.Models
{

		// Clase para mostrar las diferentes opciones del "listView"
		public class ItemsListView
        {

		// ATRIBUTOS
			private int a_id;
			private string a_nom;
			private string a_informacio;
			private string a_samples;
			private string a_tipus;
			private ImageSource a_foto;
			private Color a_color;			

			// CONSTRUCTOR
			public ItemsListView(int id, string nombre, string informacio, ImageSource foto, Type a_desti)
			{

				this.a_id = id;
				this.a_nom = nombre;
				this.a_informacio = informacio;
				this.a_tipus = CalcularTipus();
				this.a_foto = foto;
				DisableItemsPro();
				CalcularSamples();

			}

			// MÉTODOS PRIVADOS

			// Modifica el color de las "Cells" que són "PRO"
			private void DisableItemsPro()
			{

					if (this.a_tipus == "PRO") { this.a_color = Color.FromRgb(225, 225, 225); }
					else { this.a_color = Color.White; }

			}

			// Acción que calcula cuantas demos tenemos
			private void CalcularSamples()
			{

					Variables.Variables var = new Variables.Variables();
					switch (a_id)
					{

						case 1:
							this.a_samples = Convert.ToString(var.GetStandardNomButtonsTypes.Length + var.GetStandardNomButtonsFeatures.Length);
							break;

						case 2:
							this.a_samples = Convert.ToString(var.GetProNomButtonsTypes.Length + var.GetProNomButtonsFeatures.Length);
							break;

						case 3:
							this.a_samples = Convert.ToString(var.GetCircularGaugesNomButtons.Length);
							break;

						case 4:
							this.a_samples = Convert.ToString(var.GetMapsNomButtons.Length);
							break;

						case 5:
							this.a_samples = Convert.ToString(var.GetTreeMapNomButtons.Length);
							break;

						case 6:
							this.a_samples = Convert.ToString(var.GetKnobGaugeNomButtons.Length);
							break;

						case 7:
							this.a_samples = Convert.ToString(var.GetClockNomButtons.Length);
							break;

						case 8:
							this.a_samples = Convert.ToString(var.GetOrganizationalNomButtons.Length);
							break;

						case 9:
							this.a_samples = Convert.ToString(var.GetNumericGaugeNomButtons.Length);
							break;

						case 10:
							this.a_samples = Convert.ToString(var.GetLinearGaugeNomButtons.Length);
							break;

						case 11:
							this.a_samples = Convert.ToString(var.GetCalendarNomButtons.Length);
							break;

						case 12:
							this.a_samples = Convert.ToString(var.GetSparkLinesNomButtons.Length);
							break;

						case 13:
							this.a_samples = Convert.ToString(var.GetTagCloudNomButtons.Length);
							break;

						case 14:
							this.a_samples = Convert.ToString(var.GetStandardFunctionsNomButtons.Length);
							break;

						case 15:
							this.a_samples = Convert.ToString(var.GetProFunctionsNomButtons[0].Length + var.GetProFunctionsNomButtons[1].Length + var.GetProFunctionsNomButtons[2].Length);
							break;

					}
					this.a_samples += " Samples";


			}

			// Función que devuelve si ese elemento es de la versión "STD" o "PRO"
			private string CalcularTipus()
			{

					string tipus = "";

					switch(this.a_id) {

						case 1: case 3: case 6: case 9: case 10: case 11: case 14: tipus = "STD"; break;
						case 2: case 4: case 5: case 7: case 8: case 12: case 13: case 15: tipus = "PRO"; break;

					}

					return tipus;

			}

			// PROPIEDADES
			public int Id { get { return a_id; } }
			public string Nom { get { return a_nom; } }
			public string Informacio { get { return a_informacio; } }
			public string Samples { get { return a_samples; } }
			public string Tipus { get { return a_tipus; } }
			public ImageSource Foto { get { return a_foto; } }
			public Color BColor { get { return a_color; } }

		}

}
