using System.Collections.Generic;
using Eintech.Services.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Eintech.Services.Tests.Extensions
{
    [TestFixture]
    public class UserModelExtensionsShould
    {
        [Test]
        public void ToGroupModel_ShouldReturnFullyPopulatedModel()
        {
            var model = new Models.User("a", "b", new List<Models.Group>());

            var entity = model.ToEntity();

            entity.FirstName.Should().Be("a");
            entity.LastName.Should().Be("b");
        }
    }
}
