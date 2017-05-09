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
using CloudSDK.Models;
using WeatherApp.Helper;
using CloudSDK.Adapter;
namespace WeatherApp
{
    [Activity(Label = "Under the Weather", MainLauncher = false)]
    public class weatherAppActivity : Activity
    {
        private string TAG = "weatherAppActivity";
        TextView maxTemperature;
        TextView minTemperature;
        TextView place;
        TextView temperature;
        TextView date;
        TextView description;
        ImageView icon;
        private double longitude;
        private double lattitude;

        LocationManager locationManager;
        Location currentLocation;

        private string locationProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.weatherAppLayout);
            //ActionBar.Hide();
            maxTemperature = FindViewById(Resource.Id.maxTemperatureID) as TextView;
            minTemperature = FindViewById(Resource.Id.minTemperatureID) as TextView;
            place = FindViewById(Resource.Id.txtNameOfPlace) as TextView;
            temperature = FindViewById(Resource.Id.txtTemperature) as TextView;
            date = FindViewById(Resource.Id.Time) as TextView;
            description = FindViewById(Resource.Id.description) as TextView;
            icon = FindViewById(Resource.Id.imgIcon) as ImageView;
            initializeUI();
        }

        public void initializeUI()
        {
            try
            {
                Log.d(TAG, "START | initializeUI");
                maxTemperature.Text = " Max " + TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.maximumTemperature).ToString() + "°C";
                minTemperature.Text = " Min " + TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.minimumTemparature).ToString() + "°C";
                place.Text = WeatherSingleton.Instance.nameOfPlace;
                temperature.Text = TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.temperature).ToString() + "°C";
                date.Text = WeatherSingleton.Instance.dateTime.ToString("dd MMMM,yyyy");
                description.Text = WeatherSingleton.Instance.weatherDescription;
                icon.SetImageBitmap(WeatherSingleton.Instance.getBitMap);
            }
            catch (Exception ex)
            {
                Log.e(TAG, "ERR | Faieled to initialize UI because : " + ex.Message);
            }
        }


    }
}