using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stack.Domain.Model
{
    public class Collectives
    {
        public Guid Id { get; init; }
        public Guid TagId { get; init; }
        [JsonPropertyName("description")]
        public string Description{ get; init; }
        [JsonPropertyName("external_links")]
        public List<CollectiveExternalLink> ExternalLinks{ get; init; }
        [JsonPropertyName("link")]
        public string Link { get; init; }
        [JsonPropertyName("name")]
        public string Name{ get; init; }
        [JsonPropertyName(" slug")]
        public string Slug{ get; init; }
        [JsonPropertyName("tags")]
        public List<string>  Tags{ get; init; }
    }
}
