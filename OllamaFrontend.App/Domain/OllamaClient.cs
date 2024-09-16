using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Ndjson.AsyncStreams.Net.Http;
using OllamaFrontend.App.Models;

namespace OllamaFrontend.App.Domain;

public class OllamaClient : IAiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _ollamaHost;

    public OllamaClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _ollamaHost = configuration[SettingConsts.OllamaHost] ?? "http://localhost:11434";
    }

    public async Task<IReadOnlyList<Model>> GetModelsAsync()
    {
         
        var httpClient = _httpClientFactory.CreateClient();
        var models = await httpClient.GetFromJsonAsync<ModelsResponse>(new Uri($"{_ollamaHost}/api/tags", UriKind.Absolute));
        return models?.Models ?? [];
    }

    public async IAsyncEnumerable<string> SendRequestAsync(PromptRequest promptRequest, CancellationToken token = default)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var content = JsonContent.Create(promptRequest);
        var request = new HttpRequestMessage
        {
            Content = content,
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_ollamaHost}/api/generate", UriKind.Absolute),
            Version = new Version(3, 0),
            VersionPolicy = HttpVersionPolicy.RequestVersionOrLower
        };
        request.SetBrowserResponseStreamingEnabled(true);
        request.Headers.Add("Accept", "application/x-ndjson");
        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
        if (response.IsSuccessStatusCode)
        {
            await foreach (var promptResponse in response.Content.ReadFromNdjsonAsync<PromptResponse>(cancellationToken: token))
            {
                if (promptResponse is null) continue;
                yield return promptResponse.Response;
            }
        }
        else
        {
            Console.WriteLine($"Ollama api error: {await response.Content.ReadAsStringAsync(CancellationToken.None)}");
        }
    }
    
}