using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KoshelnykAndroidTestTask.Activities;

namespace KoshelnykAndroidTestTask
{
    [Activity(Label = "HomeActivity", Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Landscape)]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            //checking internet connection
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            //checking internet connection ended

            if (isOnline == false)
            {
                Toast.MakeText(this, "No Internet Connection.\nTurn the Internet connection on and try again", ToastLength.Long).Show();
            }
            else
            {
                FindViewById<ImageButton>(Resource.Id.drivingReportBn).Click += HomeActivity_Click;
            }
        }

        private void HomeActivity_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(DriverReportActivity)));
        }
    }
}