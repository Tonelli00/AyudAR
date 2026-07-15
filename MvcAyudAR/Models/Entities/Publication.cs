namespace MvcAyudAR.Models;

public class Publication
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Photos { get; set; }
    public double TTR { get; set; }
    
    //Relationship
    
    public User Publisher { get; set; }
    public IEnumerable<Payment> Payments { get; set; }
        
        
}