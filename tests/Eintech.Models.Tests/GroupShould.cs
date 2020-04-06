using System;
using Eintech.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorIdName_ShouldReturnProperlyPopulatedInstance()
        {
            var result = new Group(1, "storm");

            result.Id.Should().Be(1);
            result.Name.Should().Be("storm");
        }

        [Test]
        public void ConstructorIdNameDateAdded_ShouldReturnProperlyPopulatedInstance()
        {
            var expectedDate = new DateTime(2020, 1, 1, 1, 1, 1);

            var result = new Group(1, "storm", expectedDate);

            result.Id.Should().Be(1);
            result.Name.Should().Be("storm");
            result.DateAdded.Should().Be(expectedDate);
        }
    }
}