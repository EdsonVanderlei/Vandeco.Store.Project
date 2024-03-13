using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.ObjectValues
{
    public struct Phone
    {
        public int AreaCode { get; private set; }
        public int CountryCode { get; private set; }
        public string PhoneNumber { get; private set; }

        public Phone(int areaCode, int countryCode, string phoneNumber)
        {
            AreaCode = areaCode;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            Validate();
        }

        public void UpdatePhone(Phone phone)
        {
            AreaCode = phone.AreaCode;
            CountryCode = phone.CountryCode;
            PhoneNumber = phone.PhoneNumber;
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(PhoneNumber, "The Field PhoneNumber Must be Provided !");
        }
    }
}
