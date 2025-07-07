import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { removeFromCart } from "../redux/cartSlice";

export default function Cart() {
  const cartItems = useSelector((state) => state.cart.items);
  const dispatch = useDispatch();
  return (
    <>
      <h2>Cart</h2>
      {cartItems.length === 0 ? (
        <h2>Cart is Empty</h2>
      ) : (
        cartItems.map((item) => (
          <div key={item.name}>
            <span>
              {item.name}- {item.price}
            </span>
            <button onClick={() => dispatch(removeFromCart(item.id))}>
              Remove
            </button>
          </div>
        ))
      )}
    </>
  );
}
