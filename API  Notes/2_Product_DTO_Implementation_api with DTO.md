
### DTO (Data Transfer Object) for Product

To create **DTOs** for your `Product` class, we'll define separate DTO classes that contain only the necessary fields for transferring data between the client and the API. This will also provide flexibility for handling different requirements (like excluding sensitive data or adding computed fields).

#### 1. **ProductDTO** (For data transfer purposes)

This DTO will be used to transfer a subset of the `Product` properties to the client.

```csharp
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }
    public string Category { get; set; }
    public int Selling_Price { get; set; }
    public int StockQuantity { get; set; }
    public string ProductImageUrl { get; set; }  // Stores image URL or relative path
}
```

#### 2. **ProductCreationDTO** (For creating a product)

This DTO will be used when creating a new product. It may not include properties like `Id`, `CreatedDate`, etc., that are auto-generated.

```csharp
public class ProductCreationDTO
{
    public string Name { get; set; }
    public string SKU { get; set; }
    public string Category { get; set; }
    public int Manufacturing_Cost { get; set; }
    public int Selling_Price { get; set; }
    public int StockQuantity { get; set; }
    public string ProductImageUrl { get; set; }  // Stores image URL or relative path
    public DateTime? ManufacturedDate { get; set; }
}
```

#### 3. **ProductUpdateDTO** (For updating product data)

This DTO will be used when updating an existing product. It can include most of the properties but not those that are auto-generated or fixed.

```csharp
public class ProductUpdateDTO
{
    public string Name { get; set; }
    public string SKU { get; set; }
    public string Category { get; set; }
    public int Manufacturing_Cost { get; set; }
    public int Selling_Price { get; set; }
    public int StockQuantity { get; set; }
    public string ProductImageUrl { get; set; }  // Stores image URL or relative path
    public DateTime? ManufacturedDate { get; set; }
    public bool IsActive { get; set; }
}
```

### Updated Methods in Repository to Use DTO

We'll update the repository methods to use DTOs instead of directly manipulating `Product` entities. The methods will return DTOs wherever necessary.

#### 1. **AddProduct** - Adding a product using `ProductCreationDTO`:

```csharp
public string AddProduct(ProductCreationDTO productDTO)
{
    try
    {
        if (productDTO != null)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                SKU = productDTO.SKU,
                Category = productDTO.Category,
                Manufacturing_Cost = productDTO.Manufacturing_Cost,
                Selling_Price = productDTO.Selling_Price,
                StockQuantity = productDTO.StockQuantity,
                ProductImageUrl = productDTO.ProductImageUrl,
                ManufacturedDate = productDTO.ManufacturedDate,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return "Product added successfully";
        }
        else
        {
            return "Enter product details properly";
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error in AddProduct: {ex.Message}");
    }
}
```

#### 2. **GetAllProducts** - Returning a list of `ProductDTO`s:

```csharp
public List<ProductDTO> GetAllProducts()
{
    try
    {
        return _context.Products
            .Where(p => p.IsActive)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Category = p.Category,
                Selling_Price = p.Selling_Price,
                StockQuantity = p.StockQuantity,
                ProductImageUrl = p.ProductImageUrl
            })
            .ToList();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error in GetAllProducts: {ex.Message}");
    }
}
```

#### 3. **UpdateProduct** - Using `ProductUpdateDTO` for product updates:

```csharp
public string UpdateProduct(int id, ProductUpdateDTO productDTO)
{
    try
    {
        var existingProduct = GetProductById(id);
        if (existingProduct == null)
            return $"Product with Id {id} not found";

        existingProduct.Name = productDTO.Name;
        existingProduct.SKU = productDTO.SKU;
        existingProduct.Category = productDTO.Category;
        existingProduct.Manufacturing_Cost = productDTO.Manufacturing_Cost;
        existingProduct.Selling_Price = productDTO.Selling_Price;
        existingProduct.StockQuantity = productDTO.StockQuantity;
        existingProduct.ProductImageUrl = productDTO.ProductImageUrl;
        existingProduct.ManufacturedDate = productDTO.ManufacturedDate;
        existingProduct.IsActive = productDTO.IsActive;
        existingProduct.UpdatedDate = DateTime.UtcNow;

        _context.SaveChanges();
        return $"Product with Id {id} updated successfully";
    }
    catch (Exception ex)
    {
        throw new Exception($"Error in UpdateProduct: {ex.Message}");
    }
}
```

### Controller Changes to Use DTOs

Now, we will update the **controller** to accept and return the appropriate DTOs.

#### 1. **Controller Method to Add a Product**:

```csharp
[HttpPost]
public IActionResult AddProduct([FromBody] ProductCreationDTO productDTO)
{
    var result = _productRepo.AddProduct(productDTO);
    return Ok(result);
}
```

#### 2. **Controller Method to Get All Products**:

```csharp
[HttpGet]
public IActionResult GetAllProducts()
{
    var products = _productRepo.GetAllProducts();
    return Ok(products);
}
```

#### 3. **Controller Method to Update a Product**:

```csharp
[HttpPut("{id}")]
public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateDTO productDTO)
{
    var result = _productRepo.UpdateProduct(id, productDTO);
    return Ok(result);
}
```

#### 4. **Controller Method to Delete a Product (Soft Delete)**:

```csharp
[HttpDelete("{id}")]
public IActionResult DeleteProduct(int id)
{
    var result = _productRepo.DeleteProduct(id);
    return Ok(result);
}
```

### Additional Real-World Method for Implementing DTOs

#### **Search Products by Category**:

You can add a method to search products by their **category** and return the results as **ProductDTO**:

```csharp
public List<ProductDTO> GetProductsByCategory(string category)
{
    try
    {
        return _context.Products
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && p.IsActive)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Category = p.Category,
                Selling_Price = p.Selling_Price,
                StockQuantity = p.StockQuantity,
                ProductImageUrl = p.ProductImageUrl
            })
            .ToList();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error in GetProductsByCategory: {ex.Message}");
    }
}
```

### Conclusion

With these changes, you've:

1. Created DTOs (`ProductDTO`, `ProductCreationDTO`, `ProductUpdateDTO`) for handling data transfer.
2. Updated repository methods to use these DTOs, ensuring data integrity and separation of concerns.
3. Modified controller actions to work with DTOs, ensuring that only necessary data is passed between the API and the client.

These modifications improve maintainability and scalability, providing a clean separation between the internal data model (Entity) and the data that is exposed to external consumers (DTO).
