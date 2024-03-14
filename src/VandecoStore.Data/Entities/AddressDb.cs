using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class AddressDb : Entity
    {
        public required Guid UserId { get; init; }
        public required string Street { get; init; }
        public required string ZipCode { get; init; }
        public required string NeighboardHood { get; init; }
        public required string City { get; init; }
        public required string Country { get; init; }
        public required string State { get; init; }
        public required string Number { get; init; }
        public required string Complement { get; init; }
        //EF Relations 
        public required List<OrderDb> Orders { get; init; }
        public required UserDb User { get; init; }
        public AddressDb() { }

        public Address ToAddress()
        {
            return new Address
            {
                City = City,
                Complement = Complement,
                State = State,
                Number = Number,
                Country = Country,
                NeighboardHood = NeighboardHood,
                Street = Street,
                ZipCode = ZipCode,
                Id = Id,
            };
        }
    }
}
