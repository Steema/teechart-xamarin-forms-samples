using System;

using XamControls.Models;
using XamControls.ViewModels.Base;

namespace XamControls.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;

        }

    }
}
