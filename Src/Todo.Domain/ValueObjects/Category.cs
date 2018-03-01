using System;
using System.Linq;

namespace Todo.Domain.ValueObjects
{
    public sealed class Category : ValueObject<Category>
    {
        public static Category Create(string name) =>
            new Category(name);

        public string Name { get; }

        private Category(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = CapitalizeName(name);
        }

        public override bool EqualsCore(Category other)
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
