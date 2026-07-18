namespace MvcAyudAR.Services.DTOs.Payment;

public class PaymentRequestDTO
{
    public Guid UserId { get; set; }
    public Guid PublicationId { get; set; }
    public double TotalAmount { get; set; }
}