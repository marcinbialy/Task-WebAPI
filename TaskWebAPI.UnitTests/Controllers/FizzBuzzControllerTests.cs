using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebAPI.Controllers;
using TaskWebAPI.Methods;

namespace TaskWebAPI.UnitTests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzz> service;
        private FizzBuzzController controller;

        [SetUp]
        public void SetUp()
        {
            service = new Mock<IFizzBuzz>();
            controller = new FizzBuzzController(service.Object);
        }

        [Test]
        public void Get_ServiceReturnString_ReturnsOkObjectResult()
        {
            service.Setup(ms => ms.Get(It.IsAny<int>())).Returns("Fizz");

            var result = controller.Get(2);

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Get_ServiceReturnNullOrEmptyString_ReturnsNotFoundResult()
        {
            service.Setup(ms => ms.Get(It.IsAny<int>())).Returns(String.Empty);

            var result = controller.Get(2);

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
