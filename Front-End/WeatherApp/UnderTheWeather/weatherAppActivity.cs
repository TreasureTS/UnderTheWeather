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
using Com.Lilarcor.Cheeseknife;
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
        [InjectView(Resource.Id.maxTemperatureID)] TextView maxTemperature;
        [InjectView(Resource.Id.minTemperatureID)] TextView minTemperature;
        [InjectView(Resource.Id.txtNameOfPlace)] TextView place;
        [InjectView(Resource.Id.txtTemperature)] TextView temperature;
        [InjectView(Resource.Id.Time)] TextView date;
        [InjectView(Resource.Id.description)] TextView description;
        [InjectView(Resource.Id.imgIcon)] ImageView icon;
        private double longitude;
        private double lattitude;

        LocationManager locationManager;
        Location currentLocation;

        private string locationProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.weatherAppLayout);
            Cheeseknife.Inject(this);
            //ActionBar.Hide();
            maxTemperature.Text = " Max " + TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.maximumTemperature).ToString() + "°C";
            minTemperature.Text = " Min " + TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.minimumTemparature).ToString() + "°C";
            place.Text = WeatherSingleton.Instance.nameOfPlace;
            temperature.Text = TemperatureConverter.convertToCelcius(WeatherSingleton.Instance.temperature).ToString() + "°C";
            date.Text = WeatherSingleton.Instance.dateTime.ToString("dd MMMM,yyyy");
            description.Text = WeatherSingleton.Instance.weatherDescription;
            icon.SetImageBitmap(WeatherAdapter.getImageBitMapFromURL(WeatherSingleton.Instance.imgIcon));
        }
       

      
    }
}