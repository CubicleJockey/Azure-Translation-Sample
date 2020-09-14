using System.Configuration;
using Azure.Translation.Samples.Azure.Configuration;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
