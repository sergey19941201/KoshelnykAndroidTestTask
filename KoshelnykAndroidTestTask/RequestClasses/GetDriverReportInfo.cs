using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;

namespace KoshelnykAndroidTestTask.RequestClasses
{
    public class GetDriverReportInfo
    {

        private string jsonString; //string for getting data from the url

        public async Task<string> FetchAsync(string url)
        {
            //getting data process goes here
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var stream = await httpClient.GetStreamAsync(url);
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
            }

            

            //var responseCountries = JArray.Parse(JObject.Parse(jsonString).ToString());
            //parsing data from jsonstring
            //int u = 9;
            /*foreach (var countryInResponse in responseCountries)//the foreach-loop
            {
                var rootObject = new RootObject((int)countryInResponse["id"], (string)countryInResponse["title"]);
            }*/

            return jsonString;
        }
    }
}