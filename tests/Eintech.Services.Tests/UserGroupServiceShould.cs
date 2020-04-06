using Eintech.Data.Entities;
using Eintech.Data.Repositories;
using Moq;
using NUnit.Framework;

namespace Eintech.Services.Tests
{
    [TestFixture]
    public class UserGroupServiceShould
    {
        [Test]
        public void AssociateUserToGroup_ShouldCallRepositoryCreateOnce()
        {
            var userGroupRepositoryMock = new Mock<IUserGroupRepository>();

            var sut = new UserGroupService(userGroupRepositoryMock.Object);

            sut.AssociateUserToGroup(new UserGroup
                                     {
                                         GroupId = 1,
                                         UserId = 2
                                     });

            userGroupRepositoryMock.Verify(i => i.Create(It.Is<UserGroup>(p => p.UserId == 2 && p.GroupId == 1)), Times.Once);
        }
    }
}
