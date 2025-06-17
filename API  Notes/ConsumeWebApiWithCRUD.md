
# 🛠 Consuming ASP.NET Core Web API with CRUD in ASP.NET Core MVC 8.0

This guide covers how to consume a Web API that manages Products using **ASP.NET Core MVC** with full **CRUD operations** and **search** functionality.

---

## ✅ Web API Setup (`ProductsApi`)

### 🔹 Product Model

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 🔹 ProductsController

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 50000 },
        new Product { Id = 2, Name = "Mouse", Price = 500 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(_products);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpGet("search")]
    public IActionResult Search(string name)
    {
        var results = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return Ok(results);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updatedProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        _products.Remove(product);
        return NoContent();
    }
}
```

---

## ✅ MVC Setup (`ProductMvcClient`)

### 🔹 Product Model

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 🔹 ProductService

```csharp
public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>> GetAllAsync() =>
        await _http.GetFromJsonAsync<List<Product>>("api/products");

    public async Task<Product> GetByIdAsync(int id) =>
        await _http.GetFromJsonAsync<Product>($"api/products/{id}");

    public async Task<List<Product>> SearchAsync(string name) =>
        await _http.GetFromJsonAsync<List<Product>>($"api/products/search?name={name}");

    public async Task CreateAsync(Product product) =>
        await _http.PostAsJsonAsync("api/products", product);

    public async Task UpdateAsync(Product product) =>
        await _http.PutAsJsonAsync($"api/products/{product.Id}", product);

    public async Task DeleteAsync(int id) =>
        await _http.DeleteAsync($"api/products/{id}");
}
```

### 🔹 Register in Program.cs

```csharp
builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7030/");
});
```

---

## ✅ ProductController in MVC

```csharp
public class ProductController : Controller
{
    private readonly ProductService _service;

    public ProductController(ProductService service) => _service = service;

    public async Task<IActionResult> Index(string searchTerm)
    {
        var products = string.IsNullOrEmpty(searchTerm)
            ? await _service.GetAllAsync()
            : await _service.SearchAsync(searchTerm);

        ViewBag.SearchTerm = searchTerm;
        return View(products);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _service.CreateAsync(product);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {
        await _service.UpdateAsync(product);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
```

---

## ✅ Views

### 🔹 Index.cshtml

```html
@model List<ProductMvcClient.Models.Product>
@{
    ViewBag.Title = "Product List";
}

<h2>Products</h2>

<form method="get">
    <input type="text" name="searchTerm" value="@ViewBag.SearchTerm" placeholder="Search by name" />
    <button type="submit">Search</button>
    <a href="/Product/Create">Add New</a>
</form>

<table class="table">
    <tr><th>ID</th><th>Name</th><th>Price</th><th>Actions</th></tr>
@foreach (var p in Model)
{
    <tr>
        <td>@p.Id</td>
        <td>@p.Name</td>
        <td>@p.Price</td>
        <td>
            <a href="/Product/Edit/@p.Id">Edit</a> |
            <a href="/Product/Delete/@p.Id">Delete</a>
        </td>
    </tr>
}
</table>
```

### 🔹 Create.cshtml / Edit.cshtml / Delete.cshtml

```html
@model ProductMvcClient.Models.Product

<form method="post">
    <div class="form-group">
        <label>Name:</label>
        <input asp-for="Name" class="form-control" />
    </div>
    <div class="form-group">
        <label>Price:</label>
        <input asp-for="Price" class="form-control" />
    </div>
    <button type="submit">Save</button>
</form>
```

---

## ✅ Summary

- Full CRUD and search operations from MVC to API
- Reusable service with HttpClient
- Clean separation of concerns

---

