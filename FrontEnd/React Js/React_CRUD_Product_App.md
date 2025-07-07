
# 🛒 React JS CRUD App with API Integration

This is a real-world practice project that demonstrates how to perform CRUD (Create, Read, Update, Delete) operations in React JS using a RESTful API.

---

## 📁 Folder Structure

```
product-crud-app/
├── public/
├── src/
│   ├── components/
│   │   ├── ProductList.jsx
│   │   ├── ProductForm.jsx
│   │   └── ProductCard.jsx
│   ├── services/
│   │   └── productService.js
│   ├── App.jsx
│   ├── index.js
│   └── utils/
│       └── api.js
├── package.json
```

---

## 📦 Setup Instructions

### 1. Create Project

```bash
npx create-react-app product-crud-app
cd product-crud-app
npm install axios react-router-dom bootstrap react-toastify
```

### 2. `src/utils/api.js`

````js
import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000/api/products',
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;
````

### 3. `src/services/productService.js`

````js
import api from '../utils/api';

export const getAllProducts = () => api.get('/');
export const getProductById = (id) => api.get(`/${id}`);
export const createProduct = (product) => api.post('/', product);
export const updateProduct = (id, product) => api.put(`/${id}`, product);
export const deleteProduct = (id) => api.delete(`/${id}`);
````

### 4. `src/components/ProductCard.jsx`

````jsx
import React from 'react';

export default function ProductCard({ product, onEdit, onDelete }) {
  return (
    <div className="card m-2" style={{ width: '18rem' }}>
      <img
        src={product.productImageUrl}
        className="card-img-top"
        alt={product.name}
        style={{ height: '180px', objectFit: 'cover' }}
      />
      <div className="card-body">
        <h5 className="card-title">{product.name}</h5>
        <p>Category: {product.category}</p>
        <p>Price: ₹{product.selling_Price}</p>
        <p>Stock: {product.stockQuantity}</p>
        <button className="btn btn-warning me-2" onClick={() => onEdit(product)}>Edit</button>
        <button className="btn btn-danger" onClick={() => onDelete(product.id)}>Delete</button>
      </div>
    </div>
  );
}
````

### 5. `src/components/ProductForm.jsx`

````jsx
import React, { useState, useEffect } from 'react';

export default function ProductForm({ onSubmit, productToEdit }) {
  const [formData, setFormData] = useState({
    name: '',
    category: '',
    selling_Price: '',
    stockQuantity: '',
    productImageUrl: ''
  });

  useEffect(() => {
    if (productToEdit) {
      setFormData(productToEdit);
    }
  }, [productToEdit]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
    setFormData({ name: '', category: '', selling_Price: '', stockQuantity: '', productImageUrl: '' });
  };

  return (
    <form onSubmit={handleSubmit} className="card p-3 mb-4">
      <input type="text" name="name" value={formData.name} onChange={handleChange} placeholder="Name" required className="form-control mb-2" />
      <input type="text" name="category" value={formData.category} onChange={handleChange} placeholder="Category" required className="form-control mb-2" />
      <input type="number" name="selling_Price" value={formData.selling_Price} onChange={handleChange} placeholder="Selling Price" required className="form-control mb-2" />
      <input type="number" name="stockQuantity" value={formData.stockQuantity} onChange={handleChange} placeholder="Stock Quantity" required className="form-control mb-2" />
      <input type="text" name="productImageUrl" value={formData.productImageUrl} onChange={handleChange} placeholder="Image URL or Base64" required className="form-control mb-2" />
      <button className="btn btn-primary" type="submit">{productToEdit ? 'Update' : 'Add'} Product</button>
    </form>
  );
}
````

### 6. `src/components/ProductList.jsx`

````jsx
import React, { useEffect, useState } from 'react';
import ProductCard from './ProductCard';
import ProductForm from './ProductForm';
import { getAllProducts, createProduct, updateProduct, deleteProduct } from '../services/productService';
import { toast } from 'react-toastify';

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [editProduct, setEditProduct] = useState(null);

  const loadProducts = async () => {
    try {
      const { data } = await getAllProducts();
      setProducts(data);
    } catch (err) {
      toast.error('Error loading products');
    }
  };

  useEffect(() => {
    loadProducts();
  }, []);

  const handleAddOrUpdate = async (product) => {
    try {
      if (product.id) {
        await updateProduct(product.id, product);
        toast.success('Product updated!');
      } else {
        await createProduct(product);
        toast.success('Product added!');
      }
      loadProducts();
      setEditProduct(null);
    } catch {
      toast.error('Error saving product');
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm('Are you sure you want to delete this product?')) {
      try {
        await deleteProduct(id);
        toast.success('Product deleted');
        loadProducts();
      } catch {
        toast.error('Error deleting product');
      }
    }
  };

  return (
    <div className="container">
      <h2 className="my-4">Product Inventory</h2>
      <ProductForm onSubmit={handleAddOrUpdate} productToEdit={editProduct} />
      <div className="d-flex flex-wrap">
        {products.map((product) => (
          <ProductCard
            key={product.id}
            product={product}
            onEdit={setEditProduct}
            onDelete={handleDelete}
          />
        ))}
      </div>
    </div>
  );
}
````

### 7. `src/App.jsx`

````jsx
import React from 'react';
import ProductList from './components/ProductList';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <>
      <ToastContainer />
      <ProductList />
    </>
  );
}

export default App;
````

### 8. `src/index.js`

````js
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);
````

---

## 🧪 API for Local Testing

Create `db.json`:

````json
{
  "products": []
}
````

Run mock API:

```bash
npm install -g json-server
json-server --watch db.json --port 5000
```

---

## ✅ Features

- Add, Edit, Delete, List products
- Base64 image or URL supported
- Toast notifications for actions
- Reusable service layer with Axios
- Responsive card UI

---
