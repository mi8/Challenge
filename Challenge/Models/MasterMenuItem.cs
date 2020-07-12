using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Models
{
    public class MasterMenuItem
    {
        public string Text { get; set; }
        public string Detail { get; set; }
        public string ImagePath { get; set; }
        public string TargetPage { get; set; }
        public Type TargetType { get; set; }
    }
}
