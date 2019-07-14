using System;
using System.Collections;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories
{
    public interface INormalizerFactory
    {
        INormalizer Create(string type);
    }
}