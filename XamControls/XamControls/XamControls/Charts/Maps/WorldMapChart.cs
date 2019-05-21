using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using Xamarin.Forms;

namespace XamControls.Charts.Maps
{
    public class WorldMapChart
    {
        #if !TEE_STD
				private World world;
				private ChartView BaseChart;
				private Picker pickerChangeMap;
                private Variables.Variables var;

				public WorldMapChart(ChartView BaseChart)
				{

						this.BaseChart = BaseChart;
						this.world = new World();
                        var = new Variables.Variables();

						world.UseColorRange = false;
                        world.StartColor = var.GetPaletteBasic[0].AddLuminosity(0.14);
                        world.MidColor = var.GetPaletteBasic[0].AddLuminosity(-0.05);
                        world.EndColor = var.GetPaletteBasic[0].AddLuminosity(-0.26);
                        world.UseColorRange = true;
						world.Shadow.Visible = false;

						world.FillSampleValues();

						world.Map = WorldMapType.Europe27;

                        BaseChart.Chart.Series.Add(world);
                        BaseChart.Chart.Axes.Left.Automatic = true;
                        BaseChart.Chart.Axes.Bottom.Automatic = true;
                        BaseChart.Chart.Axes.Left.Ticks.Transparency = 100;
                        BaseChart.Chart.Axes.Left.Visible = false;
                        BaseChart.Chart.Axes.Bottom.Visible = false;
                        BaseChart.Chart.Legend.Visible = false;

						AddChangeMapToolbarItem();

				}

				// Añade el toolbarItem al ContentPage
				private void AddChangeMapToolbarItem()
				{

					ToolbarItem itemChangePage;
					var page = (((BaseChart.Parent as StackLayout).Parent as Grid).Parent as ContentPage);

					itemChangePage = new ToolbarItem();
					itemChangePage.Icon = new FileImageSource() { File = "ic_map_white_24dp.png" };
					itemChangePage.Text = "Change Map";
					itemChangePage.Clicked += ItemChangePage_Clicked;
					AddItemsInPickerChangeMap();

					page.ToolbarItems.Add(itemChangePage);
					ReverseToolbarItems(page.ToolbarItems[0], page.ToolbarItems[1], page.ToolbarItems[2], page.ToolbarItems);

				}

				// Añade los elementos del picker
				private void AddItemsInPickerChangeMap()
				{

						pickerChangeMap = new Picker();
						pickerChangeMap.ItemsSource = new List<WorldMapType> { WorldMapType.World, WorldMapType.Africa, WorldMapType.Asia, WorldMapType.Australia, WorldMapType.CentralAmerica, WorldMapType.Europe, WorldMapType.Europe15, WorldMapType.Europe27, WorldMapType.MiddleEast, WorldMapType.NorthAmerica, WorldMapType.SouthAmerica, WorldMapType.Spain, WorldMapType.USA, WorldMapType.USAHawaiiAlaska };
						pickerChangeMap.SelectedItem = WorldMapType.World;
						pickerChangeMap.IsVisible = false;
                        pickerChangeMap.SelectedIndexChanged += PickerChangeMap_SelectedIndexChanged;
						pickerChangeMap.Title = "Change the map";
						(BaseChart.Parent as StackLayout).Children.Add(pickerChangeMap);

				}

                private void PickerChangeMap_SelectedIndexChanged(object sender, EventArgs e)
                {

                    switch (pickerChangeMap.SelectedItem)
                    {

                        case WorldMapType.World:
                            world.Map = WorldMapType.World;
                            break;
                        case WorldMapType.Africa:
                            world.Map = WorldMapType.Africa;
                            break;
                        case WorldMapType.Asia:
                            world.Map = WorldMapType.Asia;
                            break;
                        case WorldMapType.Australia:
                            world.Map = WorldMapType.Australia;
                            break;
                        case WorldMapType.CentralAmerica:
                            world.Map = WorldMapType.CentralAmerica;
                            break;
                        case WorldMapType.Europe:
                            world.Map = WorldMapType.Europe;
                            break;
                        case WorldMapType.Europe15:
                            world.Map = WorldMapType.Europe15;
                            break;
                        case WorldMapType.Europe27:
                            world.Map = WorldMapType.Europe27;
                            break;
                        case WorldMapType.MiddleEast:
                            world.Map = WorldMapType.MiddleEast;
                            break;
                        case WorldMapType.NorthAmerica:
                            world.Map = WorldMapType.NorthAmerica;
                            break;
                        case WorldMapType.SouthAmerica:
                            world.Map = WorldMapType.SouthAmerica;
                            break;
                        case WorldMapType.Spain:
                            world.Map = WorldMapType.Spain;
                            break;
                        case WorldMapType.USA:
                            world.Map = WorldMapType.USA;
                            break;
                        case WorldMapType.USAHawaiiAlaska:
                            world.Map = WorldMapType.USAHawaiiAlaska;
                            break;
                        default:
                            throw new Exception("Unexpected Case");
                    }

                }

                // Gira la toolbar
                private void ReverseToolbarItems(ToolbarItem item1, ToolbarItem item2, ToolbarItem item3, IList<ToolbarItem> toolbar)
				{

						for(int i = toolbar.Count - 1; i >= 0; i--) { toolbar.RemoveAt(i); }
                        toolbar.Add(item3);
						toolbar.Add(item1);
						toolbar.Add(item2);

				}

				// Muestra el picker cuando haces click al "mapItem"
				private void ItemChangePage_Clicked(object sender, EventArgs e)
				{

						pickerChangeMap.Focus();

				}
#endif
		}
}
