using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataAccessLayer;

internal static class JsonStorage
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static T Read<T>(string path)
    {
        if (!File.Exists(path))
            throw new DataAccessException($"Файл не найден: {path}");

        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json, Options)
                   ?? throw new DataAccessException($"Файл пуст: {path}");
        }
        catch (JsonException ex)
        {
            throw new DataAccessException($"Файл повреждён или имеет неверный формат: {path}", ex);
        }
        catch (IOException ex)
        {
            throw new DataAccessException($"Не удалось прочитать файл: {path}", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new DataAccessException($"Нет доступа к файлу: {path}", ex);
        }
    }

    public static void Write<T>(string path, T value) =>
        WriteText(path, JsonSerializer.Serialize(value, Options));

    public static void WriteText(string path, string content)
    {
        try
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(path));
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(path, content);
        }
        catch (IOException ex)
        {
            throw new DataAccessException($"Не удалось записать файл: {path}", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new DataAccessException($"Нет доступа к файлу: {path}", ex);
        }
    }
}