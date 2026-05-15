using cw7.Entities;

namespace cw7.DTOs;

public class GetComponentDTO
{
    
    public int Amount{get;set;}
    public string Code{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public GetManufacturerDTO ComponentManufacturer{get;set;}
    public GetTypeDTO ComponentType{get;set;}
}