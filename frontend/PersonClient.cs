using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace frontend
{
    public class PersonClient
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _client;

        public PersonClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            try
            {
                var response = await _client.GetAsync("/PersonInfo");

                if (response is not null)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<List<Person>>(stream, _options);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            return new List<Person>();
        }
    }
}
