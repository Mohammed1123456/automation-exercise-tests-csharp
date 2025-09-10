using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Tests.Pages;

public class SignupLoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public SignupLoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    private By NewUserNameInput => By.CssSelector("input[data-qa='signup-name']");
    private By NewUserEmailInput => By.CssSelector("input[data-qa='signup-email']");
    private By SignupButton => By.CssSelector("button[data-qa='signup-button']");

    private By AccountInformationHeader => By.XPath("//b[normalize-space()='Enter Account Information']");
    private By PasswordInput => By.Id("password");
    private By DaysSelect => By.Id("days");
    private By MonthsSelect => By.Id("months");
    private By YearsSelect => By.Id("years");
    private By FirstNameInput => By.Id("first_name");
    private By LastNameInput => By.Id("last_name");
    private By Address1Input => By.Id("address1");
    private By CountrySelect => By.Id("country");
    private By StateInput => By.Id("state");
    private By CityInput => By.Id("city");
    private By ZipcodeInput => By.Id("zipcode");
    private By MobileNumberInput => By.Id("mobile_number");
    private By CreateAccountButton => By.CssSelector("button[data-qa='create-account']");
    private By AccountCreatedHeader => By.XPath("//b[normalize-space()='Account Created!']");
    private By ContinueButton => By.CssSelector("a[data-qa='continue-button']");

    public void StartSignup(string name, string email)
    {
        _wait.Until(d => d.FindElement(NewUserNameInput)).SendKeys(name);
        _driver.FindElement(NewUserEmailInput).SendKeys(email);
        _driver.FindElement(SignupButton).Click();
    }

    public void FillAccountInformation(string password, string firstName, string lastName, string address, string state, string city, string zipcode, string mobile)
    {
        _wait.Until(d => d.FindElement(AccountInformationHeader).Displayed);
        _driver.FindElement(PasswordInput).SendKeys(password);
        new SelectElement(_driver.FindElement(DaysSelect)).SelectByValue("1");
        new SelectElement(_driver.FindElement(MonthsSelect)).SelectByValue("1");
        new SelectElement(_driver.FindElement(YearsSelect)).SelectByValue("2000");
        _driver.FindElement(FirstNameInput).SendKeys(firstName);
        _driver.FindElement(LastNameInput).SendKeys(lastName);
        _driver.FindElement(Address1Input).SendKeys(address);
        new SelectElement(_driver.FindElement(CountrySelect)).SelectByText("Canada");
        _driver.FindElement(StateInput).SendKeys(state);
        _driver.FindElement(CityInput).SendKeys(city);
        _driver.FindElement(ZipcodeInput).SendKeys(zipcode);
        _driver.FindElement(MobileNumberInput).SendKeys(mobile);
        _driver.FindElement(CreateAccountButton).Click();
    }

    public bool IsAccountCreated()
    {
        return _wait.Until(d => d.FindElement(AccountCreatedHeader).Displayed);
    }

    public void ContinueAfterCreation()
    {
        _driver.FindElement(ContinueButton).Click();
    }
}


