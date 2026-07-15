namespace MvcAyudAR.Models;

public class User
{
    public Guid Id { get; set; }
    public int UserTypeId { get; set; }
    public string FullName { get; set; }
    public string Dni { get; set; }
    public string Password {get;set;}
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ProfilePicture { get; set; }
    public DateOnly BirthDate { get; set; }
    
    //Relationships
    public IEnumerable<Publication> Publications { get; set; }
    public IEnumerable<Message> Messages { get; set; }
    public IEnumerable<Payment> Payments { get; set; }
    public IEnumerable<UserChat> UserChats { get; set; }
    public UserType UserType { get; set; }
}