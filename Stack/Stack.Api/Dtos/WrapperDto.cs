using System.Text.Json.Serialization;

namespace Stack.Api.Dtos;

public class WrapperDto<T> where T : class//implement marker interface here
{
    [JsonPropertyName("backoff")]
    public int? BackOff { get; init; }
    [JsonPropertyName("error_id")]
    public int? ErrorId { get; init; }
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; init; }
    [JsonPropertyName("error_name")]
    public string? ErrorName { get; init; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; init; }
    [JsonPropertyName("items")]
    public T Items { get; init; }
    [JsonPropertyName("quota_max")]
    public int QuotaMax { get; init; }
    [JsonPropertyName("quota_remaining")]
    public int QuotaRemaining { get; init; }
}
