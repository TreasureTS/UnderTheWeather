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
using CloudSDK.Helper;

namespace WeatherApp.Helper
{
    public class TemperatureConverter
    {
        private static string TAG = "TemperatureConverter";
        public static double convertToCelcius(double kelvin)
        {
            double newKelvin = 0.0;
            double rounded = 0.0;
            try
            {
                Log.d(TAG, "START | convertToCelcius");
                newKelvin = kelvin - 273.15;
                rounded = Math.Round(newKelvin, 1); 
            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | Failed to convert to celcius " + ex.Message);
            }
            return rounded;
        }
    }
}