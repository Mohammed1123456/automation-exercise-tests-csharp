using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Tests.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private By Logo => By.XPath("//img[@alt='Website for automation practice']");
    private By SignupLoginLink => By.CssSelector("a[href='/login']");

    public bool IsLoaded()
    {
        return _wait.Until(d => d.FindElement(Logo).Displayed);
    }

    public void ClickSignupLogin()
    {
        var element = _wait.Until(d => d.FindElement(SignupLoginLink));
        element.Click();
    }
}


