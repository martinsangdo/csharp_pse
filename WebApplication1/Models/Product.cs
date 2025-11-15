public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string description { get; set; }
    public string image_url { get; set; }
    public int category_id { get; set; }

    public double revenue { get; set; }  //this is private info that not show to user
    public int provider_id { get; set; }  //this is private info that not show to user

}
