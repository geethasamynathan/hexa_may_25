
# ✅ Consuming ASP.NET Core Web API 8.0 in ASP.NET Core MVC 8.0 – Step-by-Step Guide

## 🧩 Scenario
You have a **Web API** project (`ProductsApi`) exposing endpoints like `/api/products`, and now you want to **consume this API in your MVC project** (`ProductMvcClient`) using `HttpClient`.

---

## ✅ Step 1: Create Web API Project

1. Open **Visual Studio 2022** (or newer).
2. Create a new project: **ASP.NET Core Web API**.
3. Name it `ProductsApi`.
4. Choose `.NET 8.0`, uncheck “Use minimal API”.
5. Add sample controller:

```csharp
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static readonly List<string> products = new() { "Laptop", "Mouse", "Keyboard" };

    [HttpGet]
    public IActionResult GetAll() => Ok(products);
}
```

6. Run the app and confirm endpoint: `https://localhost:7030/api/products`

---

## ✅ Step 2: Create MVC Project to Consume the API

1. Create a new project: **ASP.NET Core Web App (Model-View-Controller)**.
2. Name it `ProductMvcClient`.
3. Choose `.NET 8.0`.

---

## ✅ Step 3: Add Product Model

Create `Models/Product.cs`:

```csharp
namespace ProductMvcClient.Models
{
    public class Product
    {
        public string Name { get; set; }
    }
}
```

---

## ✅ Step 4: Create Service to Call Web API

Create `Services/ProductService.cs`:

```csharp
using System.Net.Http;
using System.Net.Http.Json;
using ProductMvcClient.Models;

namespace ProductMvcClient.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<string>>("api/products");
            return response.Select(p => new Product { Name = p }).ToList();
        }
    }
}
```

---

## ✅ Step 5: Register HttpClient in `Program.cs`

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register HttpClient for ProductService
builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7030/");
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
```

---

## ✅ Step 6: Create Controller in MVC App

Create `Controllers/ProductController.cs`:

```csharp
using Microsoft.AspNetCore.Mvc;
using ProductMvcClient.Services;

namespace ProductMvcClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}
```

---

## ✅ Step 7: Create View

Create `Views/Product/Index.cshtml`:

```html
@model List<ProductMvcClient.Models.Product>

<h2>Product List</h2>

<ul>
@foreach (var item in Model)
{
    <li>@item.Name</li>
}
</ul>
```

---

## ✅ Final Result

- Visit: `https://localhost:<port>/Product/Index` (MVC)
- It fetches data from `https://localhost:7030/api/products` (Web API)

---

## ✅ Tips

- Enable CORS in Web API if hosted separately:

```csharp
builder.Services.AddCors();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
```

- Use `IHttpClientFactory` for multiple APIs.
- Handle errors gracefully with `try-catch`.

---

