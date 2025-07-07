
# 🧩 Services in React JS – Full Tutorial with Examples

## ✅ What is a Service in React?

A **service** in React is a separate JavaScript module that handles:
- Fetching data from APIs
- Business logic (e.g., formatting, validation)
- Authentication and token handling

> Services help separate logic from UI and make code more reusable and testable.

---

## 🎯 When Should You Use a Service?

| Use Case | Recommendation |
|----------|----------------|
| API call reused in many components | ✅ Use a service |
| One-time fetch in a component | 👌 Direct fetch in `useEffect` |
| Centralized token/headers | ✅ Use a service with `axios` |
| Complex business logic | ✅ Abstract into service |

---

## 🧪 Examples: API Calls in React

### ✅ Option 1: Direct API Call in Component

```jsx
import { useEffect, useState } from "react";

export default function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch("https://fakestoreapi.com/products")
      .then(res => res.json())
      .then(data => setProducts(data));
  }, []);

  return (
    <div>
      <h2>Products</h2>
      {products.map(p => (
        <div key={p.id}>{p.title}</div>
      ))}
    </div>
  );
}
```

---

### ✅ Option 2: Use a Service File

#### `services/productService.js`

```js
export async function getAllProducts() {
  const res = await fetch("https://fakestoreapi.com/products");
  if (!res.ok) throw new Error("Failed to load products");
  return res.json();
}
```

#### `pages/ProductList.jsx`

```jsx
import { useEffect, useState } from "react";
import { getAllProducts } from "../services/productService";

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    getAllProducts()
      .then(setProducts)
      .catch(err => setError(err.message));
  }, []);

  return (
    <div>
      <h2>Products</h2>
      {error && <p>{error}</p>}
      {products.map(p => (
        <div key={p.id}>{p.title}</div>
      ))}
    </div>
  );
}
```

---

### ✅ Option 3: Use Axios for Service

#### `services/api.js`

```js
import axios from "axios";

const api = axios.create({
  baseURL: "https://fakestoreapi.com",
  timeout: 10000
});

export default api;
```

#### `services/productService.js`

```js
import api from "./api";

export async function getAllProducts() {
  const res = await api.get("/products");
  return res.data;
}
```

---

### 🛡️ Bonus: Auth Service Example

#### `services/authService.js`

```js
export async function loginUser(credentials) {
  const res = await fetch("https://example.com/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(credentials)
  });
  if (!res.ok) throw new Error("Login failed");
  return res.json();
}
```

---

## 🔁 Summary: When to Use What

| Situation | Approach |
|-----------|----------|
| 1-off API call | Direct in component (`useEffect`) |
| Reused across app | Create a service file |
| Needs token/header management | Use `axios` with a service |
| Clean architecture + testing | ✅ Use services always |

---

Would you like a full CRUD service example exported next?
