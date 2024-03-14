namespace VandecoStore.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            var entity = obj as Entity;

            if(ReferenceEquals(entity,this)) return true;
            if(entity is null) return false;
            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return  (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if(ReferenceEquals(a,null) && ReferenceEquals(b,null)) return true;

            if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }


    }
}
