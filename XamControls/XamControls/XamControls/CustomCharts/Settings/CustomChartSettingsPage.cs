using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamControls.CustomCharts.Layouts;
using XamControls.Views;
using Steema.TeeChart.Styles;

namespace XamControls.CustomCharts.Settings
{
    public class CustomChartSettingsPage : TabbedPage
    {

        CustomChart _customChart;
        CustomNavigationPage _navPage;

        public CustomChartSettingsPage(CustomChart myChart, CustomNavigationPage navBar)
        {

            this.Title = "Chart Settings";
            _navPage = navBar;
            _customChart = myChart;
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this, Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Top);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);

            BuildView();

        }

        private void BuildView()
        {

            ChartData();

            if (_customChart.IsEmpty) { DisplaySettingsPage(); }
            else { DisplayConfiguratePage(); }

        }

        /// <summary>
        /// Get Data for picker (Chart Types)
        /// </summary>
        /// <returns></returns>
        private List<String[]> ChartData()
        {

            List<String[]> dataChartType = new List<String[]>();
            String[] item;
            string[] imagePath = new string[27] { "area.png", "arrow.png", "bar.png", "barjoin.png", "bezier.png", "box.png", "bubbles.png", "candle.png", "contour.png",
                "darvas.png", "donut.png", "error.png", "errorbar.png", "errorpoint.png", "fastline.png", "highlow.png",
                "histogram.png", "horizarea.png", "horizbar.png", "horizline.png", "isosurface.png", "line.png", "linepoint.png", "pie.png", "surface.png", "tower.png", "volume.png" };

            for (int i = 0; i < imagePath.Length; i++)
            {

                item = new String[2];
                
                item[0] = imagePath[i].Split('.')[0].ToUpper(); // Name
                item[1] = imagePath[i]; // Image URL

                dataChartType.Add(item);

            }

            return dataChartType;

        }

        #region Configuration

        // First time en aquest chart
        private void DisplayConfiguratePage()
        {

            this.Children.Add(InitializePrincipalPage());
            this.Children.Add(InitializeDataPage());
            this.Children.Add(InitializeAxesPage());
            this.Children.Add(InitializeLegendPage());
            this.Children.Add(InitializeFormatPage());

            _customChart.IsEmpty = false;

        }

        private Xamarin.Forms.Page InitializeFormatPage()
        {

            ContentPage specificPage = new ContentPage();

            specificPage.Title = "Format";

            return specificPage;

        }

        private Xamarin.Forms.Page InitializeLegendPage()
        {

            ContentPage legendPage = new ContentPage();

            legendPage.Title = "Legend";

            return legendPage;

        }

        private Xamarin.Forms.Page InitializeAxesPage()
        {

            ContentPage axesPage = new ContentPage();

            axesPage.Title = "Axes";

            return axesPage;

        }

        private Xamarin.Forms.Page InitializeDataPage()
        {

            ContentPage dataPage = new ContentPage();
            ScrollView scrollView = new ScrollView();
            StackLayout view = new StackLayout();
            StackLayout fillSampleValuesView = new StackLayout();
            Button fillSampleValuesButton = new Button();
            Label fillSampleValuesLabel = new Label();
            StackLayout customValuesView = new StackLayout();
            Label customValuesLabel = new Label();
            ListView listViewValues = new ListView(ListViewCachingStrategy.RecycleElementAndDataTemplate);

            dataPage.Content = scrollView;
            dataPage.Title = "Data";

            scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
            scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
            scrollView.Content = view;

            view.HorizontalOptions = LayoutOptions.FillAndExpand;
            view.VerticalOptions = LayoutOptions.FillAndExpand;
            view.Children.Add(fillSampleValuesView);
            view.Children.Add(customValuesView);

            #region Group Data

            // FillSample View
            fillSampleValuesView.HorizontalOptions = LayoutOptions.FillAndExpand;
            fillSampleValuesView.VerticalOptions = LayoutOptions.Start;
            fillSampleValuesView.Children.Add(fillSampleValuesLabel);
            fillSampleValuesView.Children.Add(fillSampleValuesButton);

            fillSampleValuesLabel.Text = "Fill Sample Values";
            fillSampleValuesButton.Text = "Random";
            fillSampleValuesButton.Clicked += FillSampleValuesButton_Clicked;

            // CustomValues View
            customValuesView.HorizontalOptions = LayoutOptions.FillAndExpand;
            customValuesView.VerticalOptions = LayoutOptions.Start;
            customValuesView.Children.Add(customValuesLabel);
            customValuesView.Children.Add(listViewValues);

            customValuesLabel.Text = "Custom Values";
            listViewValues.WidthRequest = 100;
            listViewValues.HeightRequest = 100;
            listViewValues.HorizontalOptions = LayoutOptions.FillAndExpand;
            listViewValues.VerticalOptions = LayoutOptions.Start;
            listViewValues.BackgroundColor = Color.Red;
            listViewValues.IsPullToRefreshEnabled = true;
            if(_customChart.ChartView.Chart?.Series.Count != 0) listViewValues.ItemsSource = _customChart.ChartView.Chart?.Series?[0]?.Colors;
            ConfigureListViewCustomValues(ref listViewValues);

            #endregion

            return dataPage;

        }


        /// <summary>
        /// Pagina principal amb nom, chart a elegir, descripcio...
        /// </summary>
        /// <returns></returns> 
        private Xamarin.Forms.Page InitializePrincipalPage()
        {

            ContentPage principalPage = new ContentPage();
            ScrollView scrollView = new ScrollView();
            StackLayout layout = new StackLayout();
            Grid gridAboutChart = new Grid();
            StackLayout groupAboutChart = new StackLayout();
            Label lblGroupAboutChart = new Label();
            Picker pickerChart = new Picker();
            StackLayout groupMarksChart = new StackLayout();
            Label lblGroupMarksChart = new Label();
            StackLayout layoutShowMarks = new StackLayout();
            StackLayout linLayoutShowMarks = new StackLayout();
            CustomRenders.CustomCheckBox checkShowMarks = new CustomRenders.CustomCheckBox();

            sTextEntry nameChart = new sTextEntry();
            sTextEntry descriptionChart = new sTextEntry();
            Button imageChart = new Button();

            List<String[]> originalData = ChartData();
            String[] dataPicker = new String[originalData.Count];

            for(int i = 0; i < originalData.Count; i++)
            {

                dataPicker[i] = originalData[i][0];

            }

            principalPage.Content = scrollView;
            principalPage.Title = "General";

            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            layout.Children.Add(groupAboutChart);
            layout.Children.Add(gridAboutChart);
            layout.Children.Add(groupMarksChart);
            layout.Children.Add(layoutShowMarks);

            scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
            scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
            scrollView.Content = layout;

            #region Group AboutThisChart

            groupAboutChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            groupAboutChart.Margin = new Thickness(5, 5, 0, 10);
            groupAboutChart.Children.Add(lblGroupAboutChart);
            lblGroupAboutChart.Text = "ABOUT CHART";
            lblGroupAboutChart.FontSize = 14;
            lblGroupAboutChart.TextColor = Color.FromRgb(26, 115, 232);
            lblGroupAboutChart.FontAttributes = FontAttributes.Bold;

            nameChart.Margin = 5;
            nameChart.PlaceHolder = "Rename your chart";
            nameChart.Title = "Chart name";
            (nameChart.Elements[1] as Entry).Unfocused += NameChart_Unfocused;

            descriptionChart.Margin = 5;
            descriptionChart.Title = "Description";
            descriptionChart.EntryDisplayMode = sEntryDisplayMode.Multiline;
            (descriptionChart.Elements[1] as Editor).Unfocused += DescriptionChart_Unfocused;

            imageChart.HorizontalOptions = LayoutOptions.Fill;
            imageChart.VerticalOptions = LayoutOptions.Fill;
            imageChart.Image = "bar.png";
            imageChart.Clicked += ImageChart_Clicked;
            imageChart.CornerRadius = 0;
            imageChart.BorderWidth = 0;
            imageChart.BackgroundColor = Color.Transparent;

            gridAboutChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            gridAboutChart.VerticalOptions = LayoutOptions.Start;
            gridAboutChart.Margin = 10;
            gridAboutChart.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.2, GridUnitType.Star) });
            gridAboutChart.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.8, GridUnitType.Star) });
            gridAboutChart.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.15, GridUnitType.Star) });
            gridAboutChart.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.85, GridUnitType.Star) });
            gridAboutChart.Children.Add(nameChart, 1, 0);
            gridAboutChart.Children.Add(descriptionChart, 0, 1);
            Grid.SetColumnSpan(descriptionChart, 2);
            gridAboutChart.Children.Add(imageChart, 0, 0);
            gridAboutChart.Children.Add(pickerChart, 0, 0);

            pickerChart.ItemsSource = dataPicker;
            pickerChart.IsVisible = false;
            pickerChart.SelectedIndexChanged += PickerChart_SelectedIndexChanged;

            #endregion

            #region Group MarksChart

            groupMarksChart.HorizontalOptions = LayoutOptions.FillAndExpand;
            groupMarksChart.Margin = new Thickness(15, 5, 0, 10);
            groupMarksChart.Children.Add(lblGroupMarksChart);
            lblGroupMarksChart.Text = "MARKS";
            lblGroupMarksChart.FontSize = 14;
            lblGroupMarksChart.TextColor = Color.FromRgb(26, 115, 232);
            lblGroupMarksChart.FontAttributes = FontAttributes.Bold;

            layoutShowMarks.HorizontalOptions = LayoutOptions.FillAndExpand;
            layoutShowMarks.VerticalOptions = LayoutOptions.Start;
            layoutShowMarks.Children.Add(linLayoutShowMarks);

            linLayoutShowMarks.Orientation = StackOrientation.Horizontal;
            linLayoutShowMarks.Children.Add(checkShowMarks);

            checkShowMarks.Text = "Show marks";
            checkShowMarks.Checked = false;
            checkShowMarks.WasCheckedChanged += CheckShowMarks_Focoused;

            #endregion

            return principalPage;

        }

        private void CheckShowMarks_Focoused(object sender, EventArgs e)
        {

            var view = sender as CustomRenders.CustomCheckBox;

            if(view.Checked) _customChart.ChartView.Chart.Series[0].Marks.Visible = true;
            else _customChart.ChartView.Chart.Series[0].Marks.Visible = false;

        }

        private void ChartToCreate(String item)
        {
            List<String[]> originalData = ChartData();
            String[] dataPicker = new String[originalData.Count];

            for (int i = 0; i < originalData.Count; i++)
            {

                dataPicker[i] = originalData[i][1];

            }
            _customChart.ChartView.Chart.Series.RemoveAllSeries();

            var imageButton = ((((this.Children[0] as ContentPage).Content as ScrollView).Content as StackLayout).Children[1] as Grid).Children[2] as Button;

            switch (item)
            {

                case "AREA":
                    Area area = new Area();
                    area.FillSampleValues(3);
                    _customChart.ChartView.Chart.Series.Add(area);
                    _customChart.ImageSource = dataPicker[0];
                    imageButton.Image = dataPicker[0];

                    break;

                case "ARROW":
                    Arrow arrow = new Arrow();
                    arrow.FillSampleValues(10);
                    _customChart.ChartView.Chart.Series.Add(arrow);
                    _customChart.ImageSource = dataPicker[1];
                    imageButton.Image = dataPicker[1];
                    break;

                case "BAR":
                    Bar bar = new Bar();
                    bar.FillSampleValues(4);
                    _customChart.ChartView.Chart.Series.Add(bar);
                    _customChart.ImageSource = dataPicker[2];
                    imageButton.Image = dataPicker[2];
                    break;

                case "BARJOIN":
                    BarJoin barjoin = new BarJoin();
                    barjoin.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(barjoin);
                    _customChart.ImageSource = dataPicker[3];
                    imageButton.Image = dataPicker[3];
                    break;

                case "BEZIER":
                    Bezier bezier = new Bezier();
                    bezier.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(bezier);
                    _customChart.ImageSource = dataPicker[4];
                    imageButton.Image = dataPicker[4];
                    break;

                case "BOX":
                    Box box = new Box();
                    box.FillSampleValues(3);
                    _customChart.ChartView.Chart.Series.Add(box);
                    _customChart.ImageSource = dataPicker[5];
                    imageButton.Image = dataPicker[5];
                    break;

                case "BUBBLES":
                    Bubble bubble = new Bubble();
                    bubble.FillSampleValues(7);
                    _customChart.ChartView.Chart.Series.Add(bubble);
                    _customChart.ImageSource = dataPicker[6];
                    imageButton.Image = dataPicker[6];
                    break;

                case "CANDLE":
                    Candle candle = new Candle();
                    candle.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(candle);
                    _customChart.ImageSource = dataPicker[7];
                    imageButton.Image = dataPicker[7];
                    break;

                case "CONTOUR":
                    Contour countour = new Contour();
                    countour.FillSampleValues(1);
                    _customChart.ChartView.Chart.Series.Add(countour);
                    _customChart.ImageSource = dataPicker[8];
                    imageButton.Image = dataPicker[8];
                    break;

                case "DARVAS":
                    Darvas darvas = new Darvas();
                    darvas.FillSampleValues(3);
                    _customChart.ChartView.Chart.Series.Add(darvas);
                    _customChart.ImageSource = dataPicker[9];
                    imageButton.Image = dataPicker[9];
                    break;

                case "DONUT":
                    Donut donut = new Donut();
                    donut.FillSampleValues(1);
                    _customChart.ChartView.Chart.Series.Add(donut);
                    _customChart.ImageSource = dataPicker[10];
                    imageButton.Image = dataPicker[10];
                    break;

                case "ERROR":
                    Error error = new Error();
                    error.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(error);
                    _customChart.ImageSource = dataPicker[11];
                    imageButton.Image = dataPicker[11];
                    break;

                case "ERRORBAR":
                    ErrorBar errorbar = new ErrorBar();
                    errorbar.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(errorbar);
                    _customChart.ImageSource = dataPicker[12];
                    imageButton.Image = dataPicker[12];
                    break;

                case "ERRORPOINT":
                    ErrorPoint errorPoint = new ErrorPoint();
                    errorPoint.FillSampleValues(7);
                    _customChart.ChartView.Chart.Series.Add(errorPoint);
                    _customChart.ImageSource = dataPicker[13];
                    imageButton.Image = dataPicker[13];
                    break;

                case "FASTLINE":
                    FastLine fastLine = new FastLine();
                    fastLine.FillSampleValues(2);
                    _customChart.ChartView.Chart.Series.Add(fastLine);
                    _customChart.ImageSource = dataPicker[14];
                    imageButton.Image = dataPicker[14];
                    break;

                case "HIGHLOW":
                    HighLow highLow = new HighLow();
                    highLow.FillSampleValues(4);
                    _customChart.ChartView.Chart.Series.Add(highLow);
                    _customChart.ImageSource = dataPicker[15];
                    imageButton.Image = dataPicker[15];
                    break;

                case "HISTOGRAM":
                    Histogram histogram = new Histogram();
                    histogram.FillSampleValues(6);
                    _customChart.ChartView.Chart.Series.Add(histogram);
                    _customChart.ImageSource = dataPicker[16];
                    imageButton.Image = dataPicker[16];
                    break;

                case "HORIZAREA":
                    HorizArea horizArea = new HorizArea();
                    horizArea.FillSampleValues(6);
                    _customChart.ChartView.Chart.Series.Add(horizArea);
                    _customChart.ImageSource = dataPicker[17];
                    imageButton.Image = dataPicker[17];
                    break;

                case "HORIZBAR":
                    HorizBar horizBar = new HorizBar();
                    horizBar.FillSampleValues(6);
                    _customChart.ChartView.Chart.Series.Add(horizBar);
                    _customChart.ImageSource = dataPicker[18];
                    imageButton.Image = dataPicker[18];
                    break;

                case "HORIZLINE":
                    HorizLine horizLine = new HorizLine();
                    horizLine.FillSampleValues(6);
                    _customChart.ChartView.Chart.Series.Add(horizLine);
                    _customChart.ImageSource = dataPicker[19];
                    imageButton.Image = dataPicker[19];
                    break;

                case "ISOSURFACE":
                    IsoSurface isoSurface = new IsoSurface();
                    isoSurface.FillSampleValues(10);
                    _customChart.ChartView.Chart.Series.Add(isoSurface);
                    _customChart.ImageSource = dataPicker[20];
                    imageButton.Image = dataPicker[20];
                    break;

                case "LINE":
                    Line line = new Line();
                    line.FillSampleValues(5);
                    _customChart.ChartView.Chart.Series.Add(line);
                    _customChart.ImageSource = dataPicker[21];
                    imageButton.Image = dataPicker[21];
                    break;

                case "LINEPOINT":
                    LinePoint linePoint = new LinePoint();
                    linePoint.FillSampleValues(6);
                    _customChart.ChartView.Chart.Series.Add(linePoint);
                    _customChart.ImageSource = dataPicker[22];
                    imageButton.Image = dataPicker[22];
                    break;

                case "PIE":
                    Pie pie = new Pie();
                    pie.FillSampleValues(4);
                    _customChart.ChartView.Chart.Series.Add(pie);
                    _customChart.ImageSource = dataPicker[23];
                    imageButton.Image = dataPicker[23];
                    break;

                case "SURFACE":
                    Surface surface = new Surface();
                    surface.FillSampleValues(10);
                    //surface.
                    _customChart.ChartView.Chart.Series.Add(surface);
                    _customChart.ImageSource = dataPicker[24];
                    imageButton.Image = dataPicker[24];
                    break;

                case "TOWER":
                    Tower tower = new Tower();
                    tower.FillSampleValues(8);
                    _customChart.ChartView.Chart.Series.Add(tower);
                    _customChart.ImageSource = dataPicker[25];
                    imageButton.Image = dataPicker[25];
                    break;

                case "VOLUME":
                    Volume volume = new Volume();
                    volume.FillSampleValues(9);
                    _customChart.ChartView.Chart.Series.Add(volume);
                    _customChart.ImageSource = dataPicker[26];
                    imageButton.Image = dataPicker[26];
                    break;

            }

            _customChart.ChartView.Chart.Axes.Left.Automatic = true;
            _customChart.ChartView.Chart.Axes.Bottom.Automatic = true;

        
        }

        // Configurar el listView per veure els values actuals
        Grid gridListViewValues;
        private void ConfigureListViewCustomValues(ref ListView listView)
        {

            listView.ItemTemplate = new DataTemplate(() =>
            {

                ViewCell vCell = new ViewCell();
                gridListViewValues = new Grid();
                Entry entryName = new Entry();
                Entry entryValue = new Entry();
                Button colorPicker = new Button();

                gridListViewValues.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.4, GridUnitType.Star) });
                gridListViewValues.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.3, GridUnitType.Star) });
                gridListViewValues.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.3, GridUnitType.Star) });

                gridListViewValues.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

                colorPicker.Clicked += ColorPicker_Clicked;

                entryName.HorizontalOptions = LayoutOptions.Fill;
                entryValue.HorizontalOptions = LayoutOptions.Fill;
                colorPicker.Text = "Pick";

                gridListViewValues.Children.Add(entryName, 0, 0);
                gridListViewValues.Children.Add(entryValue, 1, 0);
                gridListViewValues.Children.Add(colorPicker, 2, 0);

                vCell.View = gridListViewValues;

                return vCell;

            });

        }

        private void ColorPicker_Clicked(object sender, EventArgs e)
        {

            //Amporis.Xamarin.Forms.ColorPicker.ColorPickerDialog.Show(gridListViewValues, "Choose the serie item color", Color.Blue, null);

        }

        #endregion

        #region Settings

        // Chart ja configurat
        private void DisplaySettingsPage()
        {

            this.Title = "Settings";

        }

        #endregion

        #region Events

        private void PickerChart_SelectedIndexChanged(object sender, EventArgs e)
        {

            var view = sender as Picker;
            var selectedItem = view.SelectedItem as String;

            ChartToCreate(selectedItem);

        }
        private void FillSampleValuesButton_Clicked(object sender, EventArgs e)
        {
            if (_customChart.ChartView.Chart.Series.Count != 0)
            {

                for (int i = 0; i < _customChart.ChartView.Chart.Series.Count; i++)
                {

                    _customChart.ChartView.Chart.Series[i].FillSampleValues();

                }

            }
        }
        private void ImageChart_Clicked(object sender, EventArgs e)
        {

            var layout = (sender as Button).Parent as Grid;

            (layout.Children[3] as Picker).Focus();

        }
        private void NameChart_Unfocused(object sender, FocusEventArgs e)
        {

            var item = sender as Entry;

            if (item.Text != "" && item.Text != null)
            {

                _customChart.ChartView.Chart.Title.Text = item.Text;
                _customChart.Name = item.Text;

            }

        }
        private void DescriptionChart_Unfocused(object sender, FocusEventArgs e)
        {

            var item = sender as Editor;

            if (item.Text != "" && item.Text != null)
            {

                _customChart.Description = item.Text;

            }

        }
        protected override void OnAppearing()
        {
            _navPage = _customChart.ChartPage.NavigationPage;
            _navPage.BarBackgroundColor = Color.FromRgb(33, 150, 243);
            _navPage.Elevation = 0;
            _navPage.BarVisivility = true;

            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {

            base.OnDisappearing();

        }

        #endregion


    }
}