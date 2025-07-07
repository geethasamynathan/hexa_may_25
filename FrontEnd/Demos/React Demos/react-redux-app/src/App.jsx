import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import ProductList from "./Components/ProductList";
import Cart from "./Components/cart";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <div
        style={{ display: "flex", justifyContent: "space-around", padding: 20 }}
      >
        <ProductList />
        <Cart />
      </div>
    </>
  );
}

export default App;
