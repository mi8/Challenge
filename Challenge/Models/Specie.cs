using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class Specie
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("classification")]
        public string Classification { get; set; }

        [JsonPropertyName("designation")]
        public string Designation { get; set; }

        [JsonPropertyName("average_height")]
        public string AverageHeight { get; set; }

        [JsonPropertyName("average_lifespan")]
        public string AverageLifespan { get; set; }

        [JsonPropertyName("eye_colors")]
        public string CommonEyeColors { get; set; }

        [JsonPropertyName("hair_colors")]
        public string CommonHairColors { get; set; }

        [JsonPropertyName("skin_colors")]
        public string CommonSkinColors { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

    }
}
