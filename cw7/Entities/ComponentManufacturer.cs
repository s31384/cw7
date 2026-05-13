namespace cw7.Entities;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public DateTime FoundationDate { get; set; }
    public List<Component> Components { get; set; } = new();
}