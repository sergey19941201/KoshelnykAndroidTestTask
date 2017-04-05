using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
//using Java.Lang.Reflect;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace KoshelnykAndroidTestTask.RequestClasses
{
    public class Authentication
    {
        public static string sessionToken, workerName;

        //private string tokenFromCache;
        public bool Auth(string login, string password, Action<Intent> navigationFunc, Intent intent)
        {
            login = "yaniv@nr.co.il";
            password = "Aa123456";



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
                workerName = LoginDataArr[29];
                //getting loginData ENDED

                //get vehicle check
                var requestVehicleCheck = new RestRequest("qa/api/VehicleCheck/GetVehicleCheck", Method.POST);
                requestVehicleCheck.AddQueryParameter("sessionToken", sessionToken);
                IRestResponse responseVehicleCheck = client.Execute(requestVehicleCheck);
                var contentVehicleCheck = responseVehicleCheck.Content;
                //get vehicle check ENDED

                navigationFunc(intent);
            }
            return true;
        }
    }
}