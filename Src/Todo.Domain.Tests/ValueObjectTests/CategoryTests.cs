using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.ValueObjects;

namespace Todo.Domain.Tests.ValueObjectTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void ShouldBeNotEqualWhenCategoryIsNull()
        {
            // arrange
            Category Category = null;
            Category otherCategory = Category.Create("nicolas");

            // act
            var actual = otherCategory.Equals(Category);

            // assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenCategoryHasSameReference()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category;

            // act
            var actual = Category.Equals(otherCategory);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualWhenCategoryHasSameValue()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category.Create("nicolas");

            // act
            var actual = Category.Equals(otherCategory);

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenCategoryHasSameReference()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category;

            // act
            var actual = Category == otherCategory;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenCategoryHasSameValue()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category.Create("nicolas");

            // act
            var actual = Category == otherCategory;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeEqualByOperatorWhenCategoryHasSameHashcode()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category.Create("nicolas");

            // act
            var actual = Category.GetHashCode() == otherCategory.GetHashCode();

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeNotEqualByOperatorWhenCategoryHasDifferentValue()
        {
            // arrange
            Category Category = Category.Create("nicolas");
            Category otherCategory = Category.Create("jean");

            // act
            var actual = Category != otherCategory;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldThrownArgumentNullExceptionWhenNameIsEmpty()
        {
            // assert
            Assert.ThrowsException<ArgumentNullException>(() => Category.Create(string.Empty));
        }

        [TestMethod]
        public void ShouldCapitalizeName()
        {
            // arrange
            var name = "NICOLAS";

            // act
            var actual = Category.Create(name);

            // assert
            Assert.AreEqual("Nicolas", actual.Name);
        }
    }
}
