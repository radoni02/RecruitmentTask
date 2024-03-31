using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stack.Domain.Model;

public class CollectiveExternalLink
{
    public Guid CollectiveId { get; init; }
    [JsonPropertyName("link")]
    public string Link { get; init; }

    [JsonPropertyName("type")]
    [AllowedValues("website","twitter","github","facebook","instagram","support","linkedin")]
    public string Type { get; init; }
}
