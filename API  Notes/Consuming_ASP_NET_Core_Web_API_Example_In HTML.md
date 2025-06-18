
# Example to Consume ASP.NET Core Web API in HTML using JavaScript

## 1. ASP.NET Core Web API Controller

Assume you have a simple Web API that provides information about products. Here’s an example controller:

```csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetProducts()
        {
            var products = new List<object>
            {
                new { Id = 1, Name = "Product 1", Price = 100 },
                new { Id = 2, Name = "Product 2", Price = 200 },
                new { Id = 3, Name = "Product 3", Price = 300 }
            };

            return Ok(products);
        }
    }
}
```

This API endpoint returns a list of products in JSON format when accessed through `/api/products/all`.

---

## 2. HTML Page with JavaScript to Consume the API

Here’s an example of an HTML page that uses JavaScript to consume the above Web API:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Product List</title>
    <style>
        .product-list { margin-top: 20px; }
        .product { margin: 10px 0; }
    </style>
</head>
<body>

    <h1>Product List</h1>
    <button id="fetch-products">Load Products</button>

    <div class="product-list" id="product-list">
        <!-- Products will be displayed here -->
    </div>

    <script>
        // This function will fetch products from the API and display them
        document.getElementById('fetch-products').addEventListener('click', function() {
            fetch('https://localhost:5001/api/products/all')  // Adjust URL based on your local API
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    const productListElement = document.getElementById('product-list');
                    productListElement.innerHTML = '';  // Clear any previous content

                    data.forEach(product => {
                        const productElement = document.createElement('div');
                        productElement.classList.add('product');
                        productElement.innerHTML = `<strong>${product.Name}</strong> - ₹${product.Price}`;
                        productListElement.appendChild(productElement);
                    });
                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });
        });
    </script>

</body>
</html>
```

### Explanation:

1. **HTML Structure**:
   - The page contains a `<button>` with the id `fetch-products` that, when clicked, triggers the API call.
   - The `<div>` with the id `product-list` will hold the list of products fetched from the API.

2. **JavaScript to Fetch Data**:
   - When the button is clicked, an event listener is triggered which sends a `GET` request to the Web API endpoint `/api/products/all` using the `fetch()` function.
   - The response is parsed as JSON and then dynamically inserted into the DOM (inside the `product-list` div).
   - If the fetch operation fails (for example, due to network issues or server errors), it logs an error to the console.

3. **Displaying Data**:
   - Each product returned by the API is displayed in its own `div` inside the `product-list` element.

4. **CORS (Cross-Origin Resource Sharing)**:
   - If your Web API is hosted on a different domain or port than your HTML page, you will need to ensure that CORS is enabled in your ASP.NET Core Web API to allow the HTML page to fetch data from the API.
   
   To enable CORS in ASP.NET Core, you can add the following to the `Startup.cs` file:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
    });

    services.AddControllers();
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseCors("AllowAll");  // Allow all origins, methods, and headers

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

---

### Conclusion:

This example shows how you can create a simple web page that fetches and displays data from an ASP.NET Core Web API using JavaScript. You can adapt this pattern to interact with any Web API and display the results dynamically on your web page.

Let me know if you need further help!
