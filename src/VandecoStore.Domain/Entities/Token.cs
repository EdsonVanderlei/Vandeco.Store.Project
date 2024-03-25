using VandecoStore.Domain.Enum;

namespace VandecoStore.Domain.Entities
{
    public class Token : EntityValidation
    {
        private string _tokenCode;
        public required string TokenCode
        {
            get => _tokenCode;
            init
            {
                FailIfNullOrEmpty(value, nameof(TokenCode));
                _tokenCode = value;
            }
        }
        public required DateTime Expiration { get; init; }
        public required User User { get; set; }
        public required ChannelTokenEnum ChannelToken { get; init; }

        public Token()
        {
        }
    }
}
