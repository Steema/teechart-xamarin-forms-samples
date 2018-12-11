using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Utils
{
    public class StatusPermissions
    {

        public Pages.ErrorTypes errorType;

        public StatusPermissions() {  }

        public bool CheckConnection()
        {

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected) errorType = Pages.ErrorTypes.Connectivity;
            return Plugin.Connectivity.CrossConnectivity.Current.IsConnected;

        }

    }

}
