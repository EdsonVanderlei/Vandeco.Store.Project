using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class TokenExtension
    {
        public static TokenDb ToTokenDb(this Token token)
        {
            return new TokenDb
            {
                ChannelToken = token.ChannelToken,
                Expiration = token.Expiration,
                TokenCode = token.TokenCode,
                User = token.User.ToUserDb(),
                UserId = token.User.Id, 
            };
        }
    }
}
