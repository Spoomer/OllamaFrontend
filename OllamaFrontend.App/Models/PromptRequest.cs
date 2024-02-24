namespace OllamaFrontend.App.Models;

public record PromptRequest
{
    public required string Model { get; set; }
    public required string Prompt { get; set; }
}