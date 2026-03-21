using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Account
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    public string fullname { get; set; }

    public string email { get; set; }

    public string hashed_password { get; set; }

    public string phone { get; set; }

    public string address { get; set; }

    public DateTime? created_at { get; set; }

    public string status { get; set; }

    public string? avatar { get; set; }
}