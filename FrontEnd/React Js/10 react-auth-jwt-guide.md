# 🔐 React + Web API Authentication & Role-Based Authorization (JWT)

This guide explains how to integrate your Web API's JWT-based login endpoint with a React application. Once logged in, users are redirected to a dashboard based on their roles.

---

## ✅ Overview of Flow

1. React Login form accepts username/password.
2. Sends credentials to `POST /api/login` (your Web API).
3. If valid, API responds with JWT token.
4. React saves token and decodes it.
5. Protected routes use `PrivateRoute` to restrict access.
6. Role-based views are rendered based on token payload.

---

## 🧱 Backend Assumption

### Endpoint:
```http
POST /api/login
```

### Request:
```json
{
  "username": "admin",
  "password": "admin123"
}
```

### Response:
```json
{
  "token": "JWT_TOKEN_HERE"
}
```

Decoded token:
```json
{
  "sub": "admin",
  "role": "Admin",
  "exp": 9999999999
}
```

---

## 🛠️ Step-by-Step React Setup

---

### 🔹 1. Install Required Packages

```bash
npm install axios jwt-decode react-router-dom
```

---

### 🔹 2. `auth/AuthContext.js` – Auth Context

```js
import React, { createContext, useContext, useState } from "react";
import jwtDecode from "jwt-decode";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(localStorage.getItem("token") || null);
  const user = token ? jwtDecode(token) : null;

  const login = (token) => {
    localStorage.setItem("token", token);
    setToken(token);
  };

  const logout = () => {
    localStorage.removeItem("token");
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
```

---

### 🔹 3. `pages/Login.jsx` – Login Component

```js
import React, { useState } from "react";
import axios from "axios";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [credentials, setCredentials] = useState({ username: "", password: "" });
  const [error, setError] = useState("");
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await axios.post("http://localhost:5000/api/login", credentials);
      login(res.data.token);
      navigate("/dashboard");
    } catch (err) {
      setError("Invalid credentials");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Login</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}
      <input name="username" value={credentials.username} onChange={handleChange} placeholder="Username" />
      <input name="password" type="password" value={credentials.password} onChange={handleChange} placeholder="Password" />
      <button type="submit">Login</button>
    </form>
  );
}
```

---

### 🔹 4. `auth/PrivateRoute.jsx` – Route Guard

```js
import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthContext";

export default function PrivateRoute({ children, role }) {
  const { user } = useAuth();

  if (!user) return <Navigate to="/login" />;
  if (role && user.role !== role) return <Navigate to="/unauthorized" />;

  return children;
}
```

---

### 🔹 5. `pages/Dashboard.jsx` – Protected Component

```js
import { useAuth } from "../auth/AuthContext";

export default function Dashboard() {
  const { user } = useAuth();

  return (
    <div>
      <h2>Welcome {user?.sub}</h2>
      <p>Your role: {user?.role}</p>

      {user.role === "Admin" && (
        <div>Admin-only Product Dashboard</div>
      )}

      {user.role === "User" && (
        <div>User-specific content</div>
      )}
    </div>
  );
}
```

---

### 🔹 6. `App.js` – Define Routes

```js
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import PrivateRoute from "./auth/PrivateRoute";
import { AuthProvider } from "./auth/AuthContext";

export default function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/dashboard" element={
            <PrivateRoute role="Admin">
              <Dashboard />
            </PrivateRoute>
          } />
          <Route path="/unauthorized" element={<h2>Access Denied</h2>} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
}
```

---

## ✅ Bonus: Axios with JWT Token

Create a custom axios instance:

```js
// utils/axiosInstance.js
import axios from "axios";

const instance = axios.create({
  baseURL: "http://localhost:5000/api",
});

instance.interceptors.request.use(config => {
  const token = localStorage.getItem("token");
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export default instance;
```

---

## 🧪 Example JWT Payload Decoded

```json
{
  "sub": "admin",
  "role": "Admin",
  "exp": 1723456789
}
```

---

## 🗂️ Suggested Folder Structure

```
src/
├── auth/
│   ├── AuthContext.js
│   └── PrivateRoute.jsx
├── pages/
│   ├── Login.jsx
│   └── Dashboard.jsx
├── utils/
│   └── axiosInstance.js
├── App.js
└── index.js
```

---

## 🚀 How to Run

```bash
npm install
npm start
```

Ensure your backend API (`/api/login`) is running locally on port `5000`.

---

## 🔐 Access Control Summary

| Scenario              | Behavior              |
|-----------------------|------------------------|
| No token              | Redirect to login     |
| Valid token, wrong role | Redirect to `/unauthorized` |
| Valid token, correct role | Access granted |

---

## 📌 Next Steps

- Add Logout functionality.
- Token expiry handling.
- Refresh tokens if supported.
- Store token in httpOnly cookie for better security (advanced).