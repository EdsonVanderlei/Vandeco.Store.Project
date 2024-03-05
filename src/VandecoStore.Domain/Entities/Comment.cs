using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Comment : Entity
    {
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        //EF Relation 
        public Product Product { get; private set; }
        public User User { get; private set; }

        public Comment(Guid productId, string title, string text, Product product, User user)
        {
            ProductId = productId;
            Title = title;
            Text = text;
            Product = product;
            User = user;
            ProductId = product.Id;
            UserId = user.Id;
            Validate();
        }

        protected Comment() { }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Title, "The Field Title Must be provided!");
            AssertionConcern.AssertArgumentNotEmpty(Text, "The Field Text Must be provided!");
        }
    }
}
