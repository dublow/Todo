using System;

namespace Todo.Domain.ValueObjects
{
    public sealed class Deadline : ValueObject<Deadline>
    {
        private readonly DateTime _deadline;

        public Deadline(DateTime deadline)
        {
            if (deadline == DateTime.MinValue)
                throw new ArgumentNullException(nameof(deadline));

            _deadline = deadline;
        }



        public override bool EqualsCore(Deadline other)
        {
            return _deadline == other._deadline;
        }

        public override int GetHashCodeCore()
        {
            return _deadline.GetHashCode();
        }

        public bool IsExpired(DateTime currentDate)
        {
            return _deadline <= currentDate;
        }
    }
}
