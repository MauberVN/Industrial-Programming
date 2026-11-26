namespace DataAccessLayer.Dto;

public class GiftDto
{
    public string Name { get; set; } = string.Empty;
    public List<SweetDto> Sweets { get; set; } = [];
}