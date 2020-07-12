using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class Number
    {
        [JsonPropertyName("try")]
        public int Try { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}
