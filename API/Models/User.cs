namespace API.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int Age { get; set; }
}
