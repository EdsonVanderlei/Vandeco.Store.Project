

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class AddressExtension
    {
        public static AddressDb ToAddressDb(this Address address)
        {
            return new AddressDb
            {
                City = address.City,
                State = address.State,
                Complement = address.Complement,
                Country = address.Country,
                NeighboardHood = address.NeighboardHood,
                Number = address.Number,
                Street = address.Street,
                ZipCode = address.ZipCode,
                Id = address.Id,
                Orders = address.Orders.Select(p => p.ToOrderDb()).ToList(),
                User = address.User.ToUserDb(),
                UserId = address.User.Id,
            };
        }
    }
}
