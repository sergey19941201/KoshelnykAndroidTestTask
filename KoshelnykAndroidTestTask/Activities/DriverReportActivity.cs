using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KoshelnykAndroidTestTask.RequestClasses;

namespace KoshelnykAndroidTestTask.Activities
{
    [Activity(Label = "DriverReportActivity", Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Landscape)]
    public class DriverReportActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DriverReport);

            var driverUrl = "https://networkrail-uk-qa.traffilog.com/qa/api/DriverReport/Get?sessionToken=" + Authentication.sessionToken;

            //GetDriverReportInfo getDriverReportInfo = new GetDriverReportInfo();
            await FetchAsync(driverUrl);
        }


        private async Task<string> FetchAsync(string url)
        {
            string jsonString; //string for getting data from the url
            //getting data process goes here
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var stream = await httpClient.GetStreamAsync(url);
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
            }

            string[] contentArr = jsonString.Split('"');
            FindViewById<TextView>(Resource.Id.DriverStatus).Text = "Driver Status" + contentArr[2];
            FindViewById<TextView>(Resource.Id.DriverId).Text = "Driver ID: " + contentArr[7];
            FindViewById<TextView>(Resource.Id.turnsCountTV).Text = "Turns count: " + contentArr[11];
            FindViewById<TextView>(Resource.Id.TurnsPer).Text = "Turns per: " + contentArr[15];
            FindViewById<TextView>(Resource.Id.BrakesCount).Text = "Brakes count: " + contentArr[19];
            FindViewById<TextView>(Resource.Id.BrakesPer).Text = "Brakes per: " + contentArr[23];
            FindViewById<TextView>(Resource.Id.SpeedCount).Text = "Speed count: " + contentArr[27];
            FindViewById<TextView>(Resource.Id.SpeedPer).Text = "Speed per: " + contentArr[31];
            FindViewById<TextView>(Resource.Id.AccelarationCount).Text = "Acceleration count: " + contentArr[35];
            FindViewById<TextView>(Resource.Id.AccelarationPer).Text = "Acceleration per: " + contentArr[39];
            FindViewById<TextView>(Resource.Id.Tip).Text = "Tip: " + contentArr[43];
            FindViewById<TextView>(Resource.Id.GradeType).Text = "Grade type: " + contentArr[47];
            FindViewById<TextView>(Resource.Id.GradeTypeDescription).Text = "Grade description: " + contentArr[51];

            return jsonString;
        }
    }
}