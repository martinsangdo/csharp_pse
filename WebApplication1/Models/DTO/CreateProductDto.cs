using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Name must be between 3 and 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, 100000,
        ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    [MinLength(30, ErrorMessage = "Description must be at least 30 characters.")]
    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string description { get; set; }

    [Required(ErrorMessage = "Image URL is required.")]
    [Url(ErrorMessage = "Invalid image URL format.")]
    public string image_url { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [Range(1, int.MaxValue,
        ErrorMessage = "Category must be valid.")]
    public int category_id { get; set; }

    // [EmailAddress]
    // public string Email { get; set; }

    // [Phone(ErrorMessage = "Invalid phone number format.")]
    // public string PhoneNumber { get; set; }

    // [Required]
    // [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{8,}$",
    //     ErrorMessage = "Password must contain at least 8 characters, one uppercase letter and one number.")]
    // public string Password { get; set; }

}
