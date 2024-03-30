using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stack.Infrastructure.Model;

public class Tag
{
    [JsonPropertyName("collectives ")]
    public List<Collectives>? Collectives { get; init; }
    [JsonPropertyName("count")]
    public int Count{ get; init; }
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
