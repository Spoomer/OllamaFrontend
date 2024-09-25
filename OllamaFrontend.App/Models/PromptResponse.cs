using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace OllamaFrontend.App.Models;

public record PromptResponse(
    [property: JsonPropertyName("model")]
    string Model,
    
    [property: JsonPropertyName("created_at")]
    DateTimeOffset CreatedAt,
    
    [property: JsonPropertyName("response")]
    string Response,
    
    [property: JsonPropertyName("done")]
    bool Done,
    
    [property: JsonPropertyName("done_reason")]
    [property: MemberNotNullWhen(true, "Done")]
    string? DoneReason,
    
    [property: JsonPropertyName("context")]
    [property: MemberNotNullWhen(true, "Done")]
    IReadOnlyList<int>? Context,
    
    [property: JsonPropertyName("total_duration")]
    [property: MemberNotNullWhen(true, "Done")]
    long? TotalDuration,
    
    [property: JsonPropertyName("load_duration")]
    [property: MemberNotNullWhen(true, "Done")]
    long? LoadDuration,
    
    [property: JsonPropertyName("prompt_eval_count")]
    [property: MemberNotNullWhen(true, "Done")]
    long? PromptEvalCount,
    
    [property: JsonPropertyName("prompt_eval_duration")]
    [property: MemberNotNullWhen(true, "Done")]
    long? PromptEvalDuration,
    
    [property: JsonPropertyName("eval_count")]
    [property: MemberNotNullWhen(true, "Done")]
    long? EvalCount,
    
    [property: JsonPropertyName("eval_duration")]
    [property: MemberNotNullWhen(true, "Done")]
    long? EvalDuration
);