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
using CloudSDK.RESTFulService;
using CloudSDK.Helper;
using Android.Graphics;

namespace CloudSDK.Adapter
{
    public class WeatherAdapter
    {
        private static string TAG = "WeatherAdapter";
        public static bool getWeatherConditionInfo(double latitute, double longitude)
        {
            bool isThereResponse = false;
            try
            {
                Log.d(TAG, "START | getWeatherConditionInfo Adapter ");
                IAPIRequest api = new APIRequest();
                isThereResponse = api.getWeatherConditionInfo(latitute,longitude);
                Log.d(TAG, "END | getWeatherConditionInfo Adapter ");
            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get weather info because " + ex.Message);
                isThereResponse = false;
            }
            return isThereResponse;
        }

        public static Bitmap getImageBitMapFromURL(string imgIcon)
        {
            Bitmap bitmapImage = null;
            try
            {
                IAPIRequest api = new APIRequest();
                Log.d(TAG, "START | getImageBitMapFromURL ");
                bitmapImage = api.getImageBitMapFromURL(imgIcon);
            }
            catch(Exception ex)
            {
                Log.e(TAG, "ERR | getImageBitMapFromURL " + ex.Message);
            }
            return bitmapImage;
        }


    }
}