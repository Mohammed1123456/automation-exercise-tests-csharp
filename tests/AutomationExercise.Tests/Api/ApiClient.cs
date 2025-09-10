using RestSharp;

namespace AutomationExercise.Tests.Api;

public class ApiClient
{
    private readonly RestClient _client;

    public ApiClient()
    {
        var options = new RestClientOptions("https://automationexercise.com/api/")
        {
            ThrowOnAnyError = false,
            Timeout = TimeSpan.FromSeconds(60)
        };
        _client = new RestClient(options);
    }

    public async Task<RestResponse> CreateAccountAsync(Dictionary<string, string> formParams, Action<string>? log = null)
    {
        var endpoint = "createAccount";
        var request = new RestRequest(endpoint, Method.Post);
        foreach (var kv in formParams)
        {
            request.AddParameter(kv.Key, kv.Value);
        }
        log?.Invoke($"POST {endpoint}\nForm: {System.Text.Json.JsonSerializer.Serialize(formParams)}");
        var response = await _client.ExecuteAsync(request);
        log?.Invoke($"Status: {(int)response.StatusCode} {response.StatusCode}\nBody: {response.Content}");
        return response;
    }
}


