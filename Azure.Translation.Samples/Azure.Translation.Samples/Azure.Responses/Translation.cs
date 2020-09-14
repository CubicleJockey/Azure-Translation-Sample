namespace Azure.Translation.Samples.Azure.Responses
{
    public class Translation
    {
        public string Text { get; set; }
        public TextResult Tranliteration { get; set; }
        public string To { get; set; }
        public Alignment Alignment { get; set; }
        public SentenceLength SentLen { get; set; }
    }
}
