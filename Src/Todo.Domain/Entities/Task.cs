using System;
using Todo.Domain.Utils;
using Todo.Domain.ValueObjects;

namespace Todo.Domain.Entities
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public Deadline Deadline { get; set; }

        public Task(string title, User user, Category category, Deadline deadline)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));

            Title = title.Capitalize();
            User = user;
            Category = category;
            Deadline = deadline;
        }

        public override string ToString()
        {
            return $"[{User}] {Category}|{Title} => {Deadline}";
        }
    }
}
