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
        //private static readonly HttpClient client = new HttpClient();
        public void Auth()
        {
            //string login = "yaniv@nr.co.il";
            string login = "yaniv@nr.co.il";
            string password = "Aa123456";
            //using RestSharp;

            //var client = new RestClient("https://networkrail-uk-qa.traffilog.com/swagger/ui/index#!/User/User_LoginData");


            var client = new RestClient("https://networkrail-uk-qa.traffilog.com");
            var request = new RestRequest("UK/api/User/Login", Method.POST);
            request.AddQueryParameter("username", login);
            request.AddQueryParameter("password", password);

            IRestResponse response = client.Execute(request);
            var content = response.Content;


            //var client = new RestClient("https://networkrail-uk-qa.traffilog.com/User/User_Login");
            //var client = new RestClient("https://networkrail-uk-qa.traffilog.com/POST/UK/api/User/Login");


            /* var client = new RestClient("https://networkrail-uk-qa.traffilog.com/UK/api/User/Login");
            var request = new RestRequest(Method.POST);
            request.AddParameter("username", login);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);
            var content = response.Content;

           */


            //var client = new RestClient("https://networkrail-uk-qa.traffilog.com/UK/api/User/User_Login");


            //var request = new RestRequest(Method.POST);



            //request.AddParameter("username", "password");
            //client.Authenticator = new HttpBasicAuthenticator(login, password);

            //request.Resource = "statuses/friends_timeline.xml";
            /*request.AddParameter("username", login);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);
             var content = response.Content;
             Console.WriteLine("RRRR");*/

            //Console.WriteLine(content);
            //Console.WriteLine("FFFFFFFF" + (int)response.StatusCode);
            Console.WriteLine(content);

            /*WebRequest request = WebRequest.Create("https://networkrail-uk-qa.traffilog.com/UK/api/User/Login");
             request.Method = "POST";

             /*using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
             {
                 writer.Write("username=" + login + "&password=" + password);
             }

             HttpWebResponse response = (HttpWebResponse)request.GetResponse();
             //Retrieve your cookie that id's your session
             //response.Cookies

             //using (StreamReader reader = new StreamReader(response.GetResponseStream())
             ;
             /*{
                 Console.WriteLine(reader.ReadToEnd());
              }









             /*


             var client = new RestClient("https://networkrail-uk-qa.traffilog.com/UK/api/User/Login");
             // client.Authenticator = new HttpBasicAuthenticator(username, password);

             var request = new RestRequest("resource/{id}", Method.POST);
             request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
             request.AddUrlSegment("id", 123); // replaces matching token in request.Resource

             // add parameters for all properties on an object
             request.AddObject(object);

             // or just whitelisted properties
             request.AddObject(object, "PersonId", "Name", ...);

             // easily add HTTP Headers
             request.AddHeader("header", "value");

             // add files to upload (works with compatible verbs)
             request.AddFile(path);

             // execute the request
             RestResponse response = client.Execute(request);
             var content = response.Content; // raw content as string












             // or automatically deserialize result
             // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
             /*RestResponse<Person> response2 = client.Execute<Person>(request);
             var name = response2.Data.Name;

             // or download and save file to disk
             //client.DownloadData(request).SaveAs(path);

             // easy async support
             /*client.ExecuteAsync(request, response => {
                 Console.WriteLine(response.Content);
             });

             // async with deserialization
             var asyncHandle = client.ExecuteAsync<Person>(request, response => {
                 Console.WriteLine(response.Data.Name);
             });

             // abort the request on demand
             asyncHandle.Abort();
             */
        }


        //private string jsonString; //string for getting data from the url
        /*public async Task<bool> FetchAsync(string url)
        {
            //getting data process goes here
            /*using (var httpClient = new System.Net.Http.HttpClient())
            {
                var stream = await httpClient.GetStreamAsync(url);
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
            }

            //var responseCities = JArray.Parse(JObject.Parse(jsonString)["response"].ToString());//parsing data from jsonstring

            /*foreach (var cityInResponse in responseCities)//the foreach-loop
            {
                var rootObject = new RootObject((int)cityInResponse["cid"], (string)cityInResponse["title"]);
                listOfCitiesRoot.Add(rootObject);//here the program adds Id and Title of each city to the list
                listOfCities.Add(rootObject.Title);//adding to the list with names of the cities
            }

        //return true;//returned list
    }

        /*public int retrievingChoosenCityId()//uses to retrieve id of the pressed city to retrieve universities of this city
        {
            foreach (var item in listOfCitiesRoot)//foreach loop to compare item title of the city with pressed title of the city
            {
                if (item.Title == FillingPage.chosenCityTitle)
                {
                    return item.Id;//retrieving needed id of the city
                }
            };
            return 0;
        }*/
    }
}