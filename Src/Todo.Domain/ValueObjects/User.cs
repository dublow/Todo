using System;
using System.Linq;
using Todo.Domain.Utils;

namespace Todo.Domain.ValueObjects
{
    public sealed class User : ValueObject<User>
    {
        public static User Create(string name) =>
            new User(name);

        public string Name { get; }

        private User(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name.Capitalize();
        }

        public override bool EqualsCore(User other)
        {
            return Name == other.Name;
        }

        public override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
