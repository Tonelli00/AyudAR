namespace MvcAyudAR.Application.DTOs.Publication;

public class PublicationResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double TTR { get; set; }
    public double CurrentlyTotal { get; set; }
}