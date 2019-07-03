using System;
using System.Collections.Generic;
using System.Text;
using XamControls.Models;
using XamControls.Views;
using XamControls.Variables;
using Xamarin.Forms;

namespace XamControls.Services
{
    // Clase que conté les dades del "lView" en el "Home"
    public class LViewDataStore
    {

        private List<ItemsListView> ListItems;
        private Type NavigateTo = typeof(ChartTabPage);
        private int identificador = 0;
        private Variables.Variables var = new Variables.Variables();
        private string[] imagePath;

        // Constructor
        public LViewDataStore()
        {

            ListItems = new List<ItemsListView>();
            var mockItems = new List<ItemsListView>();
            if (Device.RuntimePlatform != Device.UWP)
            {
                imagePath = new string[] { "bar.png", "tower.png", "circulargauge.png", "map.png", "renko.png", "knobgauge.png", "clock.png", "org.png", "numericgauge.png", "lineargauge.png", "calendar.png", //"linepoint.png",
                            "tagcloud.png", "kagi.png", "ternary.png" };
            }
            else
            {
                imagePath = new string[] { "Assets/bar.png", "Assets/tower.png", "Assets/circulargauge.png", "Assets/map.png", "Assets/renko.png", "Assets/knobgauge.png", "Assets/clock.png", "Assets/org.png", "Assets/numericgauge.png", "Assets/lineargauge.png", "Assets/calendar.png", //"linepoint.png",
                            "Assets/tagcloud.png", "Assets/kagi.png", "Assets/ternary.png" };
            }

            for (int i = 0; i < var.GET_N_ELEMENTS_LVIEW; i++)
            {

                if (identificador == 11) { identificador++; }
                if (Device.RuntimePlatform == Device.UWP)
                {

                    mockItems.Add(new ItemsListView(++identificador, var.GetListViewNoms[i], var.GetListViewDescripcion[i], imagePath[i], NavigateTo));
                }
                else
                {
                    mockItems.Add(new ItemsListView(++identificador, var.GetListViewNoms[i], var.GetListViewDescripcion[i], imagePath[i], NavigateTo));
                }
            }

            foreach (var item in mockItems)
            {

                ListItems.Add(item);

            }

        }

        // Retorna la llista de items que mostra el "lView" en el "Home"
        public List<ItemsListView> GetListItems
        {

            get { return ListItems; }

        }


    }
}
