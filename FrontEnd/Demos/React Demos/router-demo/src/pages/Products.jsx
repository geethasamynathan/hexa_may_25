import React from "react";
import { useState, useEffect } from "react";
import ProductCard from "../components/ProductCard";
import getAllProducts from "../services/ProductService";

export default function Products() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState("");
  //console.log("Rendering Product component and calling fetch");

  //   useEffect(() => {
  //     fetch("https://fakestoreapi.com/products")
  //       .then((res) => res.json())
  //       .then((data) => {
  //         console.log("Setting products:" + data);
  //         setProducts(data);
  //       })
  //       .catch((error) => console.log("Error while Fetching", error));
  //   }, []);

  //call Service Mehtod

  useEffect(() => {
    getAllProducts()
      .then(setProducts)
      .catch((err) => setError(err.message));
  }, []);

  return (
    <div>
      <h2> products List</h2>
      {products.map((p) => (
        <ProductCard key={p.id} product={p} />
      ))}
    </div>
  );
}
