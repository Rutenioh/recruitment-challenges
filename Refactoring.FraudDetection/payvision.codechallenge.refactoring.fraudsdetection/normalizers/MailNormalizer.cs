using System;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.payvision.codechallenge.refactoring.fraudsdetection.factories
{
    public class MailNormalizer : INormalizer
    {
        public string Normalize(string email)
        {
            //Normalize email
            var mailParts = GetMailParts(email);
            mailParts[0] = GetMailWithoutDotsAndPlus(mailParts[0]);

            return JoinMailParts(mailParts);
        }

        private static string JoinMailParts(string[] mailParts)
        {
            return string.Join("@", new string[] { mailParts[0], mailParts[1] });
        }

        private string GetMailWithoutDotsAndPlus(string mail)
        {
            var atIndex = mail.IndexOf("+", StringComparison.Ordinal);

            return atIndex < 0 ? mail.Replace(".", "") : mail.Replace(".", "").Remove(atIndex);
        }

        private static string[] GetMailParts(string email)
        {
            return email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}