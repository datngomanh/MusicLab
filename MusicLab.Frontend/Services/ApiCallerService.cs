using MusicLab.Frontend.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MusicLab.Frontend.Services
{
    public class ApiCallerService : IApiCallerService
    {
        public ApiCallerService()
        {
            
        }

        public async Task<T?> GetApi<T>(string url, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dataObjects = JsonConvert.DeserializeObject<T>(data);
                return dataObjects;
            }
            return default(T?);
        }

        public async Task<bool> PostApi<T>(string url, T requestObject, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            if (requestObject is null)
            {
                return false;
            }
            var objectSerialize = JsonConvert.SerializeObject(requestObject);
            var content = new StringContent(objectSerialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PostApiFormData(string url, FormUrlEncodedContent formContent, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            if (formContent is null)
            {
                return false;
            }
            HttpResponseMessage response = await client.PostAsync(url, formContent).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteApi(string url, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            HttpResponseMessage response = await client.DeleteAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> PutApi<T>(string url, T objectRequest, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            if (objectRequest is null)
            {
                return false;
            }
            var objectSerialize = JsonConvert.SerializeObject(objectRequest);
            var content = new StringContent(objectSerialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<T?> PostApiWithReturn<T>(string url, object requestObject, string jwtToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(jwtToken))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwtToken);
            }

            var objectSerialize = JsonConvert.SerializeObject(requestObject);
            var content = new StringContent(objectSerialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var dataObjects = JsonConvert.DeserializeObject<T>(data);
                return dataObjects;
            }
            return default;
        }
    }
}
