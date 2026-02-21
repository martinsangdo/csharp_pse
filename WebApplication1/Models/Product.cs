
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }  //primary key, auto match with product_id

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    public decimal SalesPrice { get; set; }
    public DateTime? ProducedDate { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Active";

    [Column("slug")]
    public string? Slug { get; set; }

    // public double revenue { get; set; }  //this is private info that not show to user
    // public int provider_id { get; set; }  //this is private info that not show to user

}
