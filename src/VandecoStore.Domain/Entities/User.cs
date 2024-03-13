using VandecoStore.Core;
using VandecoStore.Domain.ObjectValues;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public Document Document { get; set; }
        public Mail Mail { get; private set; }
        public Phone Phone { get; private set; }
        public Phone? Fax { get; private set; }
        public DateTime BirthDate { get; private set; }

        //EF Relations
        public List<Address> Address { get; private set; }
        public Cart Cart { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<Comment> Comments { get; private set; }

        protected User() { }

        public User(string name, Mail mail, Phone phoneNumber, DateTime birthDate, List<Address> addresses, Document document, Phone? faxNumber = null)
        {
            Name = name;
            Cart = new Cart(this);
            Mail = mail;
            Phone = phoneNumber;
            Fax = faxNumber;
            BirthDate = birthDate;
            Address = addresses;
            Document = document;
            Orders = [];

            Validate();
        }

        public bool HasFaxPhone()
        {
            return Phone is not null;
        }

        public void UpdatePrincipalPhone(Phone phone)
        {
            Phone.UpdatePhone(phone);
        }

        public void UpdateFaxPhone(Phone phone)
        {
            Fax ??= phone;
            Fax.UpdatePhone(phone);
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "The Field Name Must Be Provided !");
            AssertionConcern.AssertArgumentNotNull(Phone, "The Field PhoneNumber Must Be Provided !");
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
