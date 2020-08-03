using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class Root
    {
        [JsonPropertyName("films")]
        public string FilmsUrl { get; set; }

        [JsonPropertyName("people")]
        public string PeopleUrl { get; set; }

        [JsonPropertyName("planets")]
        public string PlanetsUrl { get; set; }

        [JsonPropertyName("species")]
        public string SpeciesUrl { get; set; }

        [JsonPropertyName("starships")]
        public string StarshipsUrl { get; set; }

        [JsonPropertyName("vehicles")]
        public string VehiclesUrl { get; set; }
    }
}
