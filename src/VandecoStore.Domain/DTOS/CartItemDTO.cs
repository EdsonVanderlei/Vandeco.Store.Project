using System.ComponentModel.DataAnnotations;

namespace VandecoStore.Domain.DTOS
{
    public record class CartItemDTO
    {
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Guid ItemId { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public int Quantiy { get; set; }
    }
}
