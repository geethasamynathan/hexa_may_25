import React, { useState } from "react";
import { useAuth } from "../auth/AuthContext";
import { replace, useNavigate } from "react-router-dom";

export default function Login() {
  const { login } = useAuth();
  const navigate = useNavigate();

  const [form, setForm] = useState({ username: "", password: "" });
  const [error, setError] = useState("");

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = (e) => {
    e.preventDefault();
    const result = login(form);

    if (!result.ok) {
      setError(result.message);
      return;
    }
    const routesByRole = {
      admin: "/admin-dashboard",
      staff: "/staff-dashboard",
      student: "/student-dashboard",
    };
    navigate(routesByRole[result.role] ?? "/dashboard", { replace: true });
  };
  const handleLogin = () => {
    login({ username: "admin" });
    navigate("/dashboard");
  };
  return (
    <div>
      <div style={{ maxWidth: 400, margin: "2rem auto" }}>
        <h2>Login</h2>

        <form onSubmit={handleSubmit}>
          <label>
            Username
            <input
              name="username"
              value={form.username}
              onChange={handleChange}
              autoComplete="username"
              required
            />
          </label>

          <label style={{ display: "block", marginTop: "1rem" }}>
            Password
            <input
              name="password"
              type="password"
              value={form.password}
              onChange={handleChange}
              autoComplete="current-password"
              required
            />
          </label>

          {error && <p style={{ color: "red" }}>{error}</p>}

          <button type="submit" style={{ marginTop: "1rem" }}>
            Sign in
          </button>
        </form>
      </div>
    </div>
  );
}
