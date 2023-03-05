using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
                    return await System.Text.Json.JsonSerializer.DeserializeAsync<List<Person>>(stream, _options);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            return new List<Person>();
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            bool isSuccess = false;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("/PersonInfo", content);
                
                if(response is not null)
                {
                    response.EnsureSuccessStatusCode();
                    isSuccess = true;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            return isSuccess;
        }
    }
}
