
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace CRUD_API_Source
{
    public class CallingApi
    {
        public static DataTable CallApiPostDS(string URL, object obj)
        {
            DataTable dt = new DataTable();

            //HttpClientHandler handler = new HttpClientHandler
            //{
            //    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            //};
            //using (HttpClient HClient = new HttpClient(handler))

            using (HttpClient HClient = new HttpClient())
            {

                HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseURL"].ToString());
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HClient.Timeout = TimeSpan.FromMinutes(10);
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = HClient.PostAsync(URL, content).Result;
                var resStr = response.Content.ReadAsStringAsync().Result.ToString();
                Console.WriteLine(resStr);
                dt = JsonConvert.DeserializeObject<DataTable>(resStr);

                return dt;

            }
        }



         public static DataTable CallApiGetDt(string URL)
        {
            DataTable dt = new DataTable();
            try
            {
                //HttpClientHandler handler = new HttpClientHandler
                //{
                //    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                //};
                //using (HttpClient HClient = new HttpClient(handler))
                using (HttpClient HClient = new HttpClient())
                {
                    HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());
                    HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var uri = URL;
                    var response = HClient.GetAsync(uri).Result;
                    var resData = response.Content.ReadAsStringAsync().Result.ToString();
                    dt = new DataTable();
                    dt = JsonConvert.DeserializeObject<DataTable>(resData);
                    return dt;

                }
            }
            catch (Exception)
            {
                dt = new DataTable();
                return dt;
            }
        }
    }
}