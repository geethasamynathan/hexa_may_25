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
  //   useEffect(() => {
  //     if (product) {
  //       setForm({
  //         name: product.name || "",
  //         sku: product.sku || "",
  //         category: product.category || "",
  //         manufacturing_Cost: product.manufacturing_Cost ?? 0,
  //         selling_Price: product.selling_Price ?? 0,
  //         stockQuantity: product.stockQuantity ?? 0,
  //         productImageUrl: product.productImageUrl || "",
  //         manufacturedDate: product.manufacturedDate
  //           ? new Date(product.manufacturedDate).toISOString().slice(0, 10)
  //           : new Date().toISOString().slice(0, 10),
  //       });
  //     }
  //   }, [product]);
  useEffect(() => {
    if (product) {
      setForm({
        ...product,
        manufacturedDate: product.manufacturedDate
          ? new Date(product.manufacturedDate).toISOString().slice(0, 10)
          : new Date().toISOString().slice(0, 10),
      });
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
      <input
        name="name"
        value={form.name}
        onChange={handleChange}
        placeholder="Name"
        required
      />
      <input
        name="sku"
        value={form.sku}
        onChange={handleChange}
        placeholder="SKU"
        required
      />
      <input
        name="category"
        value={form.category}
        onChange={handleChange}
        placeholder="Category"
      />
      <input
        name="manufacturing_Cost"
        type="number"
        value={form.manufacturing_Cost}
        onChange={handleChange}
        placeholder="Manufacturing Cost"
      />
      <input
        name="selling_Price"
        type="number"
        value={form.selling_Price}
        onChange={handleChange}
        placeholder="Selling Price"
      />
      <input
        name="stockQuantity"
        type="number"
        value={form.stockQuantity}
        onChange={handleChange}
        placeholder="Stock Quantity"
      />
      <input
        name="productImageUrl"
        value={form.productImageUrl}
        onChange={handleChange}
        placeholder="Image URL"
      />
      <input
        name="manufacturedDate"
        type="date"
        value={form.manufacturedDate.slice(0, 10)}
        onChange={handleChange}
      />

      <button type="submit" className="btn btn-success">
        {product ? "Update Product" : "Add Product"}
      </button>
      <button type="button" onClick={onCancel} className="btn btn-secondary">
        Cancel
      </button>
    </form>
  );
}
