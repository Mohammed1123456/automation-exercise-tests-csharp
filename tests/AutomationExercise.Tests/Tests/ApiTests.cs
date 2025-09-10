using AutomationExercise.Tests.Api;
using Bogus;
using FluentAssertions;
using RestSharp;

namespace AutomationExercise.Tests.Tests;

public class ApiTests
{
    [Test]
    [Category("api")]
    public async Task CreateAccount_Should_Return_Success()
    {
        var faker = new Faker();
        var form = new Dictionary<string, string>
        {
            ["name"] = faker.Name.FullName(),
            ["email"] = $"{faker.Internet.UserName().ToLower()}.{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}@example.com",
            ["password"] = faker.Internet.Password(12),
            ["title"] = "Mr",
            ["birth_date"] = "1",
            ["birth_month"] = "1",
            ["birth_year"] = "2000",
            ["firstname"] = faker.Name.FirstName(),
            ["lastname"] = faker.Name.LastName(),
            ["company"] = faker.Company.CompanyName(),
            ["address1"] = faker.Address.StreetAddress(),
            ["address2"] = "",
            ["country"] = "Canada",
            ["zipcode"] = faker.Address.ZipCode(),
            ["state"] = faker.Address.State(),
            ["city"] = faker.Address.City(),
            ["mobile_number"] = faker.Phone.PhoneNumber()
        };

        var api = new ApiClient();
        TestContext.Progress.WriteLine("--- API createAccount call ---");
        RestResponse response = await api.CreateAccountAsync(form, s => TestContext.Progress.WriteLine(s));

        // API returns 201 with message "User created!" on success per api_list
        response.StatusCode.Should().BeOneOf(System.Net.HttpStatusCode.OK, System.Net.HttpStatusCode.Created);
        response.Content.Should().NotBeNullOrWhiteSpace();
        response.Content!.ToLower().Should().MatchRegex("user created|success");
    }
}