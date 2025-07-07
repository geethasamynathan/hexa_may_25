import React, { useState, useContext, createContext, useEffect } from "react";
import { isAuthenticated } from "../services/loginService";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState({ isLoggedIn: false });

  // useEffect(() => {
  //   console.log("useEffect -AuthContexrt.jsx");
  //   setAuth({ isLoggedIn: isAuthenticated() });
  // }, []);

  const loginUser = () => setAuth({ isLoggedIn: true });
  const logoutUser = () => setAuth({ isLoggedIn: false });

  return (
    <AuthContext.Provider value={{ auth, loginUser, logoutUser }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);
