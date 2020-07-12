using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class PagedStarships
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string NextPage { get; set; }

        [JsonPropertyName("previous")]
        public string PreviousPage { get; set; }

        [JsonPropertyName("results")]
        public ICollection<Starship> Starships { get; set; }
    }
}
