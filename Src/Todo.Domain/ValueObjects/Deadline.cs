using System;

namespace Todo.Domain.ValueObjects
{
    public sealed class Deadline : ValueObject<Deadline>
    {
        private readonly DateTime _value;

        public Deadline(DateTime value)
        {
            _value = value;
        }

        public override bool EqualsCore(Deadline other)
        {
            return _value == other._value;
        }

        public override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }
    }
}
