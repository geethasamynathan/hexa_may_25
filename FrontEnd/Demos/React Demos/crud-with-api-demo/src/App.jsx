import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
// import "./App.css";
import Login from "./Components/Login";
import { AuthProvider } from "./Auth/AuthContext";
import { BrowserRouter, Route, Router, Routes } from "react-router-dom";
import PrivateRoute from "./Auth/PrivateRoute";
import ProductList from "./Components/ProductList";
import Home from "./Pages/Home";
import Navbar from "./Components/Navbar";
import Greet from "./Components/classcomponentdemo";
import LifeCycleDemo from "./Components/LifecycleClass";
import LifecycleFunctional from "./Components/LifecycleFunctional";
function App() {
  const [count, setCount] = useState(0);

  return (
    <AuthProvider>
      {/* <BrowserRouter> */}
      <div className="container">
        <Navbar />
        {/*  <Greet />
        <LifeCycleDemo />
        <br />
        {/* <br /> 
        <LifecycleFunctional /> */}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="login" element={<Login />} />
          <Route
            path="product-list"
            element={<PrivateRoute>{<ProductList />}</PrivateRoute>}
          />
          <Route path="unauthorized" element={<h2>Access Denied</h2>} />
        </Routes>
      </div>
    </AuthProvider>
  );
}

export default App;
