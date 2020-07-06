using Refractored.FabControl;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamControls.ViewModels;
using XamControls.Views;

namespace XamControls.Components.UpPopup.Types
{
    public class EntryPopup : PopupModel
    {
        private CustomCharts.Services.ChartController _chartService;
        private CustomNavigationPage _navPage;

		public EntryPopup()
		{
            InternalSelectItemsDisplay();
		}

        #region PUBLIC FUNCTIONS

        /// <summary>
        /// Muestra el popupView y guarda el objeto chartController
        /// </summary>
        /// <param name="chartService"></param>
        public void Display(CustomCharts.Services.ChartController chartService, CustomNavigationPage navPage)
		{

            this._chartService = chartService;
            this._navPage = navPage;
			PopupNavigation.Instance.PushAsync(this);

		}

        #endregion

        #region PRIVATE FUNCTIONS

        /// <summary>
        /// Crea los objetos a mostrar el el popupView
        /// </summary>
        private Entry editTextView;
        private void InternalSelectItemsDisplay()
        {

            Label labelTitle = new Label();
            labelTitle.Text = "Create a chart";
            labelTitle.FontSize = 20;
            labelTitle.TextColor = Color.Black;
            labelTitle.Margin = new Thickness(10, 5, 0, 0);

            Label labelSubTitle = new Label();
            labelSubTitle.Text = "Name your chart";
            labelSubTitle.FontSize = 15;
            labelSubTitle.Margin = new Thickness(10, 5, 0, 0);

            editTextView = new Entry();
            editTextView.Margin = new Thickness(10, 0, 0, 20);
            editTextView.MaxLength = 30;
            editTextView.Text = "Write the name for your chart";
            editTextView.TextColor = Color.FromRgb(140, 140, 140);
            editTextView.Focused += EditTextView_Focused;
            editTextView.Unfocused += EditTextView_Unfocused;

            Button buttonOK = new Button();
            buttonOK.Text = "CREATE";
            buttonOK.HorizontalOptions = LayoutOptions.End;
            buttonOK.Clicked += ButtonOK_Clicked;

            StackLayout layoutButtons = new StackLayout();
            layoutButtons.HorizontalOptions = LayoutOptions.FillAndExpand;
            layoutButtons.Orientation = StackOrientation.Horizontal;
            layoutButtons.WidthRequest = 200;
            layoutButtons.HeightRequest = 50;
            layoutButtons.Children.Add(buttonOK);

            DefaultPopup();

            AddView(labelTitle);
            AddView(labelSubTitle);
            AddView(editTextView);
            AddView(layoutButtons);


        }

        private void EditTextView_Unfocused(object sender, FocusEventArgs e)
        {

            var editor = sender as Entry;

            if(editor.Text == "") { editor.Text = "Write the name for your chart"; editor.TextColor = Color.FromRgb(140, 140, 140); }

        }

        /// <summary>
        /// Muestra alerta de error cuando el nombre introducido es menor que 5
        /// </summary>
        /// <returns></returns>
        private async Task DisplayAlertShortNameAsync()
        {

            await DisplayAlert("Short name", "Put 5 characters or more", "OK");

        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Evento de click en el boton "OK"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonOK_Clicked(object sender, EventArgs e)
        {
            if (editTextView.Text.Length >= 5)
            {
                CustomCharts.CustomChart chart = new CustomCharts.CustomChart(editTextView.Text, _navPage);
                _chartService.Add(chart);
                editTextView.Text = "Write the name for your chart";
                editTextView.TextColor = Color.FromRgb(140, 140, 140);
                await PopupNavigation.Instance.RemovePageAsync(this);
            }
            else { await DisplayAlertShortNameAsync(); }
        }
        /// <summary>
        /// Edicion del textView para introducir nombre del chart
        /// </summary>
		private void EditTextView_Focused(object sender, FocusEventArgs e)
		{
            var editor = sender as Entry;

            if (editor.Text == "Write the name for your chart")
            {
                editor.Text = "";
                editor.TextColor = Color.Black;
            }
            else { editor.Focus(); }
		}

		/// <summary>
		/// OnAppearing Event
		/// </summary>
		private FloatingActionButtonView onAppearingActionElement;
		public void SetOnAppearing(FloatingActionButtonView view)
		{
			onAppearingActionElement = view;
		}

		protected override void OnAppearing()
		{
			if (onAppearingActionElement != null) onAppearingActionElement.Hide();
			base.OnAppearing();
		}

		/// <summary>
		/// OnDisappearing Event
		/// </summary>
		private FloatingActionButtonView onBackActionElement;
		public void SetOnBackButtonPressed(FloatingActionButtonView view)
		{
			onBackActionElement = view;
		}

		protected override void OnDisappearing()
		{
			if (onBackActionElement != null) onBackActionElement.Show();
			base.OnDisappearing();
		}

        #endregion

    }

}
