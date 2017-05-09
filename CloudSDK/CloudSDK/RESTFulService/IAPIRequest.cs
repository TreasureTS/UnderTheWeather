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
using Android.Graphics;

namespace CloudSDK.RESTFulService
{
    public interface IAPIRequest
    {
        /// <summary>
        /// Resposible for getting the weather information from the API
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        bool getWeatherConditionInfo(double latitude, double longitude, int retry = 0);
        Bitmap getImageBitMapFromURL(string uri);
    }
}