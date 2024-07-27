using System.Text.Json.Serialization;

namespace OllamaFrontend.App.Models;

public record ModelsResponse(
    [property: JsonPropertyName("models")] IReadOnlyList<Model> Models
);

public record Model(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("model")] string ModelName,
    [property: JsonPropertyName("modified_at")] string ModifiedAt,
    [property: JsonPropertyName("size")] object Size,
    [property: JsonPropertyName("digest")] string Digest,
    [property: JsonPropertyName("details")] Details Details
);

public record Details(
    [property: JsonPropertyName("parent_model")] string ParentModel,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("family")] string Family,
    [property: JsonPropertyName("families")] IReadOnlyList<string> Families,
    [property: JsonPropertyName("parameter_size")] string ParameterSize,
    [property: JsonPropertyName("quantization_level")] string QuantizationLevel
);