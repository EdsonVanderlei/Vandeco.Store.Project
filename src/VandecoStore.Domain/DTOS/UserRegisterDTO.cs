using System.ComponentModel.DataAnnotations;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.DTOS
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        [StringLength(100,ErrorMessage = "The Field {0} Must Be Greather Than {2} and Less Than {1}", MinimumLength = 5)]
        public string Name { get; private set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Document Document { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Mail Mail { get; private set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Phone Phone { get; private set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Phone? Fax { get; private set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public DateTime BirthDate { get; private set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public List<Address?> Address { get; private set; }
    }
}
