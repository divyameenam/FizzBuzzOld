using FizzBuzzAPI.Controllers;
using FizzBuzzAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzzAPI.Test.Controller;

[TestFixture]
public class FizzBuzzControllerTest
{
    private readonly Mock<IFizzBuzzService> _mockFizzBuzzService;
    private readonly FizzBuzzController _controller;

    public FizzBuzzControllerTest()
    {
        _mockFizzBuzzService = new Mock<IFizzBuzzService>();
        _controller = new FizzBuzzController(_mockFizzBuzzService.Object);
    }

    [Test]
    public void GetFizzBuzz_ReturnsSuccess()
    {
        _mockFizzBuzzService.Setup(m => m.GetFizzBuzzResult(It.IsAny<string[]>())).Returns(new List<string>());

        string[] input = new string[] { "3" };

        var result = _controller.GetFizzBuzz(input);
        var OkResult = result as OkObjectResult;

        Assert.That(OkResult?.StatusCode, Is.EqualTo(200));
    }
}