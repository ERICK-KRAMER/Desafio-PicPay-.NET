using System.Text.Json;
using System.Text.Json.Serialization;

namespace PicPay.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://util.devi.tools/api/v2/authorize";

    public AuthorizationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<bool> AuthorizatorAsync()
    {
        var response = await _httpClient.GetAsync(_baseUrl);

        if (!response.IsSuccessStatusCode) return false;

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response Content: " + content);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<ApiResponse>(content, options);

        Console.WriteLine($"Status: {result?.Status}");
        Console.WriteLine($"Authorization: {result?.Data?.Autorization}");

        return string.Equals(result?.Status, "success", StringComparison.OrdinalIgnoreCase);
    }

}

public class ApiResponse
{
    public string Status { get; set; }
    public DataResponse Data { get; set; }
}

public class DataResponse
{
    [JsonPropertyName("authorization")]
    public bool Autorization { get; set; }
}
