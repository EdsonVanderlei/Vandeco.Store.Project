using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class CommentDb : Entity
    {
        public required Guid UserId { get; init; }
        public required Guid ProductId { get; init; }
        public required string Title { get; init; }
        public required string Text { get; init; }

        //EF Relation 
        public required ProductDb Product { get; init; }
        public required UserDb User { get; init; }

        public CommentDb() { }

        public Comment ToComment()
        {
            return new Comment
            {
                Id = Id,
                Product = Product.ToProduct(),
                Text = Text,
                Title = Title,
                User = User.ToUser(),
            };
        }
    }
}
