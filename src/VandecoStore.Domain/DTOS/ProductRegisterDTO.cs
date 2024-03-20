using System.ComponentModel.DataAnnotations;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Domain.DTOS
{
    public record class ProductRegisterDTO
    {
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        [Range(0.01,double.MaxValue,ErrorMessage = "The Field {0} Must Be Greather Than {2}")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        [StringLength(200,ErrorMessage = "The Length of {0} Must Be Between {2} e {1}")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        [EnumDataType(typeof(CategoryEnum))]
        public CategoryEnum CategoryEnum { get; set; }
        [Required(ErrorMessage = "The Field {0} Must Be Provided !")]
        public Guid BrandId { get; set; }
    }
}
