using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using _5.Models.Sweets.Abstract;

namespace _5.Services;

public class SweetsRepository
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    private readonly string _filePath;

    public SweetsRepository(string filePath) => _filePath = filePath;

    public IEnumerable<Sweet> Load()
    {
        var json = File.ReadAllText(_filePath);
        var dtos = JsonSerializer.Deserialize<List<SweetDto>>(json, Options)
                   ?? throw new InvalidDataException("Файл данных пуст или повреждён.");

        foreach (var dto in dtos)
        {
            for (var i = 0; i < Math.Max(1, dto.Count ?? 1); i++)
                yield return SweetFactory.Create(dto);
        }
    }

    public void Save(IEnumerable<Sweet> sweets, string filePath)
    {
        var dtos = sweets.Select(SweetDtoMapper.ToDto).ToList();
        var json = JsonSerializer.Serialize(dtos, Options);

        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        File.WriteAllText(filePath, json);
    }
}