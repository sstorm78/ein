using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eintech.Services;
using Eintech.Website.Controllers.Api;
using Eintech.Website.UiModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Eintech.Website.Tests.Controllers.Api
{
    [TestFixture]
    public class UsersControllerShould
    {
        private UsersController _usersController;
        private Mock<IUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _usersController = new UsersController(_userServiceMock.Object);
        }

        [Test]
        public async Task Create_ShouldReturnCreatedStatus()
        {
            _userServiceMock.Setup(i => i.Create(It.IsAny<Models.User>())).ReturnsAsync(1);

            var result = await _usersController.Create(new User
                                                       {
                                                           FirstName = "a",
                                                           LastName = "b",
                                                           Groups = new List<Group>
                                                                    {
                                                                        new Group
                                                                        {
                                                                            Id = 1
                                                                        }
                                                                    }
                                                       });

            result.Should().BeOfType<ActionResult<int>>();
            result.Result.Should().BeOfType<CreatedResult>();
            (result.Result as CreatedResult).Value.Should().Be(1);
        }

        [Test]
        public async Task Create_ShouldReturnInternalServerErrorWhenAnExceptionOccured()
        {
            _userServiceMock.Setup(i => i.Create(It.IsAny<Models.User>())).ThrowsAsync(new Exception());

            var result = await _usersController.Create(new User
                                                       {
                                                           LastName = "b",
                                                           Groups = new List<Group>
                                                                    {
                                                                        new Group
                                                                        {
                                                                            Id = 1
                                                                        }
                                                                    }
                                                       });

            result.Should().BeOfType<ActionResult<int>>();
            result.Result.Should().BeOfType<StatusCodeResult>();
            (result.Result as StatusCodeResult).StatusCode.Should().Be(500);
        }

        [Test]
        public async Task Create_ShouldReturnBadRequestWhenARequiredParamIsMissing()
        {
            _userServiceMock.Setup(i => i.Create(It.IsAny<Models.User>())).ReturnsAsync(1);

            _usersController.ModelState.AddModelError("FirstName", "Required");

            var result = await _usersController.Create(new User
                                                       {
                                                           LastName = "b",
                                                           Groups = new List<Group>
                                                                    {
                                                                        new Group
                                                                        {
                                                                            Id = 1
                                                                        }
                                                                    }
                                                       });

            result.Should().BeOfType<ActionResult<int>>();
            result.Result.Should().BeOfType<BadRequestObjectResult>();

            var details = (ObjectResult) result.Result;

            ((SerializableError)details.Value).First().Key.Should().Be("FirstName");

            var errorMessages = ((SerializableError) details.Value).First().Value;

            ((string[])errorMessages).First().Should().Be("Required");
        }

        [Test]
        public async Task Search_ShouldReturnTwoUsers()
        {
            var expectedResult = new List<Models.User>();
            expectedResult.Add(new Models.User("a","b",new List<Models.Group>()));
            expectedResult.Add(new Models.User("c", "d", new List<Models.Group>()));

            _userServiceMock.Setup(i => i.Search(It.IsAny<string>())).ReturnsAsync(expectedResult);

            var result = await _usersController.Search("test");

            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Result.Should().BeOfType<OkObjectResult>();
            var data = result.Result as OkObjectResult;

            (data.Value as List<User>).First().FirstName.Should().Be("a");
            (data.Value as List<User>).Last().FirstName.Should().Be("c");
        }

        [Test]
        public async Task Search_ShouldReturnInternalServerErrorWhenAnExceptionOccured()
        {
            _userServiceMock.Setup(i => i.Search(It.IsAny<string>())).ThrowsAsync(new Exception());

            var result = await _usersController.Search("test");

            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Result.Should().BeOfType<StatusCodeResult>();
            (result.Result as StatusCodeResult).StatusCode.Should().Be(500);
        }

        [Test]
        public async Task Search_ShouldReturnBadRequestWhenNoKeyWordWasProvided()
        {
            _userServiceMock.Setup(i => i.Search(It.IsAny<string>())).ThrowsAsync(new Exception());

            var result = await _usersController.Search("");

            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Result.Should().BeOfType<BadRequestObjectResult>();
            ((ObjectResult) result.Result).Value.Should().Be("keyword parameter is required");
        }

    }
}