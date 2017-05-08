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
using Android.Locations;
using CloudSDK.Helper;
using CloudSDK.Adapter;
using CloudSDK.Models;

namespace WeatherApp
{
    [Service]
    public class WeatherIntentService : IntentService,ILocationListener
    {
        private string TAG = "WeatherIntentService";
        LocationManager locationmanager;
        public override void OnCreate()
        {
            base.OnCreate();

            initializeLocation();

        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        //Name of my worker thread
        public WeatherIntentService() :base("workerThread")
        {
           
        }
        //Handles data that hase been pass on through the intent
        protected override void OnHandleIntent(Intent intent)
        {
            
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return base.OnStartCommand(intent, flags, startId);
        }



        public void OnLocationChanged(Location location)
        {
            
            WeatherSingleton.Instance.dateTime = DateTime.Now;
            bool save = WeatherAdapter.getWeatherConditionInfo(location.Latitude, location.Longitude);
            Log.d(TAG, "Lattitude " + location.Latitude + "Longitude " + location.Longitude);
        }

        public void OnProviderDisabled(string provider)
        {
           
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            Toast.MakeText(this, "GPS cannot get location", ToastLength.Long).Show();
        }

        /// <summary>
        /// Method handles initialization of the location manager
        /// </summary>
        public void initializeLocation()
        {
            try
            {
                Log.d(TAG, "START | initializeLocation");
                locationmanager = GetSystemService(LocationService) as LocationManager;
                string provider = LocationManager.NetworkProvider;
                locationmanager.RequestLocationUpdates(provider, 1000, 0, this);
            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR " + ex.Message);
            }
          
        }
    }
}