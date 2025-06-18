
# ✅ Monolithic vs Microservices Architecture with ASP.NET Core 8.0

---

## 🏗️ What is Monolithic Architecture?

A **Monolithic Architecture** is a unified model where all components of an application are packaged and deployed as a single unit.

### 🔹 Use Cases:
- Simple applications
- Startups and MVPs
- Limited development team

### 🔻 Drawbacks:
| Issue | Description |
|-------|-------------|
| Tight Coupling | Changes impact entire app |
| Large Deployment | Requires full redeploy |
| Poor Scalability | Cannot scale individual features |
| Testing Complexity | Harder to isolate issues |
| Onboarding Overhead | Entire codebase knowledge required |

---

## 🧱 What is Microservice Architecture?

A software design pattern where applications are composed of loosely coupled, independently deployable services.

### 🔹 Features:
- Independent deployments
- Language agnostic
- Fault isolation
- Enables DevOps and CI/CD pipelines

---

## 🔁 Monolithic vs Microservices

| Feature | Monolithic | Microservices |
|--------|------------|---------------|
| Structure | Single codebase | Multiple independent services |
| Deployment | All-in-one | Per-service |
| Scalability | Entire app | Per service |
| Fault Isolation | Low | High |
| DevOps | Complex | Easier with CI/CD |
| Tech Stack | Uniform | Mixed allowed |

---

## 🕵️ When to Choose Microservices

- Complex, evolving systems
- Multiple teams working concurrently
- Independent service scaling
- Require better fault isolation

---

## 🛍️ Real-World Example: E-commerce Microservices with Ocelot in ASP.NET Core 8.0

### 🔧 Setup Projects
- Solution: `ECommerceMicroservices.sln`
- Projects:
  - `ProductService`
  - `OrderService`
  - `APIGateway`

---

## 📦 ProductService

### `Program.cs`
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();
```

### `ProductController.cs`
```csharp
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] {
        new { Id = 1, Name = "Laptop" },
        new { Id = 2, Name = "Phone" }
    });
}
```

---

## 📦 OrderService

### `OrderController.cs`
```csharp
[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    [HttpPost]
    public IActionResult PlaceOrder([FromBody] dynamic order)
        => Ok(new { Status = "Order Placed", OrderId = Guid.NewGuid() });
}
```

---

## 🌐 API Gateway (Ocelot)

Install Ocelot:
```bash
Install-Package Ocelot
```

### `Program.cs`
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();

var app = builder.Build();
await app.UseOcelot();
app.Run();
```

### `ocelot.json`
```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/products",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [ { "Host": "localhost", "Port": 5001 } ],
      "UpstreamPathTemplate": "/products",
      "UpstreamHttpMethod": [ "GET" ]
    },
    {
      "DownstreamPathTemplate": "/api/orders",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [ { "Host": "localhost", "Port": 5002 } ],
      "UpstreamPathTemplate": "/orders",
      "UpstreamHttpMethod": [ "POST" ]
    }
  ],
  "GlobalConfiguration": {
    "BaseUrl": "http://localhost:5000"
  }
}
```

---

## 🧪 Test the Setup

- Product API: `GET http://localhost:5000/products`
- Order API: `POST http://localhost:5000/orders`

---

## ✅ Summary

- Microservices provide modular, scalable architecture
- Use Ocelot to route APIs in .NET Core
- Easier to scale and manage in large systems
