using XamControls.Models;
using XamControls.ViewModels.Base;
using XamControls.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamControls.Utils;
using System.Linq;
using Steema.TeeChart;

namespace XamControls.ViewModels
{

		public class MasterViewModel : ViewModelBase
		{

                private ObservableCollection<GroupeditemsMasterViewModel> MenuItems = new ObservableCollection<GroupeditemsMasterViewModel>();
                private GroupeditemsMasterViewModel groupBase;
                private GroupeditemsMasterViewModel groupResources;
                private GroupeditemsMasterViewModel groupMore;
                private ImageSource[] iconSources;

				public MasterViewModel()
				{

                    InitializeIcons();

                    groupBase = new GroupeditemsMasterViewModel() { groupName = "Main", shortName = "h" };
                    groupResources = new GroupeditemsMasterViewModel() { groupName = "Resources", shortName = "r" };
                    groupMore = new GroupeditemsMasterViewModel() { groupName = "More", shortName = "m" };

                    groupBase.Add(new MasterViewMenuItem(Id: 0, Title: "Home", TargetType: typeof(HomePage), ImageSource: iconSources[0], BackgroundColor: Color.Transparent));
                    groupResources.Add(new MasterViewMenuItem(Id: 1, Title: "Product", TargetType: null, ImageSource: iconSources[1], BackgroundColor: Color.Transparent));
                    groupResources.Add(new MasterViewMenuItem(Id: 2, Title: "GitHub", TargetType: null, ImageSource: iconSources[2], BackgroundColor: Color.Transparent));
                    groupResources.Add(new MasterViewMenuItem(Id: 3, Title: "Documentation", TargetType: null, ImageSource: iconSources[3], BackgroundColor: Color.Transparent));
                    groupMore.Add(new MasterViewMenuItem(Id: 4, Title: "Settings", TargetType: typeof(SettingsPage), ImageSource: iconSources[4], BackgroundColor: Color.Transparent));
                    groupMore.Add(new MasterViewMenuItem(Id: 5, Title: "About us", TargetType: typeof(AboutPage), ImageSource: iconSources[5], BackgroundColor: Color.Transparent));
                    groupMore.Add(new MasterViewMenuItem(Id: 6, Title: "Send comments", TargetType: typeof(SendCommentsPage), ImageSource: iconSources[6], BackgroundColor: Color.Transparent));

                    MenuItems.Add(groupBase);
                    MenuItems.Add(groupResources);
                    MenuItems.Add(groupMore);

				}

                private void InitializeIcons()
                {

                    string[] sources;
                    iconSources = new ImageSource[7];

                    if (Device.RuntimePlatform == Device.Android)
                    {

                        sources = new string[7] { "ic_home_black_36dp.png", "iconSteema_day.png", "iconGithub.png", "ic_help_black_48dp.png", "ic_settings_black_36dp.png", "ic_info_black_24dp.png", "ic_chat_bubble_black_36dp.png" };
                        for (int i = 0; i < iconSources.Length; i++)
                        {

                            iconSources[i] = sources[i];

                        }

                    }
                    else if (Device.RuntimePlatform == Device.iOS)
                    {

                        sources = new string[7] { "ic_home_black_24dp.png", "iconSteema_day.png", "iconGithub.png", "ic_help_black_36dp.png", "ic_settings_black_24dp.png", "ic_info_black_24dp.png", "ic_chat_bubble_black_36dp.png" };
                        for (int i = 0; i < iconSources.Length; i++)
                        {

                            iconSources[i] = sources[i];

                        }

                    }

                }

                public ObservableCollection<GroupeditemsMasterViewModel> GetMenuItems
                {

                        get { return MenuItems; }
						set { MenuItems = value; }

                }

    }

}
