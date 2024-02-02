using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Model;
using FizzBuzzAPI.Services;
using FizzBuzzAPI.Utility;
using Moq;
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
        private readonly Mock<IMathUtil> mockMathUtil;

        public FizzBuzzServiceTest()
        {
            mockMathUtil = new Mock<IMathUtil>();
            fizzBuzzService = new FizzBuzzService(mockMathUtil.Object);
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsFizz()
        {
            string[] input = new string[] { "3", "9", "33" };
            mockMathUtil.Setup(m => m.Division(It.IsAny<int>(), It.IsAny<int>())).Returns<int,int>((a,b)=> a % b);

            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.That(result[0], Is.EqualTo("3 - " + Constants.strFizz));
            Assert.That(result[1], Is.EqualTo("9 - " + Constants.strFizz));
            Assert.That(result[2], Is.EqualTo("33 - " + Constants.strFizz));
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsBuzz()
        {
            string[] input = new string[] { "5", "25" };
            mockMathUtil.Setup(m => m.Division(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a % b);
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.That(result[0], Is.EqualTo("5 - " + Constants.strBuzz));
            Assert.That(result[1], Is.EqualTo("25 - " + Constants.strBuzz));
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsFizzBuzz()
        {
            string[] input = new string[] { "15", "75" };
            mockMathUtil.Setup(m => m.Division(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a % b);
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.That(result[0], Is.EqualTo("15 - " + Constants.strFizzBuzz));
            Assert.That(result[1], Is.EqualTo("75 - " + Constants.strFizzBuzz));
        }

        [Test]
        public void GetFizzBuzzResult_ReturnsInvalidItem()
        {
            string[] input = new string[] { " ", "abc" };
            mockMathUtil.Setup(m => m.Division(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a % b);
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.That(result[0], Is.EqualTo("  - " + Constants.strInvalidItem));
            Assert.That(result[1], Is.EqualTo("abc - " + Constants.strInvalidItem));
        }

        [Test]
        public void GetFizzBuzzResult_NotDivisibleBy3And5()
        {
            string[] input = new string[] { "1", "2" };
            mockMathUtil.Setup(m => m.Division(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a % b);
            var result = fizzBuzzService.GetFizzBuzzResult(input);

            Assert.IsNotNull(result);
            Assert.That(result[0], Is.EqualTo("Divided 1 by 3 & Divided 1 by 5"));
            Assert.That(result[1], Is.EqualTo("Divided 2 by 3 & Divided 2 by 5"));
        }
    }
}
