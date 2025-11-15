public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public double description { get; set; }
    public double image_url { get; set; }
    public double category_id { get; set; }

    public double revenue { get; set; }  //this is private info that not show to user
    public double provider_id { get; set; }  //this is private info that not show to user

}
