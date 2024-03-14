using VandecoStore.Core;
using VandecoStore.Domain.Entities;

namespace VandecoStore.Data.Entities
{
    public class CommentDb : Entity
    {
        public required Guid UserId { get; init; }
        public required Guid ProductId { get; init; }
        public string Title { get; init; }
        public string Text { get; init; }

        //EF Relation 
        public required ProductDb Product { get; init; }
        public required UserDb User { get; init; }

        public CommentDb() { }

        public Comment ToComment()
        {

        }
    }
}
