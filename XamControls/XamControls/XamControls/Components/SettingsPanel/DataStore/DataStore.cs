using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Components.SettingsPanel.DataStore
{
	public class DataStore : List<StackLayout>
    {

				private List<StackLayout> sections;
				private StackLayout stack = new StackLayout();

				public DataStore()
				{

						sections = new List<StackLayout>();

				}

				/// <summary>
				/// Permite añadir una section
				/// </summary>
				public new StackLayout Add { set { sections.Add(value); } }
				

		

    }
}
