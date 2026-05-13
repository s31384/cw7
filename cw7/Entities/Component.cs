namespace cw7.Entities;

public class Component
{
    public string Code{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public int ComponentTypesId{get;set;}
    public int ComponentManufacturersId{get;set;}
    
    public ComponentManufacturer ComponentManufacturer{get;set;}
    public ComponentType ComponentType{get;set;}
    
    public List<PCComponent> PcComponents { get; set; }

}