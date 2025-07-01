import React from "react";
import { useNavigate } from "react-router-dom";

export default function ProductCard({ product }) {
  const navigate = useNavigate();
  return (
    <>
      {
        <div
          onClick={() => navigate(`/products/${product.id}`)}
          style={{
            border: "1px solid blue",
            padding: "10px",
            cursor: "pointer",
          }}
        >
          <h4>{product.title}</h4>
          <p>{product.price}</p>
        </div>
      }
    </>
  );
}
