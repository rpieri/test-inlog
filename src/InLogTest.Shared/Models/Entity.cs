using Flunt.Notifications;
using System;

namespace InLogTest.Shared.Models
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public bool Deleted { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }


        public void Delete() => Deleted = true;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (ReferenceEquals(null, compareTo))
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 987) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id = { Id }]";
    }
}
