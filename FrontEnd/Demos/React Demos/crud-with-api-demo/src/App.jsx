import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import Login from "./Components/Login";
import { AuthProvider } from "./Auth/AuthContext";
import { BrowserRouter, Route, Router, Routes } from "react-router-dom";
import PrivateRoute from "./Auth/PrivateRoute";
import ProductList from "./Components/ProductList";

function App() {
  const [count, setCount] = useState(0);

  return (
    <AuthProvider>
      {/* <BrowserRouter> */}
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="login" element={<Login />} />
        <Route
          path="product-list"
          element={<PrivateRoute>{<ProductList />}</PrivateRoute>}
        />
        <Route path="unauthorized" element={<h2>Access Denied</h2>} />
      </Routes>
    </AuthProvider>
  );
}

export default App;
