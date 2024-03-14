using Moq;
using VandecoStore.Domain.Entities;
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

            var ex = Assert.Throws<InvalidOperationException>(() => new ReceiptPurchase(string.Empty, false, "Edson", 100m, document, new Mock<Order>().Object));
            Assert.Equal("The Field Code Must Be Provided !", ex.Message);

            ex = Assert.Throws<InvalidOperationException>(() => new ReceiptPurchase("code", false, string.Empty, 100m, document, new Mock<Order>().Object));
            Assert.Equal("The Field ApprovedBy Must Be Provided !", ex.Message);

            ex = Assert.Throws<InvalidOperationException>(() => new ReceiptPurchase("code", false, "Edson", 0, document, new Mock<Order>().Object));
            Assert.Equal("The Field Value Must Be Greather Than 0 !", ex.Message);
        }
    }
}
