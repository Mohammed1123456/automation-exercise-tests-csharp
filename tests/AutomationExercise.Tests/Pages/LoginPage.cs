using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Tests.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private By LoginEmailInput => By.CssSelector("input[data-qa='login-email']");
    private By LoginPasswordInput => By.CssSelector("input[data-qa='login-password']");
    private By LoginButton => By.CssSelector("button[data-qa='login-button']");
    private By LoggedInAs => By.XPath("//a[contains(., 'Logged in as')] ");
    private By LoginError => By.XPath("//p[contains(text(), 'Your email or password is incorrect!')]");

    public void Login(string email, string password)
    {
        _wait.Until(d => d.FindElement(LoginEmailInput)).Clear();
        _driver.FindElement(LoginEmailInput).SendKeys(email);
        _driver.FindElement(LoginPasswordInput).Clear();
        _driver.FindElement(LoginPasswordInput).SendKeys(password);
        _driver.FindElement(LoginButton).Click();
    }

    public bool IsLoggedIn()
    {
        try
        {
            return _wait.Until(d => d.FindElement(LoggedInAs).Displayed);
        }
        catch
        {
            return false;
        }
    }

    public bool IsLoginErrorShown()
    {
        try
        {
            return _wait.Until(d => d.FindElement(LoginError).Displayed);
        }
        catch
        {
            return false;
        }
    }
}


