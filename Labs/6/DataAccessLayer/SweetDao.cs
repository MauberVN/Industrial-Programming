using BusinessLayer.Sweets;
using DataAccessLayer.Dto;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

public class SweetDao : ISweetDao
{
    private readonly string _filePath;

    public SweetDao(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        _filePath = filePath;
    }

    public IReadOnlyList<Sweet> GetAll() =>
        JsonStorage.Read<List<SweetDto>>(_filePath)
            .Select(SweetDtoMapper.ToBusiness)
            .ToList();

    public void Add(Sweet sweet)
    {
        ArgumentNullException.ThrowIfNull(sweet);

        var dtos = File.Exists(_filePath)
            ? JsonStorage.Read<List<SweetDto>>(_filePath)
            : [];
        dtos.Add(SweetDtoMapper.ToDto(sweet));
        JsonStorage.Write(_filePath, dtos);
    }
}