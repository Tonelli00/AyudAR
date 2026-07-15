namespace MvcAyudAR.Models.DTOs.User;

public class UserRequestDTO
{
    public string FullName { get; set; }
    public string Dni { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string? ProfilePicture { get; set; }
    public DateOnly BirthDate { get; set; }
}