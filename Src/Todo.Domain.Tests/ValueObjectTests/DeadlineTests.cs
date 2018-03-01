using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.ValueObjects;

namespace Todo.Domain.Tests.ValueObjectTests
{
    [TestClass]
    public class DeadlineTests
    {
        [TestMethod]
        public void ShouldBeNotEqualWhenDeadlineIsNull()
        {
            // arrange
            Deadline deadline = null;
            Deadline otherDeadline = Deadline.Create(DateTime.MinValue.AddDays(1));

            // act
            var actual = otherDeadline.Equals(deadline);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenDeadlineHasSameReference()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = deadline;

            // act
            var actual = deadline.Equals(otherDeadline);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenDeadlineHasSameValue()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = Deadline.Create(DateTime.MinValue.AddDays(1));

            // act
            var actual = deadline.Equals(otherDeadline);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenDeadlineHasSameValue()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = Deadline.Create(DateTime.MinValue.AddDays(1));

            // act
            var actual = deadline == otherDeadline;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenDeadlineHasSameReference()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = deadline;

            // act
            var actual = deadline == otherDeadline;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenDeadlineHasSameHashcode()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = deadline;

            // act
            var actual = deadline.GetHashCode() == otherDeadline.GetHashCode();

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeNotEqualByOperatorWhenDeadlineHasDifferentValue()
        {
            // arrange
            Deadline deadline = Deadline.Create(DateTime.MinValue.AddDays(1));
            Deadline otherDeadline = Deadline.Create(DateTime.MaxValue);

            // act
            var actual = deadline != otherDeadline;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldThrownArgumentNullExceptionWhenDeadlineIsMinDate()
        {
            // assert
            Assert
                .ThrowsException<ArgumentNullException>(
                    () => Deadline.Create(DateTime.MinValue));
        }

        [TestMethod]
        public void ShouldNotBeExpiredWhenDeadlineIsGreaterThanArgumentDate()
        {
            // arrange
            DateTime currentDate = new DateTime(2018, 08, 01);
            Deadline deadline = Deadline.Create(new DateTime(2018, 10, 01));

            // act
            var actual = deadline.IsExpired(currentDate);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldBeExpiredWhenDeadlineIsEqualToArgumentDate()
        {
            // arrange
            DateTime currentDate = new DateTime(2018, 08, 01);
            Deadline deadline = Deadline.Create(new DateTime(2018, 08, 01));

            // act
            var actual = deadline.IsExpired(currentDate);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeExpiredWhenDeadlineIsLessThanArgumentDate()
        {
            // arrange
            DateTime currentDate = new DateTime(2018, 08, 01);
            Deadline deadline = Deadline.Create(new DateTime(2018, 06, 01));

            // act
            var actual = deadline.IsExpired(currentDate);

            // assert
            Assert.IsTrue(actual);
        }
    }
}
