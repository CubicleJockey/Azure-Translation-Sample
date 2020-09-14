using System.Collections.Generic;

namespace Azure.Translation.Samples.Azure.Responses
{
    public class TranslationResult
    {
        public DetectedLanguage DetectedLanguage { get; set; }
        public TextResult SourceText { get; set; }
        public IEnumerable<Translation> Translations { get; set; }
    }
}
