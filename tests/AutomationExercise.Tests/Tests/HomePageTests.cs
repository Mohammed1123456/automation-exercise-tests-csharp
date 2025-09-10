using AutomationExercise.Tests.Pages;
using FluentAssertions;

namespace AutomationExercise.Tests.Tests;

public class HomePageTests : BaseTest
{
    [Test]
    [Category("ui")]
    [Category("smoke")]
    public void HomePage_Should_Load_Successfully()
    {
        var home = new HomePage(Driver);
        home.IsLoaded().Should().BeTrue();
    }
}