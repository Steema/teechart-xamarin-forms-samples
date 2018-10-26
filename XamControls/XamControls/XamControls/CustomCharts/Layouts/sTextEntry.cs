using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamControls.Utils;

namespace XamControls.CustomCharts.Layouts
{
    public class sTextEntry : StackLayout
    {

        private Entry _entry;
        private Editor _editor;
        private Label _textView;

        private sEntryDisplayMode _entryDisplayMode;

        public sTextEntry() : this(sEntryDisplayMode.Normal)
        {

            

        }

        public sTextEntry(sEntryDisplayMode modeDisplayEntry)
        {

            _textView = new Label();
            _entryDisplayMode = sEntryDisplayMode.Normal;

            this.Children.Add(_textView);

            InternalDisplayMode();

            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.Start;

        }

        private void InternalDisplayMode()
        {

            _textView.IsVisible = true;
            _textView.HorizontalOptions = LayoutOptions.FillAndExpand;
            _textView.VerticalOptions = LayoutOptions.Start;
            _textView.HorizontalTextAlignment = TextAlignment.Start;
            _textView.VerticalTextAlignment = TextAlignment.Center;
            _textView.TextColor = Color.Black;
            _textView.Text = "Default text";
            _textView.FontSize = 15;

            DisplayMode();            

        }

        public void DisplayMode()
        {

            if (_entryDisplayMode == sEntryDisplayMode.Normal)
            {

                _entry = new Entry();

                _entry.TextColor = Color.Black;
                _entry.Placeholder = "Default placeholder";
                _entry.MaxLength = 20;
                _entry.Focused += entryView_Focused;
                _entry.Unfocused += entryView_Unfocused;

                this.Children.Add(_entry);

            }
            else
            {

                _editor = new Editor();

                _editor.TextColor = Color.Black;
                _editor.MaxLength = 200;
                _editor.AutoSize = EditorAutoSizeOption.TextChanges;
                _editor.Focused += entryView_Focused;
                _editor.Unfocused += entryView_Unfocused;

                this.Children.Add(_editor);

            }

        }

        private void entryView_Focused(object sender, FocusEventArgs e)
        {

            _textView.TextColor = Color.FromRgb(26, 115, 232);

        }

        private void entryView_Unfocused(object sender, FocusEventArgs e)
        {

            _textView.TextColor = Color.Black;

        }

        public List<Object> Elements
        {

            get
            {

                List<Object> elements = new List<object>();

                elements.Add(_textView);

                if (_entryDisplayMode == sEntryDisplayMode.Normal) elements.Add(_entry);
                else elements.Add(_editor);

                return elements;

            }

            set
            {

                List<Object> elements = new List<object>();

                elements.Add(_textView);

                if (_entryDisplayMode == sEntryDisplayMode.Normal) elements.Add(_entry);
                else elements.Add(_editor);

                elements = value;

            }

        }

        public string PlaceHolder
        {

            get
            {

                if(_entryDisplayMode == sEntryDisplayMode.Normal) return _entry.Placeholder;
                else { throw new Exception("Change the mode display to normal, editor haven't placeholder."); }

            }
            set
            {

                if (_entryDisplayMode == sEntryDisplayMode.Normal) _entry.Placeholder = value;
                else { throw new Exception("Change the mode display to normal, editor haven't placeholder."); }

            }

        }

        public string Title
        {

            get { return _textView.Text; }
            set { _textView.Text = value; }

        }
        
        public sEntryDisplayMode EntryDisplayMode
        {

            get { return _entryDisplayMode; }
            set
            {
                if (_entryDisplayMode != value)
                {

                    _entryDisplayMode = value;
                    this.Children.RemoveAt(1);
                    DisplayMode();

                }

            }

        }

    }

    public enum sEntryDisplayMode
    {

        Normal,
        Multiline

    }

}
