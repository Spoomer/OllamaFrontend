using OllamaFrontend.App.Models;

namespace OllamaFrontend.App.Domain;

public interface IAiClient
{
    Task<IReadOnlyList<Model>> GetModelsAsync();
    IAsyncEnumerable<string> SendRequestAsync(PromptRequest promptRequest, CancellationToken token = default);
}