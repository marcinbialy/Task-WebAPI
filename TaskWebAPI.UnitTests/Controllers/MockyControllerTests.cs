using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TaskWebAPI.Controllers;
using TaskWebAPI.Methods;

namespace TaskWebAPI.UnitTests.Controllers
{
    [TestFixture]
    public class MockyControllerTests
    {
        private Mock<IMocky> service;
        private MockyController controller;

        [SetUp]
        public void SetUp()
        {
            service = new Mock<IMocky>();
            controller = new MockyController(service.Object);
        }

        [Test]
        public void Mocky_DownloadDataFails_ReturnStatusCode503()
        {
            service.Setup(ms => ms.GetMocky(It.IsAny<string>())).Throws<WebException>();

            var result = controller.Mocky();

            Assert.That(result, Is.TypeOf<StatusCodeResult>());
        }

        [Test]
        public void Mocky_DownloadDataComplete_ReturnData()
        {
            service.Setup(ms => ms.GetMocky(It.IsAny<string>())).Returns("a");

            var result = controller.Mocky();

            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void Mocky_EmptyDownloadData_ReturnNotFound()
        {
            service.Setup(ms => ms.GetMocky(It.IsAny<string>())).Returns(String.Empty);

            var result = controller.Mocky();

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
