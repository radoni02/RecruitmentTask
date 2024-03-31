using System.Text.Json.Serialization;

namespace Stack.Api.Dtos;

public class TagDto
{
    [JsonPropertyName("collectives ")]
    public List<CollectivesDto>? Collectives { get; init; }
    [JsonPropertyName("count")]
    public int Count { get; init; }
    [JsonPropertyName("has_synonyms")]
    public bool HasSynonyms { get; init; }
    [JsonPropertyName("is_moderator_only")]
    public bool IsModeratorOnly { get; init; }
    [JsonPropertyName("is_required")]
    public bool IsRequired { get; init; }
    [JsonPropertyName("name")]
    public string Name { get; init; }
    [JsonPropertyName("user_id")]
    public int? UserId { get; init; }
}
