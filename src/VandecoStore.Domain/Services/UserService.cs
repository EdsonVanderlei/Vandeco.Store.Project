using VandecoStore.Domain.DTOS;

namespace VandecoStore.Domain.Services
{
    public class OnBoardingService : IOnBoardingService
    {
        public OnBoardingService()
        {

        }

        public async Task RegisterUser(UserRegisterDTO userRegisterDTO)
        {
        }

        public async Task VerifyDocument()
        {

        }

    }

    public interface IOnBoardingService
    {
        Task VerifyDocument();
        Task RegisterUser(UserRegisterDTO userRegisterDTO);
    }
}
