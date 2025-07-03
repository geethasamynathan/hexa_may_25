import { createContext, useContext, useState } from "react";
import { replace, useNavigate } from "react-router-dom";

const AuthContext = createContext();

const fakeInfo = [
  { username: "Alhan", password: "alhan@15", role: "admin" },
  { username: "Geetha", password: "getha@15", role: "user" },
  { username: "Pari", password: "pari@15", role: "doctor" },
];

export function AuthProvider({ children }) {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  const login = ({ username, password }) => {
    console.log("login method called", username, password);
    const logedUser = fakeInfo.find(
      (u) =>
        u.username.toLowerCase() === username.trim().toLowerCase() &&
        u.password === password
    );
    console.log("Loggedinuser", logedUser);

    if (!logedUser)
      return { ok: false, message: "invalid Username or Password" };
    setUser(logedUser);
    return { ok: true, role: logedUser.role };
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
