using Steema.TeeChart;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamControls.Utils;

namespace XamControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{

        FileController fileController = new FileController();

        TableView viewOpciones = new TableView();

        TableRoot rootTable = new TableRoot();

        TableSection section1 = new TableSection();
        TableSection section2 = new TableSection();
        TableSection section3 = new TableSection();

        // Tools
        CustomRenders.CustomSwitchCell zoomSwitchCell = new CustomRenders.CustomSwitchCell();
        //StackLayout pickerZoomTypeLayout = new StackLayout();
        //ViewCell pickerZoomTypeViewCell = new ViewCell();
        //TextCell pickerZoomTypeTextCell = new TextCell();
        //Label labelSelectedZoomType = new Label();
        CustomRenders.CustomSwitchCell panningSwitchCell = new CustomRenders.CustomSwitchCell();

        // Theme
        StackLayout pickerThemeLayout = new StackLayout();
        ViewCell pickerThemeViewCell = new ViewCell();
        TextCell pickerThemeTextCell = new TextCell();
        Label labelSelectedTheme = new Label();

        // Version
        TextCell versionTextCell = new TextCell();

        //Picker zoomTypePicker = new Picker();
        Picker themePicker = new Picker();

        public SettingsPage()
		{

			InitializeComponent ();

			this.Title = "Settings";

			viewOpciones.Root = rootTable;
			viewOpciones.Intent = TableIntent.Settings;

			section1.Title = "Tools";
			section2.Title = "Theme";
			section3.Title = "Information";

            // Section 1
            zoomSwitchCell.Text = "Active zoom";
            zoomSwitchCell.On = fileController.LeerZoomActual();
            zoomSwitchCell.OnChanged += ZoomSwitchCell_OnChanged;

            //pickerZoomTypeTextCell.Tapped += PickerZoomTypeTextCell_Tapped;
            //pickerZoomTypeTextCell.Text = "Zoom type";
            //pickerZoomTypeTextCell.TextColor = Color.Black;
            //pickerZoomTypeTextCell.Detail = "Select the zoom type in charts";

            //pickerZoomTypeViewCell.View = pickerZoomTypeLayout;
            //pickerZoomTypeViewCell.Height = 0;

            //pickerZoomTypeLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            //pickerZoomTypeLayout.Children.Add(labelSelectedZoomType);
            //pickerZoomTypeLayout.Children.Add(zoomTypePicker);

            //zoomTypePicker.Title = "Select zoom type";
            //InitializeZoomTypePickerItems();
            //zoomTypePicker.SelectedIndexChanged += ZoomTypePicker_SelectedIndexChanged;
            //zoomTypePicker.HeightRequest = 0;
            //zoomTypePicker.IsVisible = false;

            //labelSelectedZoomType.Text = zoomTypePicker.SelectedItem.ToString();
            //labelSelectedZoomType.FontSize += 1;
            //labelSelectedZoomType.TextColor = Color.FromHex("0B8DF9");
            //labelSelectedZoomType.Margin = new Thickness(0, 10, 20, 0);
            //labelSelectedZoomType.HorizontalOptions = LayoutOptions.End;

            panningSwitchCell.Text = "Active panning";
            panningSwitchCell.On = fileController.BooleanReadValues("panning:");
            panningSwitchCell.OnChanged += PanningSwitchCell_OnChanged;

            // Section 2
            pickerThemeTextCell.Tapped += PickerCell_Tapped;
            pickerThemeTextCell.Text = "Change theme";
            pickerThemeTextCell.TextColor = Color.Black;
            pickerThemeTextCell.Detail = "Select your favourite chart theme in this app";

            pickerThemeViewCell.View = pickerThemeLayout;
            pickerThemeViewCell.Height = 0;

            pickerThemeLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            pickerThemeLayout.Children.Add(labelSelectedTheme);
            pickerThemeLayout.Children.Add(themePicker);

            themePicker.Title = "Change the theme";
            InitializeThemePickerItems();
            themePicker.SelectedIndexChanged += ThemePicker_SelectedIndexChanged;
            themePicker.HeightRequest = 0;
            themePicker.IsVisible = false;

            labelSelectedTheme.Text = themePicker.SelectedItem.ToString();
            labelSelectedTheme.FontSize += 1;
            labelSelectedTheme.TextColor = Color.FromHex("0B8DF9");
            labelSelectedTheme.Margin = new Thickness(0, 10, 20, 0);
            labelSelectedTheme.HorizontalOptions = LayoutOptions.End;

            // Section 3
            versionTextCell.Text = "TeeChart DEMO Xamarin Forms";
            versionTextCell.TextColor = Color.Black;
            versionTextCell.Detail = "Version: 2.1";
            versionTextCell.DetailColor = Color.FromRgb(100, 100, 100);

            // Add Items
            rootTable.Add(section1);
            rootTable.Add(section2);
            rootTable.Add(section3);

            section1.Add(zoomSwitchCell);
            section1.Add(panningSwitchCell);
            //section1.Add(pickerZoomTypeTextCell);
            //section1.Add(pickerZoomTypeViewCell);
            section2.Add(pickerThemeTextCell);
            section2.Add(pickerThemeViewCell);
            section3.Add(versionTextCell);

			this.Content = viewOpciones;			

		}

