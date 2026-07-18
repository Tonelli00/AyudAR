using MvcAyudAR.Domain.Entities;

namespace MvcAyudAR.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }
    public Guid PublicationId { get; set; }
    public Guid UserId { get; set; }
    public double TotalAmount { get; set; }   
    
    //Relationship
    public User Donor { get; set; }
    public Publication Publication { get; set; }
}