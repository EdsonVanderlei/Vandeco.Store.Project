namespace VandecoStore.Domain.ObjectValues
{
    public readonly struct Phone
    {
        public string AreaCode { get; }
        public string CountryCode { get; }
        public string PhoneNumber { get; }

        public Phone(string areaCode, string countryCode, string phoneNumber)
        {
            AreaCode = areaCode;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
        }

        public static implicit operator string(Phone phone)
        {
            return $"+{phone.CountryCode} {phone.AreaCode} {phone.PhoneNumber}";
        }

        public static implicit operator Phone(string phone)
        {
            var data = phone.Split(" ");
            return new Phone(data[0], data[1], data[2]);
        }

        public Phone() { }
    }
}
