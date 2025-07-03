// import { createContext, useContext, useState } from "react";
// import { useNavigate } from "react-router-dom";

// const AuthContext = createContext();
// export function AuthProvider({ children }) {
//   const [user, setUser] = useState(null);
//   const login = (userData) => setUser(userData);
//   const logout = () => setUser(null);

//   return (
//     <AuthContext.Provider value={{ user, login, logout }}>
//       {children}
//     </AuthContext.Provider>
//   );
// }

// export function useAuth() {
//   return useContext(AuthContext);
// }

import React, { createContext, useContext, useState } from "react";
import { replace, useNavigate } from "react-router-dom";

const AuthContext = createContext();

const fakeUsers = [
  { username: "admin", password: "admin@123", role: "admin" },
  { username: "staff", password: "staff@123", role: "staff" },
  { username: "vedha", password: "vedha@123", role: "student" },
  { username: "sruthi", password: "sruthi@123", role: "student" },
];
export function AuthProvider({ children }) {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  const login = ({ username, password }) => {
    const found = fakeUsers.find(
      (u) => u.username === username && u.password === password
    );
    if (!found) return { ok: false, message: "Invalid Credentials" };

    setUser(found);
    return { ok: true, role: found.role };
  };

  const logout = () => {
    setUser(null);
    navigate("/login", { replace: true });
  };
  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}
export const useAuth = () => useContext(AuthContext);
