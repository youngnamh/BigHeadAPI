using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BigHeadAPI.Model;
using Microsoft.AspNetCore.Mvc;

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
        
        public async Task<Athlete> GetStravaToken(string aCode)
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
                scope = "activity:read_all",
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
                
                TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseBody);
                Athlete responseAthlete = new Athlete
                {
                    id = tokenResponse.athlete.id,
                    RefreshToken = tokenResponse.refresh_token,
                    AccessToken = tokenResponse.access_token,
                    firstname = tokenResponse.athlete.firstname,
                    lastname = tokenResponse.athlete.lastname
                };
                // String responseString = "refreshToken: " + tokenResponse.refresh_token + " accesstoken: " +
                //                         tokenResponse.access_token + "Athelete id&Name"+tokenResponse.athlete.id
                //                         + tokenResponse.athlete.firstname + tokenResponse.athlete.lastname;
                
                List<Activity> activities = await GetActivities(tokenResponse.access_token);
                responseAthlete.Activities = activities;
                responseAthlete.ListLength = activities.Count;
                //string jsonAthlete = System.Text.Json.JsonSerializer.Serialize(responseAthlete);
                return responseAthlete;
            }
            else
            {
                // Handle errors
                Athlete nullAthlete = null;
                //return $"Error from Strava Service: {response.StatusCode}";
                return nullAthlete;
            }
        }


        private async Task<List<Activity>> GetActivities(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            // Make Get Request fir activities
            HttpResponseMessage response = await _httpClient.GetAsync("https://www.strava.com/api/v3/athlete/activities?page=1&per_page=200");
            if (response.IsSuccessStatusCode)
            {
                // Read and return the response content
                string responseBody = await response.Content.ReadAsStringAsync();
                var activities = JsonSerializer.Deserialize<List<Activity>>(responseBody);
                
                var filteredActivities = new List<Activity>();
                foreach (var activity in activities)
                {
                    filteredActivities.Add(new Activity
                    {
                        start_date = activity.start_date,
                        distance = activity.distance,
                        type = activity.type
                    });
                }
                //string filteredJson = System.Text.Json.JsonSerializer.Serialize(filteredActivities);
                return filteredActivities;
            }
            else
            {
                var emptyList = new List<Activity>();
                // Handle errors
                Console.WriteLine("Error getting activities of athlete");
                return emptyList;
            }
        }
    }
}
