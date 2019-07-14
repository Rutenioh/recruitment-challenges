using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class NormalizerTests
    {
        [TestMethod]
        public void Normalize_Normal_Mail()
        {
            string mail = "hectorgti@gmail.com";
            INormalizer normalizer = new MailNormalizer();

            var mailNormalized = normalizer.Normalize(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals(mail);
        }

        [TestMethod]
        public void Normalize_Mail_With_Dot()
        {
            string mail = "hector.gti@gmail.com";
            INormalizer normalizer = new MailNormalizer();

            var mailNormalized = normalizer.Normalize(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals("hectorgti@gmail.com");
        }

        [TestMethod]
        public void Normalize_Mail_With_Dot_And_Plus()
        {
            string mail = "hec+tor.gti@gmail.com";
            INormalizer normalizer = new MailNormalizer();

            var mailNormalized = normalizer.Normalize(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals("hectorgti@gmail.com");
        }

        [TestMethod]
        public void Normalize_Street()
        {
            string street = "123 Sesame St.";
            INormalizer normalizer = new StreetNormalizer();

            var streetNormalized = normalizer.Normalize(street.ToLower());

            streetNormalized.Should().NotBeNull();
            streetNormalized.Should().Equals("123 sesame street");
        }

        [TestMethod]
        public void Normalize_Road()
        {
            string street = "123 Sesame Rd.";
            INormalizer normalizer = new StreetNormalizer();

            var streetNormalized = normalizer.Normalize(street.ToLower());

            streetNormalized.Should().NotBeNull();
            streetNormalized.Should().Equals("123 sesame road");
        }


        [TestMethod]
        public void Normalize_State()
        {
            string state = "NY";
            INormalizer normalizer = new StateNormalizer();

            var stateNormalized = normalizer.Normalize(state.ToLower());

            stateNormalized.Should().NotBeNull();
            stateNormalized.Should().Equals("new york");
        }

    }
}
