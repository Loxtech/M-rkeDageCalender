using DataAccessLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.ApiAccess
{
    public class SallingApiAccess
    {

        public List<PublicHolidayModel> _publicHoliday;
        public SallingApiAccess()
        {
            _publicHoliday = new List<PublicHolidayModel>();
        }

        public List<PublicHolidayModel> GetPublicHolidaysList()
        {
            return _publicHoliday;
        }

        // Load mærkedage from API
        public async Task GetPublicHolidays()
        {
            var httpClient = new HttpClient();
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            DateTime firstDayOfPreviousYear = new DateTime(oneYearAgo.Year, 1, 1);

            DateTime fourYearsAhead = DateTime.Now.AddYears(4);
            DateTime lastDayOfFutureYear = new DateTime(fourYearsAhead.Year, 12, 31);

            string apiUrl = $"https://api.sallinggroup.com/v1/holidays?startDate={firstDayOfPreviousYear}&endDate={lastDayOfFutureYear}";
            string apiToken = "706fa95d-511a-4ce7-bca6-c58f2bd5bf0a";
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
            string jsonContent = "{\"key\": \"value\"}";
            HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<PublicHolidayModel> apiModels = JsonConvert.DeserializeObject<List<PublicHolidayModel>>(responseBody);
                _publicHoliday.AddRange(apiModels);
            }
            else
            {
                // Handle error response
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
