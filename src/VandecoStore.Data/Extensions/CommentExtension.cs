

using VandecoStore.Data.Entities;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Extensions
{
    public static class CommentExtension
    {
        public static CommentDb ToCommentDb(this Comment comment)
        {
            return new CommentDb
            {
                Product = comment.Product.ToProductDb(),
                ProductId = comment.Product.Id,
                Text = comment.Text,
                Title = comment.Title,
                User = comment.User.ToUserDb(),
                UserId = comment.User.Id,
                Id = comment.Id
            };
        }
    }
}
