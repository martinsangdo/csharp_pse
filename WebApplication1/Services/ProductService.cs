
using System.Text.Json;
using WebApplication1.Services;

public class ProductService
{
    private readonly ExternalService _externalService;
    private readonly ApplicationDbContext _db;

    public ProductService(ExternalService externalService, ApplicationDbContext db)
    {
        _externalService = externalService;
        _db = db;
    }

    public List<Product> getAllProducts()
    {
        return _db.Product.ToList();
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

    public PagedResult<Product> GetListPagination(int page, int pageSize)
    {
        var query = _db.Product
                    .Where(p => p.Status == "Active")
                    .OrderBy(p => p.ProductId);
        int totalItems = query.Count();
        var items = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        return new PagedResult<Product>
        {
            Page = page,
            Limit = pageSize,
            Total = totalItems,
            Data = items
        };
    }

    public List<Product> GetProductsHasBigStock()
    {
        var query = _db.Product
                    .Where(p => p.Status == "Active")
                    .OrderBy(p => p.Stock);
        int totalItems = query.Count();
        var items = query
                    .Take(6)
                    .ToList();
        return items;
    }

    public List<Product> GetAllProductsByCategory(int categoryId)
    {
        var query = _db.Product
                    .Where(p => p.CategoryId == categoryId)
                    .OrderBy(p => p.ProductId);
        var items = query.ToList();
        return items;
    }

    //get product by id
    public Product? GetProductDetailById(int id)
    {
        return _db.Product.FirstOrDefault(p => p.ProductId == id);  //return null if not found
    }

    public Product? GetProductDetailBySlug(string slug)
    {
        return _db.Product.FirstOrDefault(p => p.Slug == slug);  //return null if not found
    }

    //get other products in same category, except the current one
    public List<Product> getProductsInSameCategory(int excludeProductId, int categoryId)
    {
        var query = _db.Product
                    .Where(p => p.CategoryId == categoryId && p.ProductId != excludeProductId)
                    .Take(4);
        var items = query.ToList();
        return items;
    }

    public void convertSlugForAllProducts()
    {
        //get all products
        var items = _db.Product.ToList();
        foreach (var product in items)
        {
            product.Slug = Utils.ToSlug(product.Name);
            _db.Product.Update(product);
            _db.SaveChanges();
        }
    }

    public List<Product> SearchProductsByKeyword(string keyword)
    {
        var query = _db.Product
                    .Where(p => p.Name.Contains(keyword));   //case insensitive
        var items = query.ToList();
        return items;
    }

    public List<Product> SearchProductsByPrice(int min, int max)
    {
        var query = _db.Product
                    .Where(p => p.Price >= min && p.Price <= max);
        var items = query.ToList();
        return items;
    }

    public int CreateProduct(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            CategoryId = dto.category_id,
            Price = dto.Price,
            Description = dto.description,
            ImageUrl = dto.image_url,
        };

        _db.Product.Add(product);
        return _db.SaveChanges();
    }
}