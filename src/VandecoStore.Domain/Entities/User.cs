using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public Document Document { get; set; }
        public Mail Mail { get; private set; }   
        public Phone PhoneNumber { get; private set; }
        public Phone? FaxNumber { get; private set; }
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
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
            BirthDate = birthDate;
            Address = address;
            Document = document;
            Orders = [];

            Validate();
        }

        public bool HasFaxPhone()
        {
            return PhoneNumber is not null;
        }

        public void ChangeNumber(Phone phoneNumber)
        {
            PhoneNumber.UpdatePhone(phoneNumber);
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "The Field PhoneNumber Mus be Provided !");
            AssertionConcern.AssertArgumentNotNull(PhoneNumber, "The Field PhoneNumber Mus be Provided !"); 
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
