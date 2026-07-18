namespace MvcAyudAR.Domain.Entities;

public class Chat
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid LastMessage { get; set; }
    
    //Relationship
    public IEnumerable<Message> Messages { get; set; }
    public IEnumerable<UserChat> UserChats { get; set; }
}