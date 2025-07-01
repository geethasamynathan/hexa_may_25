import React from "react";
import ProductCard from "../components/ProductCard";
export default function ProductList() {
  const products = [
    { id: 1, name: "laptop", price: "76000" },
    { id: 2, name: "Mouse", price: "3000" },
    { id: 3, name: "tablet", price: "72000" },
  ];
  return (
    <div>
      <h2>Product List</h2>
      {products.length > 0 ? (
        products.map((p) => {
          return <ProductCard key={p.id} product={p} />;
        })
      ) : (
        <p>No Products Found</p>
      )}
    </div>
  );
}
