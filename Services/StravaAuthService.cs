using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BigHeadAPI.Services
{
    
    public class StravaAuthService
    {
        private readonly HttpClient _httpClient;

        public StravaAuthService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://www.strava.com/");
        }
        
        public async Task<string> GetStravaToken(string aCode)
        {
            Console.WriteLine($"GetStravaToken: {aCode}");
            string accessToken = aCode; // You would need to obtain this from Strava
            string clientSecret = "cf0a978e472f1ac06eb9a8782e19766933276a9f";
            string clientID = "123612";
            string endpoint = "oauth/token";
            
            var requestData = new
            {
                client_id = clientID,
                client_secret = clientSecret,
                code = accessToken,
                grant_type = "authorization_code"
            };
            
            var requestContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(requestData),
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, requestContent);
            
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            else
            {
                // Handle errors
                return $"Error from Strava Service: {response.StatusCode}";
            }
        }
    
    }
}
