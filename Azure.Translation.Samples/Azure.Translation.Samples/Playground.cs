using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Translation.Samples.Azure.Configuration;
using Azure.Translation.Samples.Azure.Responses;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Azure.Translation.Samples
{
    [TestClass]
    public class Playground
    {
        private readonly IConfigurationRoot configuration;
        private readonly AzureTranslationConfigurations azureTranslationConfigurations;

        public Playground()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Playground>();
            configuration = builder.Build();

            azureTranslationConfigurations =
                new AzureTranslationConfigurations(
                    configuration.GetSection(ConfigurationKeys.SubscriptionKey)?.Value,
                    configuration.GetSection(ConfigurationKeys.Endpoint)?.Value
                );
        }

        [TestMethod]
        public void CheckConfigurations()
        {
            configuration.Should().NotBeNull();
            azureTranslationConfigurations.Should().NotBeNull();
        }

        [TestMethod]
        public async Task Sample()
        {
            const string ROUTE = "/translate?api-version=3.0&to=de&to=it&to=ja&to=th";

            var translationResults = await TranslateTextRequest(
                azureTranslationConfigurations.SubscriptionKey,
                azureTranslationConfigurations.Endpoint,
                ROUTE,
                "Hello"
                );

            foreach (var translationResult in translationResults)
            {
                // Print the detected input language and confidence score.
                Console.WriteLine("Detected input language: {0}\nConfidence score: {1}\n", translationResult.DetectedLanguage.Language, translationResult.DetectedLanguage.Score);
                // Iterate over the results and print each translation.
                foreach (var translation in translationResult.Translations)
                {
                    Console.WriteLine("Translated to {0}: {1}", translation.To, translation.Text);
                }
            }
        }

        #region Helper Methods

        private static string CreateRequestBodyJson(string text)
        {
            var body = new object[] { new { Text = text } };
            return JsonConvert.SerializeObject(body);
        }

        private static async Task<IEnumerable<TranslationResult>> TranslateTextRequest(string subscriptionKey, string endpoint, string route, string text)
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{endpoint}{route}"),
                Content = new StringContent(CreateRequestBodyJson(text), Encoding.UTF8, "application/json")
            };

            // Build the request.
            // Set the method to Post.
            // Construct the URI and add headers.
            request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();

            if (result.Contains("error"))
            {
                throw new Exception(result);
            }

            var translationResults = JsonConvert.DeserializeObject<TranslationResult[]>(result);

            return translationResults;
           
        }

        #endregion helper Methods
    }
}
