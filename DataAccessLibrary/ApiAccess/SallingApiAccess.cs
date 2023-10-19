using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DataAccessLibrary.ApiAccess
{
    public class SallingApiAccess
    {
        private readonly IConfiguration _config;

        public List<PublicHolidayModel> PublicHoliday { get; set; } = new List<PublicHolidayModel>();

        public SallingApiAccess(IConfiguration config)
        {
            _config = config;
        }
        
        // Load mærkedage from API
        public async Task<List<PublicHolidayModel>?> GetPublicHolidays()
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://api.sallinggroup.com/v1/holidays?startDate={StartDate()}&endDate={EndDate()}";
            string? apiToken = _config["ApiTokens:SallingApiToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<PublicHolidayModel>? apiModels = JsonConvert.DeserializeObject<List<PublicHolidayModel>>(responseBody);
                return PublicHoliday = apiModels;
            }
            else
            {
                // Handle error response
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }

        public static string StartDate()
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            return new DateTime(oneYearAgo.Year, 1, 1).ToString("yyyy-MM-dd");
        }

        public static string EndDate()
        {
            DateTime fourYearsAhead = DateTime.Now.AddYears(+4);
            return new DateTime(fourYearsAhead.Year, 12, 31).ToString("yyyy-MM-dd");
        }

    }
}
