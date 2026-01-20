public class PagedResult<T>
{
    public int Page { get; set; }
    public int Limit { get; set; }
    public int Total { get; set; }
    public List<T> Data { get; set; } = new();
}