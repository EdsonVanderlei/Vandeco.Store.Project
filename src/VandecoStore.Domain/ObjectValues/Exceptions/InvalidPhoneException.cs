
namespace VandecoStore.Domain.ObjectValues.Exceptions
{
    public class InvalidPhoneException : Exception
    {
        private const string DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE = "The Phone Number{0} is invalid";

        public InvalidPhoneException(string phoneNumber) : base(string.Format(DEFAULT_INVALIDE_EMAIL_MESSAGE_TEMPLATE,phoneNumber)) {}

        public static void ThrowIfInvalidPhoneNumber(bool valid, string phoneNumber)
        {
            if (!valid)
            {
                throw new InvalidPhoneException(phoneNumber);
            }
        }
    }
}
