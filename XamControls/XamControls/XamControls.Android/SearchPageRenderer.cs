using System;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.CustomRenders;
using XamControls.Droid;
using XamControls.Views;
using SearchView = Android.Support.V7.Widget.SearchView;

[assembly: ExportRenderer(typeof(CustomSearchPage), typeof(SearchPageRenderer))]
namespace XamControls.Droid
{
    public class SearchPageRenderer : PageRenderer
    {

        private readonly Context _localContext;
        public Android.Support.V7.Widget.Toolbar _toolBar;

        public SearchView _searchView;

        public Android.Support.V7.Widget.ActionMenuView actionMenuView;
        public AppCompatImageButton appCompatImageButton;
        public AppCompatTextView appCompatTextView;
        

        public SearchPageRenderer(Context context) : base(context)
        {

            _localContext = context;

        }
        
        private bool navigationPush = false;
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            AppCompatImageButton search = null;

            for (int i = 0; i < _toolBar.ChildCount; i++)
            {

                if (_toolBar.GetChildAt(i) is AppCompatImageButton) { search = (AppCompatImageButton)_toolBar.GetChildAt(i); }

            }

            this._toolBar.SetBackgroundColor(Android.Graphics.Color.Rgb(33, 150, 243));

            if ((Element as CustomSearchPage).ChangePage == 2) { navigationPush = true; }
            else if ((Element as CustomSearchPage).ChangePage == 1 && search != null) { AddSearchToToolBar(); (Element as CustomSearchPage).ChangePage = 0; }
            else if ((Element as CustomSearchPage).ChangePage == 1 && navigationPush) { AddSearchToToolBar(); (Element as CustomSearchPage).ChangePage = 0; navigationPush = false; }
            else if (search == null) { (Element as CustomSearchPage).ChangePage = 0; }

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {

            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            _toolBar = ((Android.App.Activity)_localContext).FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            (Element as CustomSearchPage).ChangePage = 1;

        }

        protected override void Dispose(bool disposing)
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange += searchView_QueryTextChange;
                _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            }
            MainActivity.ToolBar?.Menu?.RemoveItem(Resource.Layout.mainmenu);

