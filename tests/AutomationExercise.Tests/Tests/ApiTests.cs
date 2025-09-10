using AutomationExercise.Tests.Api;
using AutomationExercise.Tests.Support;
using FluentAssertions;
using RestSharp;

namespace AutomationExercise.Tests.Tests;

public class ApiTests
{
    public static IEnumerable<TestCaseData> ApiTestCases()
    {
        // Generate fresh test data for each run to avoid "email already exists" errors
        for (int i = 0; i < 3; i++)
        {
            var userData = TestDataFactory.CreateValidUser();
            var testData = new ApiTestData
            {
                Name = userData.FullName,
                Email = userData.Email,
                Password = userData.Password,
                Title = "Mr",
                BirthDate = "1",
                BirthMonth = "1",
                BirthYear = "2000",
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Company = "Test Company",
                Address1 = userData.Address,
                Address2 = "",
                Country = "Canada",
                Zipcode = userData.ZipCode,
                State = userData.State,
                City = userData.City,
                MobileNumber = userData.MobileNumber,
                ExpectedStatus = 201
            };
            
            yield return new TestCaseData(testData)
                .SetName($"CreateAccount_API_Generated_{i + 1}_{testData.ExpectedStatus}");
        }
    }

    [Test]
    [TestCaseSource(nameof(ApiTestCases))]
    [Category("api")]
    public async Task CreateAccount_With_Data_From_Csv_Should_Return_Expected_Status(ApiTestData testData)
    {
        // Arrange - Prepare test data from CSV
        var form = new Dictionary<string, string>
        {
            ["name"] = testData.Name,
            ["email"] = testData.Email,
            ["password"] = testData.Password,
            ["title"] = testData.Title,
            ["birth_date"] = testData.BirthDate,
            ["birth_month"] = testData.BirthMonth,
            ["birth_year"] = testData.BirthYear,
            ["firstname"] = testData.FirstName,
            ["lastname"] = testData.LastName,
            ["company"] = testData.Company,
            ["address1"] = testData.Address1,
            ["address2"] = testData.Address2,
            ["country"] = testData.Country,
            ["zipcode"] = testData.Zipcode,
            ["state"] = testData.State,
            ["city"] = testData.City,
            ["mobile_number"] = testData.MobileNumber
        };

        // Act - Call API
        var api = new ApiClient();
        TestContext.Progress.WriteLine($"--- API createAccount call for {testData.Email} ---");
        RestResponse response = await api.CreateAccountAsync(form, s => TestContext.Progress.WriteLine(s));

        // Assert - Verify expected status code and response
        response.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.OK, System.Net.HttpStatusCode.Created);
        response.Content.Should().NotBeNullOrWhiteSpace();
        response.Content!.Should().Contain($"\"responseCode\": {testData.ExpectedStatus}");
        response.Content!.ToLower().Should().MatchRegex("user created|success");
    }

    [Test]
    [Category("api")]
    public async Task CreateAccount_With_Generated_Data_Should_Return_Success()
    {
        // Arrange - Prepare test data using factory
        var userData = TestDataFactory.CreateValidUser();
        var form = new Dictionary<string, string>
        {
            ["name"] = userData.FullName,
            ["email"] = userData.Email,
            ["password"] = userData.Password,
            ["title"] = "Mr",
            ["birth_date"] = "1",
            ["birth_month"] = "1",
            ["birth_year"] = "2000",
            ["firstname"] = userData.FirstName,
            ["lastname"] = userData.LastName,
            ["company"] = "Test Company",
            ["address1"] = userData.Address,
            ["address2"] = "",
            ["country"] = "Canada",
            ["zipcode"] = userData.ZipCode,
            ["state"] = userData.State,
            ["city"] = userData.City,
            ["mobile_number"] = userData.MobileNumber
        };

        // Act - Call API
        var api = new ApiClient();
        TestContext.Progress.WriteLine($"--- API createAccount call for generated user {userData.Email} ---");
        RestResponse response = await api.CreateAccountAsync(form, s => TestContext.Progress.WriteLine(s));

        // Assert - Verify success response
        response.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.OK, System.Net.HttpStatusCode.Created);
        response.Content.Should().NotBeNullOrWhiteSpace();
        response.Content!.Should().Contain("\"responseCode\": 201");
        response.Content!.ToLower().Should().MatchRegex("user created|success");
    }
}