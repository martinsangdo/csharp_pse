//send request to another domain
using System.Text.Json;

namespace WebApplication1.Services
{
    public class ExternalService
    {
        private readonly HttpClient _httpClient;

        public ExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Dictionary<string, JsonElement> sendGetRequest(string apiUrl)
        {
            // 1. Make HTTP request (blocking)
            var response = _httpClient.GetAsync(apiUrl).Result;
            response.EnsureSuccessStatusCode();
            // 2. Read response body (blocking)
            var json = response.Content.ReadAsStringAsync().Result;
            // 3. Deserialize JSON to dictionary
            var root = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            return root!;
        }
        //use async -> all callers must use async
        // public async Task<Dictionary<string, JsonElement>> sendGetRequest<T>(string apiUrl)
        // {
        //     var response = await _httpClient.GetAsync(apiUrl);
        //     response.EnsureSuccessStatusCode();
        //     var json = await response.Content.ReadAsStringAsync();
        //     var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        //     return dict!;
        // }
    }
}
