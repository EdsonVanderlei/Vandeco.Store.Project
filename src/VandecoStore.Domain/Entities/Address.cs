using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Address : EntityValidation
    {
        private string _street;
        public required string Street
        {
            get => _street;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _street = value;
            }
        }
        private string _zipCode;
        public required string ZipCode
        {
            get => _zipCode;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _zipCode = value;
            }
        }
        private string _neighboardHood;
        public required string NeighboardHood
        {
            get => _neighboardHood;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _neighboardHood = value;
            }
        }
        private string _city;
        public required string City
        {
            get => _city;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _city = value;
            }
        }
        private string _country;
        public required string Country
        {
            get => _country;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _country = value;
            }
        }
        private string _state;
        public required string State
        {
            get => _state;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _state = value;
            }
        }
        private string _number;
        public required string Number
        {
            get => _number;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _number = value;
            }
        }
        private string _complement;
        public required string Complement
        {
            get => _complement;
            init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _complement = value;
            }
        }

        //EF Relations 
        public List<Order> Orders { get; init; }

        public User User { get; init; }
    }
}
