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
        public static string sessionToken;

        //private string tokenFromCache;
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
            sessionToken = contentArr[5];

            /*var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(path, "cache.txt");
            
            File.WriteAllText(filename, sessionToken);
            File.ReadAllText(filename);*/


            /*string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "sessionToken.txt");
            using (var streamReader = new StreamReader(filename))
            {
                tokenFromCache = streamReader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(tokenFromCache);
                streamReader.DiscardBufferedData();
            }
            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(sessionToken);
            }*/




            //getting loginData
            var requestLoginData = new RestRequest("/qa/api/User/LoginData", Method.POST);
            requestLoginData.AddQueryParameter("sessionToken", sessionToken);

            IRestResponse responseLoginData = client.Execute(requestLoginData);
            var contentLoginData = responseLoginData.Content;/**/
            //getting loginData ENDED







        }
    }
}