using System.Text.Json;

namespace BlazorAppz.Services
{
    public class HttpClientWrapperService
    {

        private readonly string _baseUrl = "https://localhost:7102";

        public HttpClient _httpClient;

        public HttpClientWrapperService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync(_baseUrl+url);
            response.EnsureSuccessStatusCode();


            using var responseContent = await response.Content.ReadAsStreamAsync();
           return await JsonSerializer.DeserializeAsync<T>(responseContent);
            

        }

        //public async Task<T> PutAsync<T>(string url)
        //{
        //    var response = await _httpClient.PutAsync(url);
        //    response.EnsureSuccessStatusCode();

        //    using var responseContent = await response.Content.ReadAsStreamAsync();
        //    return await JsonSerializer.DeserializeAsync<T>(responseContent);
        //}

        //public async Task<T> PostAsync<T>(string url)
        //{
        //    var response = await _httpClient.PostAsync(_baseUrl + url);
        //    response.EnsureSuccessStatusCode();

        //    using var responseContent = await response.Content.ReadAsStreamAsync();
        //    return await JsonSerializer.DeserializeAsync<T>(responseContent);
        //}




        public async Task<T> DeleteAsync<T>(string url)
        {
            var response = await _httpClient.DeleteAsync(_baseUrl + url);
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }




    }
}
