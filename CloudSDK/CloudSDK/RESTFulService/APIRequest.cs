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
using System.Net;
using System.IO;
using CloudSDK.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Android.Graphics;

namespace CloudSDK.RESTFulService
{
    public class APIRequest : IAPIRequest
    {

        private string TAG = "APIRequest";
        private int retryLimit = 3;
        /// <summary>
        /// Resposible for getting the weather information from the API
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public bool getWeatherConditionInfo(double latitude, double longitude, int retry = 0)
        {
            bool isResponse = false;
            try
            {
                Log.d(TAG, "START | getWeatherConditionInfo");
                //Base URI
                string URI = Settings.htpp + Settings.BaseURI + "lat=" + latitude + "&lon=" + longitude + "&appid=" + Settings.apiKey;

                //Http client
                WebClient client = new WebClient();
                client.Headers.Add("Authorization", Settings.apiKey);
                client.Headers.Add("content-type", "application/json");

                //Open stream and reading content from it.
                Stream stream = client.OpenRead(URI);
                StreamReader reader = new StreamReader(stream);
                var content = reader.ReadToEnd();
                isResponse = true;
                //populating the weather condition object
                // JsonConvert.PopulateObject(content, weatherconditionsObj);

                JObject jsonObject = JObject.Parse(content);

                WeatherSingleton.Instance.maximumTemperature = (double)jsonObject.SelectToken("main.temp_max");
                WeatherSingleton.Instance.minimumTemparature = (double)jsonObject.SelectToken("main.temp_min");
                WeatherSingleton.Instance.nameOfPlace = (string)jsonObject.SelectToken(".name");
                WeatherSingleton.Instance.temperature = (double)jsonObject.SelectToken("main.temp");
                WeatherSingleton.Instance.weatherDescription = (string)jsonObject.SelectToken("weather[0].description");
                WeatherSingleton.Instance.imgIcon = (string)jsonObject.SelectToken("weather[0].icon");
                Log.d(TAG, "Image Icon " + WeatherSingleton.Instance.imgIcon);
                Log.d(TAG, "Max Temperature " + WeatherSingleton.Instance.maximumTemperature);
                Log.d(TAG, "Min Temperature " + WeatherSingleton.Instance.minimumTemparature);
                Log.d(TAG, "Name " + WeatherSingleton.Instance.nameOfPlace);
                //Closing streams
                stream.Close();
                reader.Close();
                Log.d(TAG, "END | getWeatherConditionInfo");
            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get weather information from the API because " + ex.Message);

                //Code to be updated 
                if (retry < retryLimit)
                {
                    IAPIRequest api = new APIRequest();
                    Log.d(TAG, "Retries " + retry);
                    bool weatherConditionRetry = api.getWeatherConditionInfo(latitude, longitude, retry + 1);
                    return weatherConditionRetry;
                }
                isResponse = false;
            }
            return isResponse;
        }

        /// <summary>
        /// Method handles downloading image from URI
        /// </summary>
        /// <param name="iconCode"></param>
        /// <returns></returns>
        Bitmap IAPIRequest.getImageBitMapFromURL(string iconCode)
        {
            Bitmap bitmapImage = null;
            try
            {
                Log.d(TAG, "START | getImageBitMapFromURL");
                string URI = Settings.htpp + Settings.bitMapImageURI + iconCode + ".png";
                Log.d(TAG, "Image URI " + URI);
                WebClient client = new WebClient();
                Log.d(TAG, "URI " + URI);
                var imageBytes = client.DownloadData(URI);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    bitmapImage = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }

            }
            catch (Exception ex)
            {
                Log.e(TAG, "Failed to get image because : " + ex.Message);
            }
            return bitmapImage;
        }


    }
}