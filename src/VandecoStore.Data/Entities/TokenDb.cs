using VandecoStore.Core;
using VandecoStore.Domain.Entities;
using VandecoStore.Domain.Enum;

namespace VandecoStore.Data.Entities
{
    public class TokenDb : Entity
    {
        public required Guid UserId { get; init; }
        public required string TokenCode { get; init; }
        public required DateTime Expiration { get; init; }
        public required UserDb User { get; set; }
        public required ChannelTokenEnum ChannelToken { get; init; }

        public Token ToToken()
        {
            return new Token
            {
                ChannelToken = ChannelToken,
                Expiration = Expiration,
                TokenCode = TokenCode,
                User = User.ToUser(),
            };
        }
    }
}
