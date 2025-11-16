
using System.Text.Json;
using WebApplication1.Services;

public class ProductService
{
    private readonly ExternalService _externalService;
    public ProductService(ExternalService externalService)
    {
        _externalService = externalService;
    }
    //get dummy product from external source
    public List<ProductDto> getDummyProducts()
    {
        List<ProductDto> products = new List<ProductDto>();
        Dictionary<string, JsonElement> rawDict = _externalService.sendGetRequest("https://dummyjson.com/products");
        if (!rawDict.TryGetValue("products", out JsonElement productsElement))
        {
            throw new Exception("JSON does not contain 'products'");
        }
        List<Dictionary<string, JsonElement>> rawProducts = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(rawDict["products"])!;
        foreach (var item in rawProducts)
        {
            var product = new ProductDto
            {
                Id = item["id"] is JsonElement jeId ? jeId.GetInt32() : 0,
                Name = item["title"] is JsonElement jeName ? jeName.GetString() ?? "" : "",
                Price = item["price"] is JsonElement jePrice ? jePrice.GetDouble() : 0,
                description = item["description"] is JsonElement jeDesc ? jeDesc.GetString() ?? "" : "",
                image_url = item["thumbnail"] is JsonElement jeImg ? jeImg.GetString() ?? "" : ""
            };
            products.Add(product);
        }
        return products;
    }
    //call external API
    public ProductDto getDummyProductDetail()
    {
        Dictionary<string, JsonElement> rawDict = _externalService.sendGetRequest("https://dummyjson.com/products/1");
        var product = new ProductDto
            {
                Id = rawDict["id"] is JsonElement jeId ? jeId.GetInt32() : 0,
                Name = rawDict["title"] is JsonElement jeName ? jeName.GetString() ?? "" : "",
                Price = rawDict["price"] is JsonElement jePrice ? jePrice.GetDouble() : 0,
                description = rawDict["description"] is JsonElement jeDesc ? jeDesc.GetString() ?? "" : "",
                image_url = rawDict["thumbnail"] is JsonElement jeImg ? jeImg.GetString() ?? "" : ""
            };
        return product;
    }
}