import React, { useEffect, useState } from "react";
import { getAllProducts } from "../services/productService";
export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const data = await getAllProducts();
        setProducts(data);
      } catch (err) {
        setError("Failed To load products");
      }
    };
    fetchProducts();
  }, []);

  return (
    <div className="container py-4">
      <h2 className="text-center mb-4">Product List</h2>
      {error && <p className="text-danger">{error}</p>}

      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4">
        {products.length === 0 ? (
          <p>No Products Available</p>
        ) : (
          products.map((p) => (
            <div className="col" key={p.id}>
              <div className="card h-100 shadow-sm">
                <img
                  src={p.productImageUrl}
                  className="card-img-top"
                  alt={p.name}
                  style={{ height: "200px", objectFit: "cover" }}
                />
                <div className="card-body d-flex flex-column">
                  <h5 className="card-title">{p.name}</h5>
                  <p className="card-text">Category: {p.category}</p>
                  <p className="card-text">Price: ₹{p.selling_Price}</p>
                  <p className="card-text">Stock: {p.stockQuantity}</p>
                  <a href="#" className="btn btn-outline-primary mt-auto">
                    View Details
                  </a>
                </div>
              </div>
            </div>
          ))
        )}
      </div>
    </div>
  );
}
