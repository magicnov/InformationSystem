using System.Globalization;
using CsvHelper;

namespace InformationSystem.Services;

internal static class FileWorkService
{
    public static List<T> Deserialization<T>(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<T>();
        var list = records.ToList();
        return list;
    }

    public static void Serialization<T>(List<T> list, string path)
    {
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(list);
    }
}