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
        public required List<Address> Addresses { get; init; }
        public required Cart Cart { get; init; }
        public required List<Order> Orders { get; init; }
        public required List<Comment> Comments { get; init; }

        public User() { }

        public bool HasFaxPhone()
        {
            return Fax is not null;
        }

        public void UpdatePrincipalPhone(Phone phone)
        {
            _phone = phone;
        }

        public void UpdateFaxPhone(Phone phone)
        {
            _fax = phone;
        }
    }
}
