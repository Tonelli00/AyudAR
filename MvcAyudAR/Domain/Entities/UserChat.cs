namespace MvcAyudAR.Domain.Entities;

public class UserChat
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }
    public DateTime JoinedAt { get; set; }
    
    //Relationship
    public User User { get; set; }
    public Chat Chat { get; set; }
}