        private void PanningSwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {

            var element = sender as SwitchCell;

            fileController.UpdateBooleanValues((element.On).ToString().ToLower(), "panning:");

        }
        /*
        private void ZoomTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            labelSelectedZoomType.Text = zoomTypePicker.SelectedItem as String;
            fileController.UpdateZoomTypeActual(zoomTypePicker.SelectedItem.ToString());

        }
        

        private Steema.TeeChart.ZoomStyles[] zoomTypes;
        private void InitializeZoomTypePickerItems()
        {

            zoomTypes = new Steema.TeeChart.ZoomStyles[2];

            zoomTypes[0] = Steema.TeeChart.ZoomStyles.FullChart;
            zoomTypes[1] = Steema.TeeChart.ZoomStyles.InChart;

            for (int i = 0; i < zoomTypes.Length; i++) { zoomTypePicker.Items.Add(zoomTypes[i].ToString()); }

            UpdateZoomTypeSelectedFromFile();

        }

        private void PickerZoomTypeTextCell_Tapped(object sender, EventArgs e)
        {

            zoomTypePicker.Focus();

        }

        */

        private void ZoomSwitchCell_OnChanged(object sender, EventArgs e)
        {

            var element = sender as SwitchCell;

            fileController.UpdateZoomActual((element.On).ToString().ToLower());

        }

        private Steema.TeeChart.ThemeType[] themes;
        private void InitializeThemePickerItems()
        {

            themes = new Steema.TeeChart.ThemeType[14];

            themes[0] = Steema.TeeChart.ThemeType.None;
            themes[1] = Steema.TeeChart.ThemeType.BlackIsBack;
            themes[2] = Steema.TeeChart.ThemeType.Opera;
            themes[3] = Steema.TeeChart.ThemeType.TeeChart;
            themes[4] = Steema.TeeChart.ThemeType.Excel;
            themes[5] = Steema.TeeChart.ThemeType.Classic;
            themes[6] = Steema.TeeChart.ThemeType.XP;
            themes[7] = Steema.TeeChart.ThemeType.Web;
            themes[8] = Steema.TeeChart.ThemeType.Business;
            themes[9] = Steema.TeeChart.ThemeType.BlueSky;
            themes[10] = Steema.TeeChart.ThemeType.Grayscale;
            themes[11] = Steema.TeeChart.ThemeType.Lookout;
            themes[12] = Steema.TeeChart.ThemeType.Andros;
            themes[13] = Steema.TeeChart.ThemeType.Report;

            for (int i = 0; i < themes.Length; i++) { themePicker.Items.Add(themes[i].ToString()); }

            UpdateThemeSelectedFromFile();

        }

        private void ThemePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            labelSelectedTheme.Text = themePicker.SelectedItem.ToString();
            fileController.UpdateThemeActual(themePicker.SelectedItem.ToString());

        }

        private void PickerCell_Tapped(object sender, EventArgs e)
        {

            themePicker.Focus();

        }

        int i = 0;

		private void ViewCellTheme_Tapped(object sender, EventArgs e)
		{


			if (i == 0) { 
				//this.BackgroundColor = Color.Red;
				switch(Device.RuntimePlatform)
				{

					case Device.iOS:

						
						break;

				}
				i++;
			}
			else { this.BackgroundColor = Color.White; i--; }
			
		}

        /*
        private void UpdateZoomTypeSelectedFromFile()
        {

            string zoomtypeSelectedFile = fileController.LeerZoomTypeActual();

            switch (zoomtypeSelectedFile)
            {

                case "FullChart":
                    zoomTypePicker.SelectedItem = zoomTypePicker.Items[0];
                    break;
                case "InChart":
                    zoomTypePicker.SelectedItem = zoomTypePicker.Items[1];
                    break;

            }

        }
        */

        private void UpdateThemeSelectedFromFile()
        {

            string themeSelectedFile = fileController.LeerThemeActual();

            switch(themeSelectedFile)
            {

                case "None":
                    themePicker.SelectedItem = themePicker.Items[0];
                    break;
                case "BlackIsBack":
                    themePicker.SelectedItem = themePicker.Items[1];
                    break;
                case "Opera":
                    themePicker.SelectedItem = themePicker.Items[2];
                    break;
                case "TeeChart":
                    themePicker.SelectedItem = themePicker.Items[3];
                    break;
                case "Excel":
                    themePicker.SelectedItem = themePicker.Items[4];
                    break;
                case "Classic":
                    themePicker.SelectedItem = themePicker.Items[5];
                    break;
                case "XP":
                    themePicker.SelectedItem = themePicker.Items[6];
                    break;
                case "Web":
                    themePicker.SelectedItem = themePicker.Items[7];
                    break;
                case "Business":
                    themePicker.SelectedItem = themePicker.Items[8];
                    break;
                case "BlueSky":
                    themePicker.SelectedItem = themePicker.Items[9];
                    break;
                case "Grayscale":
                    themePicker.SelectedItem = themePicker.Items[10];
                    break;
                case "Lookout":
                    themePicker.SelectedItem = themePicker.Items[11];
                    break;
                case "Andros":
                    themePicker.SelectedItem = themePicker.Items[12];
                    break;
                case "Report":
                    themePicker.SelectedItem = themePicker.Items[13];
                    break;

            }

        }

	}
}