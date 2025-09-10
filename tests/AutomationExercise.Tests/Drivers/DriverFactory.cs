using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;

namespace AutomationExercise.Tests.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateChromeDriver(bool headless = false)
    {
        var chromeOptions = new ChromeOptions();
        if (headless)
        {
            chromeOptions.AddArgument("--headless=new");
        }
        chromeOptions.AddArgument("--window-size=1920,1080");
        chromeOptions.AddArgument("--disable-gpu");
        chromeOptions.AddArgument("--no-sandbox");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            chromeOptions.AddArgument("--disable-dev-shm-usage");
        }

        var driver = new ChromeDriver(chromeOptions);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        driver.Manage().Window.Size = new System.Drawing.Size(1440, 900);
        return driver;
    }
}
