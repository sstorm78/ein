using System;
using System.Collections.Generic;
using Eintech.Data.Entities;
using Eintech.Services.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Eintech.Services.Tests.Extensions
{
    public class UserEntityExtensionsShould
    {
        [Test]
        public void ToModel_ShouldReturnFullyPopulatedModel()
        {
            var expectedDate = new DateTime(2020, 1, 1, 1, 1, 1);

            var entity = new Data.Entities.User
                         {
                             Id = 1,
                             FirstName = "a",
                             LastName = "b",
                             DateAdded = expectedDate,
                             UserGroups = new List<UserGroup>
                                          {
                                              new UserGroup
                                              {
                                                  Group = new Group()
                                              }
                                          }
                         };

            var model = entity.ToModel();

            model.Id.Should().Be(1);
            model.FirstName.Should().Be("a");
            model.LastName.Should().Be("b");
            model.DateAdded.Should().Be(expectedDate);
            model.Groups.Count.Should().Be(1);
        }
    }
}