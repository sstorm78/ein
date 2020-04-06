using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eintech.Data;
using Eintech.Data.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Group = Eintech.Models.Group;
using User = Eintech.Models.User;

namespace Eintech.Services.Tests
{
    [TestFixture]
    public class UserServiceShould
    {
        [Test]
        public async Task Create_ShouldCallRepositoryCreateOnce()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userGroupServiceMock = new Mock<IUserGroupService>();

            userRepositoryMock.Setup(i => i.Create(It.IsAny<Data.Entities.User>())).ReturnsAsync(1);

            var sut = new UserService(userRepositoryMock.Object, userGroupServiceMock.Object);

            var result = await sut.Create(new User("a", "b", new List<Group>()));

            userRepositoryMock.Verify(
                i => i.Create(It.Is<Data.Entities.User>(p => p.FirstName == "a" && p.LastName == "b")), Times.Once);

            result.Should().Be(1);
        }

        [Test]
        public async Task Create_ShouldCallUserGroupServiceAssociateUserToGroupTwice()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userGroupServiceMock = new Mock<IUserGroupService>();

            userRepositoryMock.Setup(i => i.Create(It.IsAny<Data.Entities.User>())).ReturnsAsync(1);

            var sut = new UserService(userRepositoryMock.Object, userGroupServiceMock.Object);

            var result = await sut.Create(new User("a", "b", new List<Group>
                                                             {
                                                                 new Group(1, "a"),
                                                                 new Group(2,"b")
                                                             }));

            userGroupServiceMock.Verify(i => i.AssociateUserToGroup(It.Is<UserGroup>(p => p.GroupId == 1 && p.UserId == 1)), Times.Once);
            userGroupServiceMock.Verify(i => i.AssociateUserToGroup(It.Is<UserGroup>(p => p.GroupId == 2 && p.UserId == 1)), Times.Once);

            result.Should().Be(1);
        }

        [Test]
        public async Task Search_ShouldReturnAListOfTwoUsers()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userGroupServiceMock = new Mock<IUserGroupService>();

            var expectedResult = new List<Data.Entities.User>();
            expectedResult.Add(new Data.Entities.User
                               {
                                   Id = 1,
                                   FirstName = "a",
                                   LastName = "b",
                                   UserGroups = new List<UserGroup>
                                                {
                                                    new UserGroup
                                                    {
                                                        Group=new Data.Entities.Group
                                                              {
                                                                  Id = 1,
                                                                  Name ="r"
                                                              }
                                                    },
                                                    new UserGroup
                                                    {
                                                        Group=new Data.Entities.Group
                                                              {
                                                                  Id = 3,
                                                                  Name ="t"
                                                              }
                                                    }
                                                }
                               });

            expectedResult.Add(new Data.Entities.User
                               {
                                   Id = 2,
                                   FirstName = "c",
                                   LastName = "d",
                                   UserGroups = new List<UserGroup>
                                                {
                                                    new UserGroup
                                                    {
                                                        Group=new Data.Entities.Group
                                                              {
                                                                  Id = 1,
                                                                  Name ="r"
                                                              }
                                                    },
                                                    new UserGroup
                                                    {
                                                        Group=new Data.Entities.Group
                                                              {
                                                                  Id = 3,
                                                                  Name ="t"
                                                              }
                                                    }
                                                }
                               });
            userRepositoryMock.Setup(i => i.Search(It.IsAny<string>())).ReturnsAsync(expectedResult);

            var sut = new UserService(userRepositoryMock.Object, userGroupServiceMock.Object);

            var result = await sut.Search("test");

            result.Count.Should().Be(2);
            result.First().FirstName.Should().Be("a");
            result.Last().FirstName.Should().Be("c");
        }
    }
}
