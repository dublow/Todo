using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.ValueObjects;

namespace Todo.Domain.Tests.ValueObjectTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void ShouldBeNotEqualWhenUserIsNull()
        {
            // arrange
            User user = null;
            User otherUser = User.Create("nicolas");

            // act
            var actual = otherUser.Equals(user);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenUserHasSameReference()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = user;

            // act
            var actual = user.Equals(otherUser);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenUserHasSameValue()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = User.Create("nicolas");

            // act
            var actual = user.Equals(otherUser);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenUserHasSameReference()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = user;

            // act
            var actual = user == otherUser;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenUserHasSameValue()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = User.Create("nicolas");

            // act
            var actual = user == otherUser;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenUserHasSameHashcode()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = User.Create("nicolas");

            // act
            var actual = user.GetHashCode() == otherUser.GetHashCode();

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeNotEqualByOperatorWhenUserHasDifferentValue()
        {
            // arrange
            User user = User.Create("nicolas");
            User otherUser = User.Create("jean");

            // act
            var actual = user != otherUser;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldThrownArgumentNullExceptionWhenNameIsEmpty()
        {
            // assert
            Assert.ThrowsException<ArgumentNullException>(() => User.Create(string.Empty));
        }

        [TestMethod]
        public void ShouldCapitalizeName()
        {
            // arrange
            var name = "NICOLAS";

            // act
            var actual = User.Create(name);

            // assert
            Assert.AreEqual("Nicolas", actual.Name);
        }
    }
}
