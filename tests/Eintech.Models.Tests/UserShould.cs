using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Eintech.Models.Tests
{
    [TestFixture]
    public class UserShould
    {
        [Test]
        public void ConstructorFirstNameLastNameGroups_shouldReturnProperlyPopulatedInstance()
        {
            var result = new User("sergey","storm", new List<Group>
                                                    {
                                                        new Group(1,"a"),
                                                        new Group(2,"b")
                                                    } );

            result.FirstName.Should().Be("sergey");
            result.LastName.Should().Be("storm");
            result.Groups.Count.Should().Be(2);
        }

        [Test]
        public void ConstructorIdFirstNameLastNameDateAddedGroups_shouldReturnProperlyPopulatedInstance()
        {
            var expectedDate = new DateTime(2020, 1, 1, 1, 1, 1);

            var result = new User(1,"sergey", "storm", expectedDate, new List<Group>
                                                                     {
                                                                         new Group(1,"a"),
                                                                         new Group(2,"b")
                                                                     });

            result.Id.Should().Be(1);
            result.FirstName.Should().Be("sergey");
            result.LastName.Should().Be("storm");
            result.DateAdded.Should().Be(expectedDate);
            result.Groups.Count.Should().Be(2);
        }


    }
}
