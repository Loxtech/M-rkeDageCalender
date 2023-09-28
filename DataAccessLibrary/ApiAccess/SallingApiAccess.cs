﻿using DataAccessLibrary.Models;
using Newtonsoft.Json;

namespace DataAccessLibrary.ApiAccess
{
    public class SallingApiAccess
    {

        public List<PublicHolidayModel> _publicHoliday { get; set; } = new List<PublicHolidayModel>();
        public List<PublicHolidayModel> GetPublicHolidaysList()
        {
            return _publicHoliday;
        }

        // Load mærkedage from API
        public async Task GetPublicHolidays()
        {
            var httpClient = new HttpClient();
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            string firstDayOfPreviousYear = new DateTime(oneYearAgo.Year, 1, 1).ToString("yyyy-MM-dd");

            DateTime fourYearsAhead = DateTime.Now.AddYears(+4);
            string lastDayOfFutureYear = new DateTime(fourYearsAhead.Year, 12, 31).ToString("yyyy-MM-dd");

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