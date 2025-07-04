import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../services/loginService";
export default function Login({ onLogin }) {
  const [credentials, setCredentials] = useState({
    username: "",
    password: "",
  });
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");
    try {
      await login(credentials.username, credentials.password);
      // onLogin();
      navigate("/product-list");
    } catch (err) {
      setError(err.message);
    }
  };
  return (
    <form onSubmit={handleSubmit}>
      <h2>Login</h2>
      {error && <p className="text-danger">{error}</p>}
      <div className="form-group">
        <input
          type="text"
          name="username"
          value={credentials.username}
          onChange={handleChange}
          placeholder="username"
          className="form-control"
        />
      </div>
      <div className="form-group">
        <input
          type="text"
          name="password"
          value={credentials.password}
          onChange={handleChange}
          placeholder="password"
          className="form-control"
        />
      </div>
      <button type="submit" className="btn btn-primary">
        Login
      </button>
    </form>
  );
}
