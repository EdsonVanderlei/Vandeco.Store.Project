using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Address : Entity
    {
        public Guid UserId { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string NeighboardHood { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }

        //EF Relations 
        public User User { get; private set; }

        protected Address() { }

        public Address(string street, string zipCode, string neighboardHood, string city, string country, string state, string number, string complement,User user)
        {
            User = user;
            UserId = user.Id;
            Street = street;
            ZipCode = zipCode;
            NeighboardHood = neighboardHood;
            City = city;
            Country = country;
            State = state;
            Number = number;
            Complement = complement;

            Validate();
        }

        public void UpdateAddress(Address address)
        {
            Street = address.Street;
            ZipCode = address.ZipCode;
            NeighboardHood = address.NeighboardHood;
            City = address.City;
            Country = address.Country;
            State = address.State;
            Number = address.Number;
            Complement = address.Complement;
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Street, "The Field Street Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(ZipCode, "The Field ZipCode Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(NeighboardHood, "The Field NeighboardHood Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(City, "The Field City Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(Country, "The Field Country Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(State, "The Field State Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(Number, "The Field Number Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(Complement, "The Field Complement Must be provided!");
        }
    }
}
