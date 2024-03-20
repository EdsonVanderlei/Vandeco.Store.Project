using System.ComponentModel.DataAnnotations;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.DTOS
{
    public record class UserRegisterDTO
    {
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        [StringLength(100,ErrorMessage = "The Field {0} Must Be Greather Than {2} and Less Than {1}", MinimumLength = 5)]
        public string Name { get; init; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Document Document { get; init; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Mail Mail { get;  init; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Phone Phone { get; init; }
        public Phone? Fax { get; init; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public DateTime BirthDate { get; init; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public List<Address> Address { get; init; }

        public User ToUser()
        {
            var user =  new User
            {
                BirthDate = BirthDate,
                Document = Document,
                Mail = Mail,
                Name = Name,
                Phone = Phone,
                Fax = Fax,
            };
            user.Addresses.AddRange(Address);
            return user;
        }
    }
}
