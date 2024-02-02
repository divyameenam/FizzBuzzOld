using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzAPI.Test.Services
{
    [TestFixture]
    public class FizzBuzzServiceTest
    {
        private readonly IFizzBuzzService fizzBuzzService;

        public FizzBuzzServiceTest()
        {
            fizzBuzzService = new FizzBuzzService(); ;
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsFizz()
        {
            string[] input = new string[] { "3", "9", "33" };
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("3 - Fizz", result[0]);
            Assert.AreEqual("9 - Fizz", result[1]);
            Assert.AreEqual("33 - Fizz", result[2]);
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsBuzz()
        {
            string[] input = new string[] { "5", "25" };
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("5 - Buzz", result[0]);
            Assert.AreEqual("25 - Buzz", result[1]);
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsFizzBuzz()
        {
            string[] input = new string[] { "15", "75" };
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("15 - FizzBuzz", result[0]);
            Assert.AreEqual("75 - FizzBuzz", result[1]);
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsInvalidItem()
        {
            string[] input = new string[] { " ", "abc" };
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("  - Invalid Item", result[0]);
            Assert.AreEqual("abc - Invalid Item", result[1]);
        }

        [Test]
        public void GetFizzBuzzResult_NotDivisibleBy3And5()
        {
            string[] input = new string[] { "1", "2" };
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.AreEqual("Divided 1 by 3 & Divided 1 by 5", result[0]);
            Assert.AreEqual("Divided 2 by 3 & Divided 2 by 5", result[1]);
        }
    }
}
