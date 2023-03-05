using System.Text.Json;

namespace frontend.blazor.Clients;

public class ProductClient
{
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private HttpClient _httpClient;

    public ProductClient(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task<List<Product>> GetProductAsync(int id = 0)
    {
        var result = new List<Product>();
        
        try
        {
            var response = new HttpResponseMessage();
            if (id > 0)
                response = await _httpClient.GetAsync($"/Product/{id}");
            else
                response = await _httpClient.GetAsync("/Product");

            if(response is not null)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _options);
            }
        }
        catch (HttpRequestException ex)
        {
            throw ex;
        }

        return result is null ? new List<Product>() : result;
    }
}
