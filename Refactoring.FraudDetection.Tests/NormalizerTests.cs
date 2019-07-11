using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class NormalizerTests
    {
        [TestMethod]
        public void Normalize_Normal_Mail()
        {
            string mail = "hectorgti@gmail.com";
            INormalizer normalizer = new OrderNormalizer();

            var mailNormalized = normalizer.NormalizeMail(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals(mail);
        }

        [TestMethod]
        public void Normalize_Mail_With_Dot()
        {
            string mail = "hector.gti@gmail.com";
            INormalizer normalizer = new OrderNormalizer();

            var mailNormalized = normalizer.NormalizeMail(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals("hectorgti@gmail.com");
        }

        [TestMethod]
        public void Normalize_Mail_With_Dot_And_Plus()
        {
            string mail = "hec+tor.gti@gmail.com";
            INormalizer normalizer = new OrderNormalizer();

            var mailNormalized = normalizer.NormalizeMail(mail);

            mailNormalized.Should().NotBeNull();
            mailNormalized.Should().Equals("hectorgti@gmail.com");
        }

        [TestMethod]
        public void Normalize_Street()
        {
            string street = "123 Sesame St.";
            INormalizer normalizer = new OrderNormalizer();

            var streetNormalized = normalizer.NormalizeStreet(street.ToLower());

            streetNormalized.Should().NotBeNull();
            streetNormalized.Should().Equals("123 sesame street");
        }

        [TestMethod]
        public void Normalize_Road()
        {
            string street = "123 Sesame Rd.";
            INormalizer normalizer = new OrderNormalizer();

            var streetNormalized = normalizer.NormalizeStreet(street.ToLower());

            streetNormalized.Should().NotBeNull();
            streetNormalized.Should().Equals("123 sesame road");
        }


        [TestMethod]
        public void Normalize_State()
        {
            string state = "NY";
            INormalizer normalizer = new OrderNormalizer();

            var stateNormalized = normalizer.NormalizeState(state.ToLower());

            stateNormalized.Should().NotBeNull();
            stateNormalized.Should().Equals("new york");
        }

    }
}
