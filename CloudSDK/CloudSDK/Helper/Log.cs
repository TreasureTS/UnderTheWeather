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
    public class Log
    {
        //Helps debug program
        public static void d(string TAG, string value)
        {
        
                if (Settings.isLogsOn == true)
                {
                    Console.WriteLine(TAG + " = " + value);
                }
     
        }
        //Helps debug program
        public static void e(string TAG, string value)
        {

            if (Settings.isLogsOn == true)
            {
                Console.WriteLine(TAG + " = " +  value);
            }

        }
    }
}