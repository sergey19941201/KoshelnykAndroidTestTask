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
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KoshelnykAndroidTestTask.Activities
{
    [Activity(Label = "MessagingActivity",Theme = "@android:style/Theme.NoTitleBar", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MessagingActivity : Activity
    {
        List<string> messagesList = new List<string>();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Messaging);

            //var messageUrl = "https://networkrail-uk-qa.traffilog.com/qa/api/Message/GetTemplates?sessionToken=" + Authentication.sessionToken;
            var client = new RestClient("https://networkrail-uk-qa.traffilog.com");
            var requestMessages = new RestRequest("/qa/api/Message/GetTemplates", Method.POST);
            requestMessages.AddQueryParameter("sessionToken", Authentication.sessionToken);

            IRestResponse responsemessages = client.Execute(requestMessages);
            var content = responsemessages.Content;
            var responseMessages = JArray.Parse(JObject.Parse(content)["Data"].ToString());
            foreach (var message in responseMessages)
            {
                messagesList.Add((string)message["Text"]);
            }
            Classes.Adapter adapter = new Classes.Adapter(this, messagesList);

            FindViewById<ListView>(Resource.Id.messagesLV).Adapter = adapter;
        }
    }
}