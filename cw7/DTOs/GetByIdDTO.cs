using cw7.Entities;

namespace cw7.DTOs;

public class GetByIdDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock{get;set;}
    
    public List<GetComponentDTO> Components { get; set; }
}