using AutomationExercise.Tests.Pages;
using AutomationExercise.Tests.Drivers;
using AutomationExercise.Tests.Support;
using Bogus;
using FluentAssertions;

namespace AutomationExercise.Tests.Tests;

public class LoginDdtTests : BaseTest
{
    public record LoginRow(string email, string password, bool expected);

    public static IEnumerable<TestCaseData> LoginCases()
    {
        var rows = CsvDataReader.Read<LoginRow>("TestData/login_data.csv");
        foreach (var r in rows)
        {
            yield return new TestCaseData(r.email, r.password, r.expected)
                .SetName($"Login_{r.email}_{(r.expected ? "Success" : "Fail")}");
        }

        // Generate a valid account dynamically for a success case
        var userData = TestDataFactory.CreateValidUser();

        // Create account
        using var driver = DriverFactory.CreateChromeDriver(TestSettings.Headless);
        driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        var home = new HomePage(driver);
        home.IsLoaded();
        home.ClickSignupLogin();
        var signup = new SignupLoginPage(driver);
        signup.StartSignup(userData.FullName, userData.Email);
        signup.FillAccountInformation(userData.Password, userData.FirstName, userData.LastName, 
            userData.Address, userData.State, userData.City, userData.ZipCode, userData.MobileNumber);
        signup.IsAccountCreated().Should().BeTrue();
        signup.ContinueAfterCreation();

        yield return new TestCaseData(userData.Email, userData.Password, true).SetName("Login_Valid_Created_Success");
    }

    [Test, TestCaseSource(nameof(LoginCases))]
    [Category("ui")]
    public void Login_With_Data_From_Csv_And_Generated(string email, string password, bool expected)
    {
        var home = new HomePage(Driver);
        home.IsLoaded().Should().BeTrue();
        home.ClickSignupLogin();

        var login = new LoginPage(Driver);
        login.Login(email, password);

        if (expected)
        {
            login.IsLoggedIn().Should().BeTrue();
        }
        else
        {
            login.IsLoginErrorShown().Should().BeTrue();
        }
    }
}


