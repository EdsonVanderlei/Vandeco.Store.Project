using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Exceptions;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Domain.Services
{
    public class CartService : ICartService
    {
        public required IUserRepository _userRepository { private get; init; }
        public required IProductRepository _productRepository { private get; init; }

        public async Task GetCartItems(Guid userId)
        {
            return 
        }

        public async Task UpdateCartItems(List<CartItemDTO> cartItemsDTO, Guid userId)
        {
            var userWithCart = await _userRepository.GetUserWithCart(userId) ?? throw new DomainException("User Not Found !");
            foreach (var item in cartItemsDTO)
            {
                var productFromId = await _productRepository.GetById(item.ItemId) ?? throw new DomainException($"Item {item.ItemId} Not Found !");
                userWithCart.Cart.UpdateCartItems(productFromId, item.Quantiy);
            }

            await _userRepository.SaveChanges();
        }

        public async Task<List<CartItem>> GetCartItemsFromUser(Guid userId)
        {
            var user = await _userRepository.GetById(userId) ?? throw new DomainException("User Not Found !");
            return user.Cart.CartItems;
        }

        public async Task ClearCart(Guid userId)
        {
            var userWithCart = await _userRepository.GetUserWithCart(userId) ?? throw new DomainException("User Not Found !");
            userWithCart.Cart.ClearCart();
            await _userRepository.SaveChanges();
        }
    }

    public interface ICartService
    {
    }
}
