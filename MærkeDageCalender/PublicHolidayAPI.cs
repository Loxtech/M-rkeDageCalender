using System.Text.Json;
using System.Net.Http;

namespace MærkeDageCalender
{
    public class PublicHolidayAPI
    {
        public async Task<List<PublicHoliday>> GetPublicHolidays()
        {
            var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2023/DK");
            if (response.IsSuccessStatusCode)
            {
                using var jsonStream = await response.Content.ReadAsStreamAsync();
                var publicHolidays = JsonSerializer.Deserialize<List<PublicHoliday>>(jsonStream, jsonSerializerOptions);
                return publicHolidays;
            }
            else
            {
                throw new Exception();
            }

            
        }
    }
}
