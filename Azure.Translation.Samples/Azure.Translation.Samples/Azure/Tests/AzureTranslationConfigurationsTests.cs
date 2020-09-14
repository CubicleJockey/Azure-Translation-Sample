using Azure.Translation.Samples.Azure.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace Azure.Translation.Samples.Azure.Tests
{
    [TestClass]
    public class AzureTranslationConfigurationsTests
    {
        [DataRow(null, @"http:\\endpoint.io")]
        [DataRow("", @"http:\\endpoint.io")]
        [DataRow("        ", @"http:\\endpoint.io")]
        [DataRow("xxxx-xxxx-xxxx-xxxx", null)]
        [DataRow("xxxx-xxxx-xxxx-xxxx", "")]
        [DataRow("xxxx-xxxx-xxxx-xxxx", "       ")]
        [DataTestMethod]
        public void SubscriptionKey(string subscriptionKey, string endpoint)
        {
            Action ctor = () => _ = new AzureTranslationConfigurations(subscriptionKey, endpoint);

            if (string.IsNullOrWhiteSpace(subscriptionKey))
            {
                ctor.Should()
                    .Throw<ArgumentException>()
                    .WithMessage("Cannot be empty. (Parameter 'subscriptionKey')");
            }
            else
            {
                ctor.Should()
                    .Throw<ArgumentException>()
                    .WithMessage("Cannot be empty. (Parameter 'endpoint')");
            }
        }
    }
}
