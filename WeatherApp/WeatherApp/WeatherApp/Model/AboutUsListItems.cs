using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.Model
{
    public class AboutUsListItems
    {

        private string _icon;
        private string _text;
        private ICommand _command;

        public AboutUsListItems(string icon, string text, ICommand command)
        {

            _icon = icon;
            _text = text;
            _command = command;

        }

        public String Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ICommand Command
        {

            get { return _command; }

        }

    }
}
