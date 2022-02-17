using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinSeries.Models;

namespace XamarinSeries.Services
{
    public class ServiceSeries
    {
        private string UrlApi;

        public ServiceSeries()
        {
            this.UrlApi = "https://apiseriesxamarin2022.azurewebsites.net/";
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    T data =
                        JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            string request = "/api/series";
            List<Serie> series =
                await this.CallApiAsync<List<Serie>>(request);
            return series;
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            string request = "/api/series/" + id;
            Serie serie =
                await this.CallApiAsync<Serie>(request);
            return serie;
        }
    }
}
