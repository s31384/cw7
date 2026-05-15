namespace cw7.DTOs;

public class GetManufacturerDTO
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public DateTime FoundationDate { get; set; }
}