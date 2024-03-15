using System.Text.RegularExpressions;
using VandecoStore.Domain.ObjectValues.Exceptions;

namespace VandecoStore.Domain.ObjectValues
{
    public readonly struct Phone
    {
        private const string REGEX_PHONE_NUMBER = @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[0-9])[0-9]{3}\-?[0-9]{4}$";

        public string AreaCode { get; }
        public string PhoneNumber { get; }

        public Phone(string areaCode, string phoneNumber)
        {
            AreaCode = areaCode;
            PhoneNumber = phoneNumber;
        }

        public static implicit operator string(Phone phone)
        {
            return $"{phone.AreaCode} {phone.PhoneNumber}";
        }

        public static implicit operator Phone(string phone)
        {
            var regex = new Regex(REGEX_PHONE_NUMBER);
            var success = regex.Match(phone.Replace(" ", ""));
            InvalidPhoneException.ThrowIfInvalidPhoneNumber(regex.Match(phone.Replace(" ", "")).Success, phone);
            var data = phone.Split(" ");
            if (data.Length != 2) InvalidPhoneException.ThrowIfInvalidPhoneNumber(false, phone);
            return new Phone(data[0], data[1]);
        }



        public Phone() { }
    }
}
