using AutomationExercise.Tests.Pages;
using AutomationExercise.Tests.Support;
using FluentAssertions;

namespace AutomationExercise.Tests.Tests;

public class SignupLoginTests : BaseTest
{
    [Test]
    [Category("ui")]
    [Category("regression")]
    public void Signup_Should_Create_New_Account_Successfully()
    {
        // Arrange - Prepare test data
        var userData = TestDataFactory.CreateValidUser();

        // Act - Execute signup flow
        var home = new HomePage(Driver);
        home.IsLoaded().Should().BeTrue();
        home.ClickSignupLogin();

        var signup = new SignupLoginPage(Driver);
        signup.StartSignup(userData.FullName, userData.Email);
        signup.FillAccountInformation(userData.Password, userData.FirstName, userData.LastName, 
            userData.Address, userData.State, userData.City, userData.ZipCode, userData.MobileNumber);
        
        // Assert - Verify account creation
        signup.IsAccountCreated().Should().BeTrue();
        signup.ContinueAfterCreation();
    }
}


