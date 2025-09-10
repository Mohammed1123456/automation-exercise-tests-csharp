using AutomationExercise.Tests.Pages;
using Bogus;
using FluentAssertions;

namespace AutomationExercise.Tests.Tests;

public class SignupLoginTests : BaseTest
{
    [Test]
    [Category("ui")]
    [Category("regression")]
    public void Signup_Should_Create_New_Account_Successfully()
    {
        var faker = new Faker();
        var fullName = faker.Name.FullName();
        var email = $"{faker.Internet.UserName().ToLower()}.{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}@example.com";
        var password = faker.Internet.Password(12);
        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var address = faker.Address.StreetAddress();
        var state = faker.Address.State();
        var city = faker.Address.City();
        var zip = faker.Address.ZipCode();
        var mobile = faker.Phone.PhoneNumber();

        var home = new HomePage(Driver);
        home.IsLoaded().Should().BeTrue();
        home.ClickSignupLogin();

        var signup = new SignupLoginPage(Driver);
        signup.StartSignup(fullName, email);
        signup.FillAccountInformation(password, firstName, lastName, address, state, city, zip, mobile);
        signup.IsAccountCreated().Should().BeTrue();
        signup.ContinueAfterCreation();
    }
}


