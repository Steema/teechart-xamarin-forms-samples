using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamControls.Models
{
    public class GroupeditemsMasterViewModel : ObservableCollection<MasterViewMenuItem>
    {

        public string groupName { get; set; }
        public string shortName { get; set; }

    }
}
