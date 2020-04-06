using System;
using Eintech.Data.Entities;
using Eintech.Services.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Eintech.Services.Tests.Extensions
{
    [TestFixture]
    public class UserGroupEntityExtensionsShould
    {
        [Test]
        public void ToGroupModel_ShouldReturnFullyPopulatedModel()
        {
            var expectedDate = new DateTime(2020, 1, 1, 1, 1, 1);

            var entity = new UserGroup
                         {
                             Id = 3,
                             Group = new Group
                                     { 
                                         Id  =1,
                                         Name = "a",
                                         DateAdded = expectedDate
                                     },
                             User = new User() 
                         };

            var model = entity.ToGroupModel();

            model.Id.Should().Be(1);
            model.Name.Should().Be("a");
            model.DateAdded.Should().Be(expectedDate);
        }
    }
}
