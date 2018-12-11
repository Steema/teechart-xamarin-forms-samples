using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{

    public enum MenuItemType{

        Error,
        Home,
        Temperature,
        MinMaxTemperature,
        MinMaxTemperatureHistogram,
        Humidity,
        WindSpeed,
        SeaLevel,
        //GroundLevel,
        About

    }

    public class MasterListItems
    {

        MenuItemType _id;
        string _name;
        string _icon;

        public MasterListItems(MenuItemType id, string name, string icon)
        {

            _id = id;
            _name = name;
            _icon = icon;

        }

        public MenuItemType Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Icon { get { return _icon; } set { _icon = value; } }

    }
}
