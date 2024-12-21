using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WinFormsTestApp
{
    public static class httpClientExtensions
    {
        public static T CallWebApi<T>(this HttpClient client, string baseUrl, string methodName, string json)
        {
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Date = DateTime.Now;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpContent.Headers.ContentLength = json.Length;

            string url = Path.Combine(baseUrl, "api", methodName).Replace("\\", "/"); ;

            return client.CallWebApi<T>(url, httpContent);
        }

        public static T CallWebApi<T>(this HttpClient client, string baseUrl, string methodName, httpClientParameters parameters)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Date = DateTime.Now;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            StringContent httpContent = new StringContent("", Encoding.UTF8, "application/json");

            string url = Path.Combine(baseUrl, "api", methodName);
            if (parameters != null)
            {
                url += parameters.GetUrlParameters();
            }

            return client.CallWebApi<T>(url, httpContent);
        }

        public static T CallWebApi<T>(this HttpClient client, string url, StringContent httpContent)
        {
            HttpResponseMessage response = client.PostAsync(url, httpContent).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                Stream responseStream = response.Content.ReadAsStreamAsync().Result;
                StreamReader sr = new StreamReader(responseStream);

                string strResult = sr.ReadToEnd();

                JsonTextReader strReader = new JsonTextReader(new StringReader(strResult));

                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Converters.Add(new IsoDateTimeConverter()); // Serializing DateTime using the ISO 8601 format

                var result = serializer.Deserialize<T>(strReader);

                return result;
            }
            else
            {
                string errResponse = response.ReasonPhrase;

                string errMsg = response.Content.ReadAsStringAsync().Result;

                if (errResponse == "Unauthorized")
                {
                    throw new Exception("Unauthorized");
                }
                else
                {
                    throw new Exception(errResponse + " - " + errMsg);
                }
            }
        }

        public static async Task<T> CallWebApiAsync<T>(this HttpClient client, string url, StringContent httpContent)
        {
            HttpResponseMessage response = await client.PostAsync(url, httpContent);  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                Stream responseStream = response.Content.ReadAsStreamAsync().Result;
                StreamReader sr = new StreamReader(responseStream);

                string strResult = sr.ReadToEnd();

                JsonTextReader strReader = new JsonTextReader(new StringReader(strResult));

                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Converters.Add(new IsoDateTimeConverter()); // Serializing DateTime using the ISO 8601 format

                var result = serializer.Deserialize<T>(strReader);

                return result;
            }
            else
            {
                string errResponse = response.ReasonPhrase;

                string errMsg = response.Content.ReadAsStringAsync().Result;

                if (errResponse == "Unauthorized")
                {
                    throw new Exception("Unauthorized");
                }
                else
                {
                    throw new Exception(errResponse + " - " + errMsg);
                }
            }
        }

        public static async Task<T> CallWebApiAsync<T>(this HttpClient client, string baseUrl, string methodName, string json)
        {
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpContent.Headers.ContentLength = json.Length;

            string url = Path.Combine(baseUrl, "api", methodName).Replace("\\", "/");

            return await client.CallWebApiAsync<T>(url, httpContent);
        }
    }

    public class httpClientParameters
    {
        private List<KeyValuePair<string, string>> _parameters;
        public httpClientParameters()
        {
            _parameters = new List<KeyValuePair<string, string>>();
        }

        public httpClientParameters(string name, string value) : this()
        {
            this.AddParameter(name, value);
        }

        public void AddParameter(string name, string value)
        {
            _parameters.Add(new KeyValuePair<string, string>(name, value));
        }

        public string GetUrlParameters()
        {
            string urlParams = "";
            if (_parameters != null)
            {
                foreach (KeyValuePair<string, string> param in _parameters)
                {
                    if (!string.IsNullOrEmpty(urlParams))
                        urlParams += "&";

                    urlParams += $"{param.Key}={param.Value}";
                }

                if (!string.IsNullOrEmpty(urlParams))
                    urlParams = $"?{urlParams}";
            }

            return urlParams;
        }
    }


}
