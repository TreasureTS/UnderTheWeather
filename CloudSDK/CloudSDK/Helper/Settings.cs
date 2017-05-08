using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CloudSDK.Helper
{
    public class Settings
    {
        //Variable controls switching on and off of logs
        public static readonly bool isLogsOn = true;
        public static string htpp = "http://";
        public static string apiKey = "b674314020516236ee7d5729a724ec20";
        public static string BaseURI = "api.openweathermap.org/data/2.5/weather?";
        public static string bitMapImageURI = "openweathermap.org/img/w/";
    }
}