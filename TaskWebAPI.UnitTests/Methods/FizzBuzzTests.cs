using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaskWebAPI.Methods;

namespace TaskWebAPI.UnitTests.Methods
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(-1, "Enter a number greater than zero!")]
        [TestCase(0, "Enter a number greater than zero!")]
        [TestCase(1, "1")]
        [TestCase(6, "FizzBuzz")]
        [TestCase(2, "Fizz")]
        [TestCase(3, "Buzz")]
        public void Get_WhenCalled_ReturnString(int number, string output)
        {
            var fizz = new FizzBuzz();

            var result = fizz.Get(number);

            Assert.That(result, Is.EqualTo(output));
        }
    }
}
