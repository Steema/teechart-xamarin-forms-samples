using Refractored.FabControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamControls.CustomCharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.Components;
using XamControls.Components.UpPopup.Types;
using XamControls.ViewModels;
using System.Collections.ObjectModel;

namespace XamControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonalChartsPage : ContentPage
	{

        private StackLayout pageLayout;
		private AbsoluteLayout absolutelayout;
		private ListView lView;
		private NavigationBarViewModel navBar;
		private MasterView master;
		private FloatingActionButtonView floatingButton;
        private ObservableCollection<CustomChart> collectionCustomChart = new ObservableCollection<CustomChart>();

		public PersonalChartsPage()
		{

			InitializeComponent();

			pageLayout = new StackLayout();
			absolutelayout = new AbsoluteLayout();
			lView = InitializeListView();
			navBar = new NavigationBarViewModel(lView, new List<Models.ItemsListView>(), master);
			floatingButton = InitializeFloatingButton();

			this.IconImageSource = new FileImageSource { File = "ic_pie_chart_black_24dp.png" };
			this.Title = "My Charts";
			this.Content = absolutelayout;

			pageLayout.Children.Add(navBar);
            UpdateLayout();
			AbsoluteLayout.SetLayoutFlags(pageLayout, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(pageLayout, new Rectangle(0f, 0f, 1f, 1f));

			absolutelayout.HorizontalOptions = LayoutOptions.FillAndExpand;
			absolutelayout.VerticalOptions = LayoutOptions.FillAndExpand;
			absolutelayout.Children.Add(pageLayout);
			absolutelayout.Children.Add(floatingButton);

		}

        private void UpdateLayout()
        {

            if (lView.ItemsSource != null)
            {
                pageLayout.Children.Add(lView);
            }
            else
            {

                StackLayout layoutNotElements = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                layoutNotElements.Children.Add(new Label() { Text = "Elements not found", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center });
                pageLayout.Children.Add(layoutNotElements);

            }

        }

		private ListView InitializeListView()
		{

				ListView listView = new ListView();

				listView.HorizontalOptions = LayoutOptions.Fill;
				listView.VerticalOptions = LayoutOptions.FillAndExpand;

				return listView;

		}

		private FloatingActionButtonView InitializeFloatingButton()
		{

			FloatingActionButtonView floatingButton = new FloatingActionButtonView();
			EntryPopup entryPopup = new EntryPopup();

			entryPopup.SetOnBackButtonPressed(floatingButton);
			entryPopup.SetOnAppearing(floatingButton);

			floatingButton.ColorNormal = Color.FromRgb(33, 150, 243);
			floatingButton.ColorPressed = floatingButton.ColorNormal.AddLuminosity(0.1);
			floatingButton.ColorRipple = floatingButton.ColorNormal.AddLuminosity(0.2);
			floatingButton.ImageName = "ic_add.png";
			AbsoluteLayout.SetLayoutFlags(floatingButton, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(floatingButton, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			return floatingButton;

		}

        public MasterView SetMaster { set { master = value; navBar.SetMasterView = value; } }

        // Evento al entrar en esta view
        protected override void OnAppearing()
		{

			base.OnAppearing();

			floatingButton.Show();

		}

		// Evento al salir de esta view
		protected override void OnDisappearing()
		{

			base.OnDisappearing();

			floatingButton.Hide();

		}

	}
}