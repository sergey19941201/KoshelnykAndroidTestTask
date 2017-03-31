using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Widget;
using Android.OS;

namespace KoshelnykAndroidTestTask
{
    [Activity(Label = "KoshelnykAndroidTestTask", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            //checking internet connection
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            //checking internet connection ended

            FindViewById<Button>(Resource.Id.loginBn).Click += delegate
            {
                if (isOnline == true)
                {
                    StartActivity(new Intent(this, typeof(HomeActivity)));
                }
                else
                {
                    Toast.MakeText(this, "No Internet Connection.\nTurn the Internet connection on and try again", ToastLength.Long).Show();
                }
            };
        }
    }
}

