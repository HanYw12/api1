using System.Text.Json;
using Model;
using Service.Interfaces;

public class ConsumirClient : IConsumirClient
{
    private readonly HttpClient _httpClient;
    public ConsumirClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User> GetUsuarioByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"http://ec2-52-207-143-169.compute-1.amazonaws.com/usuario/Users/{id}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<User>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
    }
}