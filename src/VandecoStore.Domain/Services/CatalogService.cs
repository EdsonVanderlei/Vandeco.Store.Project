using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Domain.Services
{
    public class CatalogService : ICatalogService
    {
        public required IBrandRepository _brandRepository { private get; init; }
        public required IProductRepository _productRepository { private get; init; }

        public async Task AddProductToCatalog(ProductRegisterDTO productRegisterDTO)
        {
            var brand = await _brandRepository.GetById(productRegisterDTO.BrandId) ?? throw new DomainException("Brand Not Found !");

            var product = new Product
            {
                Category = productRegisterDTO.CategoryEnum,
                Name = productRegisterDTO.Name,
                Quantity = productRegisterDTO.Quantity,
                Price = productRegisterDTO.Price,
                Description = productRegisterDTO.Description,
                Brand = brand
            };

            await _productRepository.Add(product);
        }

        public async Task DesactivateProduct(Guid productId)
        {
            var product = await GetProductAndValidate(productId);
            product.ActivateProduct();
            await _productRepository.Update(product);
        }

        public async Task ActivateProduct(Guid productId)
        {
            var product = await GetProductAndValidate(productId);
            product.DesactivateProduct();
            await _productRepository.Update(product);
        }

        public async Task UpdateProductProperties(Guid productId, UpdateProductDTO updateProductDTO)
        {
            var product = await GetProductAndValidate(productId);
            product.ChangeDescription(updateProductDTO.Description);
            product.UpdatePrice(updateProductDTO.Price);
            await _productRepository.Update(product);
        }

        private async Task<Product> GetProductAndValidate(Guid productId)
        {
            return await _productRepository.GetById(productId) ?? throw new DomainException("Product Not Found !");
        }
    }

    public interface ICatalogService
    {
    }
}
