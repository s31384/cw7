namespace cw7.Entities;

public class PCComponent
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; }
    public int Amount { get; set; }
    
    public Component  Component { get; set; }
    public Pc Pc { get; set; }
    
}