using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class UserDb : Entity
    {
        public required string Name { get; init; }
        public required string DocumentNumber { get; init; }
        public required string MailAddress { get; init; }
        public required string Phone { get; init; }
        public required string Fax { get; init; }
        public required DateTime BirthDate { get; init; }
        //EF Relations
        public required List<AddressDb> Addresses { get; init; }
        public required CartDb Cart { get; init; }
        public required List<OrderDb> Orders { get; init; }
        public required List<CommentDb> Comments { get; init; }
        public required List<TokenDb> Tokens { get; init; }

        public UserDb() { }

        public User ToUser()
        {
            return new User
            {
                Addresses = Addresses.Select(p => p.ToAddress()).ToList(),
                BirthDate = BirthDate,
                Cart = Cart.ToCart(),
                Comments = Comments.Select(p => p.ToComment()).ToList(),
                Document = DocumentNumber,
                Mail = MailAddress,
                Phone = Phone,
                Name = Name,
                Orders = Orders.Select(p => p.ToOrder()).ToList(),
                Id = Id,
                Fax = Fax,
            };
        }
    }
}
