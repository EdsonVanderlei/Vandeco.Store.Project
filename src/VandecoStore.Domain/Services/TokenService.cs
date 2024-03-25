using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;
using VandecoStore.Domain.Interfaces;

namespace VandecoStore.Domain.Services
{
    public class TokenService : ITokenService
    {
        readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<Token> GenerateToken(User user, ChannelTokenEnum channelToken)
        {
            var tokenGenerated = BuildToken(user, channelToken);
            await _tokenRepository.Add(tokenGenerated);
            return tokenGenerated;
        }

        private Token BuildToken(User user, ChannelTokenEnum channelToken)
        {
            var random = new Random();
            var tokenGenerated = random.Next(000000, 999999).ToString();
            return new Token
            {
                User = user,
                ChannelToken = ChannelTokenEnum.MAIL,
                Expiration = DateTime.Now,
                TokenCode = tokenGenerated,
            };
        }
    }

    public interface ITokenService
    {
        Task<Token> GenerateToken(User user, ChannelTokenEnum channelToken);
    }
}
