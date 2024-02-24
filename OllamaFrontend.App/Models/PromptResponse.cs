using System.Text.Json.Serialization;

namespace OllamaFrontend.App.Models;

public record PromptResponse(
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("created_at")]
    DateTimeOffset CreatedAt,
    [property: JsonPropertyName("response")]
    string Response,
    [property: JsonPropertyName("done")] bool Done
);