using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Widget;
using Android.OS;
using KoshelnykAndroidTestTask.RequestClasses;

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

            var loginET = FindViewById<EditText>(Resource.Id.loginET);
            var passwordET = FindViewById<EditText>(Resource.Id.passwordET);

            Authentication authentication = new Authentication();

            FindViewById<Button>(Resource.Id.loginBn).Click += async delegate
            {
                if (isOnline == true)
                {
                    //var url = "https://networkrail-uk-qa.traffilog.com/UK/api/User/Login?username=" + loginET.Text +
                       //       "%40live.com&password=" + passwordET.Text + "&api_key=%2FUK%2Fapi%2FUser%2FLogin";
                       var url= "https://networkrail-uk-qa.traffilog.com/UK/api/User/Login?username=nemesises%40live.com&password=dontoretto23&api_key=%2FUK%2Fapi%2FUser%2FLogin";
                    await authentication.FetchAsync(url);
                    //StartActivity(new Intent(this, typeof(HomeActivity)));
                }
                else
                {
                    Toast.MakeText(this, "No Internet Connection.\nTurn the Internet connection on and try again", ToastLength.Long).Show();
                }
            };
        }
    }
}

