using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TeeChartDashBoards
{
    public class Home : ContentPage
    {
        NavigationPage nav;

        public Home()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 5,
                RowDefinitions = 
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  },                    
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)  }
                }
            };

            // Create the Chart pages whose contain a specific Chart on each one
            DashBoards.Page1 dashchart0 = new DashBoards.Page1();
            DashBoards.Page2 dashchart1 = new DashBoards.Page2();
            DashBoards.Page3 dashchart2 = new DashBoards.Page3();
            DashBoards.Page4 dashchart3 = new DashBoards.Page4();
            DashBoards.Page5 dashchart4 = new DashBoards.Page5();
            DashBoards.Page6 dashchart5 = new DashBoards.Page6();
            DashBoards.Page7 dashchart6 = new DashBoards.Page7();

            Button button0 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page1()))
            };

            Button button1 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page2()))
            };

            Button button2 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page3()))
            };

            Button button3 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page4()))
            };

            Button button4 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page5()))
            };

            Button button5 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page6()))
            };

            Button button6 = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Command = new Command(() => Navigation.PushAsync(new DashBoards.Page7()))
            };

            // Añadimos botones a la Grid
            grid.Children.Add(dashchart0.DashView0, 0, 2, 0, 1);
            grid.Children.Add(button0, 0, 2, 0, 1);
            grid.Children.Add(dashchart1.DashView1, 2, 4, 0, 1);
            grid.Children.Add(button1, 2, 4, 0, 1);
            grid.Children.Add(dashchart2.DashView2, 0, 1);
            grid.Children.Add(button2, 0, 1);
            grid.Children.Add(dashchart3.DashView3, 1, 3, 1, 2);
            grid.Children.Add(button3, 1, 3, 1, 2);
            grid.Children.Add(dashchart4.DashView4, 3, 4, 1, 3);
            grid.Children.Add(button4, 3, 4, 1, 3);
            grid.Children.Add(dashchart5.DashView5, 0, 2, 2, 3);
            grid.Children.Add(button5, 0, 2, 2, 3);
            grid.Children.Add(dashchart6.DashView6, 2, 2);
            grid.Children.Add(button6, 2, 2);

            Content = grid;
        }
    }
}