            base.Dispose(disposing);
            
        }

        public void AddSearchToToolBar()
        {

            _toolBar.Title = "XamControls"; //Element.Title;

            //_toolBar.Menu.GetItem(0).SetIcon();

            InitializeSearchView();

            if (_toolBar?.GetChildAt(1) is AppCompatTextView)
            {
                actionMenuView = (Android.Support.V7.Widget.ActionMenuView)_toolBar?.GetChildAt(0);
                appCompatTextView = (AppCompatTextView)_toolBar?.GetChildAt(1);
                appCompatImageButton = (AppCompatImageButton)_toolBar?.GetChildAt(2);

            }
            else
            {

                actionMenuView = (Android.Support.V7.Widget.ActionMenuView)_toolBar?.GetChildAt(0);
                appCompatImageButton = (AppCompatImageButton)_toolBar?.GetChildAt(1);
                appCompatTextView = (AppCompatTextView)_toolBar?.GetChildAt(2);

            }

        }

        public void InitializeSearchView()
        {

            _searchView = new SearchView(_localContext);

            _toolBar.InflateMenu(Resource.Layout.mainmenu);

            _searchView = _toolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            _searchView.QueryTextChange += searchView_QueryTextChange;
            _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            //_searchView.QueryHint = (Element as CustomSearchPage)?.Text;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;
            _searchView.QueryHint = "Search...";

            _searchView.Focusable = true;
            _searchView.Clickable = true;
            _searchView.SetOnSearchClickListener(new OnSearchClickListener(this));

            int closeButtonId = Resource.Id.search_close_btn;
            ImageView closeButtonImage = (ImageView)_searchView.FindViewById(closeButtonId);
            closeButtonImage.SetImageResource(Resource.Drawable.ic_clear_black_24dp);

            var searchViewLinearLayout = (LinearLayout)_searchView.GetChildAt(0);

            var sViewUnderLayout = (Android.Widget.LinearLayout)searchViewLinearLayout.GetChildAt(2);

            var vsearch1_3_1 = (Android.Support.V7.Widget.AppCompatImageView)sViewUnderLayout.GetChildAt(0);
            var textViewLayout = (Android.Widget.LinearLayout)sViewUnderLayout.GetChildAt(1);
            var vsearch1_3_3 = (Android.Widget.LinearLayout)sViewUnderLayout.GetChildAt(2);

            var textView = (Android.Support.V7.Widget.AppCompatAutoCompleteTextView)textViewLayout.GetChildAt(0);

            textView.SetTextColor(Android.Graphics.Color.Rgb(80, 80, 80));
            textView.SetHintTextColor(Android.Graphics.Color.Rgb(90, 90, 90));
            textView.FocusSearch(FocusSearchDirection.Left);
            textView.Click += TextView_Click;

            var search = ((actionMenuView?.FindViewById<Android.Support.V7.View.Menu.ActionMenuItemView>(Resource.Id.action_search))?.ItemData as Android.Support.V7.View.Menu.MenuItemImpl)?.SetActionView(_searchView);

        }

        private void TextView_Click(object sender, EventArgs e)
        {
            var tView = sender as AppCompatAutoCompleteTextView;

            tView.RequestFocus();

        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {

            var baseElement = Element as CustomSearchPage;

            if (string.IsNullOrEmpty(e.NewText))
            {
                baseElement.ListView.ItemsSource = baseElement.ListItems;
            }

            else
            {
                baseElement.ListView.ItemsSource = baseElement.ListItems.Where(x => x.Nom.ToUpper().Contains(e.NewText.ToUpper()));
            }

        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            var searchPage = Element as SearchPage;
            //searchPage.SearchText = e.Query;
            //searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

    }

    /// <summary>
    /// OnSearchClickListener class
    /// </summary>
    public class OnSearchClickListener : FormsAppCompatActivity, Android.Views.View.IOnClickListener
    {

        private SearchPageRenderer _searchPageRenderer;

        public OnSearchClickListener(SearchPageRenderer searchPageRenderer) { _searchPageRenderer = searchPageRenderer; }

        public void OnClick(Android.Views.View v)
        {

            var view1 = (Android.Support.V7.Widget.ActionMenuView)_searchPageRenderer._toolBar.GetChildAt(0);
            var view1_1 = view1.GetChildAt(0);

            // White color to Toolbar
            _searchPageRenderer._toolBar.SetBackgroundColor(Android.Graphics.Color.White);

            // BackButton Listener
            
            var backButton =  (Android.Support.V7.Widget.AppCompatImageButton)_searchPageRenderer._toolBar.GetChildAt(1);
            backButton.SetImageResource(Resource.Drawable.ic_arrow_back_black_24dp);
            backButton.SetOnClickListener(new OnCloseClickListener(_searchPageRenderer));

        }

    }

    /// <summary>
    /// OnCloseClickListener class
    /// </summary>
    public class OnCloseClickListener : FormsAppCompatActivity, Android.Views.View.IOnClickListener
    {

        private SearchPageRenderer _searchPageRenderer;

        public OnCloseClickListener(SearchPageRenderer searchPageRenderer) {

            _searchPageRenderer = searchPageRenderer;

        }

        public void OnClick(Android.Views.View v)
        {

            // Blue color to Toolbar
            _searchPageRenderer._toolBar.SetBackgroundColor(Android.Graphics.Color.Rgb(33, 150, 243));

            var search = ((_searchPageRenderer.actionMenuView?.FindViewById<Android.Support.V7.View.Menu.ActionMenuItemView>(Resource.Id.action_search))?.ItemData as Android.Support.V7.View.Menu.MenuItemImpl)?.CollapseActionView();

        }

    }

}