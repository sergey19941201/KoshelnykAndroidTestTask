using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace KoshelnykAndroidTestTask.RequestClasses
{
    public class Authentication
    {
        public void Auth(string login, string password)
        {
            login = "yaniv@nr.co.il";
            password = "Aa123456";
            var client = new RestClient("https://networkrail-uk-qa.traffilog.com");
            var request = new RestRequest("/qa/api/User/Login", Method.POST);
            request.AddQueryParameter("username", login);
            request.AddQueryParameter("password", password);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            string[] contentArr = content.Split('"');
            string token = contentArr[5];



/*
            var requestLoginData = new RestRequest("/qa/api/User//UK/api/User/LoginData");
            requestLoginData.AddQueryParameter("sessionToken", token);

            IRestResponse responseLoginData = client.Execute(requestLoginData);
            var contentLoginData = responseLoginData.Content;*/
        }
    }
}