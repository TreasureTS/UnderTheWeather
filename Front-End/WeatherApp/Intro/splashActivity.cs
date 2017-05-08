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
using System.Threading.Tasks;

namespace WeatherApp
{
    [Activity(MainLauncher = true)]
    public class splashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splashLayout);
            Task task = new Task(() => { delayScreen(); });
            task.Start();

        }

        protected override void OnResume()
        {
            base.OnResume();
            //start service
            Intent intent = new Intent(this, typeof(WeatherIntentService));
            StartService(intent);
        }

        /// <summary>
        /// Method handles the splash screen
        /// </summary>
        public async void delayScreen()
        {
            await Task.Delay(2000);
            Intent intent = new Intent(this, typeof(weatherAppActivity));
            StartActivity(intent);

        }
    }
}