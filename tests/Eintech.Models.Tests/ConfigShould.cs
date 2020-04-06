using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace Eintech.Models.Tests
{
    [TestFixture]
    public class ConfigShould
    {
        private Mock<IConfigurationRoot> _configurationRootMock;

        [SetUp]
        public void Setup()
        {
            _configurationRootMock = new Mock<IConfigurationRoot>();

            _configurationRootMock.Setup(i => i["ConnectionString"]).Returns("cs");
        }

        [Test]
        public void DbConnectionString_shouldReturnExpectedConnectionString()
        {
            var config = new Config(_configurationRootMock.Object);

            config.DbConnectionString.Should().Be("cs");
        }
    }
}
