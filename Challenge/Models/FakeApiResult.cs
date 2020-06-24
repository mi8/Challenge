using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Models
{
    public enum FakeApiTryResult { Winner, Smaller, Bigger };

    public class FakeApiResult
    {
        public int Try { get; set; }
        public string Result { get; set; }

        public FakeApiResult(int tryNumber, string result)
        {
            Try = tryNumber;
            Result = result;
        }
    }
}
