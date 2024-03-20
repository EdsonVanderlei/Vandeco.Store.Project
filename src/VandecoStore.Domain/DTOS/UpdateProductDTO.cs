using System.ComponentModel.DataAnnotations;

namespace VandecoStore.Domain.DTOS
{
    public record class UpdateProductDTO
    {
        [Required(ErrorMessage ="The Field {0} Must Be Provided !")]
        [StringLength(200,ErrorMessage = "The ")]
        public string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "The Field {0} Must Be Greather Than {2}")]
        public decimal Price { get; set; }
    }
}
