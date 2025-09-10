using AutomationExercise.Tests.Drivers;
using AutomationExercise.Tests.Support;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Tests;

public abstract class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        Driver = DriverFactory.CreateChromeDriver(TestSettings.Headless);
        Driver.Navigate().GoToUrl(TestSettings.BaseUrl);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
        catch
        {
            // ignore
        }
        finally
        {
            Driver = null!;
        }
    }
}


