using BusinessLayer;
using BusinessLayer.Validation;
using DataAccessLayer.Dto;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

public class GiftDao : IGiftDao
{
    public Gift Load(string path)
    {
        var dto = JsonStorage.Read<GiftDto>(path);
        var gift = new Gift(dto.Name);

        try
        {
            foreach (var sweetDto in dto.Sweets)
                gift.Add(SweetDtoMapper.ToBusiness(sweetDto));
        }
        catch (BusinessValidationException ex)
        {
            throw new DataAccessException($"Файл содержит недопустимые данные: {ex.Message}", ex);
        }

        return gift;
    }

    public void Save(Gift gift, string path)
    {
        ArgumentNullException.ThrowIfNull(gift);

        var dto = new GiftDto
        {
            Name = gift.Name,
            Sweets = gift.Select(SweetDtoMapper.ToDto).ToList()
        };
        JsonStorage.Write(path, dto);
    }

    public void SaveReport(string path, string text) => JsonStorage.WriteText(path, text);
}