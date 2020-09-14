using System;

namespace Azure.Translation.Samples.Azure.Configuration
{
    public class AzureTranslationConfigurations
    {
        private const string MESSAGE = "Cannot be empty.";

        public AzureTranslationConfigurations(string subscriptionKey, string endpoint)
        {
            if (string.IsNullOrWhiteSpace(subscriptionKey)) { throw new ArgumentException(MESSAGE, nameof(subscriptionKey)); }
            if (string.IsNullOrWhiteSpace(endpoint)) { throw new ArgumentException(MESSAGE, nameof(endpoint)); }

            SubscriptionKey = subscriptionKey;
            Endpoint = endpoint;
        }

        public string SubscriptionKey { get; }
        public string Endpoint { get; }
    }
}
