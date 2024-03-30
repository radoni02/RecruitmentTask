using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stack.Infrastructure.Model; 
public class Wrapper<T> where T : class//implement marker interface here
{ 
    [JsonPropertyName("backoff")]
    public int? BackOff{ get; init; }
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
    public int QuotaMax{ get; init; }
    [JsonPropertyName("quota_remaining")]
    public int QuotaRemaining { get; init;} 
}
