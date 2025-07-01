import React from "react";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleLogin = () => {
    login({ username: "admin" });
    navigate("/dashboard");
  };
  return (
    <div>
      <h2>Login Page</h2>
      <button onClick={handleLogin}>Login as Admin</button>
    </div>
  );
}
