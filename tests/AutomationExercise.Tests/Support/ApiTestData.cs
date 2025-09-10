using CsvHelper.Configuration;

namespace AutomationExercise.Tests.Support;

public class ApiTestData
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
    public string BirthMonth { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public int ExpectedStatus { get; set; }
}

public class ApiTestDataMap : ClassMap<ApiTestData>
{
    public ApiTestDataMap()
    {
        Map(m => m.Name).Name("name");
        Map(m => m.Email).Name("email");
        Map(m => m.Password).Name("password");
        Map(m => m.Title).Name("title");
        Map(m => m.BirthDate).Name("birth_date");
        Map(m => m.BirthMonth).Name("birth_month");
        Map(m => m.BirthYear).Name("birth_year");
        Map(m => m.FirstName).Name("firstname");
        Map(m => m.LastName).Name("lastname");
        Map(m => m.Company).Name("company");
        Map(m => m.Address1).Name("address1");
        Map(m => m.Address2).Name("address2");
        Map(m => m.Country).Name("country");
        Map(m => m.Zipcode).Name("zipcode");
        Map(m => m.State).Name("state");
        Map(m => m.City).Name("city");
        Map(m => m.MobileNumber).Name("mobile_number");
        Map(m => m.ExpectedStatus).Name("expected_status");
    }
}
