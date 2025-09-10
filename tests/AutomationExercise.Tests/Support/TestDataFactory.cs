using Bogus;

namespace AutomationExercise.Tests.Support;

public static class TestDataFactory
{
    private static readonly Faker _faker = new();

    public static UserData CreateValidUser()
    {
        return new UserData
        {
            FullName = _faker.Name.FullName(),
            Email = $"{_faker.Internet.UserName().ToLower()}.{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}@example.com",
            Password = _faker.Internet.Password(12),
            FirstName = _faker.Name.FirstName(),
            LastName = _faker.Name.LastName(),
            Address = _faker.Address.StreetAddress(),
            State = _faker.Address.State(),
            City = _faker.Address.City(),
            ZipCode = _faker.Address.ZipCode(),
            MobileNumber = _faker.Phone.PhoneNumber()
        };
    }

    public static UserData CreateUserWithCustomEmail(string emailPrefix)
    {
        var user = CreateValidUser();
        user.Email = $"{emailPrefix}.{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}@example.com";
        return user;
    }
}

public class UserData
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
}
