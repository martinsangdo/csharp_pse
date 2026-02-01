
using Microsoft.AspNetCore.Mvc;

public class CommentService
{
    private readonly ApplicationDbContext _db;

    public CommentService(ApplicationDbContext db)
    {
        _db = db;
    }

    public int CreateComment(CreateCommentDto dto)
    {
        var comment = new Comment
        {
            ProductId = dto.ProductId,
            Content = dto.Content,
            CreatedAt = DateTime.Now
        };

        _db.Comment.Add(comment);
        return _db.SaveChanges();
    }
    //get comments of this product
    public List<Comment> getCommentsOfProduct(int productId)
    {
        var query = _db.Comment
                    .Where(c => c.ProductId == productId);
        var items = query.ToList();
        return items;
    }
}