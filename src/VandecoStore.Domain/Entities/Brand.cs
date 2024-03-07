using VandecoStore.Core;
using VandecoStore.Domain.Support;

namespace VandecoStore.Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        //EF Relation 
        public List<Product> Products { get; private set; } = [];

        public Brand(string name, string description)
        {
            Name = name;
            Description = description;
            Validate();
        }

        protected Brand() { }

        private void Validate()
        {
            AssertionConcern.AssertArgumentNotEmpty(Name, "The Field Name Must Be Provided !");
            AssertionConcern.AssertArgumentNotEmpty(Description, "The Field Description Must Be Provided !");
        }
    }
}
