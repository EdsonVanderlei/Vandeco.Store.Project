using System.Collections.ObjectModel;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.Entities
{
    public class User : EntityValidation
    {
        private string _name;
        public required string Name
        {
            get => _name; init
            {
                FailIfNullOrEmpty(value, nameof(Name));
                _name = value;
            }
        }
        public required Document Document { get; init; }
        public required Mail Mail { get; init; }
        public required Phone Phone
        {
            get => _phone;
            init
            {
                FailIfNullOrEmpty(value, nameof(Phone));
                _phone = value;
            }
        }
        private Phone _phone;
        private Phone? _fax;
        public Phone? Fax
        {
            get => _fax;
            init
            {
                FailIfNullOrEmpty(value, nameof(Fax));
                _fax = value;
            }
        }
        public required DateTime BirthDate { get; init; }
        private List<Address> _addresses = [];
        public ReadOnlyCollection<Address> Addresses
        {
            get => _addresses.AsReadOnly();
            init
            {
                _addresses = [.. value];
            }
        }
        public Cart Cart { get; init; } = new Cart { CartItems = [] };
        public List<Order> Orders { get; init; }
        public List<Comment> Comments { get; init; }

        public User() { }

        public bool HasFaxPhone()
        {
            return Fax is not null;
        }

        public void UpdatePrincipalPhone(Phone phone)
        {
            _phone = phone;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public bool HasDeliveryOrder()
        {
            var orderStatus = Orders.SelectMany(p => p.OrdersStatus);
            return orderStatus.Where(p => p.StatusProcessEnum != StatusProcessEnum.Delivered).Any();
        }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public void UpdateFaxPhone(Phone phone)
        {
            _fax = phone;
        }
    }
}
