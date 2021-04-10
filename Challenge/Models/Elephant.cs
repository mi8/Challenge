using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Models
{
    public class Elephant
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
        public string Species { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DeathDay { get; set; }
        public string WikiLink { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
    }
}
