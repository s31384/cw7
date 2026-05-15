namespace cw7.DTOs;

public class PutPcDTO
{
    public string name{get;set;} = String.Empty;
    public float weight { get; set; }
    public int warranty{get;set;}
    public DateTime createdAt { get; set; }
    public int stock { get; set; }
}