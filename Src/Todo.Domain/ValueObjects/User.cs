using System;
using System.Linq;

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

            Name = CapitalizeName(name);
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

        private string CapitalizeName(string value)
        {
            return new String(value.Select((c, index) => {
                return index == 0
                    ? Char.ToUpper(c)
                    : Char.ToLower(c);
            }).ToArray());
        }
    }
}
