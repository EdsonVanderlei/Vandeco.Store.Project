

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class UserExtension
    {
        public static UserDb ToUserDb(this User user)
        {
            return new UserDb
            {
                Addresses = user.Addresses.Select(p => p.ToAddressDb()).ToList(),
                BirthDate = user.BirthDate,
                Cart = user.Cart.ToCartDb(),
                Comments = user.Comments.Select(p => p.ToCommentDb()).ToList(),
                DocumentNumber = user.Document,
                Fax = user.Fax,
                MailAddress = user.Mail,
                Name = user.Name,
                Orders = user.Orders.Select(p => p.ToOrderDb()).ToList(),
                Phone = user.Phone,
                Id = user.Id,
            };
        }
    }
}
