using System.Globalization;
using System.Text.RegularExpressions;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.ObjectValues.Exceptions;

namespace VandecoStore.Domain.ObjectValues
{
    public readonly struct Mail
    {
        public Mail(string address)
        {
            if (IsValidEmail(address) is false)
            {
                InvalidEmailException.ThrowIfInvalidEmail(IsValidEmail(address), address);
                throw new DomainException("");
            }

            Address = address;

        }

        public string Address { get; }

        public static implicit operator string(Mail email) => email.Address;

        public static implicit operator Mail(string address) => new(address);
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }
    }

}
