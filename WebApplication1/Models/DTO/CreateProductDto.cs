using System.ComponentModel.DataAnnotations;

public class CreateProductDto : IValidatableObject
{
    public int ProductId { get; set; }
    
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

    public decimal SalesPrice { get; set; }
    public DateTime? ProducedDate { get; set; } //null for datetime2

    // [EmailAddress]
    // public string Email { get; set; }

    // [Phone(ErrorMessage = "Invalid phone number format.")]
    // public string PhoneNumber { get; set; }

    // [Required]
    // [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{8,}$",
    //     ErrorMessage = "Password must contain at least 8 characters, one uppercase letter and one number.")]
    // public string Password { get; set; }

    //custom validation
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        foreach (var error in ValidateSalesPrice())
            yield return error;     //return in a list
        foreach (var error in ValidateDates())
            yield return error;
    }
    private IEnumerable<ValidationResult> ValidateSalesPrice()
    {
        if (SalesPrice > Price)
            yield return new ValidationResult("Invalid sales price");
    }
    private IEnumerable<ValidationResult> ValidateDates()
    {
        if (ProducedDate > DateTime.Now)
            yield return new ValidationResult("Invalid produced datetime");
    }

    //merge 2 methods into 1
    // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     if (SalesPrice > Price)
    //     {
    //         yield return new ValidationResult(
    //             "Discount cannot exceed price.",
    //             new[] { nameof(SalesPrice) });
    //     }

    //     if (ProducedDate > DateTime.Now)
    //     {
    //         yield return new ValidationResult(
    //             "End date must be after start date.",
    //             new[] { nameof(ProducedDate) });
    //     }
    // }

}
