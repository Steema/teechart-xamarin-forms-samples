using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.CustomCharts.Layouts
{
    public class sFlexLayout : Grid
    {

        private Label _textView;
        private StackLayout _layoutImage;
        private FlexLayout _flexLayout;

        private string[] _dataImage;

        public sFlexLayout(string[] data)
        {

            _textView = new Label();
            _flexLayout = new FlexLayout();
            _dataImage = data;

            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.Start;

            for(int i = 0; i <_dataImage.Length; i++)
            {

                _layoutImage = new StackLayout();
                _layoutImage.Children.Add(new Label() { Text = _dataImage[i] });
                _layoutImage.Children.Add(new Image() { Source = _dataImage[i] });

                _flexLayout.Children.Add(_layoutImage);

            }

            _flexLayout.Wrap = FlexWrap.Wrap;
            _flexLayout.JustifyContent = FlexJustify.SpaceAround;

            this.Children.Add(_flexLayout);

        }



    }
}
