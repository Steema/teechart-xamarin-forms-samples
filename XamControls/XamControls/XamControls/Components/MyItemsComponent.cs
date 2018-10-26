using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.CustomRenders;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using XamControls.Components.Popup.Views;
using XamControls.Components.Popup;
using XamControls.Components.Popup.Enums;
using XamControls.Components.Popup.Styles;

namespace XamControls.Components
{

		// NO ACABADO --- MY ITEMS /CHART
    public class MyItemsComponent : StackLayout
    {

				private Grid gridPrincipal;
				private Button crearNewChart;
				private PopupView popup1;

				public MyItemsComponent()
				{

						gridPrincipal = new Grid();
						crearNewChart = new Button();

						gridPrincipal.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.2, GridUnitType.Star) });
						gridPrincipal.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.8, GridUnitType.Star) });
						gridPrincipal.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
						gridPrincipal.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });

						crearNewChart.Text = "Create new chart";
						crearNewChart.CornerRadius = 5;
						crearNewChart.BackgroundColor = Color.FromRgb(33, 150, 244);
						crearNewChart.BorderColor = Color.FromRgb(30, 134, 224);
						crearNewChart.WidthRequest = 40;
						crearNewChart.HeightRequest = 40;

						CrearMenuSuperior();

						this.Margin = 0;
						this.Padding = 0;
						gridPrincipal.Margin = 0;
						gridPrincipal.Padding = 0;
						this.Children.Add(gridPrincipal);

						crearNewChart.Clicked += CrearNewChart_Clicked;

						gridPrincipal.Children.Add(new LinearLayout(), 0, 1);
						
				}

				private void CrearMenuSuperior()
				{

						gridPrincipal.Children.Add(crearNewChart, 0, 0);

						CustomCheckBox customCheckBox = new CustomCheckBox();

						//gridPrincipal.Children.Add(new CustomButtonShowMenuInferior(), 0, 1);
						gridPrincipal.Children.Add(customCheckBox, 0, 1);
	
				}

				private void CrearNewChart_Clicked(object sender, EventArgs e)
				{

						StackLayout sl = new StackLayout();

						popup1 = new PopupView();
						popup1.PopupStyle = PopupViewStyle.Basic;
						((PopupBasicStyle)popup1.Element[0]).Title = "My Popup";
						popup1.Show();

						/*
						StackLayout basePopup = new StackLayout();
						CustomCheckBox check1 = new CustomCheckBox();
						CustomCheckBox check2 = new CustomCheckBox();
						CustomCheckBox check3 = new CustomCheckBox();

						check1.Text = "Option 1";
						check2.Text = "Option 2";
						check3.Text = "Option 3";

						check1.Pressed += Check_Pressed;
						check2.Pressed += Check_Pressed;
						check3.Pressed += Check_Pressed;

						basePopup.BackgroundColor = Color.White;
						basePopup.WidthRequest = 300;
						basePopup.HeightRequest = 200;
						basePopup.Children.Add(new Label() { Text = "Hola" });
						basePopup.Children.Add(check1);
						basePopup.Children.Add(check3);
						basePopup.Children.Add(check2);
						basePopup.HorizontalOptions = LayoutOptions.Center;
						basePopup.VerticalOptions = LayoutOptions.Center;

						popup.Content = basePopup;

						;
						*/
		

				}

		        private void Check_Pressed(object sender, EventArgs e)
		        {
			
		        }
	}

	public class LinearLayout : StackLayout
	{

		public LinearLayout()
		{

			this.Children.Add(new Label() { Text = "Hola" });

		}

	}
}
