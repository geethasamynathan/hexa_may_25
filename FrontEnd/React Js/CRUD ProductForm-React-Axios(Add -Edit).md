
# 🛒 React Product Management - Add/Edit Form using Axios

This guide demonstrates how to build a React-based product list app with an add/edit form using Axios and service-based architecture.

---

## ✅ Folder Structure

```
src/
├── App.jsx
├── main.jsx
├── services/
│   ├── axiosInstance.js
│   └── productService.js
├── components/
│   ├── ProductList.jsx
│   ├── ProductCard.jsx
│   └── ProductForm.jsx
```

---

## 🧩 `services/axiosInstance.js`

```
import axios from "axios";

const instance = axios.create({
  baseURL: "https://your-api-endpoint.com/api", // Replace with your API
  headers: {
    "Content-Type": "application/json",
  },
});

instance.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default instance;
```

---

## 🔐 `services/productService.js`

```
import axios from "./axiosInstance";

export const getAllProducts = async () => {
  const res = await axios.get("/products");
  return res.data;
};

export const addProduct = async (product) => {
  const res = await axios.post("/products", product);
  return res.data;
};

export const updateProduct = async (id, product) => {
  const res = await axios.put(`/products/${id}`, product);
  return res.data;
};
```

---

## 🛒 `components/ProductCard.jsx`

```
import React from "react";

export default function ProductCard({ product, onEdit }) {
  return (
    <div className="card" style={{ width: "18rem", margin: "10px" }}>
      <img src={product.productImageUrl} className="card-img-top" alt={product.name} />
      <div className="card-body">
        <h5 className="card-title">{product.name}</h5>
        <p className="card-text">Category: {product.category}</p>
        <p>Price: ₹{product.selling_Price}</p>
        <p>Stock: {product.stockQuantity}</p>
        <button className="btn btn-info">View Details</button>
        <button onClick={() => onEdit(product)} className="btn btn-warning ms-2">Edit</button>
      </div>
    </div>
  );
}
```

---

## 🧾 `components/ProductForm.jsx`

```
import React, { useState, useEffect } from "react";

export default function ProductForm({ product, onSubmit, onCancel }) {
  const [form, setForm] = useState({
    name: "",
    sku: "",
    category: "",
    manufacturing_Cost: 0,
    selling_Price: 0,
    stockQuantity: 0,
    productImageUrl: "",
    manufacturedDate: new Date().toISOString().slice(0, 10),
  });

  useEffect(() => {
    if (product) {
      setForm({ ...product });
    }
  }, [product]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(form);
  };

  return (
    <form onSubmit={handleSubmit}>
      <h3>{product ? "Update Product" : "Add New Product"}</h3>
      <input name="name" value={form.name} onChange={handleChange} placeholder="Name" required />
      <input name="sku" value={form.sku} onChange={handleChange} placeholder="SKU" required />
      <input name="category" value={form.category} onChange={handleChange} placeholder="Category" />
      <input name="manufacturing_Cost" type="number" value={form.manufacturing_Cost} onChange={handleChange} placeholder="Manufacturing Cost" />
      <input name="selling_Price" type="number" value={form.selling_Price} onChange={handleChange} placeholder="Selling Price" />
      <input name="stockQuantity" type="number" value={form.stockQuantity} onChange={handleChange} placeholder="Stock Quantity" />
      <input name="productImageUrl" value={form.productImageUrl} onChange={handleChange} placeholder="Image URL" />
      <input name="manufacturedDate" type="date" value={form.manufacturedDate.slice(0, 10)} onChange={handleChange} />

      <button type="submit" className="btn btn-success">
        {product ? "Update Product" : "Add Product"}
      </button>
      <button type="button" onClick={onCancel} className="btn btn-secondary">
        Cancel
      </button>
    </form>
  );
}
```

---

## 🔁 `components/ProductList.jsx`

```
import React, { useState, useEffect } from "react";
import ProductCard from "./ProductCard";
import ProductForm from "./ProductForm";
import { getAllProducts, addProduct, updateProduct } from "../services/productService";

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [editingProduct, setEditingProduct] = useState(null);
  const [showForm, setShowForm] = useState(false);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    const result = await getAllProducts();
    setProducts(result);
  };

  const handleAddOrUpdate = async (formData) => {
    if (editingProduct) {
      await updateProduct(editingProduct.id, formData);
    } else {
      await addProduct(formData);
    }
    setShowForm(false);
    setEditingProduct(null);
    loadProducts();
  };

  return (
    <div>
      {showForm && (
        <ProductForm
          product={editingProduct}
          onSubmit={handleAddOrUpdate}
          onCancel={() => {
            setShowForm(false);
            setEditingProduct(null);
          }}
        />
      )}

      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <h2>Product List</h2>
        <button onClick={() => {
          setEditingProduct(null);
          setShowForm(true);
        }} className="btn btn-primary">
          Add Product
        </button>
      </div>

      <div className="row">
        {products.map((product) => (
          <ProductCard
            key={product.id}
            product={product}
            onEdit={(product) => {
              setEditingProduct(product);
              setShowForm(true);
            }}
          />
        ))}
      </div>
    </div>
  );
}
```
