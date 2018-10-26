using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamControls.iOS;
using XamControls.Views;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace XamControls.iOS
{
    public class SearchPageRenderer : PageRenderer
    {

        private UIButton _cancelButton;
        private UIBarButtonItem _searchbarButtonItem;
        private UIView _defaultTitleView;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _defaultTitleView = NavigationItem?.TitleView;
            CreateSearchToolbar();

        }

        private void CreateSearchToolbar()
        {
            var element = Element as SearchPage;

            if (element == null || NavigationController?.NavigationBar == null)
            {
                return;
            }

            var width = NavigationController.NavigationBar.Frame.Width + 100;
            var height = NavigationController.NavigationBar.Frame.Height;
            var searchBar = new UIStackView(new CoreGraphics.CGRect(0, 0, width * 0.75, height))
            {
                Alignment = UIStackViewAlignment.Fill,
                Axis = UILayoutConstraintAxis.Horizontal,
                Spacing = 3,                
                
            };

            var searchTextField = new UITextField
            {
                BackgroundColor = UIColor.White,
                //AttributedPlaceholder = new NSAttributedString(element.SearchPlaceHolderText, foregroundColor: UIColor.Gray),
                //Placeholder = element.SearchPlaceHolderText,
            };
            searchTextField.SizeToFit();
            //searchTextField.AdjustsFontSizeToFitWidth = true;

            // Delete button
            var textDeleteButton = new UIButton(new CoreGraphics.CGRect(0, 0, searchTextField.Frame.Size.Height + 5, searchTextField.Frame.Height)) { BackgroundColor = UIColor.Clear };
            textDeleteButton.SetTitleColor(UIColor.FromRGB(146, 146, 146), UIControlState.Normal);
            textDeleteButton.SetTitle("\u24CD", UIControlState.Normal);

            textDeleteButton.TouchUpInside += (sender, e) =>
            {
                searchTextField.Text = string.Empty;
                searchTextField.ResignFirstResponder();
            };

            searchTextField.RightView = textDeleteButton;
            searchTextField.RightViewMode = UITextFieldViewMode.Always;

            // Border
            searchTextField.BorderStyle = UITextBorderStyle.RoundedRect;
            searchTextField.Layer.BorderColor = UIColor.FromRGB(239, 239, 239).CGColor;
            searchTextField.Layer.BorderWidth = 1;
            searchTextField.Layer.CornerRadius = 5;
            //searchTextField.EditingChanged += (sender, e) => element.SetValue(SearchPage.SearchTextProperty, searchTextField.Text);
            searchTextField.KeyboardType = UIKeyboardType.Default;
            //searchTextField.EditingDidEndOnExit += (sender, e) => element.SearchCommand?.Execute(searchTextField.Text);
            searchBar.AddArrangedSubview(searchTextField);

            NavigationItem.TitleView = new UIView();
            //NavigationItem.TitleView.Add(searchBar);
            _searchbarButtonItem = new UIBarButtonItem(searchBar);

            NavigationItem.SetLeftBarButtonItem(_searchbarButtonItem, true);

            NavigationItem.TitleView = new UIView();

            if (ParentViewController?.NavigationItem == null)
            {
                return;
            }
            //ParentViewController.NavigationItem.LeftBarButtonItem = 
            ParentViewController.NavigationItem.TitleView = NavigationItem.TitleView;
            ParentViewController.NavigationItem.TitleView = searchBar;

        }

        private void DisplayRightBarButton(UIView button)
        {
            if (ParentViewController?.NavigationItem != null)
            {
                ParentViewController.NavigationItem.RightBarButtonItem = new UIBarButtonItem(button);
            }
        }      

    }
}