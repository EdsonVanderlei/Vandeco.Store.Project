using VandecoStore.Core;
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
        public Address Address { get; private set; }
        public Cart Cart { get; private set; }
        public List<Order> Orders { get; private set; }

        protected User() { }

        public User(string name, Mail mail, Phone phoneNumber, DateTime birthDate, Address address, Document document, Phone? faxNumber = null)
        {
            Name = name;
            Cart = new Cart(this);
            Mail = mail;
            Phone = phoneNumber;
            Fax = faxNumber;
            BirthDate = birthDate;
            Address = address;
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
        }

        private void Validar()
        {
        }
    }
}
