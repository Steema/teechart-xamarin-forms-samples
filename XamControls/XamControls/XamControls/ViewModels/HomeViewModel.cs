using XamControls.Models;
using XamControls.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamControls.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		public HomeViewModel()
		{
			PickPhotoCommand = new Command(HandlePickPhoto);
		}

		public ICommand PickPhotoCommand { get; }

		private void HandlePickPhoto()
		{
		}


		public override void OnAppearing()
		{
			base.OnAppearing();

            //OnPropertyChanged(nameof(Memories));
            //OnPropertyChanged(nameof(HasNoMemories));
        }

	}
}
