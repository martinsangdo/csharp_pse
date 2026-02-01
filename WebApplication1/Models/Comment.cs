
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Column("comment_id")]
    public int CommentId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }
    public double Rate { get; set; }
    public string? Content { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
