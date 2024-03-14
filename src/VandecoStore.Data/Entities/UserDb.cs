using VandecoStore.Core;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Data.Entities
{
    public class UserDb : EntityValidation
    {
        public required string Name
        {
            get => _name; init
            {
                FailIfNullOrEmpty(value, nameof(value));
                _name = value;
            }
        }
        private string _name { get; set; }
        public required Document Document { get; init; }
        public required Mail Mail { get; init; }
        public required Phone Phone
        {
            get => _phone;
            init
            {
                FailIfNull(value, nameof(value));
                _phone = value;
            }

        }
        private Phone _phone { get; set; }
        public Phone? Fax { get; init; }
        private Phone _Fax
        {
            get => _Fax;
            set => _Fax = value;
        }
        public required DateTime BirthDate { get; init; }

        //EF Relations
        public required List<AddressDb> Address { get; init; }
        public required Cart Cart { get; init; }
        public required List<OrderDb> Orders { get; init; }
        public required List<CommentDb> Comments { get; init; }

        public UserDb() { }

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
            _Fax = phone;
        }
    }

    public class Document
    {
        public string DocumentNumber { get; set; }

        public Document(string documentNumber)
        {
            DocumentNumber = documentNumber;
            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(DocumentNumber, "The Field DocumentNumber Must Be Provided !");
        }
    }
}
