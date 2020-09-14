using Azure.Translation.Samples.Azure.Configuration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Translation.Samples.Azure.Tests
{
    [TestClass]
    public class ConfigurationKeysTests
    {
        [TestMethod]
        public void SubscriptionKey()
        {
            ConfigurationKeys.SubscriptionKey.Should().Be("TRANSLATOR:TEXT:SUBSCRIPTION:KEY");
        }

        [TestMethod]
        public void EndPoint()
        {
            ConfigurationKeys.Endpoint.Should().Be("TRANSLATOR:TEXT:ENDPOINT");
        }
    }
}
