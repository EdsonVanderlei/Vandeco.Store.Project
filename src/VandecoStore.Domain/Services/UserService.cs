using VandecoStore.Domain.DTOS;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Domain.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var userExists = await _userRepository.ExistsWithSameDocument(userRegisterDTO.Document);
            if (userExists) throw new Exception("User Already Exists !");
            var user = userRegisterDTO.ToUser();
            await _userRepository.Add(user);
        }

        public async Task DeleteUser(Guid userId)
        {
            var user = await _userRepository.GetById(userId) ?? throw new Exception("User Not Found !");
            if (user.HasDeliveryOrder()) throw new Exception("Open Orders, Cannot Delete The User !");
            await _userRepository.Remove(userId);
        }
    }

    public interface IUserService
    {
        Task RegisterUser(UserRegisterDTO userRegisterDTO);
        Task DeleteUser(Guid userId);
    }
}
