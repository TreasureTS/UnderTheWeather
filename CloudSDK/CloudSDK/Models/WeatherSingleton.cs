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

namespace CloudSDK.Models
{
    public class WeatherSingleton
    {
        private static WeatherSingleton instance = null;
        private WeatherSingleton() { }
        public static WeatherSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherSingleton();             
                }
               return instance;
            }
        }

        /// <summary>
        /// Method handles getting icon code from the api
        /// </summary>
        /// <param name="iconCode"></param>
        /// <returns></returns>
      

        //stores maximum temperature
        public double maximumTemperature = 0.0;
        //stores minimum temperature
        public double minimumTemparature = 0.0;
        //stores the name of the place the temperature is being displayed for.
        public string nameOfPlace = string.Empty;
        //stores temperature
        public double temperature = 0.0;
        //stores weathertype
        public int weatherType = 0;
        public DateTime dateTime;
        //handles image icon
        public string imgIcon = string.Empty;
        public StringBuilder icon = new StringBuilder();
       
        public string weatherDescription = string.Empty;
    }
}