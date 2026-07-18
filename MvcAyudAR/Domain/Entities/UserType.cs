namespace MvcAyudAR.Domain.Entities;

public class UserType
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //Relationship
    public IEnumerable<User> Users { get; set; }
}