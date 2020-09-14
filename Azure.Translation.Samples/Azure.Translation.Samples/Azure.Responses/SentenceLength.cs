using System.Collections.Generic;

namespace Azure.Translation.Samples.Azure.Responses
{
    public class SentenceLength
    {
        public IEnumerable<int> SrcSentLen { get; set; }
        public IEnumerable<int> TransSentLength { get; set; }
    }
}
