using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AutomationExercise.Tests.Support;

public static class CsvDataReader
{
    public static IEnumerable<T> Read<T>(string relativePath)
    {
        var baseDir = AppContext.BaseDirectory;
        var fullPath = Path.Combine(baseDir, relativePath);
        using var reader = new StreamReader(fullPath);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim,
            BadDataFound = null
        };
        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<T>().ToList();
    }
}


