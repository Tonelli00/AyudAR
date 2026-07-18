namespace MvcAyudAR.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime SendDate { get; set; }
    public bool Status { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditDate { get; set; }
    
    //Relationship
    public Chat Chat { get; set; }
    public User User { get; set; }
}