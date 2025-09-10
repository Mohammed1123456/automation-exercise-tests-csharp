namespace AutomationExercise.Tests.Support;

public static class TestSettings
{
    public const string BaseUrl = "https://automationexercise.com/";
    public static readonly bool Headless = Environment.GetEnvironmentVariable("HEADLESS") == "1";
}
