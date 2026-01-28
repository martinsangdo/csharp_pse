using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
    [Column("category_id")]
    public int CategoryID { get; set; }
    public required string Name { get; set; }
    [Column("parent_category_id")]
    public int? ParentCategoryId { get; set; }
}
