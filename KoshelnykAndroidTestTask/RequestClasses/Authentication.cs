using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Media;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;

namespace KoshelnykAndroidTestTask.RequestClasses
{
    public class Authentication
    {
        public async Task<bool> Auth(string login,string password)
        {
            var client = new RestClient("https://networkrail-uk-qa.traffilog.com");
            var request = new RestRequest("UK/api/User/Login", Method.POST);
            request.AddQueryParameter("username", login);
            request.AddQueryParameter("password", password);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //Console.WriteLine("FFFFFFFF" + (int)response.StatusCode);
            Console.WriteLine(content);

            return true;
        }
    }
}