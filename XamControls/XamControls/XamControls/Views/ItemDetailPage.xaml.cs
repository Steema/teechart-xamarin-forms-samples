using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamControls.Models;
using XamControls.ViewModels;

namespace XamControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

						var item = new Item
						{

								Text = "Hola",
								
								
						};


            viewModel = new ItemDetailViewModel(item);
						
            BindingContext = viewModel;

        }
    }
}