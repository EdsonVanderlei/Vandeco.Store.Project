using System.ComponentModel.DataAnnotations;

namespace VandecoStore.Domain.DTOS
{
    public class CartItemDTO
    {
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Guid ItemId { get; set; }
        public int Quantiy { get; set; }
    }
}
