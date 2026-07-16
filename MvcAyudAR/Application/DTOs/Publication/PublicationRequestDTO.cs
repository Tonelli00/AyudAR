namespace MvcAyudAR.Application.DTOs.Publication;

public class PublicationRequestDTO
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string>? Photos { get; set; }
    public double TTR { get; set; }
}