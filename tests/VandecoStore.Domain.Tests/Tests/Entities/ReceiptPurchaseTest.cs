using Moq;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.ObjectValues;

namespace VandecoStore.Domain.Tests.Tests.Entities
{
    public class ReceiptPurchaseTest
    {
        [Fact]
        public void ReceiptPurchase_Validate_ThrowsException()
        {
            //Arrange 
            var document = new Document("documentNumber");
            new ReceiptPurchase
            {
                Approved = true,
                ApprovedBy = "Edson",
                Code = string.Empty,
                Order = new Mock<Order>().Object,
                Value = 100m,
            };

            var ex = Assert.Throws<DomainException>(() => new ReceiptPurchase
            {
                Approved = true,
                ApprovedBy = "Edson",
                Code = string.Empty,
                Order = new Mock<Order>().Object,
                Value = 100m,
            }
            );
            Assert.Equal("The Field Code Must Be Provided !", ex.Message);

            ex = Assert.Throws<DomainException>(() => new ReceiptPurchase
            {
                Approved = true,
                ApprovedBy = string.Empty,
                Code = "5181561848945158",
                Order = new Mock<Order>().Object,
                Value = 100m,
            }
            );
            Assert.Equal("The Field ApprovedBy Must Be Provided !", ex.Message);

            ex = Assert.Throws<DomainException>(() => new ReceiptPurchase
            {
                Approved = true,
                ApprovedBy = "Edson",
                Code = "5181561848945158",
                Order = new Mock<Order>().Object,
                Value = 0,
            }
           );
            Assert.Equal("The Field Value Must Be Greather Than 0 !", ex.Message);
        }
    }
}
