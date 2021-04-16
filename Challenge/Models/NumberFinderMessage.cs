using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Models
{
    class NumberFinderMessage
    {
        public enum ViewTypeEnum
        {
            NumberFinderAttempt,
            NumberFinderBiggerOrSmaller,
            NumberFinderSuccess,
            NumberFinderReset,
            NumberFinderError
        }

        public ViewTypeEnum ViewType { get; set; }
        public string Text { get; set; }
    }
}
