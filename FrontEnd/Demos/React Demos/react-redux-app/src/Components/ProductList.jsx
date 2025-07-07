import React from "react";
import { useDispatch } from "react-redux";
import { addToCart } from "../redux/cartSlice";

const products = [
  { id: 1, name: "T-Shirt", price: 499 },
  { id: 2, name: "Jeans", price: 999 },
  { id: 3, name: "Shoes", price: 1499 },
];

export default function ProductList() {
  const dispatch = useDispatch();
  return (
    <>
      <h2> Products </h2>
      {products.map((p) => (
        <div key={p.id}>
          <h4>{p.name}</h4>
          <p>{p.price}</p>
          <button onClick={() => dispatch(addToCart(p))}> Add to Cart</button>
        </div>
      ))}
    </>
  );
}
