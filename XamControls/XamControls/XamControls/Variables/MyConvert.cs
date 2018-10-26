using System;
using System.Collections.Generic;
using System.Text;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using System.Collections;

namespace XamControls.Variables
{
		public class MyConvert
		{

				public MyConvert() { }

				/// <summary>
				/// Devuelve las estructuras en un array {PointerStyles, LegendPosition}
				/// </summary>
				public static object ToArray(string nombreObjeto) {

						switch (nombreObjeto) {

							case "PointerStyles":

								PointerStyles[] pointerStyles = new PointerStyles[16];
								int posPointerStyles = 0;

								pointerStyles[posPointerStyles++] = PointerStyles.Arrow;
								pointerStyles[posPointerStyles++] = PointerStyles.Circle;
								pointerStyles[posPointerStyles++] = PointerStyles.Cross;
								pointerStyles[posPointerStyles++] = PointerStyles.DiagCross;
								pointerStyles[posPointerStyles++] = PointerStyles.Diamond;
								pointerStyles[posPointerStyles++] = PointerStyles.DownTriangle;
								pointerStyles[posPointerStyles++] = PointerStyles.Hexagon;
								pointerStyles[posPointerStyles++] = PointerStyles.LeftTriangle;
								pointerStyles[posPointerStyles++] = PointerStyles.Nothing;
								pointerStyles[posPointerStyles++] = PointerStyles.PolishedSphere;
								pointerStyles[posPointerStyles++] = PointerStyles.Rectangle;
								pointerStyles[posPointerStyles++] = PointerStyles.RightTriangle;
								pointerStyles[posPointerStyles++] = PointerStyles.SmallDot;
								pointerStyles[posPointerStyles++] = PointerStyles.Sphere;
								pointerStyles[posPointerStyles++] = PointerStyles.Star;
								pointerStyles[posPointerStyles++] = PointerStyles.Triangle;
								return pointerStyles;

							case "LegendPosition":

								LegendAlignments[] legendAlignments = new LegendAlignments[4];
								int posLegendAlig = 0;

								legendAlignments[posLegendAlig++] = LegendAlignments.Left;
								legendAlignments[posLegendAlig++] = LegendAlignments.Right;
								legendAlignments[posLegendAlig++] = LegendAlignments.Top;
								legendAlignments[posLegendAlig++] = LegendAlignments.Bottom;
								return legendAlignments;

							default:
								break;

						}

						return null;

				}

				/// <summary>
				/// Devuelve el mes en texto a partir del número
				/// </summary>
				/// <param name="month"></param>
				/// <returns></returns>
				public static string NumericMonthToString(int month)
				{

						string textMonth = "";

						switch(month)
						{

						case 1:
							textMonth = "January";
							break;
						case 2:
							textMonth = "February";
							break;
						case 3:
							textMonth = "March";
							break;
						case 4:
							textMonth = "April";
							break;
						case 5:
							textMonth = "May";
							break;
						case 6:
							textMonth = "June";
							break;
						case 7:
							textMonth = "July";
							break;
						case 8:
							textMonth = "August";
							break;
						case 9:
							textMonth = "September";
							break;
						case 10:
							textMonth = "October";
							break;
						case 11:
							textMonth = "November";
							break;
						case 12:
							textMonth = "December";
							break;

						}

						return textMonth;

				}

		}
}
