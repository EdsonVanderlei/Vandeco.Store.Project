using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Mail
    {
        public string Address { get; private set; }

        public Mail(string address)
        {
            Address = address;
            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentMatches("^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$", Address, "Mail Address Not Valid !");
        }
    }
}
