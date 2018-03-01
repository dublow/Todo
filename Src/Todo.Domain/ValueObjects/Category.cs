using System;
using Todo.Domain.Utils;

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

            Name = name.Capitalize();
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
    }
}
