import React, { useEffect, useState } from "react";
import AddProductModal from "./AddProductModal";
import EditProductModal from "./EditProductModal";
import {
  getAllProducts,
  addProduct,
  updateProduct,
} from "../services/productService";

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [editingProduct, setEditingProduct] = useState(null);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    const result = await getAllProducts();
    setProducts(result);
  };

  const handleAddSubmit = async (formData) => {
    await addProduct(formData);
    setShowAddModal(false);
    loadProducts();
  };

  const handleEditSubmit = async (formData) => {
    await updateProduct(
      editingProduct.id || editingProduct.productId,
      formData
    );
    setShowEditModal(false);
    setEditingProduct(null);
    loadProducts();
  };

  return (
    <div className="container py-4">
      <AddProductModal
        show={showAddModal}
        onClose={() => setShowAddModal(false)}
        onSubmit={handleAddSubmit}
      />

      <EditProductModal
        show={showEditModal}
        product={editingProduct}
        onClose={() => {
          setShowEditModal(false);
          setEditingProduct(null);
        }}
        onSubmit={handleEditSubmit}
      />

      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2>Product List</h2>
        <button
          className="btn btn-primary"
          onClick={() => setShowAddModal(true)}
        >
          Add Product
        </button>
      </div>

      <div className="row">
        {products.map((product) => (
          <div className="col-md-4 mb-4" key={product.id || product.productId}>
            <div className="card h-100 shadow-sm">
              <img
                src={product.productImageUrl}
                className="card-img-top"
                alt={product.name}
                style={{ height: "200px", objectFit: "cover" }}
              />
              <div className="card-body">
                <h5 className="card-title">{product.name}</h5>
                <p className="card-text">Category: {product.category}</p>
                <p className="card-text">Price: ₹{product.selling_Price}</p>
                <p className="card-text">Stock: {product.stockQuantity}</p>
                <div className="d-flex justify-content-between">
                  <button className="btn btn-outline-info">View</button>
                  <button
                    className="btn btn-outline-warning"
                    onClick={() => {
                      setEditingProduct(product);
                      setShowEditModal(true);
                    }}
                  >
                    Edit
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
