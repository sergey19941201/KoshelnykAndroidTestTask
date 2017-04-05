using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Views.Animations;
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
            SetContentView(Resource.Layout.Main);

            //declaring animation
            Animation myAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.myAnimation);
            ImageView myImage = FindViewById<ImageView>(Resource.Id.animIV);
            myImage.Visibility = ViewStates.Gone;

            //checking internet connection
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            //checking internet connection ended

            var loginET = FindViewById<EditText>(Resource.Id.loginET);
            var passwordET = FindViewById<EditText>(Resource.Id.passwordET);

            Authentication authentication = new Authentication();

            FindViewById<Button>(Resource.Id.loginBn).Click +=  delegate
            {
                if (isOnline == true)
                {
                    myImage.Visibility = ViewStates.Visible;
                    myImage.StartAnimation(myAnimation);
                    Toast.MakeText(this, "Authentication", ToastLength.Short).Show();
                    bool authentic = authentication.Auth(loginET.Text, passwordET.Text, StartActivity, new Intent(this, typeof(Home_Activity)));
                    if (authentic == false)
                    {
                        Toast.MakeText(this, "Incorrect username or password", ToastLength.Short).Show();
                        myImage.Visibility = ViewStates.Gone;
                    }
                }
                else
                {
                    Toast.MakeText(this, "No Internet Connection.\nTurn the Internet connection on and try again", ToastLength.Long).Show();
                }
            };
        }
    }
}
