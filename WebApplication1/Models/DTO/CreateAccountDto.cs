using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class CreateAccountDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(30)]
    public string fullname { get; set; }

    [Required]
    [EmailAddress]
    public string email { get; set; }

    [Required]
    [MinLength(8)] //64
    public string hashed_password { get; set; }

    [Phone]
    public string? phone { get; set; }
    public string? address { get; set; }
    public string? status { get; set; }

    public DateTime? created_at { get; set; }

}