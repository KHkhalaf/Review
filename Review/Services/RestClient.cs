using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Review.Services
{
    public class RestClient<T>
    {
        private string URL;

        public RestClient(string url)
        {
            URL = url;
        }
        public async Task<List<T>> GetAsync()
        {
            string json="";
            var httpClient = new HttpClient();
            
            json = await httpClient.GetStringAsync(URL);
            
            var DataReceived = JsonConvert.DeserializeObject<List<T>>(json);

            return DataReceived;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(URL, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(URL + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(URL + id);

            return response.IsSuccessStatusCode;
        }
    }
}
