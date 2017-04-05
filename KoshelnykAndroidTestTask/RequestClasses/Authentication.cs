using System;
using Android.Content;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace KoshelnykAndroidTestTask.RequestClasses
{
    public class Authentication
    {
        public static string sessionToken, workerName;

        //private string tokenFromCache;
        public bool Auth(string login, string password, Action<Intent> navigationFunc, Intent intent)
        {
            //client login
            var client = new RestClient("https://networkrail-uk-qa.traffilog.com");
            var  request = new RestRequest("/qa/api/User/Login", Method.POST);
            request.AddQueryParameter("username", login);
            request.AddQueryParameter("password", password);

            IRestResponse  response = client.Execute(request);
            var content = response.Content;

            string[] contentArr = content.Split('"');
            sessionToken = contentArr[5];

            if (sessionToken == "")
            {
                return false;
            }
            else
            {
                //getting loginData
                var requestLoginData = new RestRequest("/qa/api/User/LoginData", Method.POST);
                requestLoginData.AddQueryParameter("sessionToken", sessionToken);

                IRestResponse responseLoginData = client.Execute(requestLoginData);
                var contentLoginData = responseLoginData.Content;
                string[] LoginDataArr = contentLoginData.Split('"');
                //this name will be displayed in right upper corner of the screen:
                workerName = LoginDataArr[29];
                //getting loginData ENDED

                //Start HomeActivity
                navigationFunc(intent);
            }
            return true;
        }
    }
}