using Android.App;
using Android.Content;
using Android.Content.PM;
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

            FindViewById<Button>(Resource.Id.button1).Click += MainActivity_Click;
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(HomeActivity)));
        }
    }
}

