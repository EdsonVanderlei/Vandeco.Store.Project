using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Domain.Services
{
    public class StockService : IStockService
    {
        public required IProductRepository _productRepository { private get; init; }

        public async Task DebitStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId) ?? throw new DomainException("Product Not Found !");
            product.RemoveQuantity(quantity);
            await _productRepository.Update(product);
        }

        public async Task CreditStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId) ?? throw new DomainException("Product Not Found !");
            product.AddQuantity(quantity);
            await _productRepository.Update(product);
        }
    }

    public interface IStockService
    {
        Task DebitStock(Guid productId, int quantity);
        Task CreditStock(Guid productId, int quantity);
    }
}
