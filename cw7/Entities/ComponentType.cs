namespace cw7.Entities;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public List<Component> Components { get; set; } = new();
}