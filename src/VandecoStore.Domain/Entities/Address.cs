using VandecoStore.Core;

namespace VandecoStore.Domain.Entities
{
    public class Address : EntityValidation
    {
        public Guid UserId { get; private set }
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

        private readonly List<Order> _orders;
        //EF Relations 
        public  List<Order> Orders
        {
            get => _orders;
            init
            {
                _orders = [];
            }
        }
        private User _user;
        public User User
        {
            get => _user;
            set
            {
                UserId = value.Id;
                _user = value;
            }
        }

        protected Address() { }

        public void UpdateAddress(Address address)
        {
            _street = address.Street;
            _zipCode = address.ZipCode;
            _neighboardHood = address.NeighboardHood;
            _city = address.City;
            _country = address.Country;
            _state = address.State;
            _number = address.Number;
            _complement = address.Complement;
        }
    }
}